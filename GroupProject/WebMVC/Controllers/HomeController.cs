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
            ViewBag.Categories = HttpContext.Application["ListCategory"];
            WCFBagServiceClient bagServiceClient = new WCFBagServiceClient();
            ViewBag.Bags = bagServiceClient.GetAllBooksForUser();
            return View("~/Views/Admin.cshtml");
        }
    }
}