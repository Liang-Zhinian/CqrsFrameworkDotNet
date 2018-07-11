using System;
using CqrsFramework.Commands;

namespace Business.Contracts.Commands
{
    public class ScheduleItemCommand
    {
        public ScheduleItemCommand(Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday)
        {
            this.SiteId = siteId;
            this.StaffId = staffId;
            this.ServiceItemId = serviceItemId;
            this.LocationId = locationId;
            this.StartDateTime = startTime;
            this.EndDateTime = endTime;
            this.Sunday = Sunday;
            this.Monday = Monday;
            this.Tuesday = Tuesday;
            this.Wednesday = Wednesday;
            this.Thursday = Thursday;
            this.Friday = Friday;
            this.Saturday = Saturday;

            TimeStamp = DateTimeOffset.Now;
        }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid StaffId { get; set; }
        public Guid ServiceItemId { get; set; }
        public Guid LocationId { get; set; }
        public Guid SiteId { get; set; }

        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
