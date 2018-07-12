using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CqrsFramework.Bus.RabbitMQ;
using CqrsFramework.Config;
using CqrsFramework.Routing;
using Infrastructure.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Domain.CommandHandlers.Appointments;
using Registration.Domain.EventHandlers;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;
using Registration.Infra.Data.Repositories;

namespace WorkerRoleCommandProcessor
{
    public class ReservationProcessor : IDisposable
    {
        private IServiceProvider serviceProvider;

        public ReservationProcessor()
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

                RabbitMQBus bus = this.serviceProvider.GetService<RabbitMQBus>();
                bus.Start();
            }
        }

        public void Stop()
        {
            //this.serviceProvider.
            Console.WriteLine("The Service Provider Disposed.");
        }

        public void Dispose()
        {
        }

        private IServiceProvider CreateServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            //setup our DI

            var services = new ServiceCollection();
            services
                .AddDbContext<ReservationDbContext>(config =>
                    {
                        config.UseMySql(configuration["PublicDbConnectionString"]);
                    }, ServiceLifetime.Scoped)
                .AddLogging()
                .AddScoped(typeof(IReadDbRepository<>), typeof(ReadDbRepository<>))
                .AddScoped<ITenantRepository, TenantRepository>()
                .AddScoped<ISiteRepository, SiteRepository>()
                .AddScoped<ILocationRepository, LocationRepository>()
                .AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>()
                .AddScoped<IServiceItemRepository, ServiceItemRepository>()
                .AddScoped<IAvailabilityRepository, AvailabilityRepository>()
                .AddScoped<IUnavailabilityRepository, UnavailabilityRepository>()

                // event handlers
                .AddScoped<TenantEventHandler>()
                .AddScoped<SiteEventHandler>()
                .AddScoped<LocationEventHandler>()
                .AddScoped<ServiceCategoryEventHandler>()
                .AddSingleton(new TestEventHandler())

                // command handlers
                .AddScoped<AppointmentCommandHandler>()


                .AddRabbitMQEventBusSetup(configuration);


            var container = new ContainerBuilder();
            container.Populate(services);
            return new AutofacServiceProvider(container.Build());

            //var _serviceProvider = services .BuildServiceProvider();

            //return _serviceProvider;
        }

        private void RegisterHandlers(IServiceProvider provider)
        {
            var registrar = new RouteRegistrar(provider);
            registrar.RegisterInAssemblyOf(typeof(LocationEventHandler));
            //registrar.RegisterInAssemblyOf(typeof(Business.Domain.EventHandlers.TenantDomainEventHandler));


            // register command handlers
            registrar.RegisterInAssemblyOf(typeof(AppointmentCommandHandler));
        }
    }

}

