using System;
using System.Collections.Generic;

#nullable disable

namespace DrReport.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public int UserTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
