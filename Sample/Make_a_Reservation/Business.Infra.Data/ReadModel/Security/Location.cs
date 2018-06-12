using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Business.Infra.Data.ReadModel.Resource;

namespace Business.Infra.Data.ReadModel.Security
{
    public class Location
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual LocationContact Contact { get; set; }

        public virtual LocationAddress Address { get; set; }

        public virtual ICollection<LocationImage> AdditionalLocationImages { get; set; }

        public string TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }
        public virtual ICollection<ResourceLocation> ResourceLocations { get; set; }
    }
}
