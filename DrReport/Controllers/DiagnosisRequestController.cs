using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

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
            var patientsIds = diagnosisRequests.Select(p => p.PatientId).ToList();
            var patients = GetPatientsFromIds(patientsIds);
            var patientNames = from p in patients
                               join u in _context.Users
                               on p.UserId equals u.UserId
                               select (u.Fname + " " + u.Lname);
            ViewBag.patientNames = patientNames.ToArray();
            // * OrderByDesending By Reserve ID
            return View(diagnosisRequests);
        }
        //Return the patient as Objects from thier list of IDs
        public List<Patient> GetPatientsFromIds(List<int>ids)
        {
            List<Patient> patients = new List<Patient>();
            foreach (var item in ids)
            {
                Patient patient = _context.Patients.FirstOrDefault(p => p.Id == item);
                patients.Add(patient);
            }
            return patients;
        }
    }
}
