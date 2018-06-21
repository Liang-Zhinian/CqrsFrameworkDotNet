using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Utils;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Models.Security
{
    public class Location : BaseObject
    {
        public Location()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public Location(Guid tenantId) : this()
        {
            TenantId = tenantId;
        }

        public Guid BusinessID { get; set; }
        public string BusinessDescription { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }

        public PostalAddress PostalAddress { get; set; }

        public virtual ICollection<LocationImage> AdditionalLocationImages { get; set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        public virtual ICollection<ResourceLocation> ResourceLocations { get; set; }

    }
}
