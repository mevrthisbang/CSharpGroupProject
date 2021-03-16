using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountService.svc or AccountService.svc.cs at the Solution Explorer and start debugging.
    public class AccountService : IWCFAccountService
    {
        public string GetUserRole(string username)
        {
            throw new NotImplementedException();
        }

        public Account Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
