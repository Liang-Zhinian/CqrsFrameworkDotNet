using System;
using MAR.Application.ReadModel.Models;

namespace MAR.Application.ReadModel
{
    public class EmployeeRepository : ReadModelRepositoryBase<Employee>
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
