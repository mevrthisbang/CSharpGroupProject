using GroupProject.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult RegisterAccount(FormCollection frmCol)
        {
            AccountDAO dao = new AccountDAO();
            string username = frmCol["txtUsername"];
            string password = frmCol["txtPassword"];

            if (dao.CheckUsername(username))
            {
                ViewBag.Message = username + " is already existed";
                return View("Register");
            }
            else
            {
                if (dao.AddAccount(username, password))
                {
                    ViewBag.Message = "Registered successfully!";
                    return View("~/Views/Login/Login.cshtml");
                }
                ViewBag.Message = "Registered failed";
                return View("Register");
            }
        }
    }
}