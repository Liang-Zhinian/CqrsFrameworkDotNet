using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Tenant> Get()
        {
            return _tenantRepository.GetAll();;
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
