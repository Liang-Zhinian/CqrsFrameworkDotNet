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
    }
}
