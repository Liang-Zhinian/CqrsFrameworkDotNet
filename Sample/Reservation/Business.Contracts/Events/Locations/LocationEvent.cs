using System;
namespace Business.Contracts.Events.Locations
{
    public class LocationEvent: BaseEvent
    {
        public LocationEvent(
            Guid id,
            Guid tenantId,
            Guid businessId,
            string businessDescription,
            string name,
            string description,
            string image,
            string primaryTelephone,
            string secondaryTelephone,
            string streetAddress,
            string streetAddress2,
            string city,
            string stateProvince,
            string postalCode,
            string countryCode)
        {
            this.Id = id;
            this.TenantId = tenantId;
            this.BusinessID = businessId;
            this.BusinessDescription = businessDescription;
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.PrimaryTelephone = primaryTelephone;
            this.SecondaryTelephone = secondaryTelephone;
            this.StreetAddress = streetAddress;
            this.StreetAddress2 = streetAddress2;
            this.City = city;
            this.StateProvince = stateProvince;
            this.PostalCode = postalCode;
            this.CountryCode = countryCode;
        }

        //public Guid Id { get; protected set; }

        public Guid BusinessID { get; protected set; }

        public string BusinessDescription { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public string Image { get; protected set; }

        public string PrimaryTelephone { get; protected set; }

        public string SecondaryTelephone { get; protected set; }

        public string City { get; protected set; }

        public string CountryCode { get; protected set; }

        public string PostalCode { get; protected set; }

        public string StateProvince { get; protected set; }

        public string StreetAddress { get; protected set; }

        public string StreetAddress2 { get; protected set; }

        public Guid TenantId { get; protected set; }
    }
}
