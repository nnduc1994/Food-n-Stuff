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
                myDatabase.CloseConnection();
                return true;
            }
            else
            {
                myDatabase.CloseConnection();
                return false;
            }
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
            myDatabase.CloseConnection();
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
            
            command = "INSERT INTO Ingredient (ID, Name, Description, PricePerKilo) VALUES ('" + (maxingredientID + 1) + "','" + Name + "','" + Description + "','" + 0 + "');";
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
        
        public static int CreateRecipe(string Name, string Instruction, int creatorID, int Duration, List<int> CategoryIDList)
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

            command = "INSERT INTO Recipe (ID, Name, Instruction, CreatedID, Duration) VALUES ('"+ (maxRecipeID + 1) + "','" + Name + "','" + Instruction + "','" + creatorID + "','" + Duration + "');";
            myDatabase.ExcuteNonQuery(command);

            //Add Category Recipe

            for (int i = 0; i < CategoryIDList.Count; i++)
            {
                command = "INSERT INTO RecipeCategory (RecipeID, CategoryID) VALUES ('" + (maxRecipeID + 1) + "','" + CategoryIDList[i] + "');";
                myDatabase.ExcuteNonQuery(command);
            }
            myDatabase.CloseConnection();
            maxRecipeID++;
            return maxRecipeID;
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
        public static List<Recipe> getRecipe(int? recipeID=null ,string searchParam = null)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();

            string command = "";

            //Create List of Recipe to be returned
            List<Recipe> recipeList = new List<Recipe>();

            //Get by ID
            if (recipeID != null && recipeID >0)
            {
                command = "SELECT * FROM Recipe WHERE ID =" + recipeID.ToString() + ";";
            }
            else if (searchParam != null)
            {
                command = "SELECT * FROM Recipe WHERE NAME LIKE '%" + searchParam + "%'";
            }
            //If enter nothing return all the recipe
            else if (searchParam == null) {
                command = "SELECT * FROM Recipe";
            }

            OleDbDataReader mainReader = myDatabase.ExcuteQuery(command);
            bool EOF = mainReader.Read();

            //Loop over list of Response
            while (EOF) {
                Recipe myRecipe = new Recipe();

                //Get Name, Instruction and AuthorID
                myRecipe.Name = mainReader["Name"].ToString();
                myRecipe.Instruction = mainReader["Instruction"].ToString();
                myRecipe.AuthorID = Convert.ToInt32(mainReader["CreatedID"]);
                myRecipe.ID = Convert.ToInt32(mainReader["ID"]);
                myRecipe.Duration = Convert.ToInt32(mainReader["Duration"]);
                //Get AuthorName

                command = "SELECT * FROM UserTable WHERE ID =" + myRecipe.AuthorID.ToString() + ";";

                myDatabase.ExcuteQuery(command);
               var reader = myDatabase.ExcuteQuery(command);
                reader.Read();

                myRecipe.AuthorName = reader["Name"].ToString();

                //Get Ingredient

                List<Ingredient> IngredientList = new List<Ingredient>();
                command = "SELECT * FROM RecipeIngredientAmount WHERE RecipeID =" + myRecipe.ID.ToString() + ";";
                myDatabase.ExcuteQuery(command);
                reader = myDatabase.ExcuteQuery(command);
                bool EOF1 = reader.Read();
                List<int> idList = new List<int>();
                while (EOF1)
                {
                    idList.Add(Convert.ToInt32(reader["IngredientID"]));
                    EOF1 = reader.Read();
                }
                for (int i = 0; i < idList.Count; i++)
                {
                    command = "SELECT * FROM RecipeIngredientAmount WHERE IngredientID =" + idList[i] + " AND RecipeID =" + myRecipe.ID.ToString() + ";";
                    myDatabase.ExcuteQuery(command);
                    reader = myDatabase.ExcuteQuery(command);
                    reader.Read();
                    Ingredient ingredientObj = new Ingredient();
                    ingredientObj.Amount = Convert.ToDouble(reader["Amount"]);
                    int UnitID = Convert.ToInt32(reader["UnitID"]);

                    myDatabase.ReturnConnection();
                    command = "SELECT * FROM Unit WHERE ID =" + UnitID + ";";
                    myDatabase.ExcuteQuery(command);
                    OleDbDataReader reader1 = myDatabase.ExcuteQuery(command);
                    reader1.Read();
                    string Unit = reader1["Name"].ToString();
                    ingredientObj.Unit = Unit;

                    IngredientList.Add(ingredientObj);


                    command = "SELECT * FROM Ingredient WHERE ID =" + idList[i] + ";";
                    myDatabase.ExcuteQuery(command);
                    reader = myDatabase.ExcuteQuery(command);
                    reader.Read();
                    IngredientList[i].Name = reader["Name"].ToString();
                }
                myRecipe.IngredientList = IngredientList;

                //Get picture path
                command = "SELECT * FROM RecipeImage WHERE RecipeID =" + myRecipe.ID.ToString() + ";";
                myDatabase.ExcuteQuery(command);
                reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                myRecipe.PicturePath = reader["Path"].ToString();

                //Get category list

                command = "SELECT * FROM RecipeCategory WHERE RecipeID =" + myRecipe.ID.ToString() + ";";
                myDatabase.ExcuteQuery(command);
                reader = myDatabase.ExcuteQuery(command);
                bool EOF2 = reader.Read();
                List<int> idList1 = new List<int>();
                while (EOF2)
                {
                    idList1.Add(Convert.ToInt32(reader["CategoryID"]));
                    EOF2 = reader.Read();
                }
                myRecipe.CategoryList = GetCategory(idList1);

                //Get recipe vote
                int Vote = VoteManagement.GetRecipeVote(Convert.ToInt32(myRecipe.ID));
                myRecipe.Vote = Vote;
                recipeList.Add(myRecipe);
                EOF = mainReader.Read();

            }
            myDatabase.CloseConnection();
            return recipeList;
        }
        public static void UpdatePrice(int IngredientID,double Price)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "UPDATE Ingredient SET PricePerKilo = " + Price.ToString() + " WHERE ID = " + IngredientID.ToString() + ";";
            myDatabase.ExcuteNonQuery(command);
            myDatabase.CloseConnection();
        }
        public static List<Category> GetCategory(List<int> IDList)
        {
            List<Category> CategoryList = new List<Category>();
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "";
            
            for (int i = 0; i < IDList.Count; i++)
            {
                Category myCategory = new Category();
                command = "SELECT * FROM Category WHERE ID =" + IDList[i] + ";";
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                myCategory.ID = Convert.ToInt32(reader["ID"]);
                myCategory.Name = reader["Name"].ToString();
                myCategory.ImagePath = reader["ImagePath"].ToString();
                CategoryList.Add(myCategory);
            }
            myDatabase.CloseConnection();
                return CategoryList;
        }
        public static List<Category> GetAllCategory()
        {
            List<Category> CategoryList = new List<Category>();
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM Category;";
            myDatabase.ExcuteQuery(command);
            OleDbDataReader reader = myDatabase.ExcuteQuery(command);
            bool EOF = reader.Read();
            List<int> idList = new List<int>();
            while (EOF)
            {
                idList.Add(Convert.ToInt32(reader["ID"]));
                EOF = reader.Read();
            }
            CategoryList = GetCategory(idList);
            myDatabase.CloseConnection();
            return CategoryList;
        }

        public static List<int> GetRecipeIDBelongToCategory(int categoryID) {
            List<int> idList = new List<int>();
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM RecipeCategory WHERE CategoryID = "+ categoryID + ";";
            OleDbDataReader reader = myDatabase.ExcuteQuery(command);
            bool EOF = reader.Read();
            while (EOF)
            {
                idList.Add(Convert.ToInt32(reader["RecipeID"]));
                EOF = reader.Read();
            }
            myDatabase.CloseConnection();
            return idList;
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
        public int Vote { get; set; }
        public int Duration { get; set; }
        public List<Category> CategoryList { get; set; }
    }

    public class Ingredient{
         public string Name {get;set;}
         public double Amount {get; set;}
         public string Unit { get; set;}
         public string ExpiredDay { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string ImagePath {get; set;}
    }
        

}