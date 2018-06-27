using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.Locations
{
    public class LocationGeolocationChangedEvent : LocationEvent, IEvent
    {
        //private Guid SiteId;
        //private double? Latitude;
        //private double? Longitude;

        public LocationGeolocationChangedEvent(Guid id, Guid siteId, double? latitude, double? longitude)
        {
            this.Id = id;
            this.SiteId = siteId;
            this.Latitude = latitude;
            this.Longitude = longitude;

            Version = 1;
            TimeStamp = DateTimeOffset.Now;
        }
    }
}