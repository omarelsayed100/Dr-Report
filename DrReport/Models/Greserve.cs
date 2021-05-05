using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class Greserve
    {
        public int? PatientId { get; set; }
        public int? GdtestId { get; set; }
        public int ClinicId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime RequestDate { get; set; }

        public virtual Clinic Clinic { get; set; }
        public virtual GeneralDiagnosisTest Gdtest { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
