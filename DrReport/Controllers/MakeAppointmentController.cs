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
        public IActionResult Index(string search)
        {
            ViewBag.accountname = TempAccount.AccountName;
            
            var clinics = _context.Clinics.Where(c => c.Name.Contains(search));
            var clinicDoctors = _context.Clinics.Select(d => d.Doctor);
            var clinicDoctorNames = from d in clinicDoctors
                join u in _context.Users
                on d.UserId equals u.UserId
                select ( "DR. "+u.Fname+" "+u.Lname);
   
            ViewBag.doctors = clinicDoctorNames.ToArray();
            return View(_context.Clinics);
        }
        public ActionResult FillIndex(int id)
        {
            Clinic clinic = _context.Clinics.FirstOrDefault(c=> c.Id==id);
            TempData["ClinicId"] = clinic.Id;
            ViewBag.clinicName = clinic.Name;
            ViewBag.accountname = TempAccount.AccountName;
            return View();
        }
        [HttpPost]
        public IActionResult CreateAppointment(Reserve reserve)
        {
            reserve.ClinicId = (int)TempData["ClinicId"];

            var doctorid = _context.Clinics.FirstOrDefault(c => c.Id == reserve.ClinicId).DoctorId;
            reserve.DoctorId = (int)doctorid;

            int y = (int)TempData["accountid"];
            int patientId = _context.Patients.FirstOrDefault(p => p.UserId == y).Id;
            reserve.PatientId=patientId;

            reserve.RequestDate = DateTime.Now;

            //DiagnosistestID,Reservationtime that he choose 

            _context.Reserves.Add(reserve);
            _context.SaveChanges();

            return RedirectToAction("Index", "MakeAppointment");
        }
    }
}
