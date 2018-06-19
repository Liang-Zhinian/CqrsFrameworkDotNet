using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.Security.Locations
{
    public class LocationCreatedEvent : BaseEvent, IEvent
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid TenantId { get; private set; }

        public LocationCreatedEvent(Guid id, string name, string description, Guid tenantId)
        {
            Id = id;
            Name = name;
            Description = description;
            TenantId = tenantId;

            Version = 1;
            TimeStamp = DateTimeOffset.Now;
        }
    }
}
