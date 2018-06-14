using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;
using Infrastructure.Utils;

namespace Business.Domain.Models.Security
{
    public class TenantAddress : BaseObject
    {

        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string ForeignZip { get; set; }

        public TenantAddress()
        {

        }

        public TenantAddress(Guid tenantId) : base(tenantId)
        {
            Id = GuidUtil.NewSequentialId();
        }

        public TenantAddress(Guid tenantId,
                             string country,
                             string state,
                             string city,
                             string street,
                             string street2,
                             string postalCode,
                             string foreignZip) : this(tenantId)
        {
            Country = country;
            State = state;
            City = city;
            Street = street;
            Street2 = street2;
            PostalCode = postalCode;
            ForeignZip = foreignZip;
        }
    }
}
