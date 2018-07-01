using System;
using System.Collections.Generic;

namespace Catalog.Api.Model
{
    public class ServiceCategory
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int CancelOffset { get; private set; }

        public int ScheduleTypeId { get; private set; }

        public virtual ICollection<ServiceItem> ServiceItems { get; private set; }

        public Guid SiteId { get; private set; }

        private ServiceCategory()
        {
            Id = Guid.NewGuid();
        }

        public ServiceCategory(Guid siteId, string name, string description, int cancelOffset, int scheduleType) : this()
        {
            SiteId = siteId;
            Name = name;
            Description = description;
            CancelOffset = cancelOffset;
            ScheduleTypeId = scheduleType;
        }
    }
}