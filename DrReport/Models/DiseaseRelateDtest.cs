using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class DiseaseRelateDtest
    {
        public int DiseaseId { get; set; }
        public int DtestId { get; set; }

        public virtual Disease Disease { get; set; }
    }
}
