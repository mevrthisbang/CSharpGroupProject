using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.Entities
{
    [DataContract]
    public class BagCategory
    {
        [DataMember]
        public string bagCID { get; set; }
        [DataMember]
        public string CateName { get; set; }

    }
}