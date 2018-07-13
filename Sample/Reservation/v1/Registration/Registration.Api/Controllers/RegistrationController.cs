using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Registration.Contracts.Commands.Appointments;
using CqrsFramework.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using Registration.Contracts.Commands;

namespace Registration.Api.Controllers
{
    [Route("api/registration")]
    public class RegistrationController: Controller
    {
        //private readonly ICommandSender _commandSender;
        private readonly IMediator _mediator;
        private readonly ILoggerFactory _logger;

        public RegistrationController(IMediator mediator,
            ILoggerFactory logger/*, ICommandSender commandSender*/)
        {
            //_commandSender = commandSender;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("StartAppointment")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> StartAppointment([FromBody]
                                                          MakeAnAppointmentCommand command
                                  )
        {
            if (!ModelState.IsValid)
            {
                return (IActionResult)BadRequest();
            }

            var result = false;

            //await _commandSender.Send<MakeAnAppointmentCommand>(command);

            result = await _mediator.Send(command);


            _logger.CreateLogger(nameof(RegistrationController))
                   .LogTrace(result ? $"MakeAnAppointmentCommand has been received and a create new appointment process is started with requestId: {command.ClientId}" :
                             $"MakeAnAppointmentCommand has been received but a new appointment process has failed with requestId: {command.ClientId}");

            return Accepted();
        }
    }
}
