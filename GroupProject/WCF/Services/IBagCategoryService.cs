using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBagCategoryService" in both code and config file together.
    [ServiceContract]
    public interface IBagCategoryService
    {
        [OperationContract]
        List<BagCategory> getAllCategories();
    }
}
