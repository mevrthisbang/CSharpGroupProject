using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject
{
    public class BagDTO
    {
        public string bagID { get; set; }
        public string bagName { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string origin { get; set; }
        public string size { get; set; }

        public double price { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public string createDate { get; set; }
        public string bagCID { get; set; }

    }
}