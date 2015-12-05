using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodnStuff.Model
{
    public class WishListManagement
    {
        //Add new row to ẂishList table
        public static void AddToWishList(int RecipeID, int UserID)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "INSERT INTO WishList (RecipeID,UserID) VALUES ('" + RecipeID + "','" + UserID + "');";
            myDatabase.ExcuteNonQuery(command);
            myDatabase.CloseConnection();

        }

        //Return a list of planRecipe Object belong to this specific UserID
        public static List<WishListRecipe> GetWishListRecipe(int UserID)
        {
            List<WishListRecipe> wishRecipeList = new List<WishListRecipe>();
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM WishList Where UserID=" + UserID + "";
            var reader = myDatabase.ExcuteQuery(command);
            bool notEOF = false;
            notEOF = reader.Read();
            while (notEOF)
            {
                wishRecipeList.Add(new WishListRecipe(Convert.ToInt32(reader["RecipeID"]), "",Convert.ToInt32(reader["ID"])));
                notEOF = reader.Read();
            }
           
            foreach (WishListRecipe wlr in wishRecipeList)
            {
                command = "SELECT Name FROM Recipe Where ID=" + wlr.RecipeId + "";
                reader = myDatabase.ExcuteQuery(command);
                notEOF = false;
                notEOF = reader.Read();
                while (notEOF)
                {
                    wlr.RecipeName = reader["Name"].ToString();
                    notEOF = reader.Read();
                }
            }
            myDatabase.CloseConnection();
            return wishRecipeList;
        }

        //use the ID of the wish in the DB to remove the row
        public static void RemoveFromWishList(int WishListID) {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "DELETE FROM WishList WHERE ID=" + WishListID + ";";
            myDatabase.ExcuteNonQuery(command);
            myDatabase.CloseConnection();
        }
    }

    public class WishListRecipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        //The ID of the row in the wishList table, use to remove from wish list
        public int WishID { get; set; }
        public WishListRecipe(int rId, string rN, int wId) 
        {
            RecipeId = rId;
            RecipeName = rN;
            WishID = wId;
        }
    }
}