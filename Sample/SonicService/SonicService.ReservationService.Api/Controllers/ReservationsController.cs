using CqrsFramework.Commands;
using Microsoft.AspNetCore.Mvc;
using SonicService.ReservationService.Code;
using SonicService.ReservationService.ReadModel;
using SonicService.ReservationService.ReadModel.Dtos;
using SonicService.ReservationService.WriteModel.Commands;
using SonicService.ReservationService.WriteModel.Domain;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SonicService.ReservationService.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : Controller
    {
        private readonly ICommandSender _commandSender;
        private readonly IReadModelFacade _readmodel;

        public ReservationsController(ICommandSender commandSender, IReadModelFacade readmodel)
        {
            _readmodel = readmodel;
            _commandSender = commandSender;
        }

        public string Index(){return "Hello World!";}

        // GET: api/values
        [HttpGet]
        public IEnumerable<ReservationDto> Get()
        {
            return _readmodel.GetAllReservations();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Guid customerId, List<Guid> resources, TimeRange timeRange, Guid reservationTypeId)
        {
            Guid id = Guid.NewGuid();

            var command = new CreatReservationCommand(id, resources, customerId, timeRange, reservationTypeId);
            //Configuration.Instance().Bus.Send<ICommand>(command);

            _commandSender.Send(command);
        }
    }
}
