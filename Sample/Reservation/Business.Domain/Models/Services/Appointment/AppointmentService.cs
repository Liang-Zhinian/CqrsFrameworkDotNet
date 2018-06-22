using System;
using System.Collections.Generic;
using Business.Domain.Models.Security;
using Business.Domain.Models;

namespace Business.Domain.Models.Services.Appointment
{
    public class AppointmentService : Service
    {
        public AppointmentService(Guid tenantId, Guid categoryId, string name, string description) : base (tenantId, categoryId, name, description)
        {
        }
        public bool SellOnline { get; set; }
        public decimal Price { get; set; }
        public decimal OnlinePrice { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public int DefaultTimeLength { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
        public virtual ICollection<PricingOption> PricingOptions { get; set; }
    }
}
