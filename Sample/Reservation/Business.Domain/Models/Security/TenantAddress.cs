using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models.ValueObjects;
using Infrastructure.Utils;

namespace Business.Domain.Models.Security
{
    public class TenantAddress
    {
        public Guid Id { get; private set; }

        public PostalAddress PostalAddress { get; private set; }

        public TenantId TenantId { get; private set; }

        public TenantAddress(TenantId tenantId, PostalAddress postalAddress)
        {
            Id = GuidUtil.NewSequentialId();
            this.TenantId = tenantId;
            this.PostalAddress = postalAddress;
        }
    }
}
