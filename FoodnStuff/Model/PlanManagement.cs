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
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "INSERT INTO Plan (RecipeID,UserID,CookingDate) VALUES ('" + RecipeID + "','" + UserID + "','" + CookingDate + "');";
            myDatabase.ExcuteNonQuery(command);
            myDatabase.CloseConnection();
        }

        //Return a list of planRecipe Object belong to this specific UserID
        public static List<PlanRecipe> GetPlanRecipe(int UserID) {

            List<PlanRecipe> planRecipeList = new List<PlanRecipe>();
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM Plan Where UserID=" + UserID + "";
            var reader = myDatabase.ExcuteQuery(command);
            bool notEOF = false;
            notEOF = reader.Read();
            while (notEOF)
            {
                planRecipeList.Add(new PlanRecipe(Convert.ToInt32(reader["RecipeID"]), "", Convert.ToDateTime(reader["CookingDate"]), Convert.ToInt32(reader["ID"])));
                notEOF = reader.Read();
            }

            foreach (PlanRecipe wlr in planRecipeList)
            {
                command = "SELECT * FROM Recipe Where ID=" + wlr.RecipeId + "";
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

            return planRecipeList;
        }

        //Remove from the planID with ID of a row as an parameter
        public static void RemoveFromPlan(int PlanID) 
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "DELETE FROM Plan WHERE ID=" + PlanID + ";";
            myDatabase.ExcuteNonQuery(command);
            myDatabase.CloseConnection();
        }
    }

    public class PlanRecipe{
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public DateTime CookingDate { get; set; }
        //use to remove from plan table
        public int planID { get; set; }
        public PlanRecipe(int rId, string rN, DateTime cD, int pId)
        {
            RecipeId = rId;
            RecipeName = rN;
            CookingDate = cD;
            planID = pId;
        }
    }
}