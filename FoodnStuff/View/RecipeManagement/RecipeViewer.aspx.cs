﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;


namespace FoodnStuff.View.RecipeManagement
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //int recipeID = 1;
            if (Request["RecipeID"] != null)
            {
                int recipeID = Convert.ToInt32(Request["RecipeID"]);
                Model.Recipe mRecipe = new Model.Recipe();
                mRecipe = Model.RecipeManagement.getRecipe(recipeID)[0];
                lbRecipeName.Text = mRecipe.Name;
                imgRecipe.ImageUrl = mRecipe.PicturePath;

                for (int i = 0; i < mRecipe.IngredientList.Count; i++)
                {
                    Model.Database myDatabase = new Model.Database();
                    myDatabase.ReturnConnection();

                    string command = "SELECT * FROM Unit WHERE ID =" + mRecipe.IngredientList[i].UnitID + ";";
                    myDatabase.ExcuteQuery(command);
                    OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                    reader.Read();
                    string Unit = reader["Name"].ToString();

                    lbIngredient.Text += mRecipe.IngredientList[i].Name + " - Amount: " + mRecipe.IngredientList[i].Amount + " " + Unit + "s<br/>";
                }
                lbInstruction.Text = mRecipe.Instruction;
            }

        }
    }
}