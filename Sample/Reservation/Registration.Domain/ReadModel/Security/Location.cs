using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registration.Domain.ReadModel.Security
{
    public class Location
    {
        private Location()
        {

        }

        public Location(Guid id, string name, string description, Guid siteId)
        {
            Id = id;
            Name = name;
            Description = description;
            SiteId = siteId;
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }

        public string StateProvince { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }

        public byte[] Image { get; set; }

        public ICollection<LocationImage> AdditionalLocationImages { get; set; }

        public Guid SiteId { get; set; }
        public virtual Site Site { get; set; }

        public ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }
    }
}
