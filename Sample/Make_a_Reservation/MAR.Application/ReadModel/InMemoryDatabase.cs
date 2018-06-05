using System;
using System.Collections.Generic;
//using MAR.Application.ReadModel.Dtos;
using MAR.Application.ReadModel.Models;

namespace MAR.Application.ReadModel
{
    public static class InMemoryDatabase
    {
        public static readonly List<Employee> Employees = new List<Employee>();
    }
}
