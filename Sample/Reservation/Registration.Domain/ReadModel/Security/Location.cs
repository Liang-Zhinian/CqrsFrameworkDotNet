using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registration.Domain.ReadModel.Security
{
    public class Location
    {
        public Location(Guid id, string name, string description, Guid tenantId)
        {
            Id = id;
            Name = name;
            Description = description;
            TenantId = tenantId;
        }

        [Key]
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Email { get; private set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }

        public string StateProvince { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string PrimaryTelephone { get; private set; }

        public string SecondaryTelephone { get; private set; }

        public byte[] Image { get; private set; }

        public ICollection<LocationImage> AdditionalLocationImages { get; private set; }

        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public ICollection<StaffLoginLocation> StaffLoginLocations { get; private set; }
    }
}
