using CqrsFramework.Domain.Exception;
using CqrsFramework.Domain.Factories;
using CqrsFramework.Events;
using System;
using System.Linq;

namespace CqrsFramework.Domain
{
    public class Repository : IRepository
    {
        private readonly IEventStore _eventStore;
        private readonly IEventPublisher _publisher;

        public Repository(IEventStore eventStore)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        [Obsolete("The eventstore should publish events after saving")]
        public Repository(IEventStore eventStore, IEventPublisher publisher)
        {
            if (eventStore == null)
                throw new ArgumentNullException("eventStore");
            if (publisher == null)
                throw new ArgumentNullException("publisher");
            _eventStore = eventStore;
            _publisher = publisher;
        }

        public T Get<T>(Guid aggregateId) where T : AggregateRoot
        {
            return LoadAggregate<T>(aggregateId);
        }

        public void Save<T>(T aggregate, int? expectedVersion = default(int?)) where T : AggregateRoot
        {
            if (expectedVersion != null && _eventStore.Get(
                    aggregate.Id, expectedVersion.Value).Any())
                throw new ConcurrencyException(aggregate.Id);

            var i = 0;
            foreach (var @event in aggregate.GetUncommittedChanges())
            {
                if (@event.Id == Guid.Empty)
                    @event.Id = aggregate.Id;
                if (@event.Id == Guid.Empty)
                    throw new AggregateOrEventMissingIdException(
                        aggregate.GetType(), @event.GetType());
                i++;
                @event.Version = aggregate.Version + i;
                @event.TimeStamp = DateTimeOffset.UtcNow;
                _eventStore.Save(@event);

                // The domain repository is responsible for publishing the events, this would normally be inside a single transaction together with storing the events in the event store.
                // http://stackoverflow.com/questions/12677926/why-is-the-cqrs-repository-publishing-events-not-the-event-store
                // The domain model is unaware of the storing mechanism. On the other hand it must make sure that the appropriate events will be published, no matter if you use an event store, a classical SQL store, or any other means of persistence.
                // If you rely on the event store to publish the events you'd have a tight coupling to the storage mechanism.
                if (_publisher != null) _publisher.Publish(@event);
            }
            aggregate.MarkChangesAsCommitted();
        }

        private T LoadAggregate<T>(Guid id) where T : AggregateRoot
        {
            var aggregate = AggregateFactory.CreateAggregate<T>();

            var events = _eventStore.Get(id, -1);
            if (!events.Any())
                throw new AggregateNotFoundException(id);

            aggregate.LoadFromHistory(events);
            return aggregate;
        }
    }
}
