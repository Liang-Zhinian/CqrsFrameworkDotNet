using System;
using System.Linq;
using Registration.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Registration.ClientWebApi.Controllers
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

        #region Services

        [HttpGet]
        [AllowAnonymous]
        [Route("Services")]
        public JsonResult Services()
        {
            var list = _serviceCategoryService.FindServices()
                                    .ToList();
            return Json(list);
        }

        #endregion

        #region Categories

        [HttpGet]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("ServiceCategories")]
        public ActionResult GetServiceCategories()
        {
            var list = _serviceCategoryService.FindServiceCategories()
                                    .ToList();
            return Json(list);
        }

        [HttpGet]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("ServiceCategories/{id}")]
        public ActionResult GetServiceCategory(Guid id)
        {
            var item = _serviceCategoryService.FindServiceCategory(id);
            return Json(item);
        }

        #endregion
        [HttpGet]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("test")]
        public ActionResult Test()
        {
            return Ok("Success!");
        }
    }
}
