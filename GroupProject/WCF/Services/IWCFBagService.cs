using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Entities;

namespace WCF
{
    [ServiceContract]
    public interface IBagService
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
    }
}