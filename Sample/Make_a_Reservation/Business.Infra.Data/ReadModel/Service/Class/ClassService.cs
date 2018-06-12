using System;
namespace Business.Infra.Data.ReadModel.Service.Class
{
    public class ClassService : ServiceLayout<ClassServiceCategory>
    {
        public ClassService(string name, string description) : base(name, description)
        {
        }
    }
}
