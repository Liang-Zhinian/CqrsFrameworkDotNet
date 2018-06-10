using System;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Events.Security.Businesses
{
    public class TenantCreatedEvent : BaseEvent
    {
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public Contact TenantContact { get; private set; }
        public Address TenantAddress { get; private set; }

        public TenantCreatedEvent(Guid id, string name, string displayName, Contact contact, Address address)
        {
            Id = id;
            Name = name;
            DisplayName = displayName;
            TenantContact = contact;
            TenantAddress = address;
        }
    }
}
