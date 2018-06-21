using System;
using System.Collections.Generic;
using CqrsFramework.Domain;
//using Business.Domain.Models.Service.PaymentOption;

namespace Business.Domain.Models
{
    public class ServiceCategory
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CancelOffset { get; set; }

        public int ScheduleTypeValue { get; set; }
        public virtual ScheduleType ScheduleType { get; set; }

        public virtual ICollection<Service> Services { get; set; }


        public ServiceCategory(string name, string description)
        {
            Name = name;
            Description = description;
            CancelOffset = 0;
            ScheduleTypeValue = 1;
        }
    }
}
