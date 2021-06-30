using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrReport.Controllers
{
    public class TempInform
    {
        public static string Disease { get; set; }
        public static string Precaution { get; set; }
        public static string DiagnosisTest { get; set; }
        public void IntializeTemp()
        {
            Disease = "";
            Precaution = "";
            DiagnosisTest = "";
        }
    }
}
