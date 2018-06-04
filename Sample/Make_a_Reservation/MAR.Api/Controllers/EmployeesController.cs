using CqrsFramework.Commands;
using Microsoft.AspNetCore.Mvc;
using MAR.Api.Code;
using MAR.Application.ReadModel;
using MAR.Application.ReadModel.Dtos;
using MAR.Contracts.Commands;
using MAR.Domain;
using System;
using System.Collections.Generic;
using MAR.Contracts.Commands.Employees;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MAR.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly ICommandSender _commandSender;
        private readonly IReadModelFacade _readmodel;

        public EmployeesController(ICommandSender commandSender, IReadModelFacade readmodel)
        {
            _readmodel = readmodel;
            _commandSender = commandSender;
        }

        public string Index(){return "Hello World!";}

        // GET: api/values
        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
            return _readmodel.GetAllEmployees();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
        {
            Guid id = Guid.NewGuid();
            Guid employeeId = Guid.NewGuid();

            var command = new CreateEmployeeCommand(id,employeeId, firstName, lastName, dateOfBirth, jobTitle);
            //Configuration.Instance().Bus.Send<ICommand>(command);

            _commandSender.Send(command);
        }
    }
}
