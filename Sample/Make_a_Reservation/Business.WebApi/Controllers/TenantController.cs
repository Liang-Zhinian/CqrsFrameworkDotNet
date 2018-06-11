using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Registration.Domain.Repositories.Interfaces;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Business.Application.Interfaces;
using Business.WebApi.Requests.Tenants;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Business.WebApi.Controllers
{
    //[Authorize]
    [Route("api/tenants")]
    public class TenantController: Controller
    {
        private readonly ITenantAppService _tenantAppService;
        private readonly ITenantRepository _tenantRepository;

        public TenantController(ITenantAppService tenantAppService, ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
            _tenantAppService = tenantAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            var list = _tenantRepository.GetAll()
                                    .Include(t => t.Address)
                                        .Include(t => t.Contact)
                                    .ToList();
            return Json(list);
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
                                   CreateTenantRequest request
                                   /*TenantViewModel request*/
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
