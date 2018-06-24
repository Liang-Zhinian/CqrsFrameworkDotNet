using System;
namespace Business.Domain.Entities
{
    public class ScheduleItem
    {
        public ScheduleItem()
        {
        }

        /// The unique ID
        public Guid Id { get; private set; }

        ///
        public DateTime BookableEndDateTime { get; private set; }

        /// Start time
        public DateTime StartDateTime { get; private set; }

        /// End time.
        public DateTime EndDateTime { get; private set; }

        /// Staff, teacher, or trainer
        public Staff Staff { get; private set; }

        /// The location of the schedule
        public Location Location { get; private set; }

        /// The session type of the schedule
        public SessionType SessionType { get; private set; }
    }
}
