using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Domain.Models.Security
{
    public class LocationAddress : BaseObject
    {
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
