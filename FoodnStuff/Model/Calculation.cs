using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace FoodnStuff.Model
{
    public class Calculation
    {
        public static bool CheckIngredientInStorage(int IngredientID)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM StorageIngredientAmount WHERE IngredientID =" + IngredientID + ";";
            myDatabase.ExcuteQuery(command);
            OleDbDataReader reader = myDatabase.ExcuteQuery(command);
            if (reader.Read())
            {
                return true;
            }
            else return false;
        }

        public static double IngredientAmountSum(int IngredientID)
        {
            double sum = 0;
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM StorageIngredientAmount WHERE IngredientID =" + IngredientID + ";";
            myDatabase.ExcuteQuery(command);
            OleDbDataReader reader = myDatabase.ExcuteQuery(command);
            bool EOF = reader.Read();
            List<double> amountList = new List<double>();
            List<double> unitIDList = new List<double>();
            while (EOF)
            {
                amountList.Add(Convert.ToDouble(reader["Amount"]));
                unitIDList.Add(Convert.ToInt32(reader["UnitID"]));
                EOF = reader.Read();
            }

            for (int i = 0; i < amountList.Count; i++)
            {
                command = "SELECT * FROM Unit WHERE ID =" + unitIDList[i] + ";";
                myDatabase.ExcuteQuery(command);
                reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                sum += amountList[i]*Convert.ToDouble(reader["RateToKilogram"]);
            }
            
            return sum;
        }

        public static int IngredientCompare(int IngredientID, int RecipeID)
        {
            if (CheckIngredientInStorage(IngredientID))
            {
                double StorageSum = IngredientAmountSum(IngredientID);
                Database myDatabase = new Database();
                myDatabase.ReturnConnection();
                string command = "SELECT * FROM RecipeIngredientAmount WHERE (IngredientID =" + IngredientID + ") AND (RecipeID =" + RecipeID + ");";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                double RecipeAmount = Convert.ToDouble(reader["Amount"]);

                command = "SELECT * FROM Unit WHERE ID =" + Convert.ToInt32(reader["UnitID"]) + ";";
                myDatabase.ExcuteQuery(command);
                reader = myDatabase.ExcuteQuery(command);
                reader.Read();

                RecipeAmount = RecipeAmount * Convert.ToDouble(reader["RateToKilogram"]);
            //Value = 1 => Equal amount of ingredient in storage
                if (StorageSum == RecipeAmount)
                {
                    return 1;
                }
                else
                {
            //Value = 2 => Storage has more amount than recipe needed
                    if (StorageSum > RecipeAmount)
                    {
                        return 2;
                    }
                    else
            //Value = 3 => Storage has less amount than recipe needed
                    {
                        return 3;
                    }
                }
            }
            
            
            //Value = 0 => No Ingredient in storage            
            else
            {
                return 0;
            }

        }
    }
}