using CqrsFramework.Events;

namespace Registration.Contracts.Events.Appointments
{
    public class AppointmentTotalsCalculated : BaseEvent, IEvent
    {
        public decimal Total { get; set; }

        //public OrderLine[] Lines { get; set; }

        public bool IsFreeOfCharge { get; set; }
    }
}
