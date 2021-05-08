using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class DoctorSignUpController : Controller
    {
        private readonly MedicalDBContext _context;
        public DoctorSignUpController(MedicalDBContext context)
        {
            _context = context;
        }
        // GET: DoctorSignUpController
        public ActionResult Index()
        {
            return View();
        }

        
        
        [HttpPost]
        public IActionResult SignUp(Doctor doctor)
        {


            var check = _context.Users.Select(u => u.Email).Contains(doctor.User.Email);

            if (ModelState.IsValid&&check==false)
            {
                doctor.User.UserTypeId = 2;
                doctor.User.IsDeleted = false;
                _context.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction("Index", "SignIn");
            }
            return View("Index");
        }
    }
}
