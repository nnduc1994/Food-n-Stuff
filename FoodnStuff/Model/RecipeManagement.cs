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
            
            
            //If ingredient available, take ingredient ID 
            if (CheckIngredientAvailability(Name))
            {
                string command = "SELECT ID FROM Ingredient Where Name ='" + Name + "';";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                int IngredientID = Convert.ToInt32(reader["ID"].ToString());
                command = "INSERT INTO RecipeIngredientAmount (Amount, IngredientID, RecipeID, UnitID) VALUES ('" + amount + "','" + IngredientID + "','" + RecipeID + "','" + UnitID + "');";
                myDatabase.ExcuteNonQuery(command);
            }
            // If not available, create a new Ingredient 
            else
            {
                //Create a new Ingredient here
                CreateIngredient(Name, "");

                string command = "SELECT ID FROM Ingredient";

                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                bool EOF = reader.Read();
                int IngredientID = 0;

                if (EOF) {
                    IngredientID++;
                    reader.Read();
                }
                command = "INSERT INTO RecipeIngredientAmount (Amount, IngredientID, RecipeID, UnitID) VALUES ('" + amount + "','" + (IngredientID + 1) + "','" + RecipeID + "','" + UnitID + "');";
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