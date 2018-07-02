using System;
using System.Collections.Generic;
using CqrsFramework.Domain;
//using Business.Domain.Entities.Service.PaymentOption;

namespace Business.Application.ViewModels
{
    public class ServiceCategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CancelOffset { get; set; }
        public int ScheduleTypeId { get; set; }
        public Guid SiteId { get; set; }
    }
}
