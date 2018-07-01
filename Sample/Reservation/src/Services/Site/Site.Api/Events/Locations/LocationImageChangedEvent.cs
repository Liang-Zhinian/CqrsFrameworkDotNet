using System;
using CqrsFramework.Events;

namespace SaaSEqt.eShop.Site.Api.Events.Locations
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
