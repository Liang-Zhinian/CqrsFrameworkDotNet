using System;
namespace Business.Domain.Models.Service.Class
{
    public class ClassService : ServiceLayout<ClassServiceCategory>
    {
        public ClassService(string name, string description) : base(name, description)
        {
        }
    }
}
