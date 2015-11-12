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
            myDatabase.CloseConnection();
        }

        public static void CreateIngredient(string Name, string Description)
        {
            int maxingredientID = 0;
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT ID FROM Ingredient";

            myDatabase.ExcuteQuery(command);
            OleDbDataReader reader = myDatabase.ExcuteQuery(command);
            bool EOF = reader.Read();
            List<int> idList = new List<int>();
            if (EOF)
            {
                idList.Add(Convert.ToInt32(reader["ID"]));
                reader.Read();
                maxingredientID = idList.Max();
            }
            
            command = "INSERT INTO Ingredient (ID, Name, Description) VALUES ('" + (maxingredientID + 1) + "','" + Name + "','" + Description + "');";
            myDatabase.ExcuteNonQuery(command);
            myDatabase.CloseConnection();
        }

        public static void AddIngredientToRecipe(string Name, double amount, int UnitID)
        {
            int maxrecipeID = 1;
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();

            string command = "SELECT ID FROM Recipe";

            myDatabase.ExcuteQuery(command);
            OleDbDataReader reader1 = myDatabase.ExcuteQuery(command);
            bool EOF1 = reader1.Read();
            List<int> idList1 = new List<int>();
            if (EOF1)
            {
                idList1.Add(Convert.ToInt32(reader1["ID"]));
                reader1.Read();
                maxrecipeID = idList1.Max();
            }
            

            //If ingredient available, take ingredient ID 
            if (CheckIngredientAvailability(Name))
            {
                command = "SELECT ID FROM Ingredient Where Name ='" + Name + "';";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                int IngredientID = Convert.ToInt32(reader["ID"].ToString());
                command = "INSERT INTO RecipeIngredientAmount (Amount, IngredientID, RecipeID, UnitID) VALUES ('" + amount + "','" + IngredientID + "','" + maxrecipeID + "','" + UnitID + "');";
                myDatabase.ExcuteNonQuery(command);
                myDatabase.CloseConnection();
            }
            // If not available, create a new Ingredient 
            else
            {

                //Create a new Ingredient here
                int maxingredientID = 1;
                CreateIngredient(Name, "");

                command = "SELECT ID FROM Ingredient";

                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                bool EOF = reader.Read();
                List<int> idList = new List<int>();
                if (EOF) {
                    idList.Add(Convert.ToInt32(reader["ID"]));
                    reader.Read();
                    maxingredientID = idList.Max();
                }
               
                command = "INSERT INTO RecipeIngredientAmount (Amount, IngredientID, RecipeID, UnitID) VALUES ('" + amount + "','" + maxingredientID + "','" + maxrecipeID + "','" + UnitID + "');";
                myDatabase.ExcuteNonQuery(command);
                myDatabase.CloseConnection();

            }
        }
        
        public static  void CreateRecipe(string Name, string Instruction, int creatorID)
        {
            int maxrecipeID = 0;
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT ID FROM Recipe";

            myDatabase.ExcuteQuery(command);
            OleDbDataReader reader1 = myDatabase.ExcuteQuery(command);
            bool EOF1 = reader1.Read();
            List<int> idList1 = new List<int>();
            if (EOF1)
            {
                idList1.Add(Convert.ToInt32(reader1["ID"]));
                reader1.Read();
                maxrecipeID = idList1.Max();
            }            
            
            command = "INSERT INTO Recipe (ID, Name, Instruction, CreatedID) VALUES ('"+ (maxrecipeID+1) + "','" + Name + "','" + Instruction + "','" + creatorID +"');";
            myDatabase.ExcuteNonQuery(command);
            myDatabase.CloseConnection();
        }
    }
}