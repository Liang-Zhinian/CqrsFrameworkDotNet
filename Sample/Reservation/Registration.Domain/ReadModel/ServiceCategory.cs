using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CqrsFramework.Domain;
//using Business.Domain.Entities.Service.PaymentOption;

namespace Registration.Domain.ReadModel
{
    public class ServiceCategory
    {
        //[Column(TypeName = "char(40)")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CancelOffset { get; set; }
        //[Column(TypeName = "char(40)")]
        public Guid ParentCategoryId { get; set; }
        public bool IsInternal { get; set; }

        public virtual ServiceCategory ParentCategory { get; set; }

        public int ScheduleTypeValue { get; set; }
        //public virtual ScheduleType ScheduleType { get; set; }

        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<ServiceCategory> SubCategories { get; set; }


        public ServiceCategory(Guid id,
                               string name, 
                               string description, 
                               int cancelOffset, 
                               int scheduleType, 
                               Guid parentCategoryId, 
                               bool isInternal=false)
        {
            Id = id;
            Name = name;
            Description = description;
            CancelOffset = cancelOffset;
            ScheduleTypeValue = scheduleType;
            ParentCategoryId = parentCategoryId;
            IsInternal = isInternal;
        }
    }
}
