using System;
using System.Collections.Generic;
using Business.Contracts.Events.ServiceCategory;
using Business.Domain.Entities.Schedules;
using CqrsFramework.Domain;

namespace Business.Domain.Entities.ServiceCategories
{
    public class ServiceCategory // : AggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool AllowOnlineScheduling { get; private set; }

        public int ScheduleTypeId { get; private set; }
        public virtual ScheduleType ScheduleType { get; private set; }

        public virtual ICollection<ServiceItem> ServiceItems { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        private ServiceCategory()
        {
            Id = Guid.NewGuid();
        }

        public ServiceCategory(Guid siteId, string name, string description, bool allowOnlineScheduling, int scheduleType) : this()
        {
            SiteId = siteId;
            Name = name;
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