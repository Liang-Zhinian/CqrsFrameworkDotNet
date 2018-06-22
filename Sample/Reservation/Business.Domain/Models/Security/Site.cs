using System;
using System.Collections.Generic;

namespace Business.Domain.Models.Security
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
        /// The image data to the site logo
        public string Logo { get; private set; }
        /// Page color
        public string PageColor1 { get; private set; }
        /// Page color
        public string PageColor2 { get; private set; }
        /// Page color
        public string PageColor3 { get; private set; }
        /// Page color
        public string PageColor4 { get; private set; }
        /// Studio contact email address
        public string ContactEmail { get; private set; }

        public TenantId TenantId { get; private set; }

        public virtual ICollection<Location> Locations { get; private set; }
        public virtual ICollection<Staff> Staffs { get; private set; }
    }
}
