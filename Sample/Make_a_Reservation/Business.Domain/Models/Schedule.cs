using System;
namespace Business.Domain.Models
{
    public class Schedule : BaseObject
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public int WeekdayStart { get; set; }
        public int DaysVisible { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public Guid LayoutId { get; set; }
        public virtual ScheduleLayout Layout { get; set; }

        public bool IsCalendarSubscriptionAllowed { get; set; }
    }
}
