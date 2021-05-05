using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class Reserve
    {
        public int? PatientId { get; set; }
        public int? DtestId { get; set; }
        public int ClinicId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime RequestDate { get; set; }

        public virtual Clinic Clinic { get; set; }
        public virtual DiagnosisResult Dtest { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
