using System;
namespace Business.Domain.Entities.Services
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
