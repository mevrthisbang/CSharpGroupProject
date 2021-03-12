using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroupProject
{
    public class BagData
    {
        string strConnection = "server=SE140157;database=BagStore;uid=sa;pwd=123456";
        private static List<BagDTO> list = new List<BagDTO>();

        public static List<BagDTO> BagList
        {
            get
            {
                return list;
            }
        }

        public List<BagDTO> GetBagList()
        {
            string SQL = "Select bagID,bagName,image,description,origin,size,price,quantity,status,bagCID from BagTBL";
            List<BagDTO> rs = new List<BagDTO>();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(SQL, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                BagDTO p = null;
                while (reader.Read())
                {
                    string id = reader.GetValue(0).ToString();
                    string name = reader.GetValue(1).ToString();
                    string image = reader.GetValue(2).ToString();
                    string description = reader.GetValue(3).ToString();
                    string origin = reader.GetValue(4).ToString();

                    string size = reader.GetValue(5).ToString();
                    float price = float.Parse(reader.GetValue(6).ToString());
                    int quantity = int.Parse(reader.GetValue(7).ToString());
                    string status = reader.GetValue(8).ToString();
                    string cid = reader.GetValue(9).ToString();
                    p = new BagDTO()
                    {
                        bagID = id,
                        bagName = name,
                        image = image,
                        description = description,
                        origin = origin,
                        size = size,
                        price = price,
                        quantity = quantity,
                        status = status,
                        bagCID = cid
                    };
                    rs.Add(p);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return rs;
        }


        // search by ID
        public BagDTO SearchByID(string id)
        {
            BagDTO p = null;
            string SQL = " Select bagName,image,description,origin,size,price,quantity,status,bagCID" +
                       " from BagTBL " +
                      "  where bagID = @ID";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    string name = reader.GetValue(0).ToString();
                    string image = reader.GetValue(1).ToString();
                    string description = reader.GetValue(2).ToString();
                    string origin = reader.GetValue(3).ToString();

                    string size = reader.GetValue(4).ToString();
                    float price = float.Parse(reader.GetValue(5).ToString());
                    int quantity = int.Parse(reader.GetValue(7).ToString());
                    string status = reader.GetValue(8).ToString();
                    string cid = reader.GetValue(9).ToString();

                    p = new BagDTO(id, name, image, price)
                    {

                        bagCID = cid,
                        description = description,
                        quantity = quantity,
                        status = status
                    };
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return p;
        }


        //search
        public List<BagDTO> searchBag(String searchValue)
        {
            string SQL = " select *" +
              "  from BagTBL" +
               "  where bagName = @Name";


            List<BagDTO> rs = new List<BagDTO>();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@Name", '%' + searchValue + '%');
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                BagDTO p = null;
                while (reader.Read())
                {
                    string id = reader.GetValue(0).ToString();
                    string name = reader.GetValue(1).ToString();
                    string image = reader.GetValue(2).ToString();
                    string description = reader.GetValue(3).ToString();
                    string origin = reader.GetValue(4).ToString();

                    string size = reader.GetValue(5).ToString();
                    float price = float.Parse(reader.GetValue(6).ToString());


                    p = new BagDTO()
                    {
                        bagID = id,
                        bagName = name,
                        image = image,
                        description = description,
                        origin = origin,
                        size = size,
                        price = price,

                    };
                    rs.Add(p);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return rs;
        }



        //history
        public List<CartDTO> loadHistoryOfUser(string user)
        {
            string SQL = "Select b.bagName as NameBag, b.price as PriceBag, od.quantity as quantityBag," +
            "o.dateOrder as Date ,o.status as Status From OrderTBL as o, OrderDetailTBL as od, BagTBL as b, AccountTBL as ac" +
            "where o.orderID = od.orderID and o.username = @Name and b.bagID = od.bagID and o.username = ac.username";
            List<CartDTO> rs = null;
            CartDTO dto = null;


            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@Name", '%' + user + '%');
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    string name = reader.GetValue(0).ToString();
                    float price = float.Parse(reader.GetValue(1).ToString());
                    int quan = int.Parse(reader.GetValue(2).ToString());
                    string date = reader.GetValue(3).ToString();
                    string statusOrder = reader.GetValue(4).ToString();
                    dto = new CartDTO()
                    {

                        bagName = name,
                        price = price,
                        quantity = quan,
                        date = date,
                        statusOrser = statusOrder
                    };
                    rs.Add(dto);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return rs;
        }

        // spham ban nhieu nhat
        //public List<BagDTO> reportBagOrder()
        //{
        //    string SQL = "Select TOP 5 bagID, bagName, image, price" +
        //                 "From BagTBL where status='Active' and quantity > 0 and counter > 0 " +
        //                 "Order by counter DESC";
        //    List<BagDTO> rs = null;
        //    BagDTO dto = null;

        //    SqlConnection connection = null;
        //    try
        //    {
        //        connection = new SqlConnection(strConnection);
        //        SqlCommand command = new SqlCommand(SQL, connection);
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            string id = reader.GetValue(0).ToString();
        //            string name = reader.GetValue(1).ToString();
        //            string image = reader.GetValue(2).ToString();
        //            float price = float.Parse(reader.GetValue(3).ToString());



        //            dto = new BagDTO()
        //            {
        //                bagID = id,
        //                bagName = name,
        //                image = image,
        //                price = price

        //            };
        //            rs.Add(dto);
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return rs;
        //}
    }
}