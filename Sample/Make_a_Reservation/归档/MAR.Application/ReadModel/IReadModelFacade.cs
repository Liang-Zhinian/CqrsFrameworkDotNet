using MAR.Application.ReadModel.Models;
using System;
using System.Collections.Generic;

namespace MAR.Application.ReadModel
{
    public interface IReadModelFacade
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}
