using System;
using System.Collections.Generic;

namespace Business.Infra.Data.ReadModel.Service.Class
{
    public class ClassServiceCategory : ServiceCategory<ClassService>
    {

        public ClassServiceCategory(string name, string description) : base(name, description)
        {
        }
    }
}
