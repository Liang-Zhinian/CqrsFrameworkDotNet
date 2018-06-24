using System;
namespace Business.Domain.Entities
{
    public class Unavailability : ScheduleItem
    {
        public Unavailability()
        {
        }

        public string Description { get; private set; }
    }
}
