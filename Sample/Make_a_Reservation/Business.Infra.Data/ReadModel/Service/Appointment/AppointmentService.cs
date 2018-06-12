using System;
namespace Business.Infra.Data.ReadModel.Service.Appointment
{
    public class AppointmentService : ServiceLayout<AppointmentServiceCategory>
    {
        public AppointmentService(string name, string description) : base (name, description)
        {
        }

    }
}
