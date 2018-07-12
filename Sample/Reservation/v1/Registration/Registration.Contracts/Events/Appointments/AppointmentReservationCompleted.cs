using System;
using CqrsFramework.Events;

namespace Registration.Contracts.Events.Appointments
{
    public class AppointmentReservationCompleted : BaseEvent, IEvent
    {
        public DateTime ReservationExpiration { get; set; }

        //public IEnumerable<SeatQuantity> Seats { get; set; }
    }
}
