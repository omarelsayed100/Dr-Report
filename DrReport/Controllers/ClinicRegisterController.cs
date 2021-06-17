using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class ClinicRegisterController : Controller
    {
        private readonly MedicalDBContext _context;
        public ClinicRegisterController(MedicalDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Clinic clinic)
        {
            //finding the last doctorid entered
            int doctorid = int.Parse(_context.Doctors.OrderByDescending(d => d.Id).Select(r => r.Id).First().ToString());
                       
            if (ModelState.IsValid)
            {
                clinic.DoctorId = doctorid;
                _context.Add(clinic);
                _context.SaveChanges();
                return RedirectToAction("Index", "SignIn");
            }
            return View("Index");
        }
    }
}
