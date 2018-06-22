using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Contracts.Events.Security.Tenants;
using Business.Domain.Models.ValueObjects;
using CqrsFramework.Domain;
using Infrastructure.Utils;

namespace Business.Domain.Models.Security
{
    public class TenantAddress : AggregateRoot
    {
        public PostalAddress PostalAddress { get; private set; }

        public Guid TenantId { get; private set; }
        //public string TenantId_Id { get; private set; }

        private TenantAddress()
        {

        }

        public TenantAddress(Guid tenantId, 
                             string streetAddress,
                             string streetAddress2,
                             string city,
                             string stateProvince,
                             string postalCode,
                             string countryCode)
        {
            this.PostalAddress = new PostalAddress(
                streetAddress,
                streetAddress2,
                city,
                stateProvince,
                postalCode,
                countryCode
            );

            Id = GuidUtil.NewSequentialId();
            this.TenantId = tenantId;

            ApplyChange(new TenantAddressCreatedEvent(
                Id,
                tenantId,
                streetAddress,
                streetAddress2,
                city,
                stateProvince,
                postalCode,
                countryCode
            ));
        }

        public void ModifyAddress(string streetAddress,
                             string streetAddress2,
                             string city,
                             string stateProvince,
                             string postalCode,
                             string countryCode)
        {
            this.PostalAddress = new PostalAddress(
                streetAddress,
                streetAddress2,
                city,
                stateProvince,
                postalCode,
                countryCode
            );

            ApplyChange(new TenantAddressUpdatedEvent(
                Id,
                TenantId,
                streetAddress,
                streetAddress2,
                city,
                stateProvince,
                postalCode,
                countryCode
            ));
        }
    }
}
