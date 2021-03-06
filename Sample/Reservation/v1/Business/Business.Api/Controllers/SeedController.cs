﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Business.Api.Controllers
{
    [Route("api/[controller]")]
    public class SeedController : Controller
    {
        string[] tenants = new string[] { 
            
        };

        private readonly ITenantService _tenantService;

        public SeedController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
