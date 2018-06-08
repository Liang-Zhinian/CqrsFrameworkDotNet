using System;
using MAR.Domain.Models.Businesses;
using MAR.Domain.Models.Employees;
using MAR.Domain.Models.Locations;

namespace MAR.Domain.Events.Locations
{
    public class LocationAssignedToSiteEvent : BaseEvent
    {
        public readonly Site NewSite;
        public readonly Location Location;

        public LocationAssignedToSiteEvent(Guid id, Site site, Location location)
        {
            Id = id;
            NewSite = site;
            Location = location;
        }
    }
}
