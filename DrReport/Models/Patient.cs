using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Candidates = new HashSet<Candidate>();
            Gives = new HashSet<Give>();
            Reserves = new HashSet<Reserve>();
        }

        public int Id { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<Give> Gives { get; set; }
        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
