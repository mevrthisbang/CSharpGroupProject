﻿using MultipleDataProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using WCF.Entities;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFBagService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WCFBagService.svc or WCFBagService.svc.cs at the Solution Explorer and start debugging.
    public class WCFBagService : IWCFBagService
    {
        DataProvider dp = new DataProvider();
        public bool AddNewBag(Bag bag)
        {
            string SQL =
                "Insert into BagTBL(bagID, bagName, image, description, origin, size, price, quantity, bagCID, status) " +
                "values(@ID,@Name,@Image,@Description,@Origin,@Size,@Price,@Quantity,@BagCID, 'Active')";
            DataParameter id = new DataParameter { Name = "@ID", Value = bag.BagID };
            DataParameter name = new DataParameter { Name = "@Name", Value = bag.BagName };
            DataParameter image = new DataParameter { Name = "@Image", Value = bag.Image };
            DataParameter description = new DataParameter { Name = "@Description", Value = bag.Description };
            DataParameter origin = new DataParameter { Name = "@Origin", Value = bag.Origin };
            DataParameter size = new DataParameter { Name = "@Size", Value = bag.size };
            DataParameter price = new DataParameter { Name = "@Price", Value = bag.Price };
            DataParameter quantity = new DataParameter { Name = "@Quantity", Value = bag.Quantity };
            DataParameter bagCID = new DataParameter { Name = "@BagCID", Value = bag.BagCID };
            try
            {
                return dp.executeNonQuery(SQL, CommandType.Text, id, name, image, description, origin, size, price, quantity, bagCID);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }

        public bool DeleteBag(string bagID)
        {
            string SQL = "Update BagTBL set status='Deactive' " +
                "where bagID=@ID";
            DataParameter id = new DataParameter { Name = "@ID", Value = bagID };
            try
            {
                return dp.executeNonQuery(SQL, CommandType.Text, id);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }

        public List<Bag> GetAllBooksForAdmin()
        {
            List<Bag> bagList = null;
            string sqlSelect = "select bagID, bagName, image, quantity, price, status, bagCID from BagTBL " +
                "Order by createDate DESC"
                ;
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sqlSelect, CommandType.Text);
            if (rd.HasRows)
            {
                bagList = new List<Bag>();
                while (rd.Read())
                {
                    Bag bag = new Bag
                    {
                        BagID = rd.GetString(0),
                        BagName = rd.GetString(1),
                        Image = rd.GetString(2),
                        Quantity = rd.GetInt32(3),
                        Price = Convert.ToDouble(rd.GetDecimal(4)),
                        Status = rd.GetString(5),
                        BagCID=rd.GetString(6)
                    };
                    bagList.Add(bag);
                }
            }
            return bagList;
        }

        public List<Bag> GetAllBooksForUser()
        {
            List<Bag> bagList = null;
            string sqlSelect = "select bagID, bagName, image, origin, size, price from BagTBL " +
                "Where status='Active' and quantity>0 " +
                "Order by createDate DESC";
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sqlSelect, CommandType.Text);
            if (rd.HasRows)
            {
                bagList = new List<Bag>();
                while (rd.Read())
                {
                    Bag bag = new Bag
                    {
                        BagID = rd.GetString(0),
                        BagName = rd.GetString(1),
                        Image = rd.GetString(2),
                        Origin = rd.GetString(3),
                        size = rd.GetString(4),
                        Price = Convert.ToDouble(rd.GetDecimal(5))
                    };
                    bagList.Add(bag);
                }
            }
            return bagList;
        }

        public Bag GetBagByID(string id)
        {
            Bag bag = null;
            string sqlSelect = "select bagName, image, origin, size, price, status, bagCID, quantity, description from BagTBL Where bagID=@ID";
            DataParameter bagID = new DataParameter { Name = "@ID", Value = id };
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sqlSelect, CommandType.Text, bagID);
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    bag = new Bag
                    {
                        BagID = id,
                        BagName = rd.GetString(0),
                        Image = rd.GetString(1),
                        Origin = rd.GetString(2),
                        size = rd.GetString(3),
                        Price = Convert.ToDouble(rd.GetDecimal(4)),
                        Status = rd.GetString(5),
                        BagCID=rd.GetString(6),
                        Quantity=rd.GetInt32(7), 
                        Description=rd.GetString(8)
                    };
                }
            }
            return bag;
        }

        public bool UpdateBag(Bag bag)
        {
            string SQL = "Update BagTBL set bagName=@Name,image=@Image,description=@Description,origin=@Origin," +
                "size=@Size, price=@Price, quantity=@Quantity, bagCID=@BagCID, status=@Status" +
                " where bagID=@ID";
            DataParameter name = new DataParameter { Name = "@Name", Value = bag.BagName };
            DataParameter image = new DataParameter { Name = "@Image", Value = bag.Image };
            DataParameter description = new DataParameter { Name = "@Description", Value = bag.Description };
            DataParameter origin = new DataParameter { Name = "@Origin", Value = bag.Origin };
            DataParameter size = new DataParameter { Name = "@Size", Value = bag.size };
            DataParameter price = new DataParameter { Name = "@Price", Value = bag.Price };
            DataParameter quantity = new DataParameter { Name = "@Quantity", Value = bag.Quantity };
            DataParameter bagCID = new DataParameter { Name = "@BagCID", Value = bag.BagCID };
            DataParameter status = new DataParameter { Name = "@Status", Value = bag.Status };
            DataParameter id = new DataParameter { Name = "@ID", Value = bag.BagID };
            try
            {
                return dp.executeNonQuery(SQL, CommandType.Text, name, image, description, origin, size, price, quantity, bagCID, status, id);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
        }
        public string GetLastBagID()
        {
            string result = null;
            string sqlSelect = "Select bagID From BagTBL "
                    + "Where createDate=(Select MAX(createDate) "
                    + "From BagTBL)";
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sqlSelect, CommandType.Text);
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    result = rd.GetString(0);
                }
            }
            return result;
        }
        public bool Checkout(Order order)
        {
            bool result = false;
            string SQLInsertOrder = "Insert Into OrderTBL(orderID, username, total, status) " +
                "Values(@ID, @Customer, @Total, 'Verifying')";
            DataParameter ID = new DataParameter { Name = "@ID", Value = order.OrderID };
            DataParameter Customer = new DataParameter { Name = "@Customer", Value = order.Customer };
            DataParameter Total = new DataParameter { Name = "@Total", Value = order.Total };
            string SQLInsertOrderDetail = "Insert Into OrderDetailTBL(orderDetailID, orderID, bagID, quantity, price) " +
                "Values(@DetailID, @ID, @BagID, @Quantity, @Price)";

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    dp.executeNonQuery(SQLInsertOrder, CommandType.Text, ID, Customer, Total);
                    int count = 1;
                    foreach (Bag bag in order.ListBuyBags.Values)
                    {
                        DataParameter DetailID = new DataParameter { Name = "@DetailID", Value = order.OrderID + "_" + count };
                        DataParameter BagID = new DataParameter { Name = "@BagID", Value = bag.BagID };
                        DataParameter Quantity = new DataParameter { Name = "@Quantity", Value = bag.Quantity };
                        DataParameter Price = new DataParameter { Name = "@Price", Value = bag.Price };
                        dp.executeNonQuery(SQLInsertOrderDetail, CommandType.Text, DetailID, ID, BagID, Quantity, Price);
                        count++;
                    }
                    scope.Complete();
                }
                result = true;

            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            return result;
        }

        public string GetLastOrderID(string username)
        {
            string result = null;
            string sqlSelect = "Select orderID From OrderTBL "
                    + "Where dateOrder=(Select MAX(dateOrder) "
                    + "From OrderTBL " +
                    "Where username=@UserName)";
            DataParameter UserName = new DataParameter { Name = "@UserName", Value = username };
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sqlSelect, CommandType.Text, UserName);
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    result = rd.GetString(0);
                }
            }
            return result;
        }

        public int CheckQuantity(string BagID)
        {
            int result = 0;
            string sqlSelect = "Select quantity From BagTBL "
                    + "Where bagID=@ID";
            DataParameter ID = new DataParameter { Name = "@ID", Value = BagID };
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sqlSelect, CommandType.Text, ID);
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    result = rd.GetInt32(0);
                }
            }
            return result;
        }

        public List<Order> GetOrderHistoryByUser(string username)
        {
            List<Order> orderList = null;
            string sqlSelect = "Select orderID, username, dateOrder, status "
                    + "From OrderTBL "
                    + "Where username=@Username " +
                    "Order by dateOrder DESC";
            DataParameter Username = new DataParameter { Name = "@Username", Value = username };
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sqlSelect, CommandType.Text, Username);
            if (rd.HasRows)
            {
                orderList = new List<Order>();
                while (rd.Read())
                {
                    Order order = new Order
                    {
                        OrderID=rd.GetString(0),
                        Customer=rd.GetString(1),
                        CreateDate=rd.GetDateTime(2),
                        status=rd.GetString(3),
                    };
                    orderList.Add(order);
                }
            }
            return orderList;
        }
        public Order GetOrderByOrderID(string orderID)
        {
            Order order = null;
            string sqlSelect = "Select B.bagName, OD.bagID, OD.quantity, OD.price "
                        + "From BagTBL B JOIN OrderDetailTBL OD ON B.bagID = OD.bagID "+
                         "Where orderID=@ID";
            DataParameter ID = new DataParameter { Name = "@ID", Value = orderID };
            SqlDataReader rd = (SqlDataReader)dp.executeQueryWithDataReader(sqlSelect, CommandType.Text, ID);
            if (rd.HasRows)
            {
                order = new Order();
                Dictionary<string, Bag> listBoughtBag = new Dictionary<string, Bag>();
                while (rd.Read())
                {
                    listBoughtBag.Add(rd.GetString(1),
                        new Bag
                        {
                            BagID = rd.GetString(1),
                            BagName = rd.GetString(0),
                            Quantity = rd.GetInt32(2),
                            Price = Convert.ToDouble(rd.GetDecimal(3))
                        });
                }
                order.ListBuyBags = listBoughtBag;
            }
            return order;
        }
    }
}
