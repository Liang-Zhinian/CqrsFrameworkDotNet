﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using SaaSEqt.eShop.Site.Api.Events.Locations;

namespace SaaSEqt.eShop.Site.Api.Model
{
    public class LocationAddress
    {
        private LocationAddress()
        {

        }

        public LocationAddress(Guid siteId,
                               Guid locationId, 
                               PostalAddress postalAddress, 
                               Geolocation geolocation,
                              int timezoneId)
        {
            this.LocationId = locationId;
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

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }
    }
}
