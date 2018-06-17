using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CqrsFramework.Domain;
using Infrastructure.Utils;

namespace SaaSEqt.BizInfo
{
    [NotMapped]
    public class Tenant : AggregateRoot
    {

        public Branding Branding { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<LocationImage> LocationImages { get; set; }

        protected Tenant()
        {
        }


    }
}
