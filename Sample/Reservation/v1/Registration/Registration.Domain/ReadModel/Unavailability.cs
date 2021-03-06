﻿using System;
namespace Registration.Domain.ReadModel
{
    public class Unavailability : ScheduleItem
    {

        protected Unavailability()
        {
        }

        public Unavailability(Guid id, Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, string description)
            : base(id, siteId, staffId, serviceItemId, locationId, startTime, endTime, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday)
        {
            this.Description = description;
        }

        public string Description { get; private set; }

        /// Staff, teacher, or trainer
        //public Guid StaffId { get; private set; }
        //public virtual Staff Staff { get; private set; }
    }
}
