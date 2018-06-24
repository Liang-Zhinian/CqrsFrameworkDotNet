using System;
namespace Business.Contracts.Events.ServiceCategory
{
    public class ServiceCategoryEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CancelOffset { get; set; }
        public int ScheduleTypeValue { get; set; }
    }
}
