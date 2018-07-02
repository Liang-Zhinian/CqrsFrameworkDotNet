using System;
using Microsoft.AspNetCore.Mvc;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Business.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Domain.Repositories;
using Business.WebApi.Requests.Locations;
using System.IO;

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

        [HttpGet]
        [AllowAnonymous]
        [Route("GenerateTestData")]
        public ActionResult GenerateTestData() {

            var site = _businessInformationService.FindSites().Where(_=>_.Name=="Chanel");

            var location = new LocationViewModel { 
                Name = "IFC",
                Description = "Chanel IFC",
            };
            _businessInformationService.ProvisionLocation(location);
            _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "IFC", "",
                                                           "Hongkong", "Hongkong", "", "China");
            _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.28588, 114.158131);


            /////////////////////////
            /// 
            location = new LocationViewModel
            {
                Name = "HM3",
                Description = "Chanel Prince's Building",
            };
            _businessInformationService.ProvisionLocation(location);
            _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "Prince's Building", "",
                                                           "Hongkong", "Hongkong", "", "China");
            _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.2812257, 114.159262799999);
            
            /////////////////////////
            /// 
            location = new LocationViewModel
            {
                Name = "HHP",
                Description = "Chanel Hysan Place",
            };
            _businessInformationService.ProvisionLocation(location);
            _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "Hysan Place", "",
                                                           "Hongkong", "Hongkong", "", "China");
            _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.2798079, 114.1837883);
            
            /////////////////////////
            ///
            location = new LocationViewModel
            {
                Name = "HEM",
                Description = "Chanel Elements",
            };
            _businessInformationService.ProvisionLocation(location);
            _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "Elements", "",
                                                           "Hongkong", "Hongkong", "", "China");
            _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.3048708, 114.1615219);
            
            /////////////////////////
            ///
            location = new LocationViewModel
            {
                Name = "HFW",
                Description = "Chanel Festival Walk",
            };
            _businessInformationService.ProvisionLocation(location);
            _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "Festival Walk", "",
                                                           "Hongkong", "Hongkong", "", "China");
            _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.3372971, 114.1745273);
            
            /////////////////////////
            ///
            location = new LocationViewModel
            {
                Name = "HTP",
                Description = "Chanel Telford Plaza",
            };
            _businessInformationService.ProvisionLocation(location);
            _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "Telford Plaza", "",
                                                           "Hongkong", "Hongkong", "", "China");
            _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.3210652, 114.2132768);
            
            /////////////////////////
            ///
            location = new LocationViewModel
            {
                Name = "HNT",
                Description = "Chanel New Town Plaza",
            };
            _businessInformationService.ProvisionLocation(location);
            _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "New Town Plaza", "",
                                                           "Hongkong", "Hongkong", "", "China");
            _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.3814592, 114.1889307);


            return Ok();
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
            Guid locationId = request.Id; 
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
        public ActionResult SetLocationImage(SetLocationImageRequest request)
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(false);
            }

            Guid siteId = request.SiteId;
            Guid locationId = request.Id;
            byte[] image;
            using (var memoryStream = new MemoryStream())
            {
                request.Image.CopyTo(memoryStream);
                image = memoryStream.ToArray();
            }

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
            Guid locationId = request.Id;
            double? latitude = request.Latitude;
            double? longitude = request.Longitude;

            _businessInformationService.SetLocationGeolocation(siteId, locationId, latitude, longitude);
            return Ok();
        }
    }
}
