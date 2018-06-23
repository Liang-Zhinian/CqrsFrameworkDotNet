using System;
using System.Collections.Generic;

namespace Business.Domain.Models
{
    public class Site
    {
        private Site()
        {
        }

        /// A site Id unique to a business
        public Guid Id { get; private set; }
        /// The name of the site
        public string Name { get; private set; }
        /// Site description
        public string Description { get; private set; }

        public Guid BrandingId { get; private set; }
        public Branding Branding { get; private set; }

        public ContactInformation ContactInformation { get; private set; }

        public TenantId TenantId { get; private set; }

        public virtual ICollection<Location> Locations { get; private set; }
        public virtual ICollection<Staff> Staffs { get; private set; }
    }
}
