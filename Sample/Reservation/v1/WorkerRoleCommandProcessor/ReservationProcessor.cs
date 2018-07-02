using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CqrsFramework.Bus.RabbitMQ;
using CqrsFramework.Config;
using Infrastructure.IoC;
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
                        config.UseMySql(configuration["ConnectionString"]);
                    }, ServiceLifetime.Scoped)
                .AddLogging()
                .AddScoped(typeof(IReadDbRepository<>), typeof(ReadDbRepository<>))
                .AddScoped<ITenantRepository, TenantRepository>()
                .AddScoped<ISiteRepository, SiteRepository>()
                .AddScoped<ILocationRepository, LocationRepository>()
                .AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>()
                .AddScoped<IServiceItemRepository, ServiceItemRepository>()
                .AddScoped<TenantEventHandler>(y => new TenantEventHandler(y.GetService<ITenantRepository>()))
                .AddScoped<SiteEventHandler>(y => new SiteEventHandler(y.GetService<ISiteRepository>()))
                .AddScoped<LocationEventHandler>(y => new LocationEventHandler(y.GetService<ILocationRepository>()))
                .AddScoped<ServiceCategoryEventHandler>(y => new ServiceCategoryEventHandler(y.GetService<IServiceCategoryRepository>(),
                                                                                             y.GetService<IServiceItemRepository>()))
                .AddSingleton(new TestEventHandler())

                .AddRabbitMQEventBusSetup(configuration);


            var container = new ContainerBuilder();
            container.Populate(services);
            return new AutofacServiceProvider(container.Build());

            //var _serviceProvider = services .BuildServiceProvider();

            //return _serviceProvider;
        }

        private void RegisterHandlers(IServiceProvider provider)
        {
            var registrar = new BusRegistrar(new DependencyResolver(provider));
            registrar.Register(typeof(LocationEventHandler));

        }
    }

}

