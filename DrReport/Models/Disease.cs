using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class Disease
    {
        public Disease()
        {
            DiseaseExistDresults = new HashSet<DiseaseExistDresult>();
            DiseaseRelateDtests = new HashSet<DiseaseRelateDtest>();
            DiseaseRelateGdtests = new HashSet<DiseaseRelateGdtest>();
            DiseaseSymptoms = new HashSet<DiseaseSymptom>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DiseaseExistDresult> DiseaseExistDresults { get; set; }
        public virtual ICollection<DiseaseRelateDtest> DiseaseRelateDtests { get; set; }
        public virtual ICollection<DiseaseRelateGdtest> DiseaseRelateGdtests { get; set; }
        public virtual ICollection<DiseaseSymptom> DiseaseSymptoms { get; set; }
    }
}
