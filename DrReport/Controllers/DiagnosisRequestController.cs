using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class DiagnosisRequestController : Controller
    {
        private readonly MedicalDBContext _context;
        public DiagnosisRequestController(MedicalDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.accountname = TempAccount.AccountName;
            var userId = TempAccount.AccountId;
            var doctorId = _context.Doctors.FirstOrDefault(u => u.UserId == userId).Id;
            var diagnosisRequests = _context.Reserves.Where(r=>r.DoctorId==doctorId).ToList();

            //var diagnosisPatientIds = _context.Reserves.Select(p=>p.PatientId).ToList();
            //foreach (var item in diagnosisPatientIds)
            //{
            //    var patientNames =_context.Users.Where(l => l.i).Select(o=>o.Fname+" "+o.Lname)
            //}

            return View(diagnosisRequests);
        }
    }
}
