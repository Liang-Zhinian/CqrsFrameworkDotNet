using CqrsFramework.Commands;
using Microsoft.AspNetCore.Mvc;
using MAR.Api.Code;
using MAR.Application.ReadModel;
using MAR.Contracts.Commands;
//using MAR.Domain;
using System;
using System.Collections.Generic;
using MAR.Contracts.Commands.Employees;
using MAR.Api.Requests.Employees;
using MAR.Application.ReadModel.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MAR.Api.Controllers
{
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private readonly ICommandSender _commandSender;
        private readonly IReadModelFacade _readmodel;

        public EmployeesController(ICommandSender commandSender, IReadModelFacade readmodel)
        {
            _readmodel = readmodel;
            _commandSender = commandSender;
        }

        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {

            //JsonSerializerSettings settings = new JsonSerializerSettings();
            ////EF Core中默认为驼峰样式序列化处理key
            ////settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            ////使用默认方式，不更改元数据的key的大小写
            //settings.ContractResolver = new DefaultContractResolver();


            //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented,
            //    ContractResolver = new DefaultContractResolver()
            //};

            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(_readmodel.GetAllEmployees()));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(CreateEmployeeRequest request)
        {
            Guid id = Guid.NewGuid();

            var command = new CreateEmployeeCommand(id, request.FirstName, request.LastName, request.DateOfBirth, request.JobTitle);
            //Configuration.Instance().Bus.Send<ICommand>(command);

            _commandSender.Send(command);
            return Ok();
        }
    }
}
