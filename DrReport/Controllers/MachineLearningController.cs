using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class MachineLearningController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
