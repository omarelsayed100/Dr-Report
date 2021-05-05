using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class DoctorSignUpController : Controller
    {
        // GET: DoctorSignUpController
        public ActionResult Index()
        {
            return View();
        }
 
    }
}
