using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using CqrsFramework.Commands;
using CqrsFramework.Events;
using CqrsFramework.Messages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client.Framing;
namespace CqrsFramework.Bus.RabbitMQ
{
    public class RabbitMQBus : IDisposable, IHandlerRegistrar, ICommandSender, IEventPublisher/*, IMessageReceiver*/
    {
        //private readonly IConnectionFactory _connectionFactory;
        //private readonly IConnection _connection;
        private readonly string _exchangeName;
        private readonly string _exchangeType;
        private readonly bool _autoAck;
        private bool _disposed;
        private bool _disposing = false;

        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly ILogger<RabbitMQBus> _logger;
        private readonly int _retryCount;

        private IModel _consumerChannel;
        private string _queueName;

        private readonly Dictionary<Type, List<Action<IMessage>>> _routes = new Dictionary<Type, List<Action<IMessage>>>();

        //public event EventHandler<MessageReceivedEventArgs> MessageReceived;



        //public RabbitMQBus(string hostName,
        //    string exchangeName,
        //    string exchangeType = ExchangeType.Fanout,
        //    string queueName = null,
        //    bool autoAck = false)
        //    : this(new ConnectionFactory() { HostName = hostName },
        //           exchangeName,
        //           exchangeType,
        //           queueName,
        //           autoAck)
        //{
        //}

        //public RabbitMQBus(ConnectionFactory connectionFactory,
        //    string exchangeName,
        //    string exchangeType = ExchangeType.Fanout,
        //    string queueName = null,
        //    bool autoAck = false)
        //{
        //    this._connectionFactory = connectionFactory;
        //    this._connection = this._connectionFactory.CreateConnection();
        //    this._consumerChannel = this._connection.CreateModel();
        //    this._exchangeType = exchangeType;
        //    this._exchangeName = exchangeName;
        //    this._autoAck = autoAck;
        //    this._queueName = queueName;

        //    this._consumerChannel.ExchangeDeclare(this._exchangeName, this._exchangeType, true, false);

        //    //this.queueName = this.ReceiveMessages(queueName);
        //}

        public RabbitMQBus(IRabbitMQPersistentConnection persistentConnection, 
                           ILogger<RabbitMQBus> logger,
                            string exchangeName,
                            string exchangeType = ExchangeType.Fanout,
                           string queueName = null,
                            bool autoAck = false,
                           int retryCount = 5)
        {
            _persistentConnection = persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _retryCount = retryCount;
            this._exchangeType = exchangeType;
            this._exchangeName = exchangeName;
            _queueName = queueName;
            this._autoAck = autoAck;
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
            string message = JsonConvert.SerializeObject(command/*, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }*/);
            byte[] body = Encoding.UTF8.GetBytes(message);

            var properties = new BasicProperties();
            properties.Headers = new Dictionary<string, object>
                    {
                        { "type", "1" }
                    };

            SendMessage(body, command.GetType().FullName, properties);
        }

        public void Publish<T>(T @event) where T : IEvent
        {
            string message = JsonConvert.SerializeObject(@event/*, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }*/);
            var body = Encoding.UTF8.GetBytes(message);

            var properties = new BasicProperties();
            properties.Headers = new Dictionary<string, object>
                    {
                        { "type", "1" }
                    };

            SendMessage(body, @event.GetType().FullName, properties);
        }

        public void Start()
        {
            //this._queueName = this.ReceiveMessages(this._queueName);
            _consumerChannel = CreateConsumerChannel();
        }

        public void Stop()
        {
            if (!_disposed)
            {
                if (_disposing)
                {
                    this._consumerChannel.Dispose();
                    //this._connection.Dispose();

                    _logger.LogInformation($"RabbitMQBus has been disposed. Hash Code:{this.GetHashCode()}.");
                }

                _disposed = true;
                _disposing = false;
            }
        }

        #endregion

        #region private methods

        private void SendMessage(byte[] body, string routingKey = "", BasicProperties basicProperties = null)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var policy = Policy.Handle<BrokerUnreachableException>()
                .Or<SocketException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                {
                    _logger.LogWarning(ex.ToString());
                });

            using (var channel = _persistentConnection.CreateModel())
            {
                var eventName = routingKey;

                channel.ExchangeDeclare(this._exchangeName, this._exchangeType, true, false);

                policy.Execute(() =>
                {
                    channel.BasicPublish(exchange: _exchangeName,
                                 routingKey: routingKey,
                                 basicProperties: basicProperties,
                                         body: body);
                });
            }
        }

        /*
        private string ReceiveMessages(string queue)
        {
            var localQueueName = queue;
            if (string.IsNullOrEmpty(localQueueName))
            {
                localQueueName = this._consumerChannel.QueueDeclare().QueueName;
            }
            else
            {
                this._consumerChannel.QueueDeclare(localQueueName, true, false, false, null);
            }

            var consumer = new EventingBasicConsumer(this._consumerChannel);
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

                if (!_autoAck)
                {
                    _consumerChannel.BasicAck(eventArgument.DeliveryTag, false);
                }
            };

            this._consumerChannel.BasicConsume(localQueueName, autoAck: this._autoAck, consumer: consumer);

            return localQueueName;
        }*/

        private IModel CreateConsumerChannel()
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var channel = _persistentConnection.CreateModel();

            channel.ExchangeDeclare(this._exchangeName, this._exchangeType, true, false);

            //_queueName = channel.QueueDeclare().QueueName;
            if (string.IsNullOrEmpty(_queueName))
            {
                _queueName = this._consumerChannel.QueueDeclare().QueueName;
            }
            else
            {
                channel.QueueDeclare(_queueName, true, false, false, null);
            }


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                //var eventName = ea.RoutingKey;
                var message = Encoding.UTF8.GetString(ea.Body);

                ProcessEvent(ea, message);
            };

            channel.BasicConsume(queue: _queueName,
                                 autoAck: this._autoAck,
                                 consumer: consumer);

            channel.CallbackException += (sender, ea) =>
            {
                _consumerChannel.Dispose();
                _consumerChannel = CreateConsumerChannel();
            };

            _logger.LogInformation($"RabbitMQBus has created the consumer chanel. Hash Code:{this.GetHashCode()}.");
            return channel;
        }

        private void ProcessEvent(BasicDeliverEventArgs ea, string message)
        {
            Console.WriteLine(" [x] {0}", message);
            _logger.LogInformation($"RabbitMQBus is processing an event: \n" + message);

            //this.MessageReceived(this, new MessageReceivedEventArgs(message));
            try
            {
                dynamic eventData = JsonConvert.DeserializeObject(message/*, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }*/);
                var @event = (IEvent)eventData;
                List<Action<IMessage>> handlers;
                if (!_routes.TryGetValue(@event.GetType(), out handlers)) return;
                //Console.WriteLine(" Count of Handlers: {0}", handlers.Count);
                foreach (var handler in handlers)
                    handler(@event);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                throw e;
            }

            if (!_autoAck)
            {
                _consumerChannel.BasicAck(ea.DeliveryTag, false);
                Console.WriteLine(" Ack sent: {0}", message);
                _logger.LogInformation($"Ack sent: \n" + message);
            }
        }
        #endregion
    }
}
