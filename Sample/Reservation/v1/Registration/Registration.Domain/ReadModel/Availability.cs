using System;
using System.Collections.Generic;

namespace Registration.Domain.ReadModel
{
    public class Availability :ScheduleItem
    {
        protected Availability()
        {
        }

        public Availability(Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, DateTime bookableEndTime)
            : base(siteId, staffId, serviceItemId, locationId, startTime, endTime, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday)
        {
            this.BookableEndDateTime = bookableEndTime;
        }

        ///
        public DateTime BookableEndDateTime { get; private set; }

        /// Staff, teacher, or trainer
        //public Guid StaffId { get; private set; }
        //public virtual Staff Staff { get; private set; }

        //public virtual ICollection<Program> Programs { get; private set; }

        // DaysOfWeek?
    }
}
