using System.Linq;
using Business.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Reservation.ClientWebApi.Controllers
{
    //[Authorize]
    [Route("api/locations")]
    public class LocationController: Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            var list = _locationService.FindLocations()
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
    }
}
