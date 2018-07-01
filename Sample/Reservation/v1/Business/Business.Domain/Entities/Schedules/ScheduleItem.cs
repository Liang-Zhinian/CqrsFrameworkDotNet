using System;
using Business.Domain.Entities.ServiceCategories;

namespace Business.Domain.Entities
{
    public class ScheduleItem
    {
        public ScheduleItem()
        {
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

        /// The location of the schedule
        public Guid LocationId { get; private set; }
        public Location Location { get; private set; }

        /// The session type of the schedule
        public Guid ServiceItemId { get; private set; }
        public ServiceItem ServiceItem { get; private set; }
    }
}
