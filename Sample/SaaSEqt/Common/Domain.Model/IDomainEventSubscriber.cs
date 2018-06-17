
namespace SaaSEqt.Common.Domain.Model
{
    using System;
    using CqrsFramework.Events;

    public interface IDomainEventSubscriber<T> where T : IEvent
    {
        void HandleEvent(T domainEvent);
        Type SubscribedToEventType();
    }
}
