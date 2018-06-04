using CqrsFramework.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CqrsFramework.Tests.Substitutes
{
    public class TestInMemoryEventStore : IEventStore
    {
        public readonly List<IEvent> Events = new List<IEvent>();
        
        public void Save(IEvent @event)
        {
            lock (Events)
            {
                Events.Add(@event);
            }
        }

        public IEnumerable<IEvent> Get(Guid aggregateId, int fromVersion)
        {
            lock (Events)
            {
                return (IEnumerable<IEvent>)Events.Where(x => x.Version > fromVersion && x.Id == aggregateId).OrderBy(x => x.Version).ToList();
            }
        }
    }
}
