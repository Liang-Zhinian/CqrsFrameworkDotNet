using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.Locations
{
    public class LocationCreatedEvent : LocationEvent, IEvent
    {
        protected LocationCreatedEvent()
        {

        }

        public LocationCreatedEvent(
            Guid id,
            Guid tenantId,
            Guid siteId,
            string name,
            string description,
            byte[] image,
            string primaryTelephone,
            string secondaryTelephone)
            : base(
                id,
                tenantId,
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
            Guid tenantId,
            Guid siteId,
            string streetAddress,
            string streetAddress2,
            string city,
            string stateProvince,
            string postalCode,
            string countryCode)
            :base(
                id,
                tenantId,
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
