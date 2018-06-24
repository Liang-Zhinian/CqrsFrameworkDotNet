using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration.Application.Interfaces;
using Reservation.ClientWebApi.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
 * Site Services:
    GetLocations
    GetPrograms
    GetResourceSchedule
    GetResources
    GetSites
    ReserveResource
*/
namespace Reservation.ClientWebApi.Controllers
{
    [Route("api/[controller]")]
    public class SiteController : Controller
    {
        private readonly ILocationService _locationService;

        public SiteController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Gets the locations.
        /// </summary>
        /// <returns>The locations.</returns>
        /// <param name="request">Request.</param>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetLocations")]
        public JsonResult GetLocations(GetLocationsRequest request)
        {
            var list = _locationService.FindLocations()
                                    .ToList();
            return Json(list);
        }

        /// <summary>
        /// Gets the sites.
        /// </summary>
        /// <returns>The sites.</returns>
        /// <param name="request">Request.</param>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetSites")]
        public JsonResult GetSites(GetSitesRequest request)
        {
            var list = _locationService.FindLocations()
                                    .ToList();
            return Json(list);
        }

        /// <summary>
        /// Gets the programs.
        /// </summary>
        /// <returns>The programs.</returns>
        /// <param name="request">Request.</param>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetPrograms")]
        public JsonResult GetPrograms(GetProgramsRequest request)
        {
            var list = _locationService.FindLocations()
                                    .ToList();
            return Json(list);
        }

    }
}
