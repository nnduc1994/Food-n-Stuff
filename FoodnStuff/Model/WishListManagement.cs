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


        }

        //Return a list of planRecipe Object belong to this specific UserID
        public static List<WishListRecipe> GetWishListRecipe(int UserID)
        {

            List<WishListRecipe> wishRecipeList = new List<WishListRecipe>();
            //Get data from DB, create new PlaneRecipe Object for each row, than add to list

            return wishRecipeList;
        }

        //use the ID of the wish in the DB to remove the row
        public static void RemoveFromWishList(int WishListID) {

        }
    }

    public class WishListRecipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        //The ID of the row in the wishList table, use to remove from wish list
        public int WishID { get; set; }
    }
}