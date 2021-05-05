using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class DoctorCrudCdoctor
    {
        public int DoctorId { get; set; }
        public int CdoctorId { get; set; }

        public virtual CandidateDoctor Cdoctor { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
