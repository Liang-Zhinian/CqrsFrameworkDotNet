using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.ServiceCategory
{
    public class ServiceItemCreatedEvent :ServiceItemEvent, IEvent
    {
        public ServiceItemCreatedEvent(Guid id, string name, string description, int defaultTimeLength, Guid serviceCategoryId, Guid siteId)
        {
            Id = id;
            Name = name;
            Description = description;
            DefaultTimeLength = defaultTimeLength;
            CategoryId = serviceCategoryId;
            SiteId = siteId;
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public Guid SiteId { get; set; }
        public int DefaultTimeLength { get; set; }
    }
}
