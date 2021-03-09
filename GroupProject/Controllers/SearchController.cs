using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search

        [HttpPost]
        //public ViewResult SearchbyName(FormCollection search)
        //{

        //    string searchValue = search["txtSearch"];
        //    BagData dao = new BagData();
        //    List<BagDTO> result = dao.searchBag(searchValue);

        //    return View("Index");
        //}

        public ActionResult Index()
        {
           

            return View();
        }
    }
}