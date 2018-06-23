using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Utils;
using Business.Contracts.Events.Security.Locations;

namespace Business.Domain.Models
{
    public class LocationAddress
    {
        public LocationAddress(TenantId tenantId, 
                               Guid siteId,
                               Guid locationId, 
                               PostalAddress postalAddress, 
                               Geolocation geolocation,
                              int timezoneId)
        {
            this.LocationId = locationId;
            this.TenantId = tenantId;
            this.SiteId = siteId;
            this.PostalAddress = postalAddress;
            this.Geolocation = geolocation;
            this.TimeZoneId = timezoneId;
        }

        public Guid Id { get; private set; }

        public Guid LocationId { get; private set; }
        public virtual Location Location { get; private set; }

        public PostalAddress PostalAddress { get; private set; }

        public Geolocation Geolocation { get; private set; }

        public int TimeZoneId { get; private set; }
        public virtual TimeZone TimeZone { get; private set; }

        public TenantId TenantId { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }
    }
}
