using System;
using System.ComponentModel.DataAnnotations;
namespace Registration.Domain.ReadModel.Security
{
    public class StaffLoginLocation
    {
        [Key]
        public Guid Id { get; private set; }

        public Guid StaffId { get; private set; }
        public Staff Staff { get; private set; }

        public Guid LocationId { get; private set; }
        public Location Location { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual Tenant Tenant { get; private set; }

        public StaffLoginLocation()
        {
        }
    }
}
