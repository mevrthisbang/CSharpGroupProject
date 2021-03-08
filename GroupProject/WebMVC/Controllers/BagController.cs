using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BagCategoryService;

namespace WebMVC.Controllers
{
    public class BagController : Controller
    {
        // GET: Bag
        public ActionResult Index()
        {
            BagCategory[] bagCategories = (BagCategory[])HttpContext.Application["ListCategory"];
            return View("Admin", bagCategories);
        }
    }
}