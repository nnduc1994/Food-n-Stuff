﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodnStuff.Model
{
    public class RecipeHistoryManagement
    {
        public static void AddNewHR(int uid,int rid)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "INSERT INTO CookingRecipeHistory (UserID,RecipeID,CookingDate) VALUES ('" + uid + "','" + rid + "','"   + DateTime.Now.Date.ToString() + "');";
            myDatabase.ExcuteNonQuery(command);
            
        }
        public List<string> GetRecList(int uid) 
        {
            List<string> RecList = new List<string>();
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM CookingRecipeHistory Where UserID=" + uid + "";
            var reader = myDatabase.ExcuteQuery(command);
            bool notEOF = false;
            notEOF = reader.Read();
            while (notEOF)
            {
                RecList.Add(reader["RecipeID"].ToString());
                notEOF = reader.Read();
           
            }
            return RecList;
        }

        public List<string> FindRecList(int uid)
        {
            List<string> RecList = new List<string>();
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM Recipe Where Name LIKE '%" + uid + "%'";
            var reader = myDatabase.ExcuteQuery(command);
            bool notEOF = false;
            notEOF = reader.Read();
            while (notEOF)
            {
                RecList.Add(reader["RecipeID"].ToString());
                notEOF = reader.Read();

            }
            return RecList;
        }
    }
}