using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DrReport.Controllers
{
    public class InformSymptomsController : Controller
    {
        private readonly MedicalDBContext _context;
        public InformSymptomsController(MedicalDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.accountname = TempAccount.AccountName;
            ViewBag.diagnosistest = TempData["diagnosistest"];
            ViewBag.precaution = TempData["precaution"];
            ViewBag.finaldisease_name = TempData["finaldisease_name"];

            return View();
        }
        public JsonResult GetSymptomList(string searchTerm)
        {
            var symptomList = _context.DiseaseSymptoms.ToList();

            if (searchTerm != null)
            {
                symptomList = _context.DiseaseSymptoms.Where(x => x.Symptom.Contains(searchTerm)).ToList();
            }

            var modifiedData = symptomList.Select(x => new
            {
                id = x.Id,
                text = x.Symptom
            });
            return Json(modifiedData);
        }
        //Get selected symptomsIds from select symptoms list
        [HttpPost]
        public JsonResult GetSelectedSymptoms(string data)
        {
            if (data!=null)
            {
                // Splitting the input data
                List<int> symptomIds = data.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                // Transform the symptom ids into distinict symptom names to prevent Repetition
                List<string> symptomsnames=new List<string>();
                foreach (var item in symptomIds)
                {
                    var selectedSymptoms = _context.DiseaseSymptoms.Where(d => d.Id == item).Select(s=>s.Symptom).FirstOrDefault();
                    symptomsnames.Add(selectedSymptoms);
                }
                //Selecting the distinict symptoms 
                var distinctsymptoms = symptomsnames.Distinct().ToList();

                // Algorithm
                List<int?> diseaseIds = new List<int?>();
                foreach (var item in distinctsymptoms)
                {
                    var selectedDiseases = _context.DiseaseSymptoms.Where(s => s.Symptom == item).Select(d=>d.DiseaseId).ToList();
                    diseaseIds.AddRange(selectedDiseases);
                }
                var mostFrequentDisease = diseaseIds.GroupBy(i => i).OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key).First();

                //Outputs for disease & its precautions
                var finalDiseaseObj = _context.Diseases.FirstOrDefault(d => d.Id== mostFrequentDisease);
                var finalDiseaseName = finalDiseaseObj.Name;
                var precaution = finalDiseaseObj.Precaution;
                TempData["precaution"] = precaution.ToString();
                TempData["finaldisease_name"] = finalDiseaseName.ToString();

                //Outputs for diagnosis test
                var diagnosisTestObj = _context.DiseaseRelateDtests.FirstOrDefault(s => s.DiseaseId == finalDiseaseObj.Id);
                string diagnosisTest;
                try
                {
                    diagnosisTest = _context.DiagnosisTests.FirstOrDefault(d => d.Id == diagnosisTestObj.DtestId).Name;
                }
                catch (Exception)
                {
                    diagnosisTest = "No Diagnosis Test Attached To This Disease";
                }
                TempData["diagnosistest"] = diagnosisTest.ToString();

                //Calcuating the accuracy
                double accuarcy = ((double)CountOccurenceOfValue(diseaseIds, (int)mostFrequentDisease) / (double)diseaseIds.Count);
            }
            return Json(0);
        }
        //Number of occurence of a specific value in a list
        public int CountOccurenceOfValue(List<int?> list, int valueToFind)
        {
            return ((from temp in list where temp.Equals(valueToFind) select temp).Count());
        }
        //public ActionResult SymptomResult()
        //{


        //    return View();
        //}

    }
}
