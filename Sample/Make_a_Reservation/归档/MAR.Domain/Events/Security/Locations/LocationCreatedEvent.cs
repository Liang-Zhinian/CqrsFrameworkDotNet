using System;
using MAR.Domain.Models.ValueObjects;

namespace MAR.Domain.Events.Security.Locations
{
    public class LocationCreatedEvent : BaseEvent
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Contact ContactInfomation { get; private set; }
        public Address AddressInfomation { get; private set; }
        public Geolocation Geolocation { get; private set; }

        public LocationCreatedEvent(Guid id, string name, string description, Contact contact, Address address, Geolocation geolocation)
        {
            Id = id;
            Name = name;
            Description = description;
            ContactInfomation = contact;
            AddressInfomation = address;
            Geolocation = geolocation;
        }
    }
}
