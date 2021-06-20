using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class ControlTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddIndex()
        {
            return View();
        }
        public IActionResult UpdateIndex()
        {
            return View();
        }
    }
}
