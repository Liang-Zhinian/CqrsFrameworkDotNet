using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.ServiceCategory
{
    public class ServiceItemCreatedEvent :BaseEvent, IEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool AllowOnlineScheduling { get; set; }
        public Guid ServiceCategoryId { get; set; }
        public int IndustryStandardCategoryId { get; set; }
        public Guid SiteId { get; set; }
        public int DefaultTimeLength { get; set; }

        public ServiceItemCreatedEvent(Guid siteId, Guid id, string name, string description, int defaultTimeLength, double price, bool allowOnlineScheduling, Guid serviceCategoryId, int industryStandardCategoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            DefaultTimeLength = defaultTimeLength;
            Price = price;
            AllowOnlineScheduling = allowOnlineScheduling;
            IndustryStandardCategoryId = industryStandardCategoryId;
            ServiceCategoryId = serviceCategoryId;
            SiteId = siteId;
            //Version = 1;
            //TimeStamp = DateTimeOffset.Now;
        }

        //public int Version { get; set; }
        //public DateTimeOffset TimeStamp { get; set; }
    }
}
