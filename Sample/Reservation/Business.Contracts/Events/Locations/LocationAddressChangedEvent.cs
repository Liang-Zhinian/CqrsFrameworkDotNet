using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.Locations
{
    public class LocationAddressChangedEvent : LocationEvent, IEvent
    {
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
