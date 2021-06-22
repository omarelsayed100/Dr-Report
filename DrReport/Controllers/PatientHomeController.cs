using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class PatientHomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.accountname = TempAccount.AccountName;
            return View();
        }
    }
}
