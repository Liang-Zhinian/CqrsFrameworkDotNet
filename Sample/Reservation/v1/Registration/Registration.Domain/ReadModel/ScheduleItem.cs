﻿using System;
using Registration.Domain.ReadModel.Security;

namespace Registration.Domain.ReadModel
{
    public class ScheduleItem
    {
        protected ScheduleItem()
        {
        }

        protected ScheduleItem(Guid id, Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday)
        {
            this.Id = id;
            this.SiteId = siteId;
            this.StaffId = staffId;
            this.ServiceItemId = serviceItemId;
            this.LocationId = locationId;
            this.StartDateTime = startTime;
            this.EndDateTime = endTime;
            this.Sunday = Sunday;
            this.Monday = Monday;
            this.Tuesday = Tuesday;
            this.Wednesday = Wednesday;
            this.Thursday = Thursday;
            this.Friday = Friday;
            this.Saturday = Saturday;
        }

        /// The unique ID
        public Guid Id { get; private set; }

        /// Start time
        public DateTime StartDateTime { get; private set; }

        /// End time.
        public DateTime EndDateTime { get; private set; }

        ///// Staff, teacher, or trainer
        public Guid StaffId { get; private set; }
        public virtual Staff Staff { get; private set; }

        /// The session type of the schedule
        public Guid ServiceItemId { get; private set; }
        public ServiceItem ServiceItem { get; private set; }

        /// The location of the schedule
        public Guid LocationId { get; private set; }
        public Location Location { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public bool Sunday { get; private set; }
        public bool Monday { get; private set; }
        public bool Tuesday { get; private set; }
        public bool Wednesday { get; private set; }
        public bool Thursday { get; private set; }
        public bool Friday { get; private set; }
        public bool Saturday { get; private set; }
    }
}
