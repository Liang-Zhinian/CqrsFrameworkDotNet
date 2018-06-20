using System;
using System.IO;
using CqrsFramework.Bus;
using CqrsFramework.Bus.RabbitMQ;
using CqrsFramework.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Domain.EventHandlers;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;
using Registration.Infra.Data.Repositories;

namespace WorkerRoleCommandProcessor
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<ReservationDbContext>
    {
        public ReservationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<ReservationDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            // Stop client query evaluation
            builder.ConfigureWarnings(w =>
                w.Throw(RelationalEventId.QueryClientEvaluationWarning));

            return new ReservationDbContext(builder.Options);
        }
    }

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
            //var optionsBuilder = new DbContextOptionsBuilder<ReservationDbContext>();
            //optionsBuilder.UseMySql("Server=localhost;database=IdentityAccess;uid=root;pwd=P@ssword;oldguids=true;SslMode=None");

            //ReservationDbContext context = new ReservationDbContext(optionsBuilder.Options);

            //(DbContextOptionsBuilder obj) => new DbContextOptionsBuilder<ReservationDbContext>()
            //.UseMySql("Server=localhost;database=IdentityAccess;uid=root;pwd=P@ssword;oldguids=true;SslMode=None")
            //setup our DI
            var _serviceProvider = new ServiceCollection()
                .AddDbContext<ReservationDbContext>(config =>
                    {
                config.UseMySql("Server=localhost;database=book2;uid=root;pwd=P@ssword;oldguids=true;SslMode=None");
                    }, ServiceLifetime.Scoped)
                .AddLogging()
                .AddScoped(typeof(IReadDbRepository<>), typeof(ReadDbRepository<>))
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

