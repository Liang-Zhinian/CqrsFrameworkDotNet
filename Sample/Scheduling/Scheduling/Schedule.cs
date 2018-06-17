using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaaSEqt.Scheduling
{
    public class Schedule
    {
        //public enum ScheduleType{
        //    All=0,
        //    DropIn,
        //    Enrollment,
        //    Appointment,
        //    Resource,
        //    Media,
        //    Arrival
        //}

        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public int WeekdayStart { get; set; }
        public int DaysVisible { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public Guid LayoutId { get; set; }
        public virtual ScheduleLayout Layout { get; set; }

        public bool IsCalendarSubscriptionAllowed { get; set; }
        //public int ScheduleTypeValue { get; set; }
        //[NotMapped]
        //public virtual ScheduleType Type { get; set; }
    }
}
