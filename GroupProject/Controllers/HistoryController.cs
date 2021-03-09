using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class HistoryController : Controller
    {
       
        // GET: History
        public ActionResult Index(string user)
        {
            BagData dao = new BagData();
            List<CartDTO> result = new List<CartDTO>();
            return View(result);
        }
    }
}