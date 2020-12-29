using CustomerWeb.Models;
using CustomerWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWeb.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ICustomerService _service;

        public HomeController(ICustomerService service)
        {
            _service = service;

        }      

        public async Task<IActionResult> Index()
        {
            var result=_service.GetCustomerList();
            //var res = await _service.AddCustomer();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
