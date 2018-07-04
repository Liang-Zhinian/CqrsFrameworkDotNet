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
using Microsoft.AspNetCore.Hosting;

namespace Business.WebApi.Controllers
{
    //[Authorize]
    [Route("api/locations")]
    public class LocationController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly IBusinessInformationService _businessInformationService;
        private readonly IBusinessInformationQueryService _businessInformationQueryService;
        //private readonly ITenantRepository _tenantRepository;

        public LocationController(
            IHostingEnvironment env,
            IBusinessInformationService businessInformationService,
            IBusinessInformationQueryService businessInformationQueryService)
        {
            this._env = env;
            _businessInformationService = businessInformationService;
            _businessInformationQueryService = businessInformationQueryService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GenerateTestData")]
        public async System.Threading.Tasks.Task<ActionResult> GenerateTestDataAsync()
        {
            var contentRootPath = this._env.ContentRootPath;
            string picFileLogo = Path.Combine(contentRootPath, "Pics", "Chanel logo.png");
            string picFileLocation = Path.Combine(contentRootPath, "Pics", "Location image.png");

            byte[] logo;
            using (var memoryStream = new MemoryStream())
            {
                (new StreamReader(picFileLogo)).BaseStream.CopyTo(memoryStream);
                logo = memoryStream.ToArray();
            }

            byte[] locImg;
            using (var memoryStream = new MemoryStream())
            {
                (new StreamReader(picFileLocation)).BaseStream.CopyTo(memoryStream);
                locImg = memoryStream.ToArray();
            }

            var site = _businessInformationQueryService.FindSites().Where(_ => _.Name == "Chanel").FirstOrDefault();

            var location = new LocationViewModel
            {
                Name = "IFC",
                Description = "Chanel IFC",
                ContactName = "test",
                PrimaryTelephone = "123-123-1234",
                SecondaryTelephone = "123-123-1234",
                City = "test",
                CountryCode = "test",
                PostalCode = "test",
                StateProvince = "test",
                StreetAddress = "test",
                StreetAddress2 = "test",
                Latitude = 0,
                Longitude = 0,
                SiteId = site.Id,
            };
            location = await _businessInformationService.ProvisionLocationAsync(location);
            await _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "IFC", "",
                                                           "Hongkong", "Hongkong", "", "China");
            await _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.28588, 114.158131);
            await _businessInformationService.SetLocationImage(location.SiteId, location.Id, logo);
            await _businessInformationService.AddAdditionalLocationImage(location.SiteId, location.Id, locImg);

            /////////////////////////
             
            location = new LocationViewModel
            {
                Name = "HM3",
                Description = "Chanel Prince's Building",
                ContactName = "test",
                PrimaryTelephone = "123-123-1234",
                SecondaryTelephone = "123-123-1234",
                City = "test",
                CountryCode = "test",
                PostalCode = "test",
                StateProvince = "test",
                StreetAddress = "test",
                StreetAddress2 = "test",
                Latitude = 0,
                Longitude = 0,
                SiteId = site.Id,
            };
            location = await _businessInformationService.ProvisionLocationAsync(location);
            await _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "Prince's Building", "",
                                                           "Hongkong", "Hongkong", "", "China");
            await _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.2812257, 114.159262799999);
            await _businessInformationService.SetLocationImage(location.SiteId, location.Id, logo);
            await _businessInformationService.AddAdditionalLocationImage(location.SiteId, location.Id, locImg);

            /////////////////////////
             
            location = new LocationViewModel
            {
                Name = "HHP",
                Description = "Chanel Hysan Place",
                ContactName = "test",
                PrimaryTelephone = "123-123-1234",
                SecondaryTelephone = "123-123-1234",
                City = "test",
                CountryCode = "test",
                PostalCode = "test",
                StateProvince = "test",
                StreetAddress = "test",
                StreetAddress2 = "test",
                Latitude = 0,
                Longitude = 0,
                SiteId = site.Id,
            };
            location = await _businessInformationService.ProvisionLocationAsync(location);
            await _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "Hysan Place", "",
                                                           "Hongkong", "Hongkong", "", "China");
            await _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.2798079, 114.1837883);
            await _businessInformationService.SetLocationImage(location.SiteId, location.Id, logo);
            await _businessInformationService.AddAdditionalLocationImage(location.SiteId, location.Id, locImg);

            /////////////////////////
            ///
            location = new LocationViewModel
            {
                Name = "HEM",
                Description = "Chanel Elements",
                ContactName = "test",
                PrimaryTelephone = "123-123-1234",
                SecondaryTelephone = "123-123-1234",
                City = "test",
                CountryCode = "test",
                PostalCode = "test",
                StateProvince = "test",
                StreetAddress = "test",
                StreetAddress2 = "test",
                Latitude = 0,
                Longitude = 0,
                SiteId = site.Id,
            };
            location = await _businessInformationService.ProvisionLocationAsync(location);
            await _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "Elements", "",
                                                           "Hongkong", "Hongkong", "", "China");
            await _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.3048708, 114.1615219);
            await _businessInformationService.SetLocationImage(location.SiteId, location.Id, logo);
            await _businessInformationService.AddAdditionalLocationImage(location.SiteId, location.Id, locImg);

            /////////////////////////
            ///
            location = new LocationViewModel
            {
                Name = "HFW",
                Description = "Chanel Festival Walk",
                ContactName = "test",
                PrimaryTelephone = "123-123-1234",
                SecondaryTelephone = "123-123-1234",
                City = "test",
                CountryCode = "test",
                PostalCode = "test",
                StateProvince = "test",
                StreetAddress = "test",
                StreetAddress2 = "test",
                Latitude = 0,
                Longitude = 0,
                SiteId = site.Id,
            };
            location = await _businessInformationService.ProvisionLocationAsync(location);
            await _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "Festival Walk", "",
                                                           "Hongkong", "Hongkong", "", "China");
            await _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.3372971, 114.1745273);
            await _businessInformationService.SetLocationImage(location.SiteId, location.Id, logo);
            await _businessInformationService.AddAdditionalLocationImage(location.SiteId, location.Id, locImg);

            /////////////////////////
            ///
            location = new LocationViewModel
            {
                Name = "HTP",
                Description = "Chanel Telford Plaza",
                ContactName = "test",
                PrimaryTelephone = "123-123-1234",
                SecondaryTelephone = "123-123-1234",
                City = "test",
                CountryCode = "test",
                PostalCode = "test",
                StateProvince = "test",
                StreetAddress = "test",
                StreetAddress2 = "test",
                Latitude = 0,
                Longitude = 0,
                SiteId = site.Id,
            };
            location = await _businessInformationService.ProvisionLocationAsync(location);
            await _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "Telford Plaza", "",
                                                           "Hongkong", "Hongkong", "", "China");
            await _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.3210652, 114.2132768);
            await _businessInformationService.SetLocationImage(location.SiteId, location.Id, logo);
            await _businessInformationService.AddAdditionalLocationImage(location.SiteId, location.Id, locImg);

            /////////////////////////
            ///
            location = new LocationViewModel
            {
                Name = "HNT",
                Description = "Chanel New Town Plaza",
                ContactName = "test",
                PrimaryTelephone = "123-123-1234",
                SecondaryTelephone = "123-123-1234",
                City = "test",
                CountryCode = "test",
                PostalCode = "test",
                StateProvince = "test",
                StreetAddress = "test",
                StreetAddress2 = "test",
                Latitude = 0,
                Longitude = 0,
                SiteId = site.Id,
            };
            location = await _businessInformationService.ProvisionLocationAsync(location);
            await _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                           "New Town Plaza", "",
                                                           "Hongkong", "Hongkong", "", "China");
            await _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, 22.3814592, 114.1889307);
            await _businessInformationService.SetLocationImage(location.SiteId, location.Id, logo);
            await _businessInformationService.AddAdditionalLocationImage(location.SiteId, location.Id, locImg);


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

            var location = _businessInformationService.ProvisionLocationAsync(request);

            return Ok(location);
        }

        [HttpPost]
        [Route("SetLocationAddress")]
        public ActionResult SetLocationAddress([FromBody]SetLocationAddressRequest request)
        {
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

        [HttpPost]
        [Route("AddAdditionalLocationImage")]
        public ActionResult AddAdditionalLocationImage(AddAdditionalLocationImageRequest request)
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(false);
            }

            Guid siteId = request.SiteId;
            Guid locationId = request.LocationId;
            byte[] image;
            using (var memoryStream = new MemoryStream())
            {
                request.Image.CopyTo(memoryStream);
                image = memoryStream.ToArray();
            }

            _businessInformationService.AddAdditionalLocationImage(siteId, locationId, image);
            return Ok();
        }
    }
}
