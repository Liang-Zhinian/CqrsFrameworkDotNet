using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.ServiceCategory
{
    public class ServiceCategoryCreatedEvent :ServiceCategoryEvent, IEvent
    {
        public ServiceCategoryCreatedEvent(Guid siteId, Guid id, string name, string description, bool allowOnlineScheduling, int scheduleTypeValue)
        {
            Id = id;
            Name = name;
            Description = description;
            AllowOnlineScheduling = allowOnlineScheduling;
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
