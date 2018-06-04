using System;
using System.Collections.Generic;
using MAR.Application.ReadModel.Dtos;

namespace MAR.Application.ReadModel
{
    public class ReadModelFacade : IReadModelFacade
    {
        public ReadModelFacade()
        {

        }
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            return InMemoryDatabase.Employees;
        }
    }
}
