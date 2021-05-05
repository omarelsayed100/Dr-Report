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
            DiseaseRelateDtests = new HashSet<DiseaseRelateDtest>();
            DtestDresults = new HashSet<DtestDresult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public int? GdtestId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<DiagnosisTestRange> DiagnosisTestRanges { get; set; }
        public virtual ICollection<DiseaseRelateDtest> DiseaseRelateDtests { get; set; }
        public virtual ICollection<DtestDresult> DtestDresults { get; set; }
    }
}
