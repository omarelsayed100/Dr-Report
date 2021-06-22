using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class MakeAppointmentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.accountname = TempAccount.AccountName;
            return View();
        }
        public IActionResult FillIndex()
        {
            ViewBag.accountname = TempAccount.AccountName;
            return View();
        }
    }
}
