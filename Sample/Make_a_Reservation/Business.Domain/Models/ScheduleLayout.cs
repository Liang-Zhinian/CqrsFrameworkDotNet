using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Domain.Models
{
    public class ScheduleLayout : BaseObject
    {
        public int TimeZoneId { get; set; }

        [NotMapped]
        public virtual TimeZone TimeZone { get; set; }

        public virtual ICollection<ScheduleLayoutTimeSlot> TimeSlots { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}