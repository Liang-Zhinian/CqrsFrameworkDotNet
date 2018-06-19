using System;
using System.Text;
using CqrsFramework.Bus;
using Infrastructure.Serialization;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace WorkerRoleCommandProcessor
{
    public class ReservationCommandProcessor : IDisposable
    {
        //ITextSerializer serializer = new JsonTextSerializer();
        //private ServiceProvider serviceProvider;
        RabbitMQEventBus bus; // = new RabbitMQEventBus();

        public ReservationCommandProcessor()
        {
            //serviceCollection = CreateServiceCollection();

            //this.serviceProvider = this.CreateServiceProvider();
            //this.RegisterHandlers(serviceProvider);

        }

        public ServiceCollection CreateServiceCollection()
        {
            return new ServiceCollection();
        }

        public void Start()
        {
            //serviceProvider.GetService<RabbitMQEventBus>();
            //bus.Listen();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "book2", type: "fanout", durable: true, autoDelete: false);

                var queueName = "book2events"; //channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                  exchange: "book2",
                                  routingKey: "");

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;

                    var message = Encoding.UTF8.GetString(body);

                    Console.WriteLine(" [x] {0}", message);

                    //var jsonObj = JsonConvert.DeserializeObject(message, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    //var @event = (IEvent)jsonObj;
                    //List<Action<IMessage>> handlers;
                    //if (!_routes.TryGetValue(typeof(IEvent), out handlers)) return;
                    //foreach (var handler in handlers)
                        //handler(@event);

                    //channel.BasicAck(ea.DeliveryTag, false);

                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        public void Stop()
        {
        }

        public void Dispose()
        {
        }

        private ServiceProvider CreateServiceProvider()
        {
            //setup our DI
            var _serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton(new TestEventHandler())

                .AddSingleton<RabbitMQEventBus>(bus)
                .AddSingleton<IHandlerRegistrar>(y => y.GetService<RabbitMQEventBus>())

                .BuildServiceProvider();

            return _serviceProvider;
        }


        private void RegisterHandlers(ServiceProvider provider)
        {
            //Register bus
            //var registrar = new BusRegistrar(new DependencyResolver(provider));
            //registrar.Register(typeof(TestEventHandler));
        }
    }

}

