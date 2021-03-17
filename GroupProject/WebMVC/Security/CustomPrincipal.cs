using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WebMVC.AccountService;

namespace WebMVC.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Account account;

        public CustomPrincipal(Account account)
        {
            this.account = account;
            this.Identity = new GenericIdentity(account.UserName);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            return role.ToUpper().Trim().Equals(this.account.Role.ToUpper().Trim());
        }
    }
}