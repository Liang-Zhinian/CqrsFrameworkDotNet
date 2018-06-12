using System;
using System.Collections.Generic;

namespace Business.Infra.Data.ReadModel.Service
{
    public class ServiceLayout<TServiceCategory>: BaseObject<string>
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
