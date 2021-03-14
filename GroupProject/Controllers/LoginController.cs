using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GroupProject.Controllers
{
    public class LoginController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["StoreDB"].ConnectionString;
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user, string returnUrl)
        {
            User u = isValidUser(user);
            if (u != null)
            {
                string fullName = u.FullName();
                FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                Session.Add("Name", u);
                
                if (returnUrl != null)
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Login Failed";
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("Name");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private User isValidUser(User user)
        {
            string username = user.UserName;
            string password = user.Password;
            SqlDataReader rs;
            SqlConnection cnn = new SqlConnection(connectionString);
            string sql = "Select UserID, Username, Password, FirstName, LastName, Email From [BagStore].[dbo].[User] where " +
                "Username=@Username AND " +
                "Password=@Password";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                rs = cmd.ExecuteReader();
                if (rs.Read())
                {
                    User lUser = new User();
                    lUser.ID = int.Parse(rs["UserID"].ToString());
                    lUser.UserName = username;
                    lUser.FirstName = rs["FirstName"].ToString();
                    lUser.LastName = rs["LastName"].ToString();
                    lUser.Email = rs["Email"].ToString();
                    lUser.Password = password;
                    return lUser;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        /*
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
        */
    }
}