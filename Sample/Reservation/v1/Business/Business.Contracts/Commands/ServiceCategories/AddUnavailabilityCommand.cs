using System;

namespace Business.Contracts.Commands.ServiceCategories
{
    public class AddUnavailabilityCommand: ScheduleItemCommand
    {
        public AddUnavailabilityCommand(Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, string description)
            : base(siteId, staffId, serviceItemId, locationId, startTime, endTime, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}
