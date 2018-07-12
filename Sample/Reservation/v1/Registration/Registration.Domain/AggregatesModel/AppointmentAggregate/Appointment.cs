using System;
using System.Collections.Generic;
using CqrsFramework.Domain;
using Registration.Contracts.Events.Appointments;

namespace Registration.Domain.AggregatesModel.AppointmentAggregate
{
    public class Appointment : AggregateRoot, IOrder
    {
        #region ctor

        public Appointment()
        {
        }

        public Appointment(Guid siteId,
                           Guid staffId,
                           Guid serviceItemId,
                           Guid locationId,
                           DateTime startDateTime,
                           DateTime endDateTime,
                          Guid clientId,
                           string genderPreference,
                           int duration,
                           bool staffRequested,
                          string notes,
                           IList<Guid> resources)
        {
            this.Id = Guid.NewGuid();
            this.SiteId = siteId;
            this.StaffId = staffId;
            this.ServiceItemId = serviceItemId;
            this.LocationId = locationId;
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
            this.ClientId = clientId;
            this.GenderPreference = genderPreference;
            this.Duration = duration;
            this.StaffRequested = staffRequested;
            this.Notes = notes;
            this.Resources = resources;

            ApplyChange(new AppointmentPlaced
            {
                Id = this.Id,
                SiteId = siteId,
                LocationId = locationId,
                StaffId = staffId,
                ServiceItemId = serviceItemId,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime,
                ClientId = clientId,
                GenderPreference = genderPreference,
                Duration = duration,
                StaffRequested = staffRequested,
                Notes = notes,
                Resources = resources
            });
        }

        #endregion

        #region properties

        /// Start time
        public DateTime StartDateTime { get; private set; }

        /// End time.
        public DateTime EndDateTime { get; private set; }

        ///// Staff, teacher, or trainer
        public Guid StaffId { get; private set; }

        /// The session type of the schedule
        public Guid ServiceItemId { get; private set; }

        /// The location of the schedule
        public Guid LocationId { get; private set; }

        public Guid SiteId { get; private set; }

        /// Prefered gender of appointment
        public string GenderPreference { get; private set; }

        /// Duration of appointment. Only used to change appointment default duration for add.
        public int Duration { get; private set; }

        /// If a user has Complementary and Alternative Medicine features enabled. This will allow a Provider ID to be assigned to an appointment.
        public string ProviderID { get; private set; }

        /// The status of this appointment.
        public string Status { get; private set; }

        /// The appointment notes.
        public string Notes { get; private set; }

        /// Whether the staff member was requested specifically by the client.
        public bool StaffRequested { get; private set; }

        /// The client booked for this appointment.
        public Guid ClientId { get; private set; }
        //public Client Client { get; private set; }

        /// Whether this is the client's first appointment at the site.
        public bool FirstAppointment { get; private set; }

        /// The service on the client's account that is paying for this appointment.
        //public PurchasedService ClientService { get; private set; }

        /// The resources this appointment is using.
        public ICollection<Guid> Resources { get; private set; }

        #endregion

        #region ordering cycle commands

        public decimal GetTotal()
        {
            throw new NotImplementedException();
        }

        public void SetAwaitingValidationStatus()
        {
            throw new NotImplementedException();
        }

        public void SetCancelledStatus()
        {
            throw new NotImplementedException();
        }

        public void SetPaidStatus()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
