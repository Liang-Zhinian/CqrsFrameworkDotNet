using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using Business.Domain.Events.Security.Tenants;

namespace Business.Domain.Models.Security
{
    public class Tenant : AggregateRoot
    {
        public const string DEFAULT_NAME = "default";
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsEnabled { get; set; }
        public virtual TenantContact Contact { get; set; }
        public virtual TenantAddress Address { get; set; }
        public virtual Branding Branding { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }

        public Tenant(Guid id, string name, string displayName)
        {
            ApplyChange(new TenantCreatedEvent(id, name, displayName));
        }

        public void Apply(TenantCreatedEvent message)
        {
            Id = message.Id;
            Name = message.Name;
            DisplayName = message.DisplayName;
        }
    }
}
