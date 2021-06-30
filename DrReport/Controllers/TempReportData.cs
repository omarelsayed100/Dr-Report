using DrReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrReport.Controllers
{
    public class TempReportData
    {
        public static int ReserveId { get; set; }
        public static List<DiagnosisTest> DiagnosisTests { get; set; }
        public static void IntializeTemp()
        {
            DiagnosisTests = new List<DiagnosisTest>();
        }
        public static string Input { get; set; }

    }
}
