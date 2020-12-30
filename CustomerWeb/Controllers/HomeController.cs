using CustomerWeb.Models;
using CustomerWeb.Models.DB;
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result=await _service.GetCustomerList();
            //var res = await _service.AddCustomer();
            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteCustomer(int Id)
        {
            var result = await _service.DeleteCustomer(Id);          
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerDesc(int Id)
        {
            @ViewData["custId"] = Id;

            if (Id == 0)
            {
                ViewData["Type"] = Enums.TypeVal.Insert.ToString();
                return View();
            }
            else { 
                var result = await _service.GetCustomerDetail(Id);
                
                ViewData["Type"] = Enums.TypeVal.Update.ToString();
                return View(result.FirstOrDefault());
        }
        }

        [HttpPost]
        public async Task<IActionResult> CustomerDesc(string TypeValue, Customer Customer)
        {   
            if (ModelState.IsValid)
            {
                if (TypeValue == Enums.TypeVal.Insert.ToString())
                {
                    var res1 = await _service.AddCustomer(Customer);
                }
                else if (TypeValue == Enums.TypeVal.Update.ToString())
                {
                    var res2 = await _service.UpdateCustomer(Customer);
                }

                return RedirectToAction("Index");
            }

            return View(Customer);
          
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
