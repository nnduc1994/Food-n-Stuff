using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace FoodnStuff.Model
{
    public class RecipeManagement
    {
        public static bool CheckIngredientAvailability(string Name)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM Ingredient Where Name ='" + Name + "';";
            myDatabase.ExcuteQuery(command);
            OleDbDataReader reader = myDatabase.ExcuteQuery(command);
            if (reader.Read())
            {
                return true;
            }
            else return false;
        }

        public static void CreateIngredient(string Name, string Description)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "INSERT INTO Ingredient (Name, Description) VALUES ('" + Name + "','" + Description + "');";
            myDatabase.ExcuteNonQuery(command);
        }

        public static void AddIngredientToRecipe(string Name, double amount, int RecipeID, int UnitID)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            if (CheckIngredientAvailability(Name))
            {
                string command = "SELECT ID FROM Ingredient Where Name ='" + Name + "';";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                string IngredientID = reader.ToString();
                command = "INSERT INTO RecipeIngredientAmount (Amount, IngredientID, RecipeID, UnitID) VALUES ('" + amount + "','" + IngredientID + "','" + RecipeID + "','" + UnitID + "');";
                myDatabase.ExcuteNonQuery(command);
            }
        }
        
        public static  void CreateRecipe(string Name, string Instruction, int creatorID)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "INSERT INTO Recipe (Name, Instruction, CreatedID) VALUES ('"+ Name + "','" + Instruction + "','" + creatorID +"');";
            myDatabase.ExcuteNonQuery(command);
        }
    }
}