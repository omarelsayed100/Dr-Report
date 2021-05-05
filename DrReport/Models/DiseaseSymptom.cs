using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class DiseaseSymptom
    {
        public int DiseaseId { get; set; }
        public string Symptom { get; set; }

        public virtual Disease Disease { get; set; }
    }
}
