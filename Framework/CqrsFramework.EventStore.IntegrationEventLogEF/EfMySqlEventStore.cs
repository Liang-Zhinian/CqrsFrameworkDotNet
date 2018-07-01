using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using CqrsFramework.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace CqrsFramework.EventStore.IntegrationEventLogEF
{
    public class EfMySqlEventStore : IEventStore
    {

        private readonly IntegrationEventLogContext _integrationEventLogContext;
        private readonly DbConnection _dbConnection;

        public EfMySqlEventStore(DbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException("dbConnection");
            _integrationEventLogContext = new IntegrationEventLogContext(
                new DbContextOptionsBuilder<IntegrationEventLogContext>()
                    .UseMySql(_dbConnection)
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
                    .Options);
        }

        public IEnumerable<IEvent> Get(Guid aggregateId, int fromVersion)
        {
            IList<IEvent> events = new List<IEvent>();
            var evts = _integrationEventLogContext.IntegrationEventLogs.Where(_=>_.EventId.Equals(aggregateId));
            foreach (var evt in evts)
            {
                var eventTypeString = evt.EventTypeName;
                var eventType = Type.GetType(eventTypeString);
                var serializedBody = evt.Content;
                var @event = JsonConvert.DeserializeObject(serializedBody, eventType);
                events.Add((IEvent)@event);
            }

            return events;
        }

        public void Save(IEvent @event)
        {
            var eventLogEntry = new IntegrationEventLogEntry(@event);

            _integrationEventLogContext.IntegrationEventLogs.Add(eventLogEntry);
            _integrationEventLogContext.SaveChanges();
        }
    }
}
