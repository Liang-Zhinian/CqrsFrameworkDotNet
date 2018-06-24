using System;
using Microsoft.AspNetCore.Mvc;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Business.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Domain.Repositories;

namespace Business.WebApi.Controllers
{
    //[Authorize]
    [Route("api/services")]
    public class ServiceCategoryController: Controller
    {
        private readonly IServiceCategoryService _serviceCategoryService;
        //private readonly ITenantRepository _tenantRepository;

        public ServiceCategoryController(IServiceCategoryService serviceCategoryService)
        {
            //_tenantRepository = tenantRepository;
            _serviceCategoryService = serviceCategoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Get()
        {
            var list = _serviceCategoryService.FindServices()
                                    .ToList();
            return Json(list);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("FindByTenant")]
        public JsonResult FindByTenant(Guid tenantId)
        {
            var list = _serviceCategoryService.FindServicesByTenant(tenantId)
                                    .ToList();
            return Json(list);
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
                                   ServiceViewModel request
                                  )
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(request);
            }

            _serviceCategoryService.AddService(request);

            return Ok(request);
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("AddServiceCategory")]
        public ActionResult AddServiceCategory([FromBody]
                                   ServiceCategoryViewModel request
                                  )
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(request);
            }

            _serviceCategoryService.AddServiceCategory(request);

            return Ok(request);
        }
    }
}
