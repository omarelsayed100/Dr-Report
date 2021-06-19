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
            ViewBag.sympid = TempData["sympid"];
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
                var final = finaldisease.Name;
                var precaution = finaldisease.Precaution;
                var diagnosistestid = _context.DiseaseRelateDtests.FirstOrDefault(s => s.DiseaseId==finaldisease.Id).DtestId;
                var diagnosistest = _context.DiagnosisTests.FirstOrDefault(d => d.Id == diagnosistestid).Name;
                double accuarcy = ((double)CountOccurenceOfValue(diseaseIds, (int) most)/ (double)diseaseIds.Count);
                TempData["sympid"] = symptomsIds.First().ToString();
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

        /*
                input :
                list S=[s1,s2,s3,s4]
                --------------------------------
        algorithm#1  Using LINQ
                var D=_context.disease(s=>s.symptoms==S[0])
         ///////////////////////////////////////////////////
        algorithm#2     طريقة الحذف 


            iteration1:
                d1   s1
                d2   s1
                d3   s1

            iteration2:
                look for s2
                Disease symptoms
                d1      s1 s2 s3
                d2      s1 s2 s3

            iteration3:
                d1   s1 s2 s3 s4
                ------------------------------------

            output:
                dtest <=>d1    mapping
                precaution <=> d1  mapping
                --------------------------------

        */

    }
}
