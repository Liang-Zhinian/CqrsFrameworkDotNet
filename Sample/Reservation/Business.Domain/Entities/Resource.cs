using System;
using System.Collections.Generic;

namespace Business.Domain.Entities
{
    public class Resource
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocatedAtAllLocations { get; set; }

        public TenantId TenantId { get; private set; }

        public int StatusId { get; set; }
        public virtual ResourceStatus Status { get; set; }

        public Guid ResourceTypeId { get; set; }
        public virtual ResourceType ResourceType { get; set; }

        public Guid ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }

        public virtual ICollection<ResourceLocation> ResourceLocations { get; set; }
    }
}
