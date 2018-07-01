using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.ServiceCategory
{
    public class ServiceCreatedEvent :ServiceEvent, IEvent
    {
        public ServiceCreatedEvent(Guid id, string name, string description, Guid serviceCategoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = serviceCategoryId;
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
            //MessageType = "DomainEvent";
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
