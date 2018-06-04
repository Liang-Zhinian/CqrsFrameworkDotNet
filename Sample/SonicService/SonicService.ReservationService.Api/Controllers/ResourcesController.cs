using CqrsFramework.Commands;
using Microsoft.AspNetCore.Mvc;
using SonicService.ReservationService.ReadModel;
using SonicService.ReservationService.ReadModel.Dtos;
using SonicService.ReservationService.WriteModel.Commands;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SonicService.ReservationService.Api.Controllers
{
    [Route("api/[controller]")]
    public class ResourcesController : Controller
    {
        private readonly ICommandSender _commandSender;
        private readonly IReadModelFacade _readmodel;

        public ResourcesController(ICommandSender commandSender, IReadModelFacade readmodel)
        {
            _readmodel = readmodel;
            _commandSender = commandSender;
        }

        // GET api/resources
        [HttpGet]
        public IEnumerable<ResourceDto> Get()
        {
            return _readmodel.GetAllResources();
        }

        // POST api/resources
        [HttpPost]
        public void Post([FromBody]string name, Guid resourceTypeId)
        {
            var command = new CreateResourceCommand(Guid.NewGuid(), name, resourceTypeId);
            _commandSender.Send(command);
        }

        // POST api/resources
        [HttpPut]
        public void Put(Guid id, string name)
        {
            var command = new RenameResourceCommand(id, name);
            _commandSender.Send(command);
        }
    }
}
