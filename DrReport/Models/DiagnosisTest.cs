using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class DiagnosisTest
    {
        public DiagnosisTest()
        {
            DiagnosisTestRanges = new HashSet<DiagnosisTestRange>();
            DtestDresults = new HashSet<DtestDresult>();
            GdtestRelateDtests = new HashSet<GdtestRelateDtest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<DiagnosisTestRange> DiagnosisTestRanges { get; set; }
        public virtual ICollection<DtestDresult> DtestDresults { get; set; }
        public virtual ICollection<GdtestRelateDtest> GdtestRelateDtests { get; set; }
    }
}
