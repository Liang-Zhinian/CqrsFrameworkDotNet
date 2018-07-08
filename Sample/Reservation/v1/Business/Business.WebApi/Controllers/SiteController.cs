using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using Business.Contracts.Commands.Sites;
using Business.WebApi.Requests.Sites;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Business.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SiteController : Controller
    {
        private readonly IBusinessInformationService _businessInformationService;

        public SiteController(IBusinessInformationService businessInformationService)
        {
            _businessInformationService = businessInformationService;
        }

        // POST api/Site/ProvisionSite
        [HttpPost]
        [Route("ProvisionSite")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ProvisionSite(CreateSiteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return (IActionResult)BadRequest();
            }

            byte[] logo;
            using (var memoryStream = new MemoryStream())
            {
                request.Logo.CopyTo(memoryStream);
                logo = memoryStream.ToArray();
            }

            ProvisionSiteCommand provisionSiteCommand = new ProvisionSiteCommand { 
                Name = request.Name,
                Description = request.Description,
                Active = true,
                //PageColor1 = request.PageColor1,
                //PageColor2 = request.PageColor2,
                //PageColor3 = request.PageColor3,
                //PageColor4 = request.PageColor4,
                ContactName = request.ContactName,
                PrimaryTelephone = request.PrimaryTelephone,
                SecondaryTelephone = request.SecondaryTelephone,
                TenantId = request.TenantId
            };

            var site = await _businessInformationService.ProvisionSite(provisionSiteCommand);

            return (IActionResult)Ok(site);
        }
    }
}
