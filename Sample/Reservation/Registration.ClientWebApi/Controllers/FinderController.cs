using System.Linq;
using Registration.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Registration.ClientWebApi.Controllers
{
    //[Authorize]
    [Route("api/locations")]
    public class FinderController: Controller
    {
        private readonly ILocationService _locationService;

        public FinderController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Gets the business locations within radius.
        /// </summary>
        /// <returns>The business locations within radius.</returns>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longitude">Longitude.</param>
        /// <param name="radius">Radius.</param>
        /// <param name="locationId">Location identifier.</param>
        /// <param name="searchText">Search text.</param>
        /// <param name="sortOption">Sort option.</param>
        [HttpGet]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("GetBusinessLocationsWithinRadius")]
        public ActionResult GetBusinessLocationsWithinRadius(double latitude, 
                                                             double longitude, 
                                                             double radius, 
                                                             Guid locationId,
                                                            string searchText,
                                                            string sortOption){
            return Ok();
        }

        /// <summary>
        /// Gets the classes within radius.
        /// </summary>
        /// <returns>The classes within radius.</returns>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longitude">Longitude.</param>
        /// <param name="radius">Radius.</param>
        /// <param name="startDateTime">Start date time.</param>
        /// <param name="endDateTime">End date time.</param>
        /// <param name="locationId">Location identifier.</param>
        /// <param name="classId">Class identifier.</param>
        /// <param name="searchText">Search text.</param>
        /// <param name="sortOption">Sort option.</param>
        [HttpGet]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("GetClassesWithinRadius")]
        public ActionResult GetClassesWithinRadius(double latitude,
                                                             double longitude,
                                                             double radius,
                                                   DateTime startDateTime,
                                                   DateTime endDateTime,
                                                   Guid locationId,
                                                   Guid classId,
                                                            string searchText,
                                                            string sortOption)
        {
            return Ok();
        }

        /// <summary>
        /// Gets the finder user.
        /// </summary>
        /// <returns>The finder user.</returns>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        [HttpGet]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("GetFinderUser")]
        public ActionResult GetFinderUser(string email, string password)
        {
            return Ok();
        }
    }
}
