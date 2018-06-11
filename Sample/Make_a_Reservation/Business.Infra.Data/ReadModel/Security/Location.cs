using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Infra.Data.ReadModel.Security
{
    public class Location
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public LocationContact Contact { get; set; }

        public LocationAddress Address { get; set; }

        public ICollection<LocationImage> AdditionalLocationImages { get; set; }

        public string TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }
    }
}
