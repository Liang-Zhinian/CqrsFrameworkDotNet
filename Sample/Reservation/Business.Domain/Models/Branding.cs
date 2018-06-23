using System;
using System.Collections.Generic;

namespace Business.Domain.Models
{
    public class Branding
    {
        private Branding()
        {
        }

        /// A site Id unique to a business
        public Guid Id { get; private set; }
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

        public TenantId TenantId { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }
    }
}
