using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDataProvider
{
    public class ConfigSetting
    {
        //Ket noi nhieu database 
        private IDbConnection icnn;
        private IDbCommand icmd;
        private IDataAdapter iadp;
        private IDataReader ird;
        public IDbConnection GetConnection
        {
            get { return icnn; }
        }
        public IDbCommand GetCommand
        {
            get { return icmd; }
        }
        public IDataAdapter GetAdapter
        {
            get { return iadp; }
        }
        public void Init()
        {
            string strConnection;
            string driverActive = ConfigurationManager.AppSettings["DriverActive"];
            if (driverActive == "SqlServer")
            {
                strConnection = ConfigurationManager.ConnectionStrings["SqlNW"].ConnectionString;
                icnn = new SqlConnection(strConnection);
                icmd = icnn.CreateCommand();
                iadp = new SqlDataAdapter(icmd as SqlCommand);
            }
            else if (driverActive == "Access")
            {
                strConnection = ConfigurationManager.ConnectionStrings["OleNW"].ConnectionString;
                icnn = new OleDbConnection(strConnection);
                icmd = icnn.CreateCommand();
                iadp = new OleDbDataAdapter(icmd as OleDbCommand);
            }
            else if (driverActive == "Oracle")
            {
                strConnection = ConfigurationManager.ConnectionStrings["OracleNW"].ConnectionString;
                icnn = new OracleConnection(strConnection);
                icmd = icnn.CreateCommand();
                iadp = new OracleDataAdapter(icmd as OracleCommand);
            }
        }
    }
}

