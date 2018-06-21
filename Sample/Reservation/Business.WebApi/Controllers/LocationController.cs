using System;
using Microsoft.AspNetCore.Mvc;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Business.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Domain.Repositories.Interfaces;

namespace Business.WebApi.Controllers
{
    //[Authorize]
    [Route("api/locations")]
    public class LocationController: Controller
    {
        private readonly ILocationService _locationService;
        //private readonly ITenantRepository _tenantRepository;

        public LocationController(ILocationService locationService)
        {
            //_tenantRepository = tenantRepository;
            _locationService = locationService;
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

            _locationService.AddLocation(request);

            return Ok(request);
        }
    }
}
