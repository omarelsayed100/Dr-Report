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
            if (search==null)
            {
                search = "";
            }
            var selectedClinics = _context.Clinics.Where(c => c.Name.Contains(search));
            var clinicDoctors = selectedClinics.Select(d => d.Doctor);
            
            var clinicDoctorNames = from d in clinicDoctors
                join u in _context.Users
                on d.UserId equals u.UserId
                select ( "DR. "+u.Fname+" "+u.Lname);
   
            ViewBag.doctors = clinicDoctorNames.ToArray();
            return View(selectedClinics);
        }
        public ActionResult FillIndex(int id)
        {   //clinic setup
            Clinic clinic = _context.Clinics.FirstOrDefault(c=> c.Id==id);
            TempData["ClinicId"] = clinic.Id;
            ViewBag.clinicName = clinic.Name;
            //diagnosis test setup
            var dTests= _context.DiagnosisTests.Select(t=>t.Name);
            var gTests = _context.GeneralDiagnosisTests.Select(t=>t.Name);
            ViewBag.dTest = dTests.Concat(gTests).ToList();

            ViewBag.accountname = TempAccount.AccountName;
            return View();
        }
        [HttpPost]
        public IActionResult CreateAppointment(Reserve reserve)
        {
            reserve.ClinicId = (int)TempData["ClinicId"];
            //get it by the reserve.dTestName

            reserve.PotentialDisease = FindPotentialDisease(reserve.DtestName);

            var doctorid = _context.Clinics.FirstOrDefault(c => c.Id == reserve.ClinicId).DoctorId;
            reserve.DoctorId = (int)doctorid;

            int userId = TempAccount.AccountId;
            int patientId = _context.Patients.FirstOrDefault(p => p.UserId == userId).Id;
            reserve.PatientId=patientId;

            reserve.RequestDate = DateTime.Now;

            //DiagnosistestID,Reservationtime that he choose 
            //*proposal concat all the data into one ViewBag*
            _context.Reserves.Add(reserve);
            _context.SaveChanges();

            return RedirectToAction("Index", "MakeAppointment");
        }
        public string FindPotentialDisease(string diagnosisName)
        {
            var x = _context.DiagnosisTests.FirstOrDefault(d => d.Name.Contains(diagnosisName.Trim()));
            var y = _context.GeneralDiagnosisTests.FirstOrDefault(d => d.Name.Contains(diagnosisName.Trim()));
            if (x!=null)
            {
                var disease = _context.DiseaseRelateDtests.FirstOrDefault(d => d.DtestId == x.Id);
                if (disease != null) 
                {
                    var diseaseName = _context.Diseases.FirstOrDefault(t => t.Id == disease.DiseaseId);
                    return diseaseName.Name;
                }
                else return "";
            }
            else {
                var disease = _context.DiseaseRelateGdtests.FirstOrDefault(d => d.GdtestId == y.Id);
                if (disease != null)
                {
                    var diseaseName = _context.Diseases.FirstOrDefault(t => t.Id == disease.DiseaseId);
                    return diseaseName.Name;
                }
                else return "";
            }
        }
    }
}
