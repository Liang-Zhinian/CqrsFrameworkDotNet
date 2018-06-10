using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registration.Domain.ReadModel.Security
{
    public class Tenant
    {
        [Key]
        public string Id { get; set; }
        public const string DEFAULT_NAME = "default";
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public TenantContact Contact { get; set; }
        public TenantAddress Address { get; set; }
        public Branding Branding { get; set; }

        public ICollection<Location> Locations { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
