using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.Locations
{
    public class LocationCreatedEvent : LocationEvent, IEvent
    {
        public LocationCreatedEvent(
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
            :base(
                id,
                tenantId,
                businessId,
                businessDescription,
                name,
                description,
                image,
                primaryTelephone,
                secondaryTelephone,
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
