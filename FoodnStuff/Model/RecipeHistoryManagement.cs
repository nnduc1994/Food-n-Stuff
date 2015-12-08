using System;
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
            myDatabase.CloseConnection();
            
        }
        public static List<HistoryRecipe> GetRecList(int uid) 
        {
            List<HistoryRecipe> historyList  = new List<HistoryRecipe>();
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM CookingRecipeHistory Where UserID=" + uid + "";
            var reader = myDatabase.ExcuteQuery(command);
            bool notEOF = false;
            notEOF = reader.Read();
            while (notEOF)
            {
                HistoryRecipe recipeObj = new HistoryRecipe();
                recipeObj.RecipeID =  Convert.ToInt16(reader["RecipeID"]);
                recipeObj.CookingDate = Convert.ToDateTime(reader["CookingDate"]);
                historyList.Add(recipeObj);
                notEOF = reader.Read();
            }

            if (historyList.Count > 0) {
                foreach (HistoryRecipe recipe in historyList) {
                    string command2 = "SELECT Name FROM Recipe WHERE ID=" + recipe.RecipeID + ";";
                    var reader2 = myDatabase.ExcuteQuery(command2);
                    bool EOF2;
                    EOF2 = reader2.Read();
                    recipe.Name = reader2["Name"].ToString();
                    
                }
            }
            myDatabase.CloseConnection();
            return historyList;
        }

        //public List<string> FindRecList(int uid)
        //{
        //    List<string> RecList = new List<string>();
        //    Database myDatabase = new Database();
        //    myDatabase.ReturnConnection();
        //    string command = "SELECT * FROM Recipe Where Name LIKE '%" + uid + "%'";
        //    var reader = myDatabase.ExcuteQuery(command);
        //    bool notEOF = false;
        //    notEOF = reader.Read();
        //    while (notEOF)
        //    {
        //        RecList.Add(reader["RecipeID"].ToString());
        //        notEOF = reader.Read();

        //    }
        //    return RecList;
        //}
        
        
    }

    ///Only contain cookinng date and name and id of the recipe
    public class HistoryRecipe
    {
       public string Name{ get; set; }
       public int RecipeID { get; set; }
       public DateTime CookingDate { get; set; }
    }
}
