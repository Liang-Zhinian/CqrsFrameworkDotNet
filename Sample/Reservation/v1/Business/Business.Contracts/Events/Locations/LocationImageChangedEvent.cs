using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.Locations
{
    public class LocationImageChangedEvent: LocationEvent, IEvent
    {
        public LocationImageChangedEvent(Guid id, Guid siteId, byte[] image)
        {
            this.Id = id;
            this.SiteId = siteId;
            this.Image = image;
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
        }
    }
}
