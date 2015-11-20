using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodnStuff.Model
{
    public class RecipeHistoryManagement
    {
        public void AddNewHR(string uid,string rid)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "INSERT INTO CookingRecipeHistory (UserID,RecipeID,CookingDate) VALUES ('" + uid + "','" + rid + "','"   + DateTime.Now.Date.ToString() + "');";
            myDatabase.ExcuteNonQuery(command);
            
        }
    }
}