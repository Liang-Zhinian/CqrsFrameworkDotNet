using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;

namespace Business.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //private readonly ITenantAppService _tenantAppService;
        ITenantRepository _tenantRepository;

        public ValuesController(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            var list = _tenantRepository.GetAll()
                                    .Include(t => t.Address)
                                        .Include(t => t.Contact)
                                    .ToList();
            return Json(list);
        }

        [HttpGet]
        [Route("getaddress")]
        public TenantAddress GetTenantAddress()
        {
            var address = _tenantRepository.GetAll().First().Address;
            return address;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
