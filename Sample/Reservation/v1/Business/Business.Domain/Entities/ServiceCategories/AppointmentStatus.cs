using System;
namespace Business.Domain.Entities.ServiceCategories
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
