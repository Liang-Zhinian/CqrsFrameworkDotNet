using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.ServiceCategory
{
    public class ServiceItemCreatedEvent :ServiceItemEvent, IEvent
    {
        public ServiceItemCreatedEvent(Guid id, string name, string description, int defaultTimeLength, double price, Guid serviceCategoryId, Guid siteId, int industryStandardCategoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            DefaultTimeLength = defaultTimeLength;
            Price = price;
            IndustryStandardCategoryId = industryStandardCategoryId;
            ServiceCategoryId = serviceCategoryId;
            SiteId = siteId;
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
        }

        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
