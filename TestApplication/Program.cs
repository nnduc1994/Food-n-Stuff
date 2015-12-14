using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodnStuff;
using System.Reflection;
using FoodnStuff.Model;
namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //RecipeManagement.CreateRecipe("Casserole", "Cook it", 1);
            //RecipeManagement.AddIngredientToRecipe("Garlic", 2, 1);
            //RecipeManagement.AddIngredientToRecipe("Onion", 4, 1);

            //List<string> a = RecipeManagement.GetAvailableIngredientByName("chic");

            //Recipe mRecipe = new Recipe();
            //mRecipe = RecipeManagement.getRecipe(5);
            //Console.WriteLine(mRecipe.Name);
            //Console.WriteLine(mRecipe.AuthorName);
            //Console.WriteLine(mRecipe.AuthorID);
            //Console.WriteLine(mRecipe.Instruction);
            //for (int i = 0; i < mRecipe.IngredientList.Count; i++)
            //{
            //    Console.WriteLine(mRecipe.IngredientList[i].Name);
            //    Console.WriteLine(mRecipe.IngredientList[i].Amount);
            //    Console.WriteLine(mRecipe.IngredientList[i].UnitID);
            //}

            //StorageManagement.AddIngredientToStorage(2, "Chicken", 3, 1, "20.12.2015");

            //Console.WriteLine(Calculation.IngredientAmountSum(1));
            //Console.WriteLine(Calculation.IngredientCompare(1, 5));

            //List<Recipe> myRecipe = new List<Recipe>();
            //myRecipe = RecipeManagement.getRecipe(null, "Chicken");
            //foreach (var a in myRecipe)
            //{
            //    Console.WriteLine(a.Name);
            //    Console.WriteLine(a.Vote);
            //    Console.WriteLine("------------------");
            //}
            //Console.ReadLine();

            //List<HistoryRecipe> l = RecipeHistoryManagement.GetRecList(3);
            //foreach (var r in l) {
            //    Console.WriteLine(r.Name);
            //    Console.WriteLine(r.RecipeID);
            //    Console.WriteLine(r.CookingDate);
            //    Console.WriteLine("----------------------------");
            //}
            //Console.ReadLine();

            //List<Ingredient> IngredientList = new List<Ingredient>();

            //IngredientList = StorageManagement.GetExpiredIngredient(2);

            //for (int i = 0; i < IngredientList.Count; i++)
            //{
            //    Console.WriteLine(IngredientList[i].Name);
            //    Console.WriteLine(IngredientList[i].Amount);
            //    Console.WriteLine(IngredientList[i].Unit);
            //    Console.WriteLine(IngredientList[i].ExpiredDay);
            //}

            //RecipeManagement.UpdatePrice(1, 2.5);

            //Console.WriteLine(Calculation.RecipeTotalPrice(7));

            //List<int> IDList = new List<int>();
            //IDList.Add(1);
            //IDList.Add(2);
            //IDList.Add(3);
            //IDList.Add(4);

            //List<Category> CategoryList = new List<Category>();
            //CategoryList = RecipeManagement.GetCategory(IDList);
            //for (int i = 0; i < CategoryList.Count; i++)
            //{
            //    Console.WriteLine(CategoryList[i].ID);
            //    Console.WriteLine(CategoryList[i].Name);
            //    Console.WriteLine(CategoryList[i].ImagePath);
            //}


        }
    }
}
