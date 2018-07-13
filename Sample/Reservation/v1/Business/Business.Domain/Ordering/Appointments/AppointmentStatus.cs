using System;
namespace Business.Domain.Entities.Orders
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
