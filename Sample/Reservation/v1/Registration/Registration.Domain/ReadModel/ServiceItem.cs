using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;

namespace Registration.Domain.ReadModel
{
    public class ServiceItem
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DefaultTimeLength { get; set; }
        public double Price { get; set; }
        public bool AllowOnlineScheduling { get; set; } 
        public int IndustryStandardCategoryId { get; set; }
        public Guid ServiceCategoryId { get; set; }
        public Guid SiteId { get; set; }

        public virtual IndustryStandardCategory IndustryStandardCategory { get; private set; }

        public virtual ServiceCategory ServiceCategory { get; private set; }

        public virtual Site Site { get; private set; }

        private ServiceItem()
        {
            Id = Guid.NewGuid();
        }

        public ServiceItem(Guid siteId, string name, string description, int defaultTimeLength, double price, bool allowOnlineScheduling, Guid serviceCategoryId, int industryStandardCategoryId)
            : this()
        {
            SiteId = siteId;
            Name = name;
            Description = description;
            DefaultTimeLength = defaultTimeLength;
            ServiceCategoryId = serviceCategoryId;
            Price = price;
            AllowOnlineScheduling = allowOnlineScheduling;
            IndustryStandardCategoryId = industryStandardCategoryId;
        }
    }
}
