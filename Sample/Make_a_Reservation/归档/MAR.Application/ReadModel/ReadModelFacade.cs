using System;
using System.Collections.Generic;
using MAR.Application.ReadModel.Models;

namespace MAR.Application.ReadModel
{
    public class ReadModelFacade : IReadModelFacade
    {
        public ReadModelFacade()
        {

        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return InMemoryDatabase.Employees;
        }
    }
}
