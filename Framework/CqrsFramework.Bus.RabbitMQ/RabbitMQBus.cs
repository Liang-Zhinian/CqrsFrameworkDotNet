using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Autofac;
using CqrsFramework.Commands;
using CqrsFramework.Events;
using CqrsFramework.Messages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private readonly ILifetimeScope _autofac;
        private readonly int _retryCount;
        private readonly string AUTOFAC_SCOPE_NAME = "saaseqt_event_bus";

        private IModel _consumerChannel;
        private string _queueName;

        private readonly Dictionary<Type, List<Action<IMessage>>> _routes = new Dictionary<Type, List<Action<IMessage>>>();


        //public event EventHandler<MessageReceivedEventArgs> MessageReceived;


        public RabbitMQBus(IRabbitMQPersistentConnection persistentConnection, 
                           ILogger<RabbitMQBus> logger,
                           ILifetimeScope autofac, 
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
            _autofac = autofac;
            _consumerChannel = CreateConsumerChannel();
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
            DoInternalSubscription(typeof(T).Name);
        }

        public void Send<T>(T command) where T : ICommand
        {
            string message = JsonConvert.SerializeObject(command, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            //byte[] body = Encoding.UTF8.GetBytes(message);

            SendMessage(message, command.GetType().Name);
        }

        public void Publish<T>(T @event) where T : IEvent
        {
            string message = JsonConvert.SerializeObject(@event, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            //var body = Encoding.UTF8.GetBytes(message);

            SendMessage(message, @event.GetType().Name);
        }

        public void Start()
        {
            //this._queueName = this.ReceiveMessages(this._queueName);
            //_consumerChannel = CreateConsumerChannel();
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

        private void SendMessage(string message, string routingKey = "")
        {
            var body = Encoding.UTF8.GetBytes(message);

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
                
                channel.ExchangeDeclare(this._exchangeName, this._exchangeType, true, false);

                policy.Execute(() =>
                {
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2; // persistent

                    channel.BasicPublish(exchange: _exchangeName,
                                         routingKey: routingKey,
                                     mandatory: true,
                                     basicProperties: properties,
                                     body: body);
                });
            }
        }

        private IModel CreateConsumerChannel()
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var channel = _persistentConnection.CreateModel();

            channel.ExchangeDeclare(this._exchangeName, this._exchangeType, true, false);

            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                
                var message = Encoding.UTF8.GetString(ea.Body);

                ProcessEvent(ea, message);

                //if (!_autoAck)
                //{
                //    channel.BasicAck(ea.DeliveryTag, multiple: false);
                //    Console.WriteLine(" Ack sent: {0}", message);
                //    _logger.LogInformation($"Ack sent: \n" + message);
                //}

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
            using (var scope = _autofac.BeginLifetimeScope(AUTOFAC_SCOPE_NAME))
            {
                Console.WriteLine(" [x] {0}", message);
                _logger.LogInformation($"RabbitMQBus is processing an event: \n" + message);

                //this.MessageReceived(this, new MessageReceivedEventArgs(message));
                try
                {
                    dynamic eventData = JsonConvert.DeserializeObject(message, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    var @event = (IEvent)eventData;
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
                    _consumerChannel.BasicAck(ea.DeliveryTag, false);
                    Console.WriteLine(" Ack sent: {0}", message);
                    _logger.LogInformation($"Ack sent: \n" + message);
                }
            }
        }

        private void DoInternalSubscription(string eventName)
        {

            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            using (var channel = _persistentConnection.CreateModel())
            {
                channel.QueueBind(queue: _queueName,
                                  exchange: this._exchangeName,
                                  routingKey: eventName);
            }

        }

        #endregion
    }
}
