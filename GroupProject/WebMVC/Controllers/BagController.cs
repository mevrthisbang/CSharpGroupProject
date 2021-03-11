using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class BagController : Controller
    {
        // GET: Bag
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Create()
        {
            TempData["CreateOrEdit"] = "Create";
            return View("~/Views/Create.cshtml");
        }
    }
}