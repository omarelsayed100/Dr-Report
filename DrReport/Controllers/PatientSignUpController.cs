using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class PatientSignUpController : Controller
    {
        private readonly MedicalDBContext _context;
        public PatientSignUpController(MedicalDBContext context)
        {
            _context = context;
        }
        // GET: PatientSignUpController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Patient patient)
        {
            
            if (ModelState.IsValid)
            {
                patient.User.UserTypeId = 1;
                patient.User.IsDeleted = false;
                _context.Add(patient);
                _context.SaveChanges();
                return RedirectToAction("Index", "PatientHome");
            }
            return RedirectToAction("Index");
        }

    }
}
