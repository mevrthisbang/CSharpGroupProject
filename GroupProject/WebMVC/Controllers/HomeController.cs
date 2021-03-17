using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BagService;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Categories = GlobalVariables.Categories;
            WCFBagServiceClient bagServiceClient = new WCFBagServiceClient();
            ViewBag.Bags = bagServiceClient.GetAllBooksForUser();
            return View("~/Views/Guest.cshtml");
        }
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Admin()
        {
            ViewBag.Categories = GlobalVariables.Categories;
            WCFBagServiceClient bagServiceClient = new WCFBagServiceClient();
            ViewBag.Bags = bagServiceClient.GetAllBooksForAdmin();
            return View("~/Views/Admin.cshtml");
        }
        
    }
}