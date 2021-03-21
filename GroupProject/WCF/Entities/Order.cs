using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Entities
{
    public class Order
    {
        public string OrderID { get; set; }
        public string Customer { get; set; }
        public double Total { get; set; }
        public string status { get; set; }
        public DateTime CreateDate { get; set; }
        public Dictionary<String, Bag> ListBuyBags { get; set; }
    }
}