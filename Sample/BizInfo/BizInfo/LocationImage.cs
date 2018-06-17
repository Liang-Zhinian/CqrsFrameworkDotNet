using System;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using Infrastructure.Utils;

namespace SaaSEqt.BizInfo
{
    public class LocationImage : AggregateRoot
    {
        public string ImageUrl { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }

        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public LocationImage()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public LocationImage(Guid locationId, Guid tenantId)
        {
            LocationId = locationId;
            TenantId = tenantId;
        }
    }
}
