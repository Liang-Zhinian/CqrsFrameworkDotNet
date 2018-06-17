
namespace SaaSEqt.Common.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using CqrsFramework.Events;

    public class DomainEventPublisher
    {
        [ThreadStatic]
        static DomainEventPublisher _instance;
        
        public static DomainEventPublisher Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DomainEventPublisher();
                }
                return _instance;
            }
        }

        DomainEventPublisher()
        {
            this.publishing = false;
        }

        bool publishing;

        List<IDomainEventSubscriber<IEvent>> _subscribers;
        List<IDomainEventSubscriber<IEvent>> Subscribers
        {
            get
            {
                if (this._subscribers == null)
                {
                    this._subscribers = new List<IDomainEventSubscriber<IEvent>>();
                }

                return this._subscribers;
            }
            set
            {
                this._subscribers = value;
            }
        }

        public void Publish<T>(T domainEvent) where T : IEvent
        {
            if (!this.publishing && this.HasSubscribers())
            {
                try
                {
                    this.publishing = true;

                    var eventType = domainEvent.GetType();

                    foreach (var subscriber in this.Subscribers)
                    {
                        var subscribedToType = subscriber.SubscribedToEventType();
                        if (eventType == subscribedToType || subscribedToType == typeof(IEvent))
                        {
                            subscriber.HandleEvent(domainEvent);
                        }
                    }
                }
                finally
                {
                    this.publishing = false;
                }
            }
        }

        public void PublishAll(ICollection<IEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                this.Publish(domainEvent);
            }
        }

        public void Reset()
        {
            if (!this.publishing)
            {
                this.Subscribers = null;
            }
        }

        public void Subscribe(IDomainEventSubscriber<IEvent> subscriber)
        {
            if (!this.publishing)
            {
                this.Subscribers.Add(subscriber);
            }
        }

        public void Subscribe(Action<IEvent> handle)
        {
            Subscribe(new DomainEventSubscriber<IEvent>(handle));
        }

        class DomainEventSubscriber<TEvent> : IDomainEventSubscriber<TEvent>
            where TEvent : IEvent
        {
            public DomainEventSubscriber(Action<TEvent> handle)
            {
                this.handle = handle;
            }

            readonly Action<TEvent> handle;

            public void HandleEvent(TEvent domainEvent)
            {
                this.handle(domainEvent);
            }

            public Type SubscribedToEventType()
            {
                return typeof(TEvent);
            }
        }

        bool HasSubscribers()
        {
            return this._subscribers != null && this.Subscribers.Count != 0;
        }
    }
}
