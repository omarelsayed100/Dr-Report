using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DrReport.Controllers
{
    public class WriteReportController : Controller
    {
        private readonly MedicalDBContext _context;
        public WriteReportController(MedicalDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.accountname = TempAccount.AccountName;
            return View();
        }
        public IActionResult ReportIndex(int id)
        {
            ViewBag.accountname = TempAccount.AccountName;

            ViewBag.Data = GetAllData(id);
            TempReportData.ReserveId = id;
            if (TempData["diagnosisTests"]!=null)
            {
                List<DiagnosisTest> d = JsonConvert.DeserializeObject<List<DiagnosisTest>>((string)TempData["diagnosisTests"]);
                return View(d);
            }
            return View();
        }
        
        public IActionResult AddTests()
        {
            string data = (string)TempData["DiagnosisData"];
            if (data != null)
            {
                // Splitting the input data
                List<int> diagnosisTestIds = data.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList();

                List<DiagnosisTest> diagnosisTests = new List<DiagnosisTest>();
                foreach (var item in diagnosisTestIds)
                {
                    var d = _context.DiagnosisTests.FirstOrDefault(d => d.Id == item);
                    diagnosisTests.Add(d);
                }
                TempData["diagnosisTests"]= JsonConvert.SerializeObject(diagnosisTests); 
            }
            int tempReportId = TempReportData.ReserveId;
            return RedirectToAction("ReportIndex", new { id= tempReportId });
        }
        public JsonResult GetDiagnosisList(string searchTerm)
        {
            var testList = _context.DiagnosisTests.ToList();
            var selectedTests = new List<DiagnosisTest>();
            if (searchTerm != null)
            {
                selectedTests = testList.Where(x => x.Name.Contains(searchTerm)).ToList();
            }
            else
            {
                selectedTests = testList;
            }
            var modifiedData = selectedTests.Select(x => new
            {
                id = x.Id,
                text = x.Name
            });
            return Json(modifiedData);
        }
        public JsonResult GetSelectedTests(string data)
        {
            TempData["DiagnosisData"] = data;
            return Json(0);
        }
        public List<string> GetAllData(int id)
        {
            var reserve = _context.Reserves.FirstOrDefault(r => r.Id == id);
            //reservation data
            var requestDate = reserve.RequestDate.ToString();
            var reservationDate = reserve.ReservationDate.ToString();

            //clinic data
            var clinicName = _context.Clinics.FirstOrDefault(c => c.Id == reserve.ClinicId).Name;

            //patient data
            var patient = _context.Patients.FirstOrDefault(p => p.Id == reserve.PatientId);
            var patientAge = patient.Age;
            var patientGender = patient.Gender;
            var patientUser = _context.Users.FirstOrDefault(u => u.UserId == patient.UserId);
            var patientName = patientUser.Fname + " " + patientUser.Lname;
            var patientEmail = patientUser.Email;

            //doctor data
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == reserve.DoctorId);
            var doctorUser = _context.Users.FirstOrDefault(u => u.UserId == doctor.UserId);
            var doctorName = doctorUser.Fname + " " + doctorUser.Lname;
            var doctorEmail = doctorUser.Email;

            List<string> dataList = new List<string>();
            dataList.AddRange(new string[] { patientName, doctorEmail,patientAge.ToString(),patientGender,
                    doctorName, requestDate,reservationDate,clinicName  });
            return dataList;
        }
    }
}
