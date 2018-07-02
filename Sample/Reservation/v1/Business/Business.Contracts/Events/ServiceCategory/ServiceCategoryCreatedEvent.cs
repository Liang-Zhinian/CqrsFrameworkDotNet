using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.ServiceCategory
{
    public class ServiceCategoryCreatedEvent :ServiceCategoryEvent, IEvent
    {
        public ServiceCategoryCreatedEvent(Guid id, string name, string description, int cancelOffset, int scheduleTypeValue, Guid siteId)
        {
            Id = id;
            Name = name;
            Description = description;
            CancelOffset = cancelOffset;
            ScheduleTypeValue = scheduleTypeValue;
            SiteId = siteId;
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
            //MessageType = "DomainEvent";
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public Guid SiteId { get; set; }
    }
}
