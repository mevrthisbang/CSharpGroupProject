using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class BagCategoryController : ApiController
    {
        private BagStoreEntities db = new BagStoreEntities();
        [HttpGet]
        public IEnumerable<CategoryTBL> GetActiveBagList()
        {
            return db.CategoryTBLs;
        }
    }
}
