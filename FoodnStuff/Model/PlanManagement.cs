using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodnStuff.Model
{
    public class PlanManagement
    {
        //Add new row to Plan table
        public static void AddPlan(int RecipeID, int UserID, DateTime CookingDate)
        {


        }

        //Return a list of planRecipe Object belong to this specific UserID
        public static List<PlanRecipe> GetPlanRecipe(int UserID) {

            List<PlanRecipe> planRecipeList = new List<PlanRecipe>();
            //Get data from DB, create new PlaneRecipe Object for each row, than add to list

            return planRecipeList;
        }

        //Remove from the planID with ID of a row as an parameter
        public static void RemoveFromPlan(int PlanID) { }
    }

    public class PlanRecipe{
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public DateTime CookingDate { get; set; }
        //use to remove from plan table
        public int planID { get; set; }
    }
}