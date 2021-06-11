using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneMVC.Services.Interfaces;

namespace PhoneMVC.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IManageService _manageService;
        public PhoneController(IManageService managerService)
        {
            _manageService = managerService;
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post(string brand, string model, int price)
        {
            var id = await _manageService.CreateAsync(brand, model, price);
            ViewBag.Message = id;
            return View("Views/Phone/OkPost.cshtml");
        }

        public IActionResult Get()
        {
            return View();
        }

        public IActionResult Put()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
