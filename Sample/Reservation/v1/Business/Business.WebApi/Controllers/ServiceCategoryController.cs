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
    [Route("api/servicecategories")]
    public class ServiceCategoryController: Controller
    {
        private readonly IServiceCategoryService _serviceCategoryService;

        public ServiceCategoryController(IServiceCategoryService serviceCategoryService)
        {
            _serviceCategoryService = serviceCategoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("FindServiceItems")]
        public JsonResult FindServiceItems()
        {
            var list = _serviceCategoryService.FindServiceItems()
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
        [Route("AddServiceItem")]
        public ActionResult AddServiceItem([FromBody]
                                   ServiceItemViewModel request
                                  )
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(request);
            }

            _serviceCategoryService.AddServiceItem(request);

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
