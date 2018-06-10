using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using CqrsFramework.Commands;
using Registration.Domain.Repositories.Interfaces;
using Business.Domain.Commands.Security.Staffs;
using Business.Api.Requests.Staffs;

namespace Business.Api.Controllers
{
    [Route("api/staffs")]
    public class StaffController: Controller
    {
        private readonly ICommandSender _commandSender;
        private readonly IStaffRepository _readmodel;

        public StaffController(ICommandSender commandSender, IStaffRepository readmodel)
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

            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(_readmodel.GetAll()));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(CreateStaffRequest request)
        {
            Guid id = Guid.NewGuid();

            //var command = new CreateStaffCommand(id, request.FirstName, request.LastName);
            //Configuration.Instance().Bus.Send<ICommand>(command);

            //_commandSender.Send(command);
            return Ok();
        }
    }
}
