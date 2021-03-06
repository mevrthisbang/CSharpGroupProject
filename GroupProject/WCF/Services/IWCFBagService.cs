﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFBagService" in both code and config file together.
    [ServiceContract]
    
    public interface IWCFBagService
    {
        [OperationContract]
        List<Bag> GetAllBooksForUser();
        [OperationContract]
        List<Bag> GetAllBooksForAdmin();
        [OperationContract]
        bool AddNewBag(Bag bag);
        [OperationContract]
        bool UpdateBag(Bag bag);
        [OperationContract]
        bool DeleteBag(string bagID);
        [OperationContract]
        Bag GetBagByID(string id);
        [OperationContract]
        string GetLastBagID();
        [OperationContract]
        string GetLastOrderID(string username);
        [OperationContract]
        bool Checkout(Order order);
        [OperationContract]
        int CheckQuantity(string BagID);
        [OperationContract]
        List<Order> GetOrderHistoryByUser(string username);
        [OperationContract]
        Order GetOrderByOrderID(string ID);
    }
}
