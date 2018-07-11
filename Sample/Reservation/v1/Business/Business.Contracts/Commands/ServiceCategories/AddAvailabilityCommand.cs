using System;

namespace Business.Contracts.Commands.ServiceCategories
{
    public class AddAvailabilityCommand: ScheduleItemCommand
    {
        public AddAvailabilityCommand(Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, DateTime bookableEndTime)
            : base(siteId, staffId, serviceItemId, locationId, startTime, endTime, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday)
        {
            this.BookableEndDateTime = bookableEndTime;
        }

        public DateTime BookableEndDateTime { get; set; }
    }
}
