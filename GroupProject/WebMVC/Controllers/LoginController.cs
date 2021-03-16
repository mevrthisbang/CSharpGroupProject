using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("~/Views/Login.cshtml");
        }
        public ActionResult Login(string Username, string Password, string returnUrl)
        {
            return View();
        }
    }
}