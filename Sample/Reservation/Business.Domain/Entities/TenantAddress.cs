using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CqrsFramework.Domain;
using Infrastructure.Utils;

namespace Business.Domain.Entities
{
    public class TenantAddress : AggregateRoot
    {
        public PostalAddress PostalAddress { get; private set; }

        public TenantId TenantId { get; private set; }

        public TenantAddress(TenantId tenantId, PostalAddress postalAddress)
        {
            Id = GuidUtil.NewSequentialId();
            this.TenantId = tenantId;
            this.PostalAddress = postalAddress;
        }

        public void ModifyAddress(TenantId tenantId, string streetAddress, string streetAddress2, string city, string stateProvince, string postalCode, string countryCode)
        {
            throw new NotImplementedException();
        }
    }
}
