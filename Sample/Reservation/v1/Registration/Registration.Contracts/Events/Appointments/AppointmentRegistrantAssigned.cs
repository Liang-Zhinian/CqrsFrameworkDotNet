using CqrsFramework.Events;

namespace Registration.Contracts.Events.Appointments
{
    public class AppointmentRegistrantAssigned : BaseEvent, IEvent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
