using System;
using System.ComponentModel.DataAnnotations;
namespace Registration.Domain.ReadModel.Security
{
    public class LocationImage
    {
        [Key]
        public Guid Id { get; private set; }
        public string ImageUrl { get; private set; }

        public Guid LocationId { get; private set; }
        public Location Location { get; private set; }

        public Guid TenantId { get; private set; }
        public Tenant Tenant { get; private set; }

        public LocationImage()
        {
        }
    }
}
