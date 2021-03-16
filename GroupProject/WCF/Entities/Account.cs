using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Entities
{
    public class Account
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public string Address { get; set; }
        public string Role { get; set; }
    }
}