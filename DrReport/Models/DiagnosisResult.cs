using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class DiagnosisResult
    {
        public DiagnosisResult()
        {
            Candidates = new HashSet<Candidate>();
            DiseaseExistDresults = new HashSet<DiseaseExistDresult>();
            DtestDresults = new HashSet<DtestDresult>();
            GdtestDresults = new HashSet<GdtestDresult>();
            Gives = new HashSet<Give>();
            Reserves = new HashSet<Reserve>();
        }

        public int Id { get; set; }
        public string AutoDresult { get; set; }
        public double? StatDresult { get; set; }
        public string DoctorNote { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<DiseaseExistDresult> DiseaseExistDresults { get; set; }
        public virtual ICollection<DtestDresult> DtestDresults { get; set; }
        public virtual ICollection<GdtestDresult> GdtestDresults { get; set; }
        public virtual ICollection<Give> Gives { get; set; }
        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
