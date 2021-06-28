using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class GdtestRelateDtest
    {
        public int GdtestId { get; set; }
        public int DtestId { get; set; }

        public virtual DiagnosisTest Dtest { get; set; }
        public virtual GeneralDiagnosisTest Gdtest { get; set; }
    }
}
