using System;
using System.Collections.Generic;
using MAR.Application.ReadModel.Dtos;

namespace MAR.Application.ReadModel
{
    public static class InMemoryDatabase
    {
        public static readonly List<EmployeeDto> Employees = new List<EmployeeDto>();
    }
}
