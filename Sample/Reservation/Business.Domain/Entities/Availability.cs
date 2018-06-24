using System;
using System.Collections.Generic;

namespace Business.Domain.Entities
{
    public class Availability :ScheduleItem
    {
        public Availability()
        {
        }

        public ICollection<Program> Programs { get; private set; }

        // DaysOfWeek?
    }
}
