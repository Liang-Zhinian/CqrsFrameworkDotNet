using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.Security.Tenants
{
    public class TenantAddressCreatedEvent : TenantAddressEvent, IEvent
    {
        public TenantAddressCreatedEvent(Guid id,
                                         Guid tenantId,
                                         string streetAddress,
                             string streetAddress2,
                             string city,
                             string stateProvince,
                             string postalCode,
                                         string countryCode)
            : base(id,
                   tenantId,
                                              streetAddress,
                             streetAddress2,
                             city,
                             stateProvince,
                             postalCode,
                                         countryCode
                                            )
        {
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
        }

        public int Version { get; set; }

        public DateTimeOffset TimeStamp { get; set; }
    }
}
