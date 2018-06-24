using System;
using Microsoft.AspNetCore.Mvc;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Business.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Domain.Repositories;

namespace Business.WebApi.Controllers
{
    //[Authorize]
    [Route("api/locations")]
    public class LocationController: Controller
    {
        private readonly IBusinessInformationService _businessInformationService;
        //private readonly ITenantRepository _tenantRepository;

        public LocationController(IBusinessInformationService businessInformationService)
        {
            //_tenantRepository = tenantRepository;
            _businessInformationService = businessInformationService;
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public JsonResult Get()
        //{
        //    var list = _locationService.()
        //                            .ToList();
        //    return Json(list);
        //}

        [HttpGet]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("test")]
        public ActionResult Test()
        {
            return Ok("Success!");
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteTenantData")]
        //[Route("register")]
        public ActionResult Post([FromBody]
                                   LocationViewModel request
                                  )
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(request);
            }

            var location = _businessInformationService.ProvisionLocation(request);

            return Ok(location);
        }
    }
}
