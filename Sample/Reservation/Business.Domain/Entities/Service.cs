using System;
using System.Collections.Generic;
using Infrastructure.Utils;

namespace Business.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

        public TenantId TenantId { get; private set; }

        public virtual ServiceCategory Category { get; set; }


        public Service(TenantId tenantId, Guid categoryId, string name, string description)
        {
            Id = GuidUtil.NewSequentialId();
            this.TenantId = tenantId;
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }
    }
}