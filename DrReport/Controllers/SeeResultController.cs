using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class SeeResultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.accountname = TempAccount.AccountName;
            return View();
        }
        public IActionResult ReportIndex()
        {
            ViewBag.accountname = TempAccount.AccountName;
            return View();
        }
    }
}
