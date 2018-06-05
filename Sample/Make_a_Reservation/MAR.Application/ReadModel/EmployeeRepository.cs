using System;
namespace MAR.Application.ReadModel
{
    public class EmployeeRepository : ReadModelRepositoryBase<Employee>
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
