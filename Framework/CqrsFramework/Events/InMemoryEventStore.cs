using System;
using System.Collections.Generic;
using System.Linq;

namespace CqrsFramework.Events
{
    public class InMemoryEventStore : IEventStore
    {
        private readonly IEventPublisher _publisher; //Use this to publish events so that event handlers can consume them
        private readonly Dictionary<Guid, List<IEvent>> _inMemoryDb = new Dictionary<Guid, List<IEvent>>();

        public InMemoryEventStore(IEventPublisher publisher)
        {
            _publisher = publisher;
        }

        public IEnumerable<IEvent> Get<T>(Guid aggregateId, int fromVersion)
        {
            List<IEvent> events;
            _inMemoryDb.TryGetValue(aggregateId, out events);
            return events?.Where(x => x.Version > fromVersion) ?? new List<IEvent>();
        }

        public IEnumerable<IEvent> Get(Guid aggregateId, int fromVersion)
        {
            List<IEvent> events;
            _inMemoryDb.TryGetValue(aggregateId, out events);
            return events != null
                ? events.Where(x => x.Version > fromVersion)
                : new List<IEvent>();
        }

        public void Save(IEvent @event)
        {
            List<IEvent> list;
            _inMemoryDb.TryGetValue(@event.Id, out list);
            if (list == null)
            {
                list = new List<IEvent>();
                _inMemoryDb.Add(@event.Id, list);
            }
            list.Add(@event);
        }
    }
}
