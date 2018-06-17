using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using Business.Domain.Events.Security.Tenants;
using Infrastructure.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Domain.Models.Security
{
    [NotMapped]
    public class Tenant : AggregateRoot
    {
        //public TenantContact Contact { get; set; }
        //public TenantAddress Address { get; set; }
        //public Branding Branding { get; set; }

        //public virtual ICollection<Location> Locations { get; set; }
        //public virtual ICollection<Staff> Staffs { get; set; }

    }
}
