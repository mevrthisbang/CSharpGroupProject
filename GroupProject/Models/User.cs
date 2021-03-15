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

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must contains at least {2} characters", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must contains at least {2} characters", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(50, ErrorMessage = "The {0} must contains at least {2} characters", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters", MinimumLength = 3)]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public bool RememberMe = false;
    }
}
