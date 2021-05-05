using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class Clinic
    {
        public Clinic()
        {
            Doctors = new HashSet<Doctor>();
            Greserves = new HashSet<Greserve>();
            Reserves = new HashSet<Reserve>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public DateTime ApOpentime { get; set; }
        public DateTime ApClosetime { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Greserve> Greserves { get; set; }
        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
