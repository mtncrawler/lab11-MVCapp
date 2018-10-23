using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab11_mvcApp.Models;

namespace lab11_mvcApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Result", new { startYear, endYear });
        }

        public ViewResult Result(int startYear, int endYear)
        {
            TimePerson person = new TimePerson();
            
            return View(person);
        }
    }
}
