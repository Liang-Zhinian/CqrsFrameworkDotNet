using System;
using MAR.Domain.Models.ValueObjects;

namespace MAR.Domain.Events.Security.Businesses
{
    public class BussnessCreatedEvent : BaseEvent
    {
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public Contact BusinessContact { get; private set; }
        public Address BusinessAddress { get; private set; }

        public BussnessCreatedEvent(Guid id, string name, string displayName, Contact contact, Address address)
        {
            Id = id;
            Name = name;
            DisplayName = displayName;
            BusinessContact = contact;
            BusinessAddress = address;
        }
    }
}
