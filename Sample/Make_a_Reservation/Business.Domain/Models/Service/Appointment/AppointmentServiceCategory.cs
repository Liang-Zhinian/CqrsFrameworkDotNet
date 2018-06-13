using System;
using System.Collections.Generic;
using Business.Domain.Models.Security;

namespace Business.Domain.Models.Service.Appointment
{
    public class AppointmentServiceCategory : ServiceCategory<AppointmentService>
    {
        public AppointmentServiceCategory(string name, string description) : base(name, description)
        {
        }

        public virtual ICollection<Staff> Staffs { get; set; }
        public virtual ICollection<Pricing> PricingOptions { get; set; }
    }
}
