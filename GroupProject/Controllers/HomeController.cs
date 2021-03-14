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
    public class HomeController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["StoreDB"].ConnectionString;

        [Authorize] 
        public ActionResult Index()
        {
            User user =  (User)Session["Name"];
            if (user != null)
            {
                ViewData["FullName"] = user.FullName();
            }
            else
                ViewData["FullName"] = "Guest";
            ViewBag.Title = "Home Page";
            return View();
        }
/*
        private string FullName(string username)
        {
            string firstName = "";
            string lastName = "";
            SqlDataReader rs;
            SqlConnection cnn = new SqlConnection(connectionString);
            string sql = "Select FirstName, LastName From [BagStore].[dbo].[User] where " +
                "Username=@Username";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Username", username);
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                rs = cmd.ExecuteReader();
                if (rs.Read())
                {
                    firstName = rs["FirstName"].ToString();
                    lastName = rs["LastName"].ToString();
                }
                return firstName + lastName;
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
*/
//        public ActionResult AuthorizedIndex()
//        {
//            return View();
//        }
    }
}
