using GroupProject.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult CheckLogin(FormCollection frmCol)
        {
            ViewBag.Title = "Login to website";

            AccountDAO dao = new AccountDAO();
            string username = frmCol["txtUsername"];
            string password = frmCol["txtPassword"];

            if (dao.CheckAccount(username, password))
            {
                ViewBag.Message = "Welcome " + username;
                return View("~/Views/Welcome/Welcome.cshtml");
            }
            else
            {
                ViewBag.Message = "Logged in failed";
                // View("~/Views/Login/Login.cshtml");
                return View("Login");
            }
        }
    }
}