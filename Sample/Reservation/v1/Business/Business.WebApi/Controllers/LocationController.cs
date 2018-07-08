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
using Business.Contracts.Commands.Locations;
using System.Threading.Tasks;
using System.Net;

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

        private ProvisionLocationCommand BuildLocationCmd(Guid siteId, 
                                                          string name, 
                                                          string description
                                                         ){
            var command = new ProvisionLocationCommand {
                Name = name,
                Description = description,
                ContactName = "test",
                EmailAddress = "test@test.com",
                PrimaryTelephone = "123-123-1234",
                SecondaryTelephone = "123-123-1234",
                SiteId = siteId
            };

            return command;
        }

        private async Task CreateTestData(Guid siteId,
                                          string locName,
                                          string locDesc,
                                          byte[] img,
                                                          double latitude = 0,
                                          double longitude = 0)
        { 

            var command = BuildLocationCmd(siteId, locName, "Chanel IFC");

            var location = await _businessInformationService.ProvisionLocationAsync(command);
            await _businessInformationService.SetLocationAddress(location.SiteId, location.Id,
                                                                 locName, "",
                                                           "Hongkong", "Hongkong", "", "China");
            await _businessInformationService.SetLocationGeolocation(location.SiteId, location.Id, latitude, longitude);
            await _businessInformationService.UpdateLocationImage(new UpdateLocationImageCommand
            {
                LocationId = location.Id,
                SiteId = location.SiteId,
                Image = img
            });
            await _businessInformationService.AddAdditionalLocationImage(location.SiteId, location.Id, img);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GenerateTestData")]
        public async System.Threading.Tasks.Task<ActionResult> GenerateTestDataAsync()
        {
            var contentRootPath = this._env.ContentRootPath;
            string picFileLogo = Path.Combine(contentRootPath, "Pics", "Chanel logo.png");
            string picFileLocation = Path.Combine(contentRootPath, "Pics", "Location image.png");

            string city = "test";
            string countryCode = "test";
            string postalCode = "test";
            string stateProvince = "test";
            string streetAddress = "test";
            string streetAddress2 = "test";
            double latitude = 0;
            double longitude = 0;

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

            await CreateTestData(site.Id, "IFC", "Chanel IFC", locImg, 22.28588, 114.158131);
            await CreateTestData(site.Id, "HM3", "Chanel Prince's Building", locImg, 22.2812257, 114.159262799999);
            await CreateTestData(site.Id, "HHP", "Chanel Hysan Place", locImg, 22.2798079, 114.1837883);
            await CreateTestData(site.Id, "HEM", "Chanel Elements", locImg, 22.3048708, 114.1615219);
            await CreateTestData(site.Id, "HFW", "Chanel Festival Walk", locImg, 22.3372971, 114.1745273);
            await CreateTestData(site.Id, "HTP", "Chanel Telford Plaza", locImg, 22.3210652, 114.2132768);
            await CreateTestData(site.Id, "HNT", "Chanel New Town Plaza", locImg, 22.3814592, 114.1889307);


            return Ok();
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("ProvisionLocation")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ProvisionLocation([FromBody]
                                                           ProvisionLocationRequest request
                                  )
        {
            if (!ModelState.IsValid)
            {
                return (IActionResult)BadRequest();
            }

            var command = new ProvisionLocationCommand
            {
                Name = request.Name,
                Description = request.Description,
                ContactName = request.ContactName,
                EmailAddress = request.EmailAddress,
                PrimaryTelephone = request.PrimaryTelephone,
                SecondaryTelephone = request.SecondaryTelephone,
                SiteId = request.SiteId
            };

            var location = _businessInformationService.ProvisionLocationAsync(command);

            return (IActionResult)Ok(location);
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

            _businessInformationService.UpdateLocationImage(new UpdateLocationImageCommand{
                LocationId = request.Id,
                SiteId = request.SiteId,
                Image = image
            });
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
