using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMVC.AccountService;
using WebMVC.Security;

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
        public ActionResult Login(string Username, string Password)
        {
            WCFAccountServiceClient accountServiceClient = new WCFAccountServiceClient();
            string role = accountServiceClient.Login(Username, Password);
            if (role != null)
            {
                SessionPersister.Username = Username;
                FormsAuthentication.SetAuthCookie(Username, false);
                if (role.Trim().Equals("admin"))
                {
                    return RedirectToAction("Admin", "Home");
                }
                else if(role.Trim().Equals("customer"))
                {
                    return RedirectToAction("Customer", "Home");
                }
                
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
            }
            return View("~/Views/Login.cshtml");
        }
    }
}