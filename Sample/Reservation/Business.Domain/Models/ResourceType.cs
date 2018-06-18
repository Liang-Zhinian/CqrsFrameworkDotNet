using System;
using System.Collections.Generic;

namespace Business.Domain.Models
{
    public class ResourceType: BaseObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
