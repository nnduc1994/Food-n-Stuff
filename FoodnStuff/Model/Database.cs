using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace FoodnStuff.Model
{
    public class Database
    {
        String connstr;
        String projectPath;
        OleDbConnection myConnection;
        OleDbCommand myCommand;
        OleDbDataReader myReader;

        public Database()
        {
            projectPath = @"C:\Users\nguyngo2\Downloads\DatabaseExample";
            connstr = "Provider = Microsoft.Jet.OLEDB.4.0;" +
                 @"Data Source = " + projectPath + @"\Data\CustomerOrders2014.mdb;";
            //OleDbConnection requires namespace System.Data.OleDb
            myConnection = new OleDbConnection();
            myConnection.ConnectionString = connstr;
            myConnection.Open();
        }
        public OleDbConnection ReturnConnection()
        {
            return myConnection;
        }

        public void ExcuteNonQuery(string command)
        {
            myCommand = new OleDbCommand();
            myCommand.CommandText = command;
            myCommand.Connection = this.myConnection;
            myCommand.ExecuteNonQuery();
        }

        public OleDbDataReader ExcuteQuery(string command)
        {
            myCommand = new OleDbCommand();
            myCommand.CommandText = command;
            myCommand.Connection = this.myConnection;
            myReader = myCommand.ExecuteReader();
            return myReader;
        }

        public void CloseConnection()
        {
            myConnection.Close();
        }
    }
}