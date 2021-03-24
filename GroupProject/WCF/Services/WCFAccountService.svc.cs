using MultipleDataProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountService.svc or AccountService.svc.cs at the Solution Explorer and start debugging.
    public class AccountService : IWCFAccountService
    {
        DataProvider dp = new DataProvider();

        public Account Find(string username)
        {
            Account account = null;
            string sql = "Select role from AccountTBL " +
                "Where username=@UserName";
            DataParameter UserName = new DataParameter { Name = "@UserName", Value = username };
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sql, CommandType.Text, UserName);
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    account = new Account
                    {
                        UserName = username,
                        Role = rd.GetString(0)
                    };
                }
            }
            return account;
        }

        public string GetUserRole(string username)
        {
            string role = null;
            string sql = "Select role from AccountTBL " +
                "Where username=@UserName";
            DataParameter UserName = new DataParameter { Name = "@UserName", Value = username };
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sql, CommandType.Text, UserName);
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    role = rd.GetString(0);
                }
            }
            return role;
        }
        public string GetUserPhone(string phone)
        {
            string role = null;
            string sql = "Select role from AccountTBL " +
                "Where phoneNumber=@PhoneNumber";
            DataParameter PhoneNumber = new DataParameter { Name = "@PhoneNumber", Value = phone };
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sql, CommandType.Text, PhoneNumber);
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    role = rd.GetString(0);
                }
            }
            return role;
        }

        public string Login(string username, string password)
        {
            string role = null;
            string sql = "Select role from AccountTBL " +
                "Where username=@UserName AND password=@Password AND isActive=1";
            DataParameter UserName = new DataParameter { Name="@UserName", Value=username };
            DataParameter Password = new DataParameter { Name = "@Password", Value = password };
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sql, CommandType.Text, UserName, Password);
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    role = rd.GetString(0);
                }
            }
            return role;
        }

        public bool Register(Account account)
        {
            string SQL =
                "Insert into AccountTBL(username, password, phoneNumber, fullName, role, address, isActive) " +
                "values(@Username, @Password, @phoneNumber, @fullName, 'customer', @Address, 1)";
            DataParameter Username = new DataParameter { Name = "@Username", Value = account.UserName };
            DataParameter Password = new DataParameter { Name = "@Password", Value = account.Password };
            DataParameter phoneNumber = new DataParameter { Name = "@phoneNumber", Value = account.PhoneNumber };
            DataParameter fullName = new DataParameter { Name = "@fullName", Value = account.FullName };
            DataParameter Address = new DataParameter { Name = "@Address", Value = account.Address };


            try
            {
                return dp.executeNonQuery(SQL, CommandType.Text, Username, Password, phoneNumber, fullName, Address);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
    }
}
