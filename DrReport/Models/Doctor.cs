using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Candidates = new HashSet<Candidate>();
            Clinics = new HashSet<Clinic>();
            DiagnosisTests = new HashSet<DiagnosisTest>();
            DoctorCrudCdoctors = new HashSet<DoctorCrudCdoctor>();
            GeneralDiagnosisTests = new HashSet<GeneralDiagnosisTest>();
            Gives = new HashSet<Give>();
            Reserves = new HashSet<Reserve>();
        }

        public int Id { get; set; }
        public int? MedicalLicenseId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<Clinic> Clinics { get; set; }
        public virtual ICollection<DiagnosisTest> DiagnosisTests { get; set; }
        public virtual ICollection<DoctorCrudCdoctor> DoctorCrudCdoctors { get; set; }
        public virtual ICollection<GeneralDiagnosisTest> GeneralDiagnosisTests { get; set; }
        public virtual ICollection<Give> Gives { get; set; }
        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
