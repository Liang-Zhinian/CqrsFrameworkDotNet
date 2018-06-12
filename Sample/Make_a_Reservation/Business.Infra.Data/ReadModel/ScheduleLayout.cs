using System.Collections.Generic;

namespace Business.Infra.Data.ReadModel
{
    public class ScheduleLayout : BaseObject<string>
    {
        public int TimeZoneId { get; set; }
        public virtual TimeZone TimeZone { get; set; }

        public virtual ICollection<ScheduleLayoutTimeSlot> TimeSlots { get; set; }
    }
}