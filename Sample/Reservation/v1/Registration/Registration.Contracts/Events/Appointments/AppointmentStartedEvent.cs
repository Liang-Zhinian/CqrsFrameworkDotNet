using System;
using System.Collections.Generic;
using CqrsFramework.Events;

namespace Registration.Contracts.Events.Appointments
{
    internal class AppointmentStartedEvent : BaseEvent, IEvent
    {
        public Guid SiteId { get; set; }
        public Guid LocationId { get; set; }
        public Guid StaffId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid ClientId { get; set; }
        public string GenderPreference { get; set; }
        public int Duration { get; set; }
        public bool StaffRequested { get; set; }
        public string Notes { get; set; }
        public IList<AppointmentServiceItem> AppointmentServiceItems { get; set; }
        public IList<AppointmentResource> AppointmentResources { get; set; }
    }
}