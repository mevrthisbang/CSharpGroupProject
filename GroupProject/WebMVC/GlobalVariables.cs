using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.BagCategoryService;

namespace WebMVC
{
    public class GlobalVariables
    {
        private static WCFBagCategoryServiceClient BagCategoryData = new WCFBagCategoryServiceClient();
        public static BagCategory[] Categories = BagCategoryData.getAllCategories();
    }
}