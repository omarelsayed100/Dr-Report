using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DrReport.Controllers
{
    public class InformController : Controller
    {
        private readonly MedicalDBContext _context;
        public InformController(MedicalDBContext context)
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
        public JsonResult Save(string ttr)
        {
            string j = ttr;
            return Json(0);
        }

    }
}
