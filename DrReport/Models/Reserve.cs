using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class Reserve
    {
        public Reserve()
        {
            DiagnosisResults = new HashSet<DiagnosisResult>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ClinicId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime RequestDate { get; set; }
        public int DoctorId { get; set; }
        public string DtestName { get; set; }
        public string PotentialDisease { get; set; }

        public virtual Clinic Clinic { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<DiagnosisResult> DiagnosisResults { get; set; }
    }
}
