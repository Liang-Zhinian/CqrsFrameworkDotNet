using System;
using System.ComponentModel.DataAnnotations;
namespace Registration.Domain.ReadModel.Security
{
    public class LocationImage
    {
        [Key]
        public Guid Id { get; private set; }
        public byte[] Image { get; private set; }

        public Guid LocationId { get; private set; }
        public Location Location { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual Tenant Tenant { get; private set; }

        public LocationImage()
        {
        }
    }
}
