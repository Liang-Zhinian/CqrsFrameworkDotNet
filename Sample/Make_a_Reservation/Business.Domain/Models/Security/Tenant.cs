using System;
using CqrsFramework.Domain;
using Business.Domain.Events.Security.Businesses;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Models.Security
{
    public class Tenant : AggregateRoot
    {
        public const string DEFAULT_NAME = "default";
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public Contact TenantContact { get; private set; }
        public Address TenantAddress { get; private set; }

        public Tenant()
        {

        }

        public Tenant(Guid id, string name, string displayName, Contact contact, Address address)
        {
            ApplyChange(new TenantCreatedEvent(id, name, displayName, contact, address));
        }

        public void Apply(TenantCreatedEvent message)
        {
            Id = message.Id;
            Name = message.Name;
            DisplayName = message.DisplayName;
            TenantContact = message.TenantContact;
            TenantAddress = message.TenantAddress;
        }

    }
}
