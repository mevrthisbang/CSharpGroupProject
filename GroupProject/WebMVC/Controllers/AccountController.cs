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
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("~/Views/Login.cshtml");
        }
        [AllowAnonymous]
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
                else if (role.Trim().Equals("customer"))
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
        [AllowAnonymous]
        public ViewResult Register()
        {
            return View("~/Views/Register.cshtml");
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Account account, string Repassword)
        {
            string username = account.UserName;
            WCFAccountServiceClient accountServiceClient = new WCFAccountServiceClient();
            if (ModelState.IsValid)
            {
                bool check = true;

                if (accountServiceClient.Find(username) != null)
                {
                    check = false;
                    ModelState.AddModelError("UserName", "Username is already existed");
                }
                if (accountServiceClient.GetUserPhone(account.PhoneNumber) != null)
                {
                    ModelState.AddModelError("PhoneNumber", "Phone number is already existed");
                    check = false;
                }
                if (!account.Password.Equals(Repassword))
                {
                    ModelState.AddModelError("Repassword", "Does not match with password");
                    check = false;
                }
                if (check)
                {
                    if (accountServiceClient.Register(account))
                    {
                        ViewBag.Message = "Register Successfully!";
                        return View("~/Views/Login.cshtml");
                    }
                    else
                    {
                        ViewBag.Message = "Server is currently not available!";
                    }
                }
            }
            return View("~/Views/Register.cshtml", account);
        }
        [CustomAuthorize(Roles="admin,customer")]
        public ViewResult Logout()
        {
            SessionPersister.Username = null;
            FormsAuthentication.SignOut();
            return View("~/Views/Login.cshtml");
        }
    }
}
