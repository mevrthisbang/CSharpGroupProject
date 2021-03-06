﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountService" in both code and config file together.
    [ServiceContract]
    public interface IWCFAccountService
    {
        [OperationContract]
        Account Find(string username);
        [OperationContract]
        string Login(string username, string password);
        [OperationContract]
        bool Register(Account account);
        [OperationContract]
        string GetUserRole(string username);
        [OperationContract]
        string GetUserPhone(string phone);
    }
}
