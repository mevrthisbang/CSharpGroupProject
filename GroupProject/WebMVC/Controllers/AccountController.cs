using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMVC.AccountService;

namespace WebMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("~/Views/Login.cshtml");
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password, string returnUrl)
        {
            WCFAccountServiceClient accountServiceClient = new WCFAccountServiceClient();
            string role = accountServiceClient.Login(Username, Password);
            if (role != null)
            {
                if (role.Trim().Equals("admin"))
                {
                    return RedirectToAction("Admin", "Home");
                }
                else if(role.Trim().Equals("customer"))
                {
                    return RedirectToAction("Customer", "Home");
                }
                var Ticket = new FormsAuthenticationTicket(1,
                    Username,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(120), // expiry
                    false,
                    role,
                    "/");
                string Encrypt = FormsAuthentication.Encrypt(Ticket);
                var cookies = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);
                cookies.Expires.AddMinutes(120);
                cookies.HttpOnly = true;
                Response.Cookies.Add(cookies);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
            }
            return View("~/Views/Login.cshtml");
        }
    }
}