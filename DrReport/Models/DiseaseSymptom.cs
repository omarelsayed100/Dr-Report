using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class DiseaseSymptom
    {
        public int Id { get; set; }
        public string Symptom { get; set; }
        public int? DiseaseId { get; set; }

        public virtual Disease Disease { get; set; }
    }
}
