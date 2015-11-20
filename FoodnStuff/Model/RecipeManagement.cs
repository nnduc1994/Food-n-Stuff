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

        public static List<string> GetAvailableIngredientByName(string hint) {
            List<string> returnString = new List<string>();
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT Name FROM Ingredient WHERE NAME LIKE '%" + hint + "%'";
            var reader = myDatabase.ExcuteQuery(command);
            bool EOF = reader.Read();
            while (EOF) {
                returnString.Add(reader["Name"].ToString());
                EOF = reader.Read();
            }
            return returnString;
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
            while (EOF)
            {
                idList.Add(Convert.ToInt32(reader["ID"]));
                EOF = reader.Read();
            }
            if (idList.Count>0)
            {
                maxingredientID = idList.Max();
            }
            
            command = "INSERT INTO Ingredient (ID, Name, Description) VALUES ('" + (maxingredientID + 1) + "','" + Name + "','" + Description + "');";
            myDatabase.ExcuteNonQuery(command);
            myDatabase.CloseConnection();
        }

        public static void AddIngredientToRecipe(string Name, double amount, int UnitID)
        {  
            int maxrecipeID = 0;
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();

            string command = "SELECT ID FROM Recipe";

            myDatabase.ExcuteQuery(command);
            OleDbDataReader reader1 = myDatabase.ExcuteQuery(command);
            bool EOF1 = reader1.Read();
            List<int> idList1 = new List<int>();
            while (EOF1)
            {
                idList1.Add(Convert.ToInt32(reader1["ID"]));
                EOF1 = reader1.Read();
            }
            if (idList1.Count()>0)
            {
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
                CreateIngredient(Name, "");
                myDatabase.ReturnConnection();
                command = "SELECT ID FROM Ingredient Where Name ='" + Name + "';";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                int IngredientID = Convert.ToInt32(reader["ID"].ToString());
                command = "INSERT INTO RecipeIngredientAmount (Amount, IngredientID, RecipeID, UnitID) VALUES ('" + amount + "','" + IngredientID + "','" + maxrecipeID + "','" + UnitID + "');";
                myDatabase.ExcuteNonQuery(command);
                myDatabase.CloseConnection();

            }
        }
        
        public static  void CreateRecipe(string Name, string Instruction, int creatorID)
        {
            int maxRecipeID = 0;
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT ID FROM Recipe";

            myDatabase.ExcuteQuery(command);
            OleDbDataReader reader1 = myDatabase.ExcuteQuery(command);
            bool EOF1 = reader1.Read();
            List<int> recipeIDList = new List<int>();
            while (EOF1)
            {
                recipeIDList.Add(Convert.ToInt32(reader1["ID"]));
                EOF1 = reader1.Read();
            }
            if (recipeIDList.Count() > 0)
            {
                maxRecipeID = recipeIDList.Max();
            }

            command = "INSERT INTO Recipe (ID, Name, Instruction, CreatedID) VALUES ('"+ (maxRecipeID + 1) + "','" + Name + "','" + Instruction + "','" + creatorID +"');";
            myDatabase.ExcuteNonQuery(command);
            myDatabase.CloseConnection();
        }
  
        public static void AddRecipePicture(string path) {
            int maxRecipeID = 0;
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();

            string command = "SELECT ID FROM Recipe";

            myDatabase.ExcuteQuery(command);
            OleDbDataReader reader1 = myDatabase.ExcuteQuery(command);
            bool EOF1 = reader1.Read();
            List<int> idList1 = new List<int>();
            while (EOF1)
            {
                idList1.Add(Convert.ToInt32(reader1["ID"]));
                EOF1 = reader1.Read();
            }
            if (idList1.Count() > 0)
            {
                maxRecipeID = idList1.Max();
            }


            command = "INSERT INTO RecipeImage (Path, RecipeID) VALUES ('" + path  + "','" + maxRecipeID  + "');";
            myDatabase.ExcuteNonQuery(command);
            myDatabase.CloseConnection();

        }
        public static Recipe getRecipe(int recipeID)
        {
            Recipe myRecipe = new Recipe();
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();

    //Get ID
            string command = "SELECT * FROM Recipe WHERE ID =" + recipeID.ToString() + ";";

            myDatabase.ExcuteQuery(command);
            OleDbDataReader reader = myDatabase.ExcuteQuery(command);
            reader.Read();

    //Get Name, Instruction and AuthorID
            myRecipe.Name = reader["Name"].ToString();
            myRecipe.Instruction = reader["Instruction"].ToString();
            myRecipe.AuthorID = Convert.ToInt32(reader["CreatedID"]);

    //Get AuthorName

            command = "SELECT * FROM UserTable WHERE ID =" + myRecipe.AuthorID.ToString() + ";";

            myDatabase.ExcuteQuery(command);
            reader = myDatabase.ExcuteQuery(command);
            reader.Read();

            myRecipe.AuthorName = reader["Name"].ToString();

    //Get Ingredient

            List<Ingredient> IngredientList = new List<Ingredient>();
            command = "SELECT * FROM RecipeIngredientAmount WHERE RecipeID =" + recipeID.ToString() + ";";
            myDatabase.ExcuteQuery(command);
            reader = myDatabase.ExcuteQuery(command);
            bool EOF = reader.Read();
            List<int> idList = new List<int>();
            while (EOF)
            {
                idList.Add(Convert.ToInt32(reader["IngredientID"]));
                EOF = reader.Read();
            }
            for (int i = 0; i < idList.Count; i++)
            {
                command = "SELECT * FROM RecipeIngredientAmount WHERE IngredientID =" + idList[i] + ";";
                myDatabase.ExcuteQuery(command);
                reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                Ingredient ingredientObj = new Ingredient();
                ingredientObj.Amount =  Convert.ToDouble(reader["Amount"]);
                ingredientObj.UnitID = Convert.ToInt32(reader["UnitID"]);
                IngredientList.Add(ingredientObj);
                

                command = "SELECT * FROM Ingredient WHERE ID =" + idList[i] + ";";
                myDatabase.ExcuteQuery(command);
                reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                IngredientList[i].Name = reader["Name"].ToString();
            }
            myRecipe.IngredientList = IngredientList;

    //Get picture path
            command = "SELECT * FROM RecipeImage WHERE RecipeID =" + recipeID.ToString() + ";";
            myDatabase.ExcuteQuery(command);
            reader = myDatabase.ExcuteQuery(command);
            reader.Read();
            myRecipe.PicturePath = reader["Path"].ToString();


            return myRecipe;
        }
    }
    

    //Business Object
    public class Recipe {

        public Recipe() {
            IngredientList = new List<Ingredient>();
        }
        public int ID { get; set; }
        public string Name{get;set;}
        public string AuthorName { get; set; }
        public int AuthorID { get; set; }
        public string Instruction { get; set; }
        public string PicturePath { get; set; }
        public List<Ingredient> IngredientList { get; set; }
    }

    public class Ingredient{
         public string Name {get;set;}
         public double Amount {get; set;}
         public int UnitID { get; set;}
    }

    
}