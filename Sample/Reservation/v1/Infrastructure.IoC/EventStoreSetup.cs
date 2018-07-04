using CqrsFramework.Caching;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using CqrsFramework.EventStore.IntegrationEventLogEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public static class EventStoreSetup
    {
        public static IConfiguration Configuration { get; private set; }

        public static void AddEventStoreSetup(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration = configuration;

            // event store
            RegisterEventStore(services);

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

        private static void RegisterEventStore(IServiceCollection services)
        {
            services.AddScoped<ISession, Session>();

            // EfMySqlEventStore
            services.AddSingleton<IEventStore>(y => new EfMySqlEventStore(y.GetService<IntegrationEventLogContext>().Database.GetDbConnection()));
            services.AddSingleton<ICache, MemoryCache>();
            services.AddScoped<IRepository>(y => new CacheRepository(new Repository(y.GetService<IEventStore>(), y.GetService<IEventPublisher>()), y.GetService<IEventStore>(), y.GetService<ICache>()));


            // InMemoryEventStore
            //services.AddSingleton<IEventStore>(y => new InMemoryEventStore(y.GetService<RabbitMQBus>()));
            //services.AddScoped<IRepository>(y => new CacheRepository(new Repository(y.GetService<IEventStore>(), y.GetService<IEventPublisher>()), y.GetService<IEventStore>()));

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
