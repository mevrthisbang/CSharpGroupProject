using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WCF.Entities
{
    [MessageContract]
    public class FileData
    {
        [MessageHeader]
        public string fileName { get; set; }

        [MessageBodyMember]
        public System.IO.Stream Stream { get; set; }
    }
}