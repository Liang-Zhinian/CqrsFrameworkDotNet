using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Models.Security
{
    public class LocationAddress : BaseObject
    {

        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string ForeignZip { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }

        public LocationAddress()
        {

        }

        public LocationAddress(Guid locationId, Guid tenantId): base(tenantId)
        {
            LocationId = locationId;
        }

        public LocationAddress(Guid locationId,
                               Guid tenantId,
                             string country,
                             string state,
                             string city,
                             string street,
                             string street2,
                             string postalCode,
                               string foreignZip) : this(locationId, tenantId)
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
