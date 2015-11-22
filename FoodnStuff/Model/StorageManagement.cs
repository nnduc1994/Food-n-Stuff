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

        public static List<Ingredient> GetAvailableIngredient(List<int> IngredientIDList,int OwnerID)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            List<Ingredient> IngredientList = new List<Ingredient>();
            List<int> ResultList = new List<int>();
            //Get Ingredient

            for (int i = 0; i < IngredientIDList.Count; i++)
            {
                if (Calculation.CheckIngredientInStorage(IngredientIDList[i],OwnerID))
                {
                    ResultList.Add(IngredientIDList[i]);
                }
            }


            for (int i = 0; i < ResultList.Count; i++)
            {
                
                string IngredientName;
                string command = "SELECT * FROM Ingredient WHERE ID =" + ResultList[i] + ";";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader1 = myDatabase.ExcuteQuery(command);
                reader1.Read();
                IngredientName = reader1["Name"].ToString();

                command = "SELECT * FROM StorageIngredientAmount WHERE (IngredientID =" + ResultList[i] + ") AND (OwnerID =" + OwnerID + ");";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                bool EOF = reader.Read();
                while (EOF)
                {
                    Ingredient ingredientObj = new Ingredient();
                    ingredientObj.Amount = Convert.ToDouble(reader["Amount"]);
                    ingredientObj.UnitID = Convert.ToInt32(reader["UnitID"]);
                    ingredientObj.ExpiredDay = (reader["ExpiredDate"].ToString()).Substring(0,10);
                    ingredientObj.Name = IngredientName;
                    IngredientList.Add(ingredientObj);
                    EOF = reader.Read();
                }

            }
            return IngredientList;
        }

    }
}