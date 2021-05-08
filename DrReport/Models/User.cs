﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DrReport.Models
{
    public partial class User
    {
        public User()
        {
            Doctors = new HashSet<Doctor>();
            Patients = new HashSet<Patient>();
        }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Please Enter First Name"),StringLength(20)]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name"), StringLength(20)]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string Pn { get; set; }

        [Required(ErrorMessage = "Please enter Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
