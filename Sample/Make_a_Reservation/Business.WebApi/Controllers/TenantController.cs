using System;
using System.Linq;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using Business.Domain.Repositories.Interfaces;
using Business.WebApi.Requests.Tenants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var list = _tenantRepository.Find(_=>true)
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
                request.Street,
                request.Street2,
                request.City,
                request.State,
                request.Country,
                request.ForeignZip,
                request.PostalCode
            );

            _tenantAppService.Register(viewModel);

            return Ok(request);
        }
    }
}
