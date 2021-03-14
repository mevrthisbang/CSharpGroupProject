using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class RegisterController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["StoreDB"].ConnectionString;
        // GET: Register
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            string username = user.UserName;
            string email = user.Email;
            if (!isUserExisted(username))
            {
                if (!isEmailExisted(email))
                {
                    addUser(user);
                    ViewBag.Message = "Register Successfully!";
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ViewBag.Message = "This Email is already existed";
                    return View(user);
                }
            }
            else
            {
                ViewBag.Message = "This user is already existed";
                return View(user);
            }
        }

        private bool addUser(User user)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string sql = "Insert into [BagStore].[dbo].[User](FirstName, LastName, Username, Password, Email) " +
                "Values(@FirstName, @LastName, @Username, @Password, @Email)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Username", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                int c = cmd.ExecuteNonQuery();
                if (c > 0)
                    return true;
                return false;
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

        private bool isUserExisted(string username)
        {
            SqlDataReader rs;
            SqlConnection cnn = new SqlConnection(connectionString);
            string sql = "Select Username From [BagStore].[dbo].[User] where " +
                "Username=@Username";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Username", username);
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    return true;
                }
                return false;
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

        private bool isEmailExisted(string email)
        {
            SqlDataReader rs;
            SqlConnection cnn = new SqlConnection(connectionString);
            string sql = "Select Email From [BagStore].[dbo].[User] where " +
                "Email=@Email";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Email", email);
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    return true;
                }
                return false;
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
                public ActionResult RegisterAccount(FormCollection frmCol)
                {
                    //AccountDAO dao = new AccountDAO();
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
        */
    }
}