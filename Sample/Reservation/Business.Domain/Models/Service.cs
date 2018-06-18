using System;
using System.Collections.Generic;
using Infrastructure.Utils;

namespace Business.Domain.Models
{
    public class Service: BaseObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

        public virtual ServiceCategory Category { get; set; }


        public Service(Guid tenantId, Guid categoryId, string name, string description):base(tenantId)
        {
            Id = GuidUtil.NewSequentialId(); 
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }
    }
}
