﻿using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;
using Infrastructure.Utils;

namespace Business.Domain.Models.Security
{
    public class LocationImage
    {
        public Guid Id { get; private set; }
        public string Image { get; private set; }

        public Guid LocationId { get; private set; }
        public virtual Location Location { get; private set; }

        public TenantId TenantId { get; private set; }
        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public LocationImage(TenantId tenantId, Guid siteId, Guid locationId, string image)
        {
            Id = GuidUtil.NewSequentialId();
            LocationId = locationId;
            Image = image;

            SiteId = siteId;
            TenantId = tenantId;
        }
    }
}
