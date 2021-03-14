using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
//using System.Web.Http;
//using System.Web.Mvc;

namespace GroupProject.Models
{
    public class User
    {
        public int ID { get; set; }

//        [Required]
//        [StringLength(50, ErrorMessage = "First Name must be 3-50 characters", MinimumLength = 3)]

        public string FirstName { get; set; }

//        [Required]
//        [StringLength(50, ErrorMessage = "Last Name must be 3-50 characters", MinimumLength = 3)]
        public string LastName { get; set; }

//        [Required]
        [StringLength(50, ErrorMessage = "User Name must be 3-50 characters", MinimumLength = 3)]
        public string UserName { get; set; }

//        [Required]
//        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email doesn't look like a valid email address.")]
        public string Email { get; set; }

//        [Required]
//        [DataType(DataType.Password)]
//        [StringLength(50, ErrorMessage = "User Name must be 6-50 characters", MinimumLength = 6)]
        public string Password { get; set; }

//        [NotMapped]
//        [Required]
//        [Compare("Password")]
//        public string F_Password { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public bool RememberMe = false;
    }
}
