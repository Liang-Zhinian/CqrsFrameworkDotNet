using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CqrsFramework.Domain;
using Infrastructure.Utils;

namespace SaaSEqt.BizInfo
{
    public class Location : AggregateRoot
    {
        public Location()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public Location(Guid tenantId) :this()
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

        [NotMapped]
        public PostalAddress PostalAddress { get; set; }

        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public virtual ICollection<LocationImage> AdditionalLocationImages { get; set; }

    }
}
