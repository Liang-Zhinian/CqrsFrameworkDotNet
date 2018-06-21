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

        public string PrimaryTelephone { get; private set; }

        public string SecondaryTelephone { get; private set; }

        public ICollection<LocationImage> AdditionalLocationImages { get; private set; }

        public Guid TenantId { get; private set; }
        public Tenant Tenant { get; private set; }

        public ICollection<StaffLoginLocation> StaffLoginLocations { get; private set; }
    }
}
