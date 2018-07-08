using System;
using System.Net;
using System.Threading.Tasks;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaaSEqt.IdentityAccess.Application;
using SaaSEqt.IdentityAccess.Application.Commands;

namespace Business.WebApi.Controllers
{
    //[Authorize]
    [Route("api/tenants")]
    public class TenantController: Controller
    {

        private readonly IdentityApplicationService _identityApplicationService;

        public TenantController(IdentityApplicationService identityApplicationService)
        {
            _identityApplicationService = identityApplicationService;

            //InitializeTenants();
        }

        private void InitializeTenants() {
            string tenantName = "Chanel";
            string email = "support@test.com";
            string phone = "123-123-1234";
            TenantViewModel tenant = new TenantViewModel(
                Guid.NewGuid(),
                tenantName,
                tenantName,
                email,
                phone,
                phone,
                "",
                "",
                "",
                "",
                "",
                ""
            );

            StaffViewModel administrator = new StaffViewModel { 
                FirstName = tenantName,
                LastName = tenantName,
                EmailAddress = email,
                PrimaryTelephone = phone,
                SecondaryTelephone = phone,
                AddressStreetAddress="Tianhe",
                AddressCity="Guangzhou",
                AddressStateProvince="Guangdong",
                AddressPostalCode="510510",
                AddressCountryCode="China"
            };

            //tenants.Add(tenant, administrator);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GenerateTestData")]
        public ActionResult GenerateTestData()
        {
            //foreach(var tenant in tenants)
                //_tenantService.ProvisionTenant(tenant.Key, tenant.Value);

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            //var list = _bizService.GetAll()
            //                        .ToList();
            //return Json(list);
            throw new NotImplementedException();
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
        [Route("Register")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register([FromBody]
                                   TenantViewModel tenant,
                                   StaffViewModel administrator
                                  )
        {
            //throw new NotImplementedException();
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return (IActionResult)BadRequest();
            }

            ProvisionTenantCommand command = new ProvisionTenantCommand(
                        tenant.Name,
                        tenant.Description,
                        administrator.FirstName,
                        administrator.LastName,
                        administrator.EmailAddress,
                        administrator.PrimaryTelephone,
                        administrator.SecondaryTelephone,
                        administrator.AddressStreetAddress,
                        administrator.AddressCity,
                        administrator.AddressStateProvince,
                        administrator.AddressPostalCode,
                        administrator.AddressCountryCode
                    );

            var _tenant = await _identityApplicationService.ProvisionTenant(command);

            return (IActionResult)Ok(_tenant);
        }

        [HttpPost]
        [HttpPut]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("TenantAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult AddOrUpdateTenantAddress([FromBody]
                                   TenantAddressViewModel tenantAddress
                                  )
        {
            //throw new NotImplementedException();
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return (IActionResult)BadRequest();
            }

            //if (Request.Method.ToUpper() == "POST")
            //    _tenantService.AddTenantAddress(tenantAddress);

            //if (Request.Method.ToUpper() == "PUT")
            //_tenantService.ModifyTenantAddress(tenantAddress);

            return (IActionResult)Ok(tenantAddress);
        }
    }
}
