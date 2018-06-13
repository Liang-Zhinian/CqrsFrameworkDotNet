using System.Collections.Generic;

namespace Business.Domain.Models
{
    public class ScheduleLayout : BaseObject
    {
        public int TimeZoneId { get; set; }
        public virtual TimeZone TimeZone { get; set; }

        public virtual ICollection<ScheduleLayoutTimeSlot> TimeSlots { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}