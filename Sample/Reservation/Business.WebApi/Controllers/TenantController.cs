using System;
using Microsoft.AspNetCore.Mvc;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Business.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Domain.Repositories.Interfaces;

namespace Business.WebApi.Controllers
{
    //[Authorize]
    [Route("api/tenants")]
    public class TenantController: Controller
    {
        private readonly ISecurityService _bizService;
        //private readonly ITenantRepository _tenantRepository;

        public TenantController(ISecurityService bizService)
        {
            //_tenantRepository = tenantRepository;
            _bizService = bizService;
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
                                   TenantViewModel request
                                  )
        {
            throw new NotImplementedException();
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(request);
            }

            //_tenantAppService.Register(request);

            return Ok(request);
        }
    }
}
