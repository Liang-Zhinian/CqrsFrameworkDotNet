﻿using System;
using Microsoft.AspNetCore.Mvc;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Business.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace Business.WebApi.Controllers
{
    //[Authorize]
    [Route("api/tenants")]
    public class TenantController: Controller
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
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
