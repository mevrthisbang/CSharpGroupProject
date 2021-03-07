using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class BagDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string origin { get; set; }
        public string size { get; set; }
        public string category { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
    }
}