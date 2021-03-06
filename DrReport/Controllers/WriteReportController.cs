using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace DrReport.Controllers
{
    public class WriteReportController : Controller
    {
        private readonly MedicalDBContext _context;
        static bool flag = false;
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
            if (flag==false)
            {
                TempReportData.IntializeTemp();
                flag=true;
            }
            if (TempReportData.DiagnosisTests != null)
            {
                List<DiagnosisTest> d = TempReportData.DiagnosisTests;
                //normals list
                ViewBag.Normal = GetNormals();
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
                
                TempReportData.DiagnosisTests = diagnosisTests;
            }
            int tempReportId = TempReportData.ReserveId;
            return RedirectToAction("ReportIndex", new { id= tempReportId });
        }
        public IActionResult DeleteTests(int id)
        {
            var u = TempReportData.DiagnosisTests.FirstOrDefault(d => d.Id == id);
            TempReportData.DiagnosisTests.Remove(u);
            int tempReportId = TempReportData.ReserveId;
            return RedirectToAction("ReportIndex", new { id = tempReportId });
        }
        public IActionResult ClearTests()
        {
            TempReportData.IntializeTemp();
            int tempReportId = TempReportData.ReserveId;
            return RedirectToAction("ReportIndex", new { id = tempReportId });
        }
        public List<string> GetNormals()
        {
            var diagnosisTests = TempReportData.DiagnosisTests;
            var reserve = _context.Reserves.FirstOrDefault(r => r.Id == TempReportData.ReserveId);
            var patient = _context.Patients.FirstOrDefault(p => p.Id == reserve.PatientId);
            var patientGender = patient.Gender;
            List<string> normals = new List<string>();
            foreach (var item in TempReportData.DiagnosisTests)
            {
                var normalRanges = _context.DiagnosisTestRanges.Where(r => r.DtestId == item.Id);
                var selectedNormals = normalRanges.FirstOrDefault(t => t.PatientType == patientGender || t.PatientType == "Neutral");
                var requiredNormal = selectedNormals.StartRange + " - " + selectedNormals.EndRange;
                normals.Add(requiredNormal);
            }
            return normals;
        }
        public JsonResult GetGeneralDiagnosisList(string searchTerm)
        {
            var gTestList = _context.GeneralDiagnosisTests.ToList();
            var selectedTests = new List<GeneralDiagnosisTest>();
            if (searchTerm != null)
            {
                selectedTests = gTestList.Where(x => x.Name.Contains(searchTerm)).ToList();
            }
            else
            {
                selectedTests = gTestList;
            }
            var modifiedData = selectedTests.Select(x => new
            {
                id = x.Id,
                text = x.Name
            });
            return Json(modifiedData);
        }
        public JsonResult GetSelectedGeneralTests(string data)
        {
            var generalTestId = data.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList().First();
            if (generalTestId != 0)
            {
                var g = _context.GdtestRelateDtests.Where(g => g.GdtestId == generalTestId).Select(d => d.Dtest).ToList();
                TempReportData.DiagnosisTests = g;
            }
            return Json(0);
        }
        public IActionResult AddGTests()
        {   // try here
            int tempReportId = TempReportData.ReserveId;
            return RedirectToAction("ReportIndex", new { id = tempReportId });
        }
        // from jquery 
        public IActionResult GetValues(List<string> input)
        {
            //storing value:DTestId   int two lists
            List<int> diagnosisIds = new List<int>();
            List<string> values = new List<string>();
            foreach (var item in input)
            {
                var splittedData = item.Split(':');
                values.Add(splittedData[0].Trim());
                diagnosisIds.Add(int.Parse(splittedData[1]));
            }
            // saving the DResult into DB
            DiagnosisResult diagnosisResult = new DiagnosisResult();
            diagnosisResult.ReserveId = TempReportData.ReserveId;
            _context.DiagnosisResults.Add(diagnosisResult);
            _context.SaveChanges();
            // saving in DTest_DResult into DB
            for (int i=0;i<diagnosisIds.Count();i++)
            {
                DtestDresult dtestDresult = new DtestDresult();
                dtestDresult.DresultId = diagnosisResult.Id;
                dtestDresult.DtestId = diagnosisIds[i];
                dtestDresult.ResultValue = values[i];
                _context.DtestDresults.Add(dtestDresult);
            }
            _context.SaveChanges();
            return RedirectToAction("Index","MachineLearning", new { id = diagnosisResult.Id } );
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
