using System;
namespace Business.Domain.Ordering.Appointments
{
    public enum AppointmentStatus
    {
        Booked=1,
        Completed,
        Confirmed,
        Arrived,
        NoShow,
        Cancelled
    }
}
