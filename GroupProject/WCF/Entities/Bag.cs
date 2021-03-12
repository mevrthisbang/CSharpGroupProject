using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.Entities
{
    [DataContract]
    public class Bag
    {
        [DataMember]
        public string BagID { get; set; }
        [DataMember]
        public string BagName { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Origin { get; set; }
        [DataMember]
        public string size { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string BagCID { get; set; }
    }
}