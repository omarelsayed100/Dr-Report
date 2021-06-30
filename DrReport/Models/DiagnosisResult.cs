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
        }

        public int Id { get; set; }
        public int ReserveId { get; set; }
        public string DoctorNote { get; set; }
        public int? CandidateDoctorId { get; set; }
        public string HasDiagnosis { get; set; }
        public string AutoDiagnosis { get; set; }
        public double? Accuracy { get; set; }

        public virtual CandidateDoctor CandidateDoctor { get; set; }
        public virtual Reserve Reserve { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<DiseaseExistDresult> DiseaseExistDresults { get; set; }
        public virtual ICollection<DtestDresult> DtestDresults { get; set; }
        public virtual ICollection<GdtestDresult> GdtestDresults { get; set; }
        public virtual ICollection<Give> Gives { get; set; }
    }
}
