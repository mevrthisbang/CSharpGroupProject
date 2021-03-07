using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class CartDTO
    {
        public BagDTO bag { get; set; }
        public int quantity { get; set; }
    }
}