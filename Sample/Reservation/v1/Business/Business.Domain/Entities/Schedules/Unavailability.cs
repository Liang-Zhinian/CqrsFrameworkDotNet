using System;
namespace Business.Domain.Entities.Schedules
{
    public class Unavailability : ScheduleItem
    {

        protected Unavailability()
        {
        }

        public Unavailability(Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, string description)
            : base(siteId, staffId, serviceItemId, locationId, startTime, endTime, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday)
        {
            this.Description = description;
        }

        public string Description { get; private set; }

        /// Staff, teacher, or trainer
        //public Guid StaffId { get; private set; }
        //public virtual Staff Staff { get; private set; }
    }
}
