using System;
using System.Collections.Generic;

namespace Business.Domain.Models
{
    public class ResourceType
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid TenantId { get; private set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
