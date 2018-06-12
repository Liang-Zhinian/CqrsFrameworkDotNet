using System;
using System.Collections.Generic;

namespace Business.Infra.Data.ReadModel
{
    public class Resource: BaseObject<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocatedAtAllLocations { get; set; }

        public int StatusId { get; set; }
        public virtual ResourceStatus Status { get; set; }

        public string ResourceTypeId { get; set; }
        public virtual ResourceType ResourceType { get; set; }

        public string ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }

        public virtual ICollection<ResourceLocation> ResourceLocations { get; set; }
    }
}
