using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration.Application.Interfaces;
using Registration.ClientWebApi.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
 * Site Services:
    FindLocations
    FindPrograms
    FindResourceSchedule
    FindResources
    FindSites
    ReserveResource
*/
namespace Registration.ClientWebApi.Controllers
{
    [Route("api/[controller]")]
    public class SiteController : Controller
    {
        private readonly ISiteService _siteService;
        private readonly ILocationService _locationService;

        public SiteController(ILocationService locationService,
                              ISiteService siteService
                             )
        {
            _locationService = locationService;
            _siteService = siteService;
        }

        /// <summary>
        /// Finds the locations.
        /// </summary>
        /// <returns>The locations.</returns>
        /// <param name="request">Request.</param>
        [HttpGet]
        [AllowAnonymous]
        [Route("FindLocations")]
        public JsonResult FindLocations(GetBusinessLocationsWithinRadiusRequest request)
        {
            var list = _locationService.FindLocations()
                                    .ToList();
            return Json(list);
        }

        /// <summary>
        /// Finds the sites.
        /// </summary>
        /// <returns>The sites.</returns>
        /// <param name="request">Request.</param>
        [HttpGet]
        [AllowAnonymous]
        [Route("FindSites")]
        public JsonResult FindSites(GetSitesRequest request)
        {
            var list = _siteService.FindSites()
                                    .ToList();
            return Json(list);
        }

        /// <summary>
        /// Finds the programs.
        /// </summary>
        /// <returns>The programs.</returns>
        /// <param name="request">Request.</param>
        [HttpGet]
        [AllowAnonymous]
        [Route("FindPrograms")]
        public JsonResult FindPrograms(GetProgramsRequest request)
        {
            var list = _locationService.FindLocations()
                                    .ToList();
            return Json(list);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("FindServiceItems")]
        public JsonResult FindServiceItems(GetServiceItemsRequest request)
        {
            var list = _locationService.FindLocations()
                                    .ToList();
            return Json(list);
        }
    }
}
