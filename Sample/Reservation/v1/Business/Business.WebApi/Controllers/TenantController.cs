using System;
using Microsoft.AspNetCore.Mvc;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Business.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;

namespace Business.WebApi.Controllers
{
    //[Authorize]
    [Route("api/tenants")]
    public class TenantController: Controller
    {
        //private static Dictionary<TenantViewModel, StaffViewModel> tenants = new Dictionary<TenantViewModel, StaffViewModel>();

        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;

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
        [Route("register")]
        public ActionResult Create([FromBody]
                                   TenantViewModel tenant,
                                   StaffViewModel administrator
                                  )
        {
            //throw new NotImplementedException();
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok();
            }

            _tenantService.ProvisionTenant(tenant, administrator);

            return Ok();
        }

        [HttpPost]
        [HttpPut]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("TenantAddress")]
        public ActionResult AddOrUpdateTenantAddress([FromBody]
                                   TenantAddressViewModel tenantAddress
                                  )
        {
            //throw new NotImplementedException();
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok();
            }

            if (Request.Method.ToUpper() == "POST")
                _tenantService.AddTenantAddress(tenantAddress);
            
            if (Request.Method.ToUpper() == "PUT")
                _tenantService.ModifyTenantAddress(tenantAddress);

            return Ok(tenantAddress);
        }
    }
}
