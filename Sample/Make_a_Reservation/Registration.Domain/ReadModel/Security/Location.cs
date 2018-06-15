using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registration.Domain.ReadModel.Security
{
    public class Location
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public ICollection<LocationImage> AdditionalLocationImages { get; set; }

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }
    }
}
