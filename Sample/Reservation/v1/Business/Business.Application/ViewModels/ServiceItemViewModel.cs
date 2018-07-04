using System;
using System.Collections.Generic;

namespace Business.Application.ViewModels
{
    public class ServiceItemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DefaultTimeLength { get; set; }
        public double Price { get; set; }
        public int IndustryStandardCategoryId { get; set; }
        public Guid ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }

        public Guid SiteId { get; set; }
    }
}
