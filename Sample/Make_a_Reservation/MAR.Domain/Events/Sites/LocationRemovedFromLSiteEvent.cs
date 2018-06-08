using System;
using MAR.Domain.Models.Businesses;
using MAR.Domain.Models.Employees;
using MAR.Domain.Models.Locations;

namespace MAR.Domain.Events.Locations
{
    public class LocationRemovedFromSiteEvent : BaseEvent
    {
        public readonly Location Location;
        public readonly Site OldSite;

        public LocationRemovedFromSiteEvent(Guid id, Site oldSite, Location location)
        {
            Id = id;
            Location = location;
            OldSite = oldSite;
        }
    }
}
