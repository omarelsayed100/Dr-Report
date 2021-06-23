using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DrReport.Models
{
    public partial class Clinic
    {
        public Clinic()
        {
            Greserves = new HashSet<Greserve>();
            Reserves = new HashSet<Reserve>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public DateTime? ApOpentime { get; set; }
        public DateTime? ApClosetime { get; set; }
        public string Location { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Greserve> Greserves { get; set; }
        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
