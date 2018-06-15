using System.IO;
using System.Linq;
using System.Reflection;
using Business.Application.Interfaces;
using Business.Application.Services.Security;
using Business.Domain.Bus;
using Business.Domain.Repositories.Interfaces;
using Business.Infra.Data.Context;
using Business.Infra.Data.Repositories;
using CqrsFramework.Bus;
using CqrsFramework.Cache;
using CqrsFramework.Commands;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Business.WebApi.Configurations
{
    public static class CqrsSetup
    {
        //private static IConfiguration Configuration { get; set; }

        public static void AddCqrsSetup(this IServiceCollection services)
        {
            //Configuration = configuration;

            //Add Cqrs services
            ConfigureCqrsFramework(services);

            // event store
            RegisterEventStore(services);

            //Scan for commandhandlers and eventhandlers
            //RegisterCommandHandlers(services);
            RegisterEventHandlers(services);

            // App service
            RegisterAppService(services);

            // Infra - Data
            RegisterReadDb(services);

            //Register bus
            //var serviceProvider = services.BuildServiceProvider();
            //var registrar = new BusRegistrar(new DependencyResolver(serviceProvider));
            //registrar.Register(typeof(StaffCommandHandler));
            //registrar.Register(typeof(TenantEventHandler));


            //var events = ((SqlEventStore)serviceProvider.GetService<IEventStore>()).GetAllEventsEver();
            //var publisher = serviceProvider.GetService<IEventPublisher>();
            //foreach (var @event in events)
            //{
            //    publisher.Publish<IEvent>((IEvent)@event);
            //}

            //var events = ((MongoEventStore)serviceProvider.GetService<IEventStore>()).GetAllEventsEver();
            //var publisher = serviceProvider.GetService<IEventPublisher>();
            //foreach (var @event in events)
            //{
            //    publisher.Publish<IEvent>((IEvent)@event);
            //}
        }

        private static void ConfigureCqrsFramework(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = config.GetConnectionString("RabbitMqHost");
            services.AddSingleton<RabbitMQEventPublisher>(new RabbitMQEventPublisher(connectionString));
            services.AddSingleton<InProcessBus>(new InProcessBus());
            services.AddSingleton<ICommandSender>(y => y.GetService<InProcessBus>());
            //services.AddSingleton<IEventPublisher>(y => y.GetService<InProcessBus>());
            services.AddSingleton<IEventPublisher>(y => y.GetService<RabbitMQEventPublisher>());
            services.AddSingleton<IHandlerRegistrar>(y => y.GetService<InProcessBus>());
            services.AddScoped<ISession, Session>();

        }

        private static void RegisterReadDb(IServiceCollection services)
        {
            //var connection = Configuration.GetConnectionString("MySqlConnection");
            //services.AddDbContext<Book2DbContext>(options => options.UseMySQL(connection));


            services.AddTransient<BusinessDbContext>();
            //services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddTransient<ITenantRepository, TenantRepository>();
        }

        private static void RegisterAppService(IServiceCollection services)
        {
            // App service
            services.AddScoped<ITenantAppService, TenantService>();
        }


        private static void RegisterEventHandlers(IServiceCollection services) { 

            //services.Scan(scan => scan
            //              .FromAssemblies(typeof(TenantEventHandler).GetTypeInfo().Assembly)
            //        .AddClasses(classes => classes.Where(x =>
            //        {
            //            var allInterfaces = x.GetInterfaces();
            //            return
            //                allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && (y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICommandHandler<>))) ||
            //                allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && (y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IEventHandler<>)));
            //        }))
            //        .AsSelf()
            //        .WithTransientLifetime()
            //);
        }

        private static void RegisterEventStore(IServiceCollection services){
            //string connectionString = Configuration.GetConnectionString("SqlEventStore");
            //services.AddSingleton<IEventStore>(y => new SqlEventStore(y.GetService<InProcessBus>(), connectionString));

            // InMemoryEventStore
            services.AddSingleton<IEventStore>(y => new InMemoryEventStore(y.GetService<InProcessBus>()));

            // MongoDbEventStore
            //string connectionString = Configuration.GetConnectionString("MongoDbEventStore");
            //services.AddSingleton<IEventStore>(y => new MongoEventStore(connectionString));

            //string connectionString = Configuration.GetConnectionString("MongoDbEventStore");
            //services.AddSingleton<IEventStore>(y => new MongoDBEventStore(y.GetService<InProcessBus>(), connectionString));

            services.AddScoped<IRepository>(y => new CacheRepository(new Repository(y.GetService<IEventStore>(), y.GetService<IEventPublisher>()), y.GetService<IEventStore>()));

        }
    }
}
