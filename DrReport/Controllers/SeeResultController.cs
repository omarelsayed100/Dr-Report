using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrReport.Controllers
{
    public class SeeResultController : Controller
    {
        private readonly MedicalDBContext _context;
        public SeeResultController(MedicalDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.accountname = TempAccount.AccountName;
            int patientId = _context.Patients.FirstOrDefault(p => p.UserId == TempAccount.AccountId).Id;
            var reserves = _context.Reserves.Where(r => r.PatientId == patientId).ToList();
            List<DiagnosisResult> results = new List<DiagnosisResult>();
            foreach (var item in reserves)
            {
                var result = _context.DiagnosisResults.FirstOrDefault(r => r.ReserveId == item.Id);
                if (result!=null)
                {
                    results.Add(result);
                }
            }
            
            var reservationData = GetReservationData(reserves);
            // viewbag of all data
            return View(results);
        }
        public IEnumerable<string> GetReservationData(List<Reserve> reserve)
        {
            var Dtests = reserve.Select(d => d.DtestName).ToList();
            var reservationDate = reserve.Select(r => r.ReservationDate).ToList();

            //start two forloops to get the doctors, clinics objects
            List<string> doctorNames = new List<string>();
            foreach (var item in reserve)
            {
                var doctor = _context.Doctors.FirstOrDefault(d => d.Id == item.DoctorId);
                var doctorUser = _context.Users.FirstOrDefault(u => u.UserId == doctor.UserId);
                string doctorFullName = "DR. " + doctorUser.Fname + " " + doctorUser.Lname;
                doctorNames.Add(doctorFullName);
            }
            List<string> clinicNames = new List<string>();
            foreach (var item in reserve)
            {
                var clinicName = _context.Clinics.FirstOrDefault(c => c.Id == item.ClinicId).Name;
                clinicNames.Add(clinicName);
            }
            //end two forloops
            var AllReservationData =doctorNames.Concat(clinicNames);
            return AllReservationData;

        }

        //id ~==>  DResultID
        public IActionResult ReportIndex(int id)
        {
            ViewBag.accountname = TempAccount.AccountName;
            var dResult = _context.DiagnosisResults.FirstOrDefault(r => r.Id == id);
            var reserveId_dResult = dResult.ReserveId;
            ViewBag.Data = GetAllData(reserveId_dResult);
            var dtestDresults = _context.DtestDresults.Where(t => t.DresultId == dResult.Id);

            //Dtest Names  Dtest Units    Dtest Normals
            var dTestsIds = dtestDresults.Select(d => d.DtestId).ToList();
            List<DiagnosisTest> diagnosisTests = new List<DiagnosisTest>();
            List<string> dTestNames = new List<string>();
            List<string> dTestUnits = new List<string>();
            foreach (var item in dTestsIds)
            {
                var dTest = _context.DiagnosisTests.FirstOrDefault(i=>i.Id==item);
                diagnosisTests.Add(dTest);
                dTestNames.Add(dTest.Name);
                dTestUnits.Add(dTest.Unit);
            }
            var normals = GetNormals(diagnosisTests, reserveId_dResult);
            ViewBag.Normals = normals;
            return View(dtestDresults);
        }
        public List<string> GetNormals(List<DiagnosisTest> diagnosisTests,int reserveId_dResult)
        {
            var reserve = _context.Reserves.FirstOrDefault(r => r.Id == reserveId_dResult);
            var patient = _context.Patients.FirstOrDefault(p => p.Id == reserve.PatientId);
            var patientGender = patient.Gender;
            List<string> normals = new List<string>();
            foreach (var item in diagnosisTests)
            {
                var normalRanges = _context.DiagnosisTestRanges.Where(r => r.DtestId == item.Id);
                var selectedNormals = normalRanges.FirstOrDefault(t => t.PatientType == patientGender || t.PatientType == "Neutral");
                var requiredNormal = selectedNormals.StartRange + " - " + selectedNormals.EndRange;
                normals.Add(requiredNormal);
            }
            return normals;
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
