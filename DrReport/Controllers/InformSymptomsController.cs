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
