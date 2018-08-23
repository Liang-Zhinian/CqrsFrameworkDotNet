using System;
using System.Reflection;
using CqrsFramework.EventSourcing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using SaaSEqt.Common.Domain.Model;
using SaaSEqt.Common.Events;
using SaaSEqt.IdentityAccess.Infra.Data.Context;

namespace SaaSEqt.IdentityAccess.Infra.Services
{
    public class MySqlEventStore : IEventStore
    {
        private readonly IdentityAccessDbContext _context;
        private readonly EventStoreDbContext _eventStoreDbContext;

        public MySqlEventStore(
            IdentityAccessDbContext context
        )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _eventStoreDbContext = new EventStoreDbContext(
                new DbContextOptionsBuilder<EventStoreDbContext>()
                .UseMySql(_context.Database.GetDbConnection())
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
                    .Options);
        }

        public StoredEvent Append(IDomainEvent domainEvent)
        {
            return SaveIntegrationEventLogContext(domainEvent);
        }

        private StoredEvent SaveIntegrationEventLogContext(IDomainEvent domainEvent)
        {
            var eventLogEntry = FromDomainEvent(domainEvent);

            eventLogEntry.Version++;
            eventLogEntry.State = EventStateEnum.Published;

            _eventStoreDbContext.Events.Add(eventLogEntry);

            int result = _eventStoreDbContext.SaveChanges();

            return new StoredEvent(domainEvent.GetType().FullName, domainEvent.TimeStamp.DateTime, JsonConvert.SerializeObject(domainEvent));
        }

        public void Close()
        {
            _eventStoreDbContext.Database.CloseConnection();
        }

        public long CountStoredEvents()
        {
            throw new NotImplementedException();
        }

        public StoredEvent[] GetAllStoredEventsBetween(long lowStoredEventId, long highStoredEventId)
        {
            throw new NotImplementedException();
        }

        public StoredEvent[] GetAllStoredEventsSince(long storedEventId)
        {
            throw new NotImplementedException();
        }

        private Event FromDomainEvent(IDomainEvent domainEvent)
        {
            var eventEntity = new Event
            {
                AggregateId = Guid.NewGuid(),
                AggregateType = "",
                Payload = JsonConvert.SerializeObject(domainEvent),
                CorrelationId = "",
                State = EventStateEnum.NotPublished,
                TimeStamp = domainEvent.TimeStamp,
                EventType = string.Format("{0}, {1}", 
                                          domainEvent.GetType().FullName, 
                                          domainEvent.GetType().GetTypeInfo().Assembly.GetName().Name)
            };

            return eventEntity;
        }
    }
}
