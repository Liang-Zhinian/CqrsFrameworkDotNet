using System;
using CqrsFramework.Events;

namespace Business.Domain.Events.ServiceCategory
{
    public class ServiceCreatedEvent :ServiceEvent, IEvent
    {
        public ServiceCreatedEvent(Guid id, string name, string description, Guid serviceCategoryId, Guid tenantId)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = serviceCategoryId;
            TenantId = tenantId;
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
            //MessageType = "DomainEvent";
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
