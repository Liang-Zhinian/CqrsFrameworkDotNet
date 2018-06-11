using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.WebTest.Models;

namespace Registration.Infra.Data.WebTest.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ITenantAppService _tenantAppService;
        ITenantRepository _tenantRepository;

        public HomeController(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public IActionResult Index()
        {
            var list = _tenantRepository.GetAll();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
