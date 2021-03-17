using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BagService;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Categories = GlobalVariables.Categories;
            WCFBagServiceClient bagServiceClient = new WCFBagServiceClient();
            ViewBag.Bags = bagServiceClient.GetAllBooksForUser();
            return View("~/Views/Guest.cshtml");
        }

        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult User()
        {
            return View();
        }
    }
}