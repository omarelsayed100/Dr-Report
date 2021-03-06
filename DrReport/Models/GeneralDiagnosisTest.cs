using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class GeneralDiagnosisTest
    {
        public GeneralDiagnosisTest()
        {
            DiseaseRelateGdtests = new HashSet<DiseaseRelateGdtest>();
            GdtestDresults = new HashSet<GdtestDresult>();
            GdtestRelateDtests = new HashSet<GdtestRelateDtest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<DiseaseRelateGdtest> DiseaseRelateGdtests { get; set; }
        public virtual ICollection<GdtestDresult> GdtestDresults { get; set; }
        public virtual ICollection<GdtestRelateDtest> GdtestRelateDtests { get; set; }
    }
}
