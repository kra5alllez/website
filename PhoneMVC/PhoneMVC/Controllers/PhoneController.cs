using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PhoneMVC.Controllers
{
    public class PhoneController : Controller
    {
        public IActionResult Post()
        {
            return View();
        }

        public IActionResult Post(string brand, string model, int price)
        {
            return View();
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
