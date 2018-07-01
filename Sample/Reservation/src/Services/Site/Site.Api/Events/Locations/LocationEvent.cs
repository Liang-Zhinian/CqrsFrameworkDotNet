using System;
namespace SaaSEqt.eShop.Site.Api.Events.Locations
{
    public class LocationEvent
    {
        protected LocationEvent()
        {

        }

        public LocationEvent(
            Guid id,
            Guid siteId,
            string streetAddress,
            string streetAddress2,
            string city,
            string stateProvince,
            string postalCode,
            string countryCode)
        {
            this.Id = id;
            this.SiteId = siteId;
            this.StreetAddress = streetAddress;
            this.StreetAddress2 = streetAddress2;
            this.City = city;
            this.StateProvince = stateProvince;
            this.PostalCode = postalCode;
            this.CountryCode = countryCode;
        }


        public LocationEvent(
            Guid id,
            Guid siteId,
            string name,
            string description,
            byte[] image,
            string primaryTelephone,
            string secondaryTelephone)
        {
            this.Id = id;
            this.SiteId = siteId;
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.PrimaryTelephone = primaryTelephone;
            this.SecondaryTelephone = secondaryTelephone;
        }

        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }


        public Guid Id { get; set; }

        //public Guid BusinessID { get; protected set; }

        //public string BusinessDescription { get; protected set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }

        public string StateProvince { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public Guid SiteId { get; set; }
    }
}
