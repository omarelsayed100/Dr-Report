using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class MakeAppointmentController : Controller
    {
        private readonly MedicalDBContext _context;
        public MakeAppointmentController(MedicalDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.accountname = TempAccount.AccountName;

            var clinicDoctors = _context.Clinics.Select(d => d.Doctor);
            var clinicDoctorNames = from d in clinicDoctors
                join u in _context.Users
                on d.UserId equals u.UserId
                select ( "DR. "+u.Fname+" "+u.Lname);
   
            ViewBag.doctors = clinicDoctorNames.ToArray();
            return View(_context.Clinics);
        }
        [HttpGet]
        public IActionResult FillIndex(int clinicId)
        {
          
            //Clinic clinic = x.FirstOrDefault(c=> c.Id==clinicId);
            ViewBag.clinicName = clinicId;
            ViewBag.accountname = TempAccount.AccountName;
            return View();
        }
        [HttpPost]
        public IActionResult CreateAppointment(Reserve reserve)
        {
            reserve.ClinicId = 1;
            var doctorid = _context.Clinics.FirstOrDefault(c => c.Id == reserve.ClinicId).DoctorId;
            
            reserve.PatientId = (int)TempData["accountid"];
            
            reserve.RequestDate = DateTime.Now;
            //DiagnosistestID,Reservationtime that he choose 

            _context.Add(reserve);
            _context.SaveChanges();

            return RedirectToAction("Index", "MakeAppointment");
        }
    }
}
