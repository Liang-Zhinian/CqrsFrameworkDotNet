using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using Business.Domain.Events.Security.Tenants;
using Infrastructure.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Domain.Models.Security
{
    public class Tenant : AggregateRoot
    {
        public enum TenantStatus
        {
            Created,
            Published
        }

        public const string DEFAULT_NAME = "default";
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int StatusValue { get; set; }
        [NotMapped]
        public TenantStatus Status { get; set; }
        public TenantContact Contact { get; set; }
        public TenantAddress Address { get; set; }
        public Branding Branding { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }

        public Tenant()
        {
            Id = GuidUtil.NewSequentialId();
            Contact = new TenantContact(Id);
            Address = new TenantAddress(Id);
            Branding = new Branding(Id);
            StatusValue = (int)TenantStatus.Created;
        }
    }
}
