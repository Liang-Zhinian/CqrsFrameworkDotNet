using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Registration.Domain.Repositories.Interfaces;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Business.Application.Interfaces;

namespace Business.WebApi.Controllers
{
    //[Authorize]
    [Route("api/tenants")]
    public class TenantController: Controller
    {
        private readonly ITenantAppService _tenantAppService;
        //private readonly IReadModelFacade _readmodel;
        //private readonly ICommandSender _commandSender;
        //private readonly IStaffRepository _readmodel;

        public TenantController(
                                ITenantAppService tenantAppService
                                /*ICommandSender commandSender, IStaffRepository readmodel
                                IReadModelFacade readmodel*/)
        {
            //_readmodel = readmodel;
            //_commandSender = commandSender;
            _tenantAppService = tenantAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        //[Route("tenants")]
        public JsonResult Get()
        {
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(_tenantAppService.GetAll()));
        }

        [HttpGet]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("test")]
        public ActionResult Test()
        {
            return Ok("Success!");
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("register")]
        public ActionResult Create([FromBody]
                                   /*CreateTenantRequest request*/
            TenantViewModel request
                                  )
        {

            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(request);
            }

            TenantViewModel viewModel = new TenantViewModel(
                Guid.NewGuid(),
                request.Name,
                request.DisplayName,
                request.Email,
                request.Email2,
                request.Phone,
                request.Phone2,
                request.Phone3,
                request.State,
                request.City,
                request.Street,
                request.Street2,
                request.ForeignZip,
                request.Country,
                request.PostalCode
            );

            _tenantAppService.Register(viewModel);

            return Ok(request);
        }
    }
}
