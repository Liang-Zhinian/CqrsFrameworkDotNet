using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CqrsFramework.Domain;
using Registration.Domain.ReadModel.Security;
//using Business.Domain.Entities.Service.PaymentOption;

namespace Registration.Domain.ReadModel
{
    public class ServiceCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CancelOffset { get; set; }
        public int ScheduleTypeId { get; set; }
        public Guid SiteId { get; private set; }
        public virtual Site Site { get; set; }


        public ServiceCategory(Guid id,
                               string name, 
                               string description, 
                               int cancelOffset, 
                               int scheduleType,
                              Guid siteId)
        {
            Id = id;
            Name = name;
            Description = description;
            CancelOffset = cancelOffset;
            ScheduleTypeId = scheduleType;
            SiteId = siteId;
        }
    }
}
