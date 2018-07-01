using System;
using CqrsFramework.Events;

namespace SaaSEqt.eShop.Site.Api.Events.Locations
{
    public class LocationCreatedEvent : LocationEvent, IEvent
    {
        protected LocationCreatedEvent()
        {

        }

        public LocationCreatedEvent(
            Guid id,
            Guid siteId,
            string name,
            string description,
            byte[] image,
            string primaryTelephone,
            string secondaryTelephone)
            : base(
                id,
                siteId,
                name,
                description,
                image,
                primaryTelephone,
                secondaryTelephone)
        {
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
        }

        public LocationCreatedEvent(
            Guid id,
            Guid siteId,
            string streetAddress,
            string streetAddress2,
            string city,
            string stateProvince,
            string postalCode,
            string countryCode)
            :base(
                id,
                siteId,
                streetAddress,
                streetAddress2,
                city,
                stateProvince,
                postalCode,
                countryCode)
        {
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
        }
    }
}
