using System;
using CqrsFramework.Bus;
using CqrsFramework.Bus.RabbitMQ;
using CqrsFramework.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Registration.Domain.EventHandlers;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;
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
            var optionsBuilder = new DbContextOptionsBuilder<ReservationDbContext>();
            optionsBuilder.UseMySql("Server=localhost;database=IdentityAccess;uid=root;pwd=P@ssword;oldguids=true;SslMode=None");

            ReservationDbContext context = new ReservationDbContext(optionsBuilder.Options);

            //setup our DI
            var _serviceProvider = new ServiceCollection()
                .AddDbContext<ReservationDbContext>(ServiceLifetime.Scoped)
                .AddLogging()
                .AddScoped<IReadDbRepository, ReadDbRepository>()
                .AddScoped<ILocationRepository, LocationRepository>()
                .AddScoped<IServiceRepository, ServiceRepository>()
                .AddScoped<LocationEventHandler>(y => new LocationEventHandler(y.GetService<ILocationRepository>()))
                .AddScoped<ServiceCategoryEventHandler>(y => new ServiceCategoryEventHandler(y.GetService<IServiceRepository>()))
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
            // registrar.Register(typeof(ServiceCategoryEventHandler));

            //registrar.Register(typeof(TestEventHandler));
        }
    }

}

