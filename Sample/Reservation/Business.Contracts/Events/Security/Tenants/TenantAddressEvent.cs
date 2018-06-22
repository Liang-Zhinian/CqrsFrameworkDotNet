using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.Security.Tenants
{
    public class TenantAddressEvent
    {
        public TenantAddressEvent(Guid id,
            Guid tenantId,
                                string streetAddress,
                             string streetAddress2,
                             string city,
                             string stateProvince,
                             string postalCode,
                             string countryCode)
        {
            this.Id = id;
            this.TenantId = tenantId;
            this.StreetAddress = streetAddress;
            this.StreetAddress2 = streetAddress2;
            this.City = city;
            this.StateProvince = stateProvince;
            this.PostalCode = postalCode;
            this.CountryCode = countryCode;
        }

        public Guid TenantId { get; private set; }

        public string City { get; private set; }

        public string CountryCode { get; private set; }

        public string PostalCode { get; private set; }

        public string StateProvince { get; private set; }

        public string StreetAddress { get; private set; }

        public string StreetAddress2 { get; private set; }

        public Guid Id { get; set; }
    }
}
