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
            RecipeManagement.CreateRecipe("Casserole", "Cook it", 1);
            RecipeManagement.AddIngredientToRecipe("Garlic",2,11,1);
            RecipeManagement.AddIngredientToRecipe("Onion", 3, 11, 1);
        }
    }
}
