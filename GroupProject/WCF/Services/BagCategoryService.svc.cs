using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BagCategoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BagCategoryService.svc or BagCategoryService.svc.cs at the Solution Explorer and start debugging.
    public class BagCategoryService : IBagCategoryService
    {
        DataProvider dp = new DataProvider();

        public List<BagCategory> getAllCategories()
        {
            List<BagCategory> bagCateList = null;
            string sqlSelect = "select bagCID, name from CategoryTBL"
                ;
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sqlSelect, CommandType.Text);
            if (rd.HasRows)
            {
                bagCateList = new List<BagCategory>();
                while (rd.Read())
                {
                    BagCategory bagCate = new BagCategory
                    {
                        bagCID=rd.GetString(0),
                        CateName=rd.GetString(1)
                    };
                    bagCateList.Add(bagCate);
                }
            }
            return bagCateList;
        }
    }
    }
}
