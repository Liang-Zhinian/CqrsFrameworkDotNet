using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models.ValueObjects;
using Infrastructure.Utils;

namespace Business.Domain.Models.Security
{
    public class TenantAddress : BaseObject
    {
        [NotMapped]
        public PostalAddress PostalAddress { get; set; }

        public TenantAddress()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public TenantAddress(Guid tenantId) : base(tenantId)
        {
            Id = GuidUtil.NewSequentialId();
        }
    }
}
