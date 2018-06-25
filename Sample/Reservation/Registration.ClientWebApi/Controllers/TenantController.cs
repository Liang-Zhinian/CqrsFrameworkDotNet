using System.Linq;
using Registration.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Reservation.ClientWebApi.Controllers
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
            var list = _tenantService.GetTenants()
                                    .ToList();
            return Json(list);
        }
    }
}
