using MAR.Application.ReadModel.Dtos;
using System;
using System.Collections.Generic;

namespace MAR.Application.ReadModel
{
    public interface IReadModelFacade
    {
        IEnumerable<EmployeeDto> GetAllEmployees();
    }
}
