using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class DiagnosisTestRange
    {
        public int DtestId { get; set; }
        public string PatientType { get; set; }
        public double? StartRange { get; set; }
        public double? EndRange { get; set; }

        public virtual DiagnosisTest Dtest { get; set; }
    }
}
