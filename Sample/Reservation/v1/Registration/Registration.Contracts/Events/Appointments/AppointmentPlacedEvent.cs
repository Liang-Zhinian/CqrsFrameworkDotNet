using System;
using System.Collections.Generic;
using CqrsFramework.Events;

namespace Registration.Contracts.Events.Appointments
{
    public class AppointmentPlacedEvent: BaseEvent, IEvent
    {
        public AppointmentPlacedEvent()
        {
        }

        public AppointmentPlacedEvent(Guid appointmentId, Guid siteId, Guid locationId, Guid staffId, DateTime startDateTime, DateTime endDateTime, Guid clientId, string genderPreference, int duration, bool staffRequested, string notes, IList<AppointmentServiceItem> appointmentServiceItems, IList<AppointmentResource> appointmentResources)
        {
            Id = Guid.NewGuid();
            AppointmentId = appointmentId;
            SiteId = siteId;
            LocationId = locationId;
            StaffId = staffId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            ClientId = clientId;
            GenderPreference = genderPreference;
            Duration = duration;
            StaffRequested = staffRequested;
            Notes = notes;
            AppointmentServiceItems = appointmentServiceItems;
            AppointmentResources = appointmentResources;
        }

        public Guid AppointmentId { get; set; }
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
