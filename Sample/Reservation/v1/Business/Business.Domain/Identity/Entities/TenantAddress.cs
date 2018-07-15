using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Contracts;
using Business.Domain.ValueObjects;
using CqrsFramework.Domain;

namespace Business.Domain.Identity.Entities
{
    public class TenantAddress
    {

        public Guid Id { get; private set; }

        public PostalAddress PostalAddress { get; private set; }

        public TenantId TenantId { get; private set; }

        public TenantAddress(TenantId tenantId, PostalAddress postalAddress)
        {
            Id = Guid.NewGuid();
            this.TenantId = tenantId;
            this.PostalAddress = postalAddress;
        }

        public void ModifyAddress(TenantId tenantId, string streetAddress, string streetAddress2, string city, string stateProvince, string postalCode, string countryCode)
        {
            throw new NotImplementedException();
        }
    }
}
