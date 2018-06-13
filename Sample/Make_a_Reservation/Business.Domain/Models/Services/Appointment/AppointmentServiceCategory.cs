using System;
using System.Collections.Generic;
using Business.Domain.Models.Security;

namespace Business.Domain.Models.Services.Appointment
{
    public class AppointmentServiceCategory : ServiceCategory
    {
        public AppointmentServiceCategory(string name, string description) : base(name, description)
        {
            this.ScheduleTypeValue = (int)ScheduleType.Appointment;
            this.ScheduleType = ScheduleType.Appointment;
        }

    }
}
