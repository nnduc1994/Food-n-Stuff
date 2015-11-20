using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodnStuff.Model
{
    public class StorageManagement
    {
        public static void CreateStorage(string uname)
        {
            string id = "";
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM UserTable Where UserName='" + uname + "'";
            var reader = myDatabase.ExcuteQuery(command);
            reader.Read();
            if (reader.HasRows == true)
            {
                id = reader["ID"].ToString();
            }
            command = "INSERT INTO Storage (Name,OwnerId) VALUES ('" + uname + "Storage" + "','" + id + "');";
            myDatabase.ExcuteNonQuery(command);

        }

    }
}