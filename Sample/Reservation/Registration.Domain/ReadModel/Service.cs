using System;
using System.Collections.Generic;
using Infrastructure.Utils;

namespace Registration.Domain.ReadModel
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid TenantId { get; set; }

        public virtual ServiceCategory Category { get; set; }


        public Service(Guid tenantId, Guid categoryId, string name, string description)
        {
            Id = GuidUtil.NewSequentialId(); 
            Name = name;
            Description = description;
            CategoryId = categoryId;
            TenantId = tenantId;
        }
    }
}
