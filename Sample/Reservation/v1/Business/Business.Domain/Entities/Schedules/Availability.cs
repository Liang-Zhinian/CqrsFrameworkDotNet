using System;
using System.Collections.Generic;
using Business.Domain.Entities.ServiceCategories;

namespace Business.Domain.Entities.Schedules
{
    public class Availability :ScheduleItem
    {
        public Availability()
        {
        }

        ///
        public DateTime BookableEndDateTime { get; private set; }

        /// Staff, teacher, or trainer
        //public Guid StaffId { get; private set; }
        //public virtual Staff Staff { get; private set; }

        public ICollection<Program> Programs { get; private set; }

        // DaysOfWeek?
    }
}
