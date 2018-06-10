using System;
using CqrsFramework.Domain;
using MAR.Domain.Events.Security.Businesses;
using MAR.Domain.Models.ValueObjects;

namespace MAR.Domain.Models.Security
{
    public class Business : AggregateRoot
    {
        public const string DEFAULT_NAME = "default";
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public Contact BusinessContact { get; private set; }
        public Address BusinessAddress { get; private set; }

        public Business()
        {

        }

        public Business(Guid id, string name, string displayName, Contact contact, Address address)
        {
            ApplyChange(new BussnessCreatedEvent(id, name, displayName, contact, address));
        }

        public void Apply(BussnessCreatedEvent message)
        {
            Id = message.Id;
            Name = message.Name;
            DisplayName = message.DisplayName;
            BusinessContact = message.BusinessContact;
            BusinessAddress = message.BusinessAddress;
        }

    }
}
