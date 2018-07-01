using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Domain.Entities
{
    public class ScheduleLayout
    {
        public Guid Id { get; private set; }
        public int TimeZoneId { get; set; }

        public virtual TimeZone TimeZone { get; set; }

        public virtual ICollection<ScheduleLayoutTimeSlot> TimeSlots { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}