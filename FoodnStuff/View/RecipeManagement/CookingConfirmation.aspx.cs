using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace FoodnStuff.View.RecipeManagement
{
    public partial class CookingConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int RecipeID = 1;
            //if (Request["RecipeID"] != null && Session["UID"] != null)
            //{
            //    //Use this to call or calculate as you wish
            //    int RecipeID = Convert.ToInt16(Request["RecipeID"]);
                int UserID = Convert.ToInt16(Session["UID"]);


                //Get Ingredient for Recipe
                List<int> IDList = new List<int>();
                Model.Recipe mRecipe = new Model.Recipe();
                mRecipe = Model.RecipeManagement.getRecipe(RecipeID)[0];
                lbRecipeName.Text = mRecipe.Name;
                for (int i = 0; i < mRecipe.IngredientList.Count; i++)
                {
                    Model.Database myDatabase = new Model.Database();
                    myDatabase.ReturnConnection();

                    string command = "SELECT * FROM Unit WHERE ID =" + mRecipe.IngredientList[i].UnitID + ";";
                    myDatabase.ExcuteQuery(command);
                    OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                    reader.Read();
                    string Unit = reader["Name"].ToString();
                    lbRecipeIngredient.Text += mRecipe.IngredientList[i].Name + " - Amount: " + mRecipe.IngredientList[i].Amount + " " + Unit + "s<br/>";

                    //Get ID list for available ingredient
                    command = "SELECT * FROM Ingredient WHERE Name ='" + mRecipe.IngredientList[i].Name + "';";
                    myDatabase.ExcuteQuery(command);
                    reader = myDatabase.ExcuteQuery(command);
                    reader.Read();
                    IDList.Add(Convert.ToInt32(reader["ID"]));
                }


            //Get Available Ingredient

            List<Model.Ingredient> AvailableIngredientList = new List<Model.Ingredient>();
            AvailableIngredientList = Model.StorageManagement.GetAvailableIngredient(IDList);
            for (int i = 0; i < AvailableIngredientList.Count; i++)
            {
                Model.Database myDatabase = new Model.Database();
                myDatabase.ReturnConnection();

                string command = "SELECT * FROM Unit WHERE ID =" + AvailableIngredientList[i].UnitID + ";";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                string Unit = reader["Name"].ToString();
                lbAvailableIngredient.Text += AvailableIngredientList[i].Name + " - Amount: " + AvailableIngredientList[i].Amount + " " + Unit + "s<br/>";

            }
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Use this function to calculate
        }
    }
}