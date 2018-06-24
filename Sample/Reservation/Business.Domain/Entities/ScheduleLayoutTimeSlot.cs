using System;
namespace Business.Domain.Entities
{
    public class ScheduleLayoutTimeSlot
    {
        public Guid Id { get; private set; }
        public string Label { get; set; }
        public string EndLabel { get; set; }

        public int AvailabilityCode { get; set; }

        public Guid LayoutId { get; set; }
        public virtual ScheduleLayout Layout { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        // from monday to sunday, null if using the same layout for all days
        public int DayOfWeek { get; set; }

        public bool IsEnabled { get; set; }
    }
}
