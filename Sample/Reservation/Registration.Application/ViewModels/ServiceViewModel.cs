using System;
using System.Collections.Generic;

namespace Registration.Application.ViewModels
{
    public class ServiceViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public Guid TenantId { get; set; }
    }
}
