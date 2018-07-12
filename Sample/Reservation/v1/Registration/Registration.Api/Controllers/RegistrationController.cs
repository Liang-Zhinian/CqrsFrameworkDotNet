using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Registration.Contracts.Commands.Appointments;
using CqrsFramework.Commands;

namespace Registration.Api.Controllers
{
    [Route("api/registration")]
    public class RegistrationController: Controller
    {
        private readonly ICommandSender _commandSender;

        public RegistrationController(ICommandSender commandSender)
        {
            _commandSender = commandSender;
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

            await _commandSender.Send<MakeAnAppointmentCommand>(command);

            return Accepted();
        }
    }
}
