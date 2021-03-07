using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDataProvider
{
    public class DataProvider
    {
        private IDbConnection cnn;
        private IDbCommand cmd;
        private IDataAdapter adp;
        private IDataReader rd;
        public ConfigSetting cs = new ConfigSetting();
        public DataProvider()
        {
            cs.Init();
            cnn = cs.GetConnection;
        }
        //Thiet lap cac tham so cho command
        public void setValuesForCommand(string strSQL, CommandType cmdType, DataParameter[] paramList)
        {
            cmd = cs.GetCommand;
            cmd.CommandText = strSQL;
            cmd.CommandType = cmdType;
            cmd.Parameters.Clear();
            foreach (DataParameter param in paramList)
            {
                IDbDataParameter p = cmd.CreateParameter();
                p.ParameterName = param.Name;
                p.Value = param.Value;
                cmd.Parameters.Add(p);
            }
        }
        //Execute Query with DataSet
        public DataSet executeQueryWithDataSet(string strSQL, CommandType cmdType,
            params DataParameter[] paramList)
        {
            DataSet ds = new DataSet();
            try
            {
                setValuesForCommand(strSQL, cmdType, paramList);
                adp = cs.GetAdapter;
                adp.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return ds;
        }
        //Execute Query with DataReader   
        public IDataReader executeQueryWithDataReader(string strSQL,
            CommandType cmdType, params DataParameter[] paramList)
        {
            try
            {
                setValuesForCommand(strSQL, cmdType, paramList);
                cnn.Open();
                rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            return rd;
        }
        //ExecuteNonQuery
        public bool executeNonQuery(string strSQL, CommandType cmdType,
            params DataParameter[] paramList)
        {
            bool result = false;

            try
            {
                setValuesForCommand(strSQL, cmdType, paramList);
                cnn.Open();
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
    }
}
