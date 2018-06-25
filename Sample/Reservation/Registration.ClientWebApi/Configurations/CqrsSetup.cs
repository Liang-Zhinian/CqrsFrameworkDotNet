using System.IO;
using CqrsFramework.Bus;
using CqrsFramework.Bus.RabbitMQ;
using CqrsFramework.Cache;
using CqrsFramework.Commands;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Registration.ClientWebApi.Configurations
{
    public static class CqrsSetup
    {
        public static void AddCqrsSetup(this IServiceCollection services)
        {
            //Add Cqrs services
            ConfigureCqrsFramework(services);

            // event store
            RegisterEventStore(services);

            //Scan for commandhandlers and eventhandlers
            //RegisterCommandHandlers(services);
            RegisterEventHandlers(services);


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
            services.AddSingleton<RabbitMQBus>(new RabbitMQBus(connectionString, "book2", "fanout", "book2events", true));
            services.AddSingleton<ICommandSender>(y => y.GetService<RabbitMQBus>());
            services.AddSingleton<IEventPublisher>(y => y.GetService<RabbitMQBus>());
            services.AddSingleton<IHandlerRegistrar>(y => y.GetService<RabbitMQBus>());

            // for local
            //services.AddSingleton<InProcessBus>(new InProcessBus());
            //services.AddSingleton<IEventPublisher>(y => y.GetService<InProcessBus>());
            //services.AddSingleton<IHandlerRegistrar>(y => y.GetService<InProcessBus>());
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
            services.AddScoped<ISession, Session>();
            // InMemoryEventStore
            services.AddSingleton<IEventStore>(y => new InMemoryEventStore(y.GetService<RabbitMQBus>()));
            services.AddScoped<IRepository>(y => new CacheRepository(new Repository(y.GetService<IEventStore>(), y.GetService<IEventPublisher>()), y.GetService<IEventStore>()));

            //string connectionString = Configuration.GetConnectionString("SqlEventStore");
            //services.AddSingleton<IEventStore>(y => new SqlEventStore(y.GetService<InProcessBus>(), connectionString));

            // MongoDbEventStore
            //string connectionString = Configuration.GetConnectionString("MongoDbEventStore");
            //services.AddSingleton<IEventStore>(y => new MongoEventStore(connectionString));

            //string connectionString = Configuration.GetConnectionString("MongoDbEventStore");
            //services.AddSingleton<IEventStore>(y => new MongoDBEventStore(y.GetService<InProcessBus>(), connectionString));


        }
    }
}
