using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Domain.Entities
{
    public class Schedule
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public int WeekdayStart { get; set; }
        public int DaysVisible { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public TenantId TenantId { get; private set; }

        public Guid LayoutId { get; set; }
        public virtual ScheduleLayout Layout { get; set; }

        public bool IsCalendarSubscriptionAllowed { get; set; }
        //public int ScheduleTypeValue { get; set; }
        //[NotMapped]
        //public virtual ScheduleType Type { get; set; }
    }
}
