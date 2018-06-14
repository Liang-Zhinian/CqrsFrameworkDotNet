using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Models.Security
{
    public class StaffAddress : BaseObject
    {

        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string ForeignZip { get; set; }

        public Guid StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public StaffAddress()
        {

        }

        public StaffAddress(Guid staffId, Guid tenantId) : base(tenantId)
        {
            StaffId = staffId;
        }

        public StaffAddress(Guid staffId,
                               Guid tenantId,
                             string country,
                             string state,
                             string city,
                             string street,
                             string street2,
                             string postalCode,
                            string foreignZip) : this(staffId, tenantId)
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
