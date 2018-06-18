using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using CqrsFramework.Events;
using Newtonsoft.Json;
using System.Collections.Generic;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Repositories;
using Business.Domain.Models;
using System.Linq;
using System.Linq.Expressions;
using Business.Domain.Events.ServiceCategory;
using Registration.Domain.EventHandlers;

namespace WorkerRoleCommandProcessor
{
    public class ReservationCommandProcessor : IDisposable
    {
        private ServiceProvider serviceProvider;
        //private ServiceCollection serviceCollection;
        private readonly Dictionary<Type, List<Action<IEvent>>> _routes = new Dictionary<Type, List<Action<IEvent>>>();

        public ReservationCommandProcessor()
        {
            //serviceCollection = CreateServiceCollection();

            this.serviceProvider = CreateServiceProvider();
            RegisterHandlers(serviceProvider);

        }

        public ServiceCollection CreateServiceCollection(){
            return new ServiceCollection();
        }

        public void Start()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "InterProcessBus", type: "fanout", durable: true, autoDelete: false);

                var queueName = "TestQueue"; //channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                  exchange: "InterProcessBus",
                                  routingKey: "");

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] {0}", message);

                    // to do: parse this event to the handler, then send ack to the chanel after this event been handled
                    //var json = Encoding.UTF8.GetString(message);
                    var @event = JsonConvert.DeserializeObject(message, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    //_routes[typeof(TestEventHandler)][0].Invoke(@event);

                    channel.BasicAck(ea.DeliveryTag, false);

                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        public void Stop()
        { 
        }

        public void Dispose()
        {
        }

        private static ServiceProvider CreateServiceProvider()
        {

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                //.AddSingleton<ServiceCategoryEventHandler>()
                .BuildServiceProvider();

            return serviceProvider;
        }


        private void RegisterHandlers(ServiceProvider services)
        {
            //services.AddScoped<IServiceRepository, ServiceRepository>();
            //services.AddSingleton<ServiceCategoryEventHandler>();

            var action = new Action<dynamic>(x =>
            {
                dynamic handler = testEventHandler;
                handler.Handle(x);
            });
            List<Action<IEvent>> actions = new List<Action<IEvent>>();
            actions.Add(action);
            _routes.Add(typeof(TestEventHandler), actions);
        }

        internal class TestEventHandler
        {
            public void Handle(ServiceCreatedEvent @event){

                Console.WriteLine("Event handled.");
            }
        }

        private TestEventHandler testEventHandler = new TestEventHandler();
    }

}
