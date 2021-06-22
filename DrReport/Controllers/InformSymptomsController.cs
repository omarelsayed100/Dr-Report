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
            var SymptomList = _context.DiseaseSymptoms.ToList();

            if (searchTerm != null)
            {
                SymptomList = _context.DiseaseSymptoms.Where(x => x.Symptom.Contains(searchTerm)).ToList();
            }

            var modifiedData = SymptomList.Select(x => new
            {
                id = x.Id,
                text = x.Symptom
            });
            return Json(modifiedData);
        }
        //Get selected symptomsIds from select symptoms list
        [HttpPost]
        public JsonResult GetSelected(string data)
        {
            if (data!=null)
            {
                List<int> symptomsIds = data.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                //transform the symptom ids into distinict symptom names to prevent Repetition
                List<string> symptomsnames=new List<string>();
                foreach (var item in symptomsIds)
                {
                    var x = _context.DiseaseSymptoms.Where(d => d.Id == item).Select(s=>s.Symptom).FirstOrDefault();
                    symptomsnames.Add(x);
                }
                var distinctsymptoms = symptomsnames.Distinct().ToList();

                // Algorithm
                List<int?> diseaseIds = new List<int?>();
                foreach (var item in distinctsymptoms)
                {
                    var y = _context.DiseaseSymptoms.Where(s => s.Symptom == item).Select(d=>d.DiseaseId).ToList();
                    diseaseIds.AddRange(y);
                }
                var most = diseaseIds.GroupBy(i => i).OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key).First();
                //outputs
                var finaldisease = _context.Diseases.FirstOrDefault(d => d.Id==most);
                var finaldisease_name = finaldisease.Name;
                var precaution = finaldisease.Precaution;
                try
                {

                    var diagnosistestObj = _context.DiseaseRelateDtests.FirstOrDefault(s => s.DiseaseId == finaldisease.Id);
                    string diagnosistest = _context.DiagnosisTests.FirstOrDefault(d => d.Id == diagnosistestObj.DtestId).Name;
                    TempData["diagnosistest"] = diagnosistest.ToString();
                }
                catch 
                {
                }
                double accuarcy = ((double)CountOccurenceOfValue(diseaseIds, (int) most)/ (double)diseaseIds.Count);
                //
                
                TempData["precaution"] = precaution.ToString();
                TempData["finaldisease_name"] = finaldisease_name.ToString();
            }
            return Json(0);
        }
        public  int CountOccurenceOfValue(List<int?> list, int valueToFind)
        {
            return ((from temp in list where temp.Equals(valueToFind) select temp).Count());
        }
        //public ActionResult SymptomResult()
        //{


        //    return View();
        //}

    }
}
