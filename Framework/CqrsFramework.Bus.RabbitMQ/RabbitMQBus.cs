using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CqrsFramework.Bus;
using CqrsFramework.Commands;
using CqrsFramework.Events;
using CqrsFramework.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Framing;

namespace CqrsFramework.Bus.RabbitMQ
{
    public class RabbitMQBus : IDisposable, IHandlerRegistrar, ICommandSender, IEventPublisher/*, IMessageReceiver*/
    {
        private readonly IConnectionFactory connectionFactory;
        private readonly IConnection connection;
        private readonly IModel channel;
        private readonly string exchangeName;
        private readonly string exchangeType;
        private string queueName;
        private readonly bool autoAck;
        //private readonly ILogger logger;
        private bool disposed;
        private bool disposing = false;

        private readonly Dictionary<Type, List<Action<IMessage>>> _routes = new Dictionary<Type, List<Action<IMessage>>>();

        //public event EventHandler<MessageReceivedEventArgs> MessageReceived;


        //private NLog.Logger logger = NLog.LogManager.GetLogger("BusEventPublisher");

        public RabbitMQBus(string hostName,
            string exchangeName,
            string exchangeType = ExchangeType.Fanout,
            string queueName = null,
            bool autoAck = false)
            : this(new ConnectionFactory() { HostName = hostName },
                   exchangeName,
                   exchangeType,
                   queueName,
                   autoAck)
        {
        }

        public RabbitMQBus(ConnectionFactory connectionFactory,
            string exchangeName,
            string exchangeType = ExchangeType.Fanout,
            string queueName = null,
            bool autoAck = false)
        {
            this.connectionFactory = connectionFactory;
            this.connection = this.connectionFactory.CreateConnection();
            this.channel = this.connection.CreateModel();
            this.exchangeType = exchangeType;
            this.exchangeName = exchangeName;
            this.autoAck = autoAck;
            this.queueName = queueName;

            this.channel.ExchangeDeclare(this.exchangeName, this.exchangeType, true, false);

            //this.queueName = this.ReceiveMessages(queueName);
        }

        #region public methods

        public void Dispose()
        {
            this.Stop();
            GC.SuppressFinalize(this);
        }

        public void RegisterHandler<T>(Action<T> handler) where T : IMessage
        {
            List<Action<IMessage>> handlers;
            if (!_routes.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<IMessage>>();
                _routes.Add(typeof(T), handlers);
            }
            handlers.Add(DelegateAdjuster.CastArgument<IMessage, T>(x => handler(x)));
        }

        public void Send<T>(T command) where T : ICommand
        {
            string message = JsonConvert.SerializeObject(command, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

            var properties = new BasicProperties();
            properties.Headers = new Dictionary<string, object>
                    {
                        { "type", "1" }
                    };

            SendMessage(message, command.GetType().FullName, properties);
        }

        public void Publish<T>(T @event) where T : IEvent
        {
            string message = JsonConvert.SerializeObject(@event, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

            var properties = new BasicProperties();
            properties.Headers = new Dictionary<string, object>
                    {
                        { "type", "1" }
                    };

            SendMessage(message, @event.GetType().FullName, properties);
        }

        public void Start()
        {
            this.queueName = this.ReceiveMessages(this.queueName);
        }

        public void Stop()
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.channel.Dispose();
                    this.connection.Dispose();

                    //logger.LogInformation($"RabbitMQBus has been disposed. Hash Code:{this.GetHashCode()}.");
                }

                disposed = true;
                disposing = false;
            }
        }

        #endregion

        #region private methods
        private void SendMessage(string message, string routingKey = "", BasicProperties basicProperties = null)
        {
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: exchangeName,
                                 routingKey: routingKey,
                                 basicProperties: basicProperties,
                                         body: body);

        }

        private string ReceiveMessages(string queue)
        {
            var localQueueName = queue;
            if (string.IsNullOrEmpty(localQueueName))
            {
                localQueueName = this.channel.QueueDeclare().QueueName;
            }
            else
            {
                this.channel.QueueDeclare(localQueueName, true, false, false, null);
            }

            var consumer = new EventingBasicConsumer(this.channel);
            consumer.Received += (model, eventArgument) =>
            {
                var body = eventArgument.Body;

                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine(" [x] {0}", message);

                //this.MessageReceived(this, new MessageReceivedEventArgs(message));
                try
                {
                    var jsonObj = JsonConvert.DeserializeObject(message, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    var @event = (IEvent)jsonObj;
                    List<Action<IMessage>> handlers;
                    if (!_routes.TryGetValue(@event.GetType(), out handlers)) return;
                    foreach (var handler in handlers)
                        handler(@event);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                    throw e;
                }

                if (!autoAck)
                {
                    channel.BasicAck(eventArgument.DeliveryTag, false);
                }
            };

            this.channel.BasicConsume(localQueueName, autoAck: this.autoAck, consumer: consumer);

            return localQueueName;
        }
        #endregion
    }
}
