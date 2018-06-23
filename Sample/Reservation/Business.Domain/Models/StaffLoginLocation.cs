using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Domain.Models
{
    public class StaffLoginLocation
    {
        public Guid Id { get; private set; }

        public Guid StaffId { get; private set; }
        public virtual Staff Staff { get; private set; }

        public Guid LocationId { get; private set; }
        public virtual Location Location { get; private set; }

        public TenantId TenantId { get; private set; }
        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public StaffLoginLocation(TenantId tenantId, Guid siteId, Guid staffId, Guid locationId)
        {
            Id = Guid.NewGuid();
            StaffId = staffId;
            LocationId = locationId;

            this.TenantId = tenantId;
            this.SiteId = siteId;
        }
    }
}
