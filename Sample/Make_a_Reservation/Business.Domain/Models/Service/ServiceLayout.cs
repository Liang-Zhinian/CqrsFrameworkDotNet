using System;
using System.Collections.Generic;

namespace Business.Domain.Models.Service
{
    public class ServiceLayout<TServiceCategory>: BaseObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual TServiceCategory Category { get; set; }


        public ServiceLayout(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
