using System;
using Microsoft.AspNetCore.Mvc;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Business.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Domain.Repositories;
using Business.WebApi.Requests.Locations;

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

        [HttpPost]
        [Route("SetLocationAddress")]
        public ActionResult SetLocationAddress([FromBody]SetLocationAddressRequest request){
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(false);
            }

            Guid siteId = request.SiteId;
            Guid locationId = request.SiteId; 
            string streetAddress = request.StreetAddress; 
            string streetAddress2 = request.StreetAddress2; 
            string city = request.City; 
            string stateProvince = request.StateProvince; 
            string postalCode = request.PostalCode; 
            string countryCode = request.CountryCode; 

            _businessInformationService.SetLocationAddress(siteId, locationId,
                                                                          streetAddress, streetAddress2,
                                                                          city, stateProvince, postalCode, countryCode);
            return Ok();
        }

        [HttpPost]
        [Route("SetLocationImage")]
        public ActionResult SetLocationImage([FromForm]SetLocationImageRequest request)
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(false);
            }

            Guid siteId = request.SiteId;
            Guid locationId = request.SiteId;
            byte[] image = request.Image;

            _businessInformationService.SetLocationImage(siteId, locationId, image);
            return Ok();
        }

        [HttpPost]
        [Route("SetLocationGeolocation")]
        public ActionResult SetLocationGeolocation([FromBody]SetLocationGeolocationRequest request)
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(false);
            }

            Guid siteId = request.SiteId;
            Guid locationId = request.SiteId;
            double? latitude = request.Latitude;
            double? longitude = request.Longitude;

            _businessInformationService.SetLocationGeolocation(siteId, locationId, latitude, longitude);
            return Ok();
        }
    }
}
