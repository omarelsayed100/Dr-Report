using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class DiseaseExistDresult
    {
        public int DiseaseId { get; set; }
        public int DresultId { get; set; }

        public virtual Disease Disease { get; set; }
        public virtual DiagnosisResult Dresult { get; set; }
    }
}
