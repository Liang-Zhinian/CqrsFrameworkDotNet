using System;
using System.Collections.Generic;
using CqrsFramework.Domain;
using Business.Domain.Events.Security.Locations;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Models.Security
{
    public class Location : AggregateRoot, IBook2Object
    {
        public Tenant Tenant { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Contact ContactInfomation { get; private set; }
        public Address AddressInfomation { get; private set; }
        public Geolocation Geolocation { get; private set; }

        public Location()
        {
        }

        public Location(Guid id, string name, string description, Contact contact, Address address, Geolocation geolocation)
        {
            ApplyChange(new LocationCreatedEvent(id, name, description, contact, address, geolocation));
        }

        // apply events
        public void Apply(LocationCreatedEvent message){

            Id = message.Id;
            Name = message.Name;
            Description = message.Description;
            ContactInfomation = message.ContactInfomation;
            AddressInfomation = message.AddressInfomation;
            Geolocation = message.Geolocation;
        }
    }
}
