using System;
namespace Business.Infra.Data.ReadModel
{
    public class Schedule : BaseObject<string>
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public int WeekdayStart { get; set; }
        public int DaysVisible { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public string LayoutId { get; set; }
        public virtual ScheduleLayout Layout { get; set; }

        public bool IsCalendarSubscriptionAllowed { get; set; }
    }
}
