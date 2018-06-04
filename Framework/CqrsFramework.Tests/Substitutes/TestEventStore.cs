using CqrsFramework.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CqrsFramework.Tests.Substitutes
{
    public class TestEventStore : IEventStore
    {
        private List<IEvent> SavedEvents { get; }
        private readonly Guid _emptyGuid;

        public TestEventStore()
        {
            _emptyGuid = Guid.NewGuid();
            SavedEvents = new List<IEvent>();
        }

        public IEnumerable<IEvent> Get(Guid aggregateId, int fromVersion)
        {
            if (aggregateId == _emptyGuid || aggregateId == Guid.Empty)
            {
                return (IEnumerable<IEvent>)new List<IEvent>();
            }

            return new List<IEvent>
            {
                new TestAggregateDidSomething {Id = aggregateId, Version = 1},
                new TestAggregateDidSomeethingElse {Id = aggregateId, Version = 2},
                new TestAggregateDidSomething {Id = aggregateId, Version = 3},
            }.Where(x => x.Version > fromVersion);
        }

        public void Save(IEvent @event)
        {
            SavedEvents.Add(@event);
        }
    }
}
