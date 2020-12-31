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
            var model = new GetModel();

            @ViewData["custId"] = Id;

            if (Id == 0)
            {
                ViewData["Type"] = Enums.TypeVal.Insert.ToString();
                return View(model);
            }
            else { 
                var result = await _service.GetCustomerDetail(Id);
                model.Customer = result.FirstOrDefault();
                model.Visitings = await _service.GetVisitList(Id);
                
                ViewData["Type"] = Enums.TypeVal.Update.ToString();

                return View(model);
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

        [HttpGet]
        public async Task<JsonResult> GetVisitingDetail(int Id)
        {
            var result = await _service.GetVisitDetail(Id);
            return Json(result.FirstOrDefault());
        }
        [HttpGet]
        public async Task<JsonResult> GetVisitings(int CustomerId)
        {
            var result = await _service.GetVisitDetail(CustomerId);
            return Json(result.FirstOrDefault());
        }

        [HttpPost]
        public async Task<JsonResult> AddVisiting(Visiting Visiting)
        {
            int result = 0;
            if (Visiting.Id > 0)
            {
                 result = await _service.UpdateVisit(Visiting);
            }
            else if (Visiting.Id == 0)
            {
                 result = await _service.AddVisit(Visiting);

            }
                return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteVisiting(int Id)
        {
            var result = await _service.DeleteVisit(Id);
            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
