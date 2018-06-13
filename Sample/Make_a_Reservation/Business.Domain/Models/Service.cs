using System;
using System.Collections.Generic;

namespace Business.Domain.Models
{
    public class Service: BaseObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

        public virtual ServiceCategory Category { get; set; }


        public Service(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
