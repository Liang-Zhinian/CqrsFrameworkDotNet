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

        public Guid ServiceCategoryId { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }

        public Guid SiteId { get; set; }
        public virtual Site Site { get; set; }

        private ServiceItem()
        {

        }

        public ServiceItem(Guid siteId, Guid categoryId, string name, string description, int defaultTimeLength)
        {
            Id = Guid.NewGuid();
            SiteId = siteId;
            Name = name;
            Description = description;
            ServiceCategoryId = categoryId;
            DefaultTimeLength = defaultTimeLength;
        }
    }
}
