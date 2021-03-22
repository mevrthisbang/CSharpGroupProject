using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BagService;
using WebMVC.Security;

namespace WebMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            WCFBagServiceClient bagServiceClient = new WCFBagServiceClient();
            int pageSize = 4;
            Bag[] listBags = bagServiceClient.GetAllBooksForUser();
            ViewBag.pageCurrent = 1;
            int totalPage = listBags.Count();
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            ViewBag.Bags = listBags.Skip(0).Take(pageSize);
            return View("~/Views/Guest.cshtml");
        }
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Admin()
        {
            ViewBag.Categories = GlobalVariables.Categories;
            WCFBagServiceClient bagServiceClient = new WCFBagServiceClient();
            int pageSize = 4;
            Bag[] listBags = bagServiceClient.GetAllBooksForAdmin();
            ViewBag.pageCurrent = 1;
            int totalPage = listBags.Count();
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            ViewBag.Bags = listBags.Skip(0).Take(pageSize);
            return View("~/Views/Admin.cshtml");
        }
        [CustomAuthorize(Roles = "customer")]
        public ActionResult Customer()
        {
            ViewBag.Categories = GlobalVariables.Categories;
            WCFBagServiceClient bagServiceClient = new WCFBagServiceClient();
            int pageSize = 4;
            Bag[] listBags = bagServiceClient.GetAllBooksForUser();
            ViewBag.pageCurrent = 1;
            int totalPage = listBags.Count();
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            ViewBag.Bags = listBags.Skip(0).Take(pageSize);
            return View("~/Views/User.cshtml");
        }

    }
}