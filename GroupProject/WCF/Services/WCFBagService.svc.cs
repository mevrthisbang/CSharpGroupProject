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
            string sqlSelect = "select bagID, bagName, image, origin, size, price, status from BagTBL"
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
                        Origin = rd.GetString(3),
                        size = rd.GetString(4),
                        Price = Convert.ToDouble(rd.GetDecimal(5)),
                        Status = rd.GetString(6)
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
                "Where status='Active' and quantity>0";
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
    }
}
