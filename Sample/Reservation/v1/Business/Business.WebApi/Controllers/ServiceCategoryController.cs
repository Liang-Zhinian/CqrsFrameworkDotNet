using System;
using Microsoft.AspNetCore.Mvc;
using Business.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Business.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Domain.Repositories;
using System.Threading.Tasks;
using System.Net;

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
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddServiceItem([FromBody]
                                   ServiceItemViewModel request
                                  )
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(request);
            }

            var result = await _serviceCategoryService.AddServiceItem(request);

            return CreatedAtAction(nameof(AddServiceItem), new { id = result.Id }, null);
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteTenantData")]
        [Route("AddServiceCategory")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddServiceCategory([FromBody]
                                   ServiceCategoryViewModel request
                                  )
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return Ok(request);
            }

            var result = await _serviceCategoryService.AddServiceCategory(request);

            return CreatedAtAction(nameof(AddServiceCategory), new { id = result.Id }, null);
        }
    }
}
