using System;
namespace Business.Domain.Entities.Schedules
{
    public class Unavailability : ScheduleItem
    {
        public Unavailability()
        {
        }

        public string Description { get; private set; }

        /// Staff, teacher, or trainer
        //public Guid StaffId { get; private set; }
        //public virtual Staff Staff { get; private set; }
    }
}
