using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class CartDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public DateTime date { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public int quantityCart { get; set; }
    }
}