using System;
using System.Collections.Generic;
using Business.Domain.Identity.Entities;
using CqrsFramework.Domain;

namespace Business.Domain.Catalog.SchedulableCatalog.Entities
{
    public class SchedulableCatalogType : CatalogType // : AggregateRoot
    {
        public string Description { get; private set; }
        public bool AllowOnlineScheduling { get; private set; }

        public int ScheduleTypeId { get; private set; }
        public virtual ScheduleType ScheduleType { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        private SchedulableCatalogType()
        {
            Id = Guid.NewGuid();
        }

        public SchedulableCatalogType(Guid siteId, string type, string description, bool allowOnlineScheduling, int scheduleType) : this()
        {
            SiteId = siteId;
            Type = type;
            Description = description;
            AllowOnlineScheduling = allowOnlineScheduling;
            ScheduleTypeId = scheduleType;

            //var serviceCategoryCreatedEvent = new ServiceCategoryCreatedEvent(Id,
            //                                                                  name,
            //                                                                  description,
            //                                                                  cancelOffset,
            //                                                                  scheduleType,
            //                                                                  siteId
            //                                                                 );
            //ApplyChange(serviceCategoryCreatedEvent);
        }
    }
}