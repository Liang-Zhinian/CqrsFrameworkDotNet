using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Infra.Data.ReadModel.Security
{
    public class Tenant
    {
        [Key]
        public string Id { get; set; }
        public const string DEFAULT_NAME = "default";
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public virtual TenantContact Contact { get; set; }
        public virtual TenantAddress Address { get; set; }
        public virtual Branding Branding { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
