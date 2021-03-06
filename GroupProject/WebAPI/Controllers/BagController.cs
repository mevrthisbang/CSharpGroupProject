using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class BagController : ApiController
    {
        private BagStoreEntities db = new BagStoreEntities();
        [HttpGet]
        public IEnumerable<BagTBL> GetActiveBagList()
        {
            return db.BagTBLs.Select(bag => new BagTBL
            {
                bagID = bag.bagID,
                bagName = bag.bagName,
                image=bag.image,
                price=bag.price,
                quantity=bag.quantity,
                size=bag.size,
                status=bag.status
            }).Where(bag=>bag.status.Equals("Active")&& bag.quantity > 0
            ).AsEnumerable();  
        }
    }
}
