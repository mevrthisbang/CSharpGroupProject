using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.BagCategoryService;

namespace WebMVC
{
    public class GlobalVariables
    {
        public static BagCategory[] GetCategories()
        {
            WCFBagCategoryServiceClient BagCategoryData = new WCFBagCategoryServiceClient();
            return BagCategoryData.getAllCategories();
        }
    }
}