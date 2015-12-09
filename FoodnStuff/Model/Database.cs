using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
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
            
            //Local
            projectPath = @"C:\Users\Anakom\Source\Repos\Food-n-Stuff\FoodnStuff";
            //Production
            //projectPath = Environment.GetEnvironmentVariable("HOME").ToString();

            //Local
            connstr = "Provider = Microsoft.Jet.OLEDB.4.0;" +
                @"Data Source = " + projectPath + @"\Data\FoodnStuff.mdb;";

            //Production
            //connstr = "Provider = Microsoft.Jet.OLEDB.4.0;" +
              //  @"Data Source = " + projectPath + @"\site\wwwroot\Data\FoodnStuff.mdb;";

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