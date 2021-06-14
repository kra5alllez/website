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
            return View("OkPost");
        }

        public IActionResult Get()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Get(int? id)
        {
            var phone = await _manageService.GetByIdAsync(id);
            ViewBag.Message = phone;
            return View("GetOk");
        }

        public IActionResult Put()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Put(int? id, string brand, string model, int price)
        {
            var result = await _manageService.UpdateAsync(id, brand, model, price);
            if (result)
            {
                ViewBag.Message = "nice";
            }
            else
            {
                ViewBag.Message = "fall";
            }

            return View("OkPut");
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            var result = await _manageService.DeleteAsync(id);
            if (result)
            {
                ViewBag.Message = "The operation was successful. Item deleted";
            }
            else
            {
                ViewBag.Message = "Item not deleted, please try again";
            }

            return View("OkDelete");
        }
    }
}
