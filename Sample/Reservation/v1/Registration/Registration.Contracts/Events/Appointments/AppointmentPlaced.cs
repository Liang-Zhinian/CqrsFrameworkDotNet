using System;
using System.Collections.Generic;
using CqrsFramework.Events;

namespace Registration.Contracts.Events.Appointments
{
    public class AppointmentPlaced: BaseEvent, IEvent
    {
        public AppointmentPlaced()
        {
        }

        public Guid AppointmentId { get; set; }

        /// Start time
        public DateTime StartDateTime { get; set; }

        /// End time.
        public DateTime EndDateTime { get; set; }

        ///// Staff, teacher, or trainer
        public Guid StaffId { get; set; }

        /// The session type of the schedule
        public Guid ServiceItemId { get; set; }

        /// The location of the schedule
        public Guid LocationId { get; set; }

        public Guid SiteId { get; set; }

        /// Prefered gender of appointment
        public string GenderPreference { get; set; }

        /// Duration of appointment. Only used to change appointment default duration for add.
        public int Duration { get; set; }

        /// If a user has Complementary and Alternative Medicine features enabled. This will allow a Provider ID to be assigned to an appointment.
        public string ProviderID { get; set; }

        /// The status of this appointment.
        public string Status { get; set; }

        /// The appointment notes.
        public string Notes { get; set; }

        /// Whether the staff member was requested specifically by the client.
        public bool StaffRequested { get; set; }

        /// The client booked for this appointment.
        public Guid ClientId { get; set; }

        /// Whether this is the client's first appointment at the site.
        public bool FirstAppointment { get; set; }

        /// The resources this appointment is using.
        public ICollection<Guid> Resources { get; set; }
    }
}
