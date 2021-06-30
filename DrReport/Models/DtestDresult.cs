using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class DtestDresult
    {
        public int DresultId { get; set; }
        public int DtestId { get; set; }
        public string ResultValue { get; set; }

        public virtual DiagnosisResult Dresult { get; set; }
        public virtual DiagnosisTest Dtest { get; set; }
    }
}
