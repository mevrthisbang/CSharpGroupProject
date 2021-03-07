using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class BagDAO
    {
        static string strConnection;
        public BagDAO()
        {
            getConnectionString();
        }
        public string getConnectionString()
        {
            strConnection = ConfigurationManager.ConnectionStrings["BagStore"].ConnectionString;
            return strConnection;
        }
        public static BagDTO getBagbyID(string id)
        {
            BagDTO bag = new BagDTO();
            string SQL = "Select * from BagTBL where bagID=@ID";
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BagStore"].ConnectionString);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                { cnn.Open(); }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string ID = reader["bagID"].ToString();
                    string name = reader["bagName"].ToString();
                    string image = reader["image"].ToString();
                    string description = reader["description"].ToString();
                    string origin = reader["origin"].ToString();
                    string size = reader["size"].ToString();
                    int quantity = int.Parse(reader["quantity"].ToString());
                    double price = double.Parse(reader["price"].ToString());
                    string status = reader["status"].ToString();
                    DateTime createDate = DateTime.Parse(reader["createDate"].ToString());
                    string bagCate = reader["bagCID"].ToString();

                    bag.id = ID;
                    bag.name = name;
                    bag.image = image;
                    bag.description = description;
                    bag.origin = origin;
                    bag.size = size;
                    bag.quantity = quantity;
                    bag.price = price;
                    bag.status = status;
                    bag.date = createDate;
                    bag.category = bagCate;
                    bag.price = price;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return bag;
        }
    }
}
