using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupProject.Models.Account
{
    public class AccountDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["StoreDB"].ConnectionString;

        public AccountDAO()
        {
        }

        public bool CheckAccount(string username, string password)
        {
            SqlDataReader rs;
            SqlConnection cnn = new SqlConnection(connectionString);
            string SQL = "Select username from Account where Username=@Username" +
                " And Password=@Password";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            try
            {
                //cnn.Open();
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        public bool CheckUsername(string username)
        {
            SqlDataReader rs;
            SqlConnection cnn = new SqlConnection(connectionString);
            string SQL = "Select Username from Account where Username=@Username";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Username", username);
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        public bool AddAccount(string username, string password)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            string SQL = "Insert Account values" +
                "(@Username,@Password)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}