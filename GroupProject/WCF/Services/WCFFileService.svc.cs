using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Hosting;
using WCF.Entities;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFFileService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WCFFileService.svc or WCFFileService.svc.cs at the Solution Explorer and start debugging.
    public class WCFFileService : IWCFFileService
    {
        public void UploadFile(FileData fileData)
        {
            System.Drawing.Image newImage;
            string FilePath = Path.Combine(HostingEnvironment.MapPath("~/img/"), fileData.fileName);
            byte[] buffer;
            var memoryStream = new MemoryStream();

            fileData.Stream.CopyTo(memoryStream);
            buffer = memoryStream.ToArray();
            memoryStream = new MemoryStream(buffer);
            using (newImage = System.Drawing.Image.FromStream(memoryStream))
            {
                newImage.Save(Path.Combine(HostingEnvironment.MapPath("~/img/"), fileData.fileName));

            }
        }
    }
}
