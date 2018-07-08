using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.Locations
{
    public class LocationAddressChangedEvent : BaseEvent, IEvent
    {
        public string City { get; set; }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }

        public string StateProvince { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public Guid SiteId { get; set; }

        protected LocationAddressChangedEvent()
        {

        }

        public LocationAddressChangedEvent(
            Guid id,
            Guid siteId,
            string streetAddress,
            string streetAddress2,
            string city,
            string stateProvince,
            string postalCode,
            string countryCode)
        {
            Version = 1;
            TimeStamp = DateTimeOffset.Now;

            this.Id = id;
            this.SiteId = siteId;
            this.StreetAddress = streetAddress;
            this.StreetAddress2 = streetAddress2;
            this.City = city;
            this.StateProvince = stateProvince;
            this.PostalCode = postalCode;
            this.CountryCode = countryCode;
        }
    }
}
