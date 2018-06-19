using System;
using CqrsFramework.Bus;
using CqrsFramework.Bus.RabbitMQ;
using CqrsFramework.Config;
using Microsoft.Extensions.DependencyInjection;
using Registration.Domain.EventHandlers;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Repositories;

namespace WorkerRoleCommandProcessor
{
    public class ReservationCommandProcessor : IDisposable
    {
        private ServiceProvider serviceProvider;

        public ReservationCommandProcessor()
        {
            this.serviceProvider = this.CreateServiceProvider();
            this.RegisterHandlers(serviceProvider);

        }

        public ServiceCollection CreateServiceCollection()
        {
            return new ServiceCollection();
        }

        public void Start()
        {
            using (var scope1 = serviceProvider.CreateScope())
            {
                var p = scope1.ServiceProvider;

                //RabbitMQBus bus = this.serviceProvider.GetService<RabbitMQBus>();
                //bus.Listen();
            }
        }

        public void Stop()
        {
            this.serviceProvider.Dispose();
            Console.WriteLine("The Service Provider Disposed.");
        }

        public void Dispose()
        {
        }

        private ServiceProvider CreateServiceProvider()
        {
            //setup our DI
            var _serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<ILocationRepository, LocationRepository>()
                .AddSingleton<LocationEventHandler>()
                .AddSingleton(new TestEventHandler())

                .AddSingleton<RabbitMQBus>(new RabbitMQBus("localhost", "book2", "fanout", "book2events", true))
                .AddSingleton<IHandlerRegistrar>(y => y.GetService<RabbitMQBus>())

                .BuildServiceProvider();

            return _serviceProvider;
        }

        private void RegisterHandlers(ServiceProvider provider)
        {
            //Register bus
            var registrar = new BusRegistrar(new DependencyResolver(provider));
            registrar.Register(typeof(LocationEventHandler));
            registrar.Register(typeof(TestEventHandler));
        }
    }

}

