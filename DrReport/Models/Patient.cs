using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DrReport.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Candidates = new HashSet<Candidate>();
            Gives = new HashSet<Give>();
            Greserves = new HashSet<Greserve>();
            Reserves = new HashSet<Reserve>();
        }

        public int Id { get; set; }
        public int? Age { get; set; }
        [Required(ErrorMessage = "*")]
        public string Gender { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<Give> Gives { get; set; }
        public virtual ICollection<Greserve> Greserves { get; set; }
        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
