using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsFramework.Commands;
using CqrsFramework.Domain;
using CqrsFramework.Domain.Exception;
using CqrsFramework.Events;
// using CqrsFramework.Snapshots;

namespace CqrsFramework.Tests.Extensions.TestHelpers
{
    public abstract class Specification<TAggregate, THandler, TCommand>
        where TAggregate : AggregateRoot
        where THandler : class, ICommandHandler<TCommand>
        where TCommand : ICommand
    {

        protected TAggregate Aggregate { get; set; }
        protected ISession Session { get; set; }
        protected abstract IEnumerable<IEvent> Given();
        protected abstract TCommand When();
        protected abstract THandler BuildHandler();

        // protected Snapshot Snapshot { get; set; }
        protected IList<IEvent> EventDescriptors { get; set; }
        protected IList<IEvent> PublishedEvents { get; set; }

        public Specification()
        {
            var eventpublisher = new SpecEventPublisher();
            var eventstorage = new SpecEventStorage(eventpublisher, Given().ToList());
            // var snapshotstorage = new SpecSnapShotStorage(Snapshot);

            // var snapshotStrategy = new DefaultSnapshotStrategy();
            // var repository = new SnapshotRepository(snapshotstorage, snapshotStrategy, new Repository(eventstorage), eventstorage);
            var repository = new Repository(eventstorage);
            Session = new Session(repository);
            Aggregate = GetAggregate();

            var handler = BuildHandler();
            handler.Handle(When());

            // Snapshot = snapshotstorage.Snapshot;
            PublishedEvents = eventpublisher.PublishedEvents;
            EventDescriptors = eventstorage.Events;
        }

        private TAggregate GetAggregate()
        {
            try
            {
                return Session.Get<TAggregate>(Guid.Empty);
            }
            catch (AggregateNotFoundException)
            {
                return null;
            }
        }

        //private async Task<TAggregate> GetAggregate()
        //{
        //    try
        //    {
        //        return await Task.Run(() => Session.Get<TAggregate>(Guid.Empty));
        //    }
        //    catch (AggregateNotFoundException)
        //    {
        //        return null;
        //    }
        //}
    }

    internal class SpecEventPublisher : IEventPublisher
    {
        public SpecEventPublisher()
        {
            PublishedEvents = new List<IEvent>();
        }

        public void Publish<T>(T @event) where T : IEvent
        {
            PublishedEvents.Add(@event);
            //return Task.CompletedTask;
        }

        public IList<IEvent> PublishedEvents { get; set; }
    }

    internal class SpecEventStorage : IEventStore
    {
        private readonly IEventPublisher _publisher;

        public SpecEventStorage(IEventPublisher publisher, List<IEvent> events)
        {
            _publisher = publisher;
            Events = events;
        }

        public List<IEvent> Events { get; set; }

        public void Save(IEvent evt)
        {
            Events.Add(evt);
            _publisher.Publish(evt);

        }

        public IEnumerable<IEvent> Get(Guid aggregateId, int fromVersion)
        {
            return Events.Where(x => x.Version > fromVersion);
        }
    }
}
