using System;
namespace Business.Domain.Models.Service.Appointment
{
    public class AppointmentService : ServiceLayout<AppointmentServiceCategory>
    {
        public AppointmentService(string name, string description) : base (name, description)
        {
        }

    }
}
