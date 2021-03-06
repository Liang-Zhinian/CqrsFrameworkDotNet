﻿using System;
using System.Collections.Generic;
using Business.Domain.Catalog.SchedulableCatalog.Entities;
using Business.Domain.Resourcing.Entities;

namespace Business.Domain.Ordering.Appointments
{
    public class Appointment : ScheduleItem
    {
        public Appointment()
        {
        }

        public Appointment(Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime,
                          Guid clientId,
                           string genderPreference,
                           int duration,
                           bool staffRequested,
                          string notes,
                           IList<Resource> resources)
            : base(siteId, staffId, serviceItemId, locationId, startTime, endTime)
        {
            this.ClientId = clientId;
            this.GenderPreference = genderPreference;
            this.Duration = duration;
            this.StaffRequested = staffRequested;
            this.Notes = notes;
            this.Resources = resources;
        }

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

        /// The program or service category this appointment belongs to.
        //public  ServiceCategory ServiceCategory { get; private set; }

        /// The session type of this appointment.
        //public  SessionType SessionType { get; private set; }

        /// Staff, teacher, or trainer
        //public Guid StaffId { get; private set; }
        //public virtual Staff Staff { get; private set; }

        /// The client booked for this appointment.
        public Guid ClientId { get; private set; }
        //public Client Client { get; private set; }

        /// Whether this is the client's first appointment at the site.
        public bool FirstAppointment { get; private set; }

        /// The service on the client's account that is paying for this appointment.
        //public PurchasedService ClientService { get; private set; }

        /// The resources this appointment is using.
        public ICollection<Resource> Resources { get; private set; }
    }
}
