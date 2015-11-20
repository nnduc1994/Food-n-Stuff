using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace FoodnStuff.Model
{
    public class StorageManagement
    {
        public static void AddIngredientToStorage(int StorageOwnerID, string Name, double amount, int UnitID, string exdate)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            //If ingredient available, take ingredient ID 
            if (Model.RecipeManagement.CheckIngredientAvailability(Name))
            {
                string command = "SELECT ID FROM Ingredient Where Name ='" + Name + "';";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                int IngredientID = Convert.ToInt32(reader["ID"].ToString());
                command = "INSERT INTO StorageIngredientAmount (Amount, IngredientID, OwnerID, UnitID, ExpiredDate) VALUES ('" + amount + "','" + IngredientID + "','" + StorageOwnerID + "','" + UnitID + "','" + exdate + "');";
                myDatabase.ExcuteNonQuery(command);
                myDatabase.CloseConnection();
            }
            // If not available, create a new Ingredient 
            else
            {
                //Create a new Ingredient here
                Model.RecipeManagement.CreateIngredient(Name, "");
                myDatabase.ReturnConnection();
                string command = "SELECT ID FROM Ingredient Where Name ='" + Name + "';";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                int IngredientID = Convert.ToInt32(reader["ID"].ToString());
                command = "INSERT INTO StorageIngredientAmount (Amount, IngredientID, OwnerID, UnitID, ExpiredDate) VALUES ('" + amount + "','" + IngredientID + "','" + StorageOwnerID + "','" + UnitID + "','" + exdate + "');";
                myDatabase.ExcuteNonQuery(command);
                myDatabase.CloseConnection();

            }
        }

    }
}