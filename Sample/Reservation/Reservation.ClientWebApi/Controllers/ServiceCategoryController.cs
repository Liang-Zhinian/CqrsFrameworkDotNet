using System;
using System.Linq;
using Registration.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Reservation.ClientWebApi.Controllers
{
    //[Authorize]
    [Route("api/services")]
    public class ServiceCategoryController: Controller
    {
        private readonly IServiceCategoryService _serviceCategoryService;

        public ServiceCategoryController(IServiceCategoryService serviceCategoryService)
        {
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
    }
}
