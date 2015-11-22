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
        //For hardcode testing
        //int RecipeID = 1;
        //int UserID = 2;
        List<int> IDList = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbRecipeIngredient.Text = "";
            lbAvailableIngredient.Text = "";
            if (Request["RecipeID"] != null && Session["UID"] != null)
            {
                //Use this to call or calculate as you wish
                int RecipeID = Convert.ToInt16(Request["RecipeID"]);
                int UserID = Convert.ToInt16(Session["UID"]);


                //Get Ingredient for Recipe
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
            AvailableIngredientList = Model.StorageManagement.GetAvailableIngredient(IDList,UserID);
            for (int i = 0; i < AvailableIngredientList.Count; i++)
            {
                Model.Database myDatabase = new Model.Database();
                myDatabase.ReturnConnection();

                string command = "SELECT * FROM Unit WHERE ID =" + AvailableIngredientList[i].UnitID + ";";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                string Unit = reader["Name"].ToString();

                lbAvailableIngredient.Text += AvailableIngredientList[i].Name + " - Amount: " + AvailableIngredientList[i].Amount + " " + Unit + "s Expired day: " + AvailableIngredientList[i].ExpiredDay + "<br/>";

            }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Use this function to calculate

            if (Request["RecipeID"] != null && Session["UID"] != null)
            {
                //Use this to call or calculate as you wish
                int RecipeID = Convert.ToInt16(Request["RecipeID"]);
                int UserID = Convert.ToInt16(Session["UID"]);
                Model.RecipeHistoryManagement.AddNewHR(UserID, RecipeID);

                for (int i = 0; i < IDList.Count; i++)
            {
                Model.Database myDatabase = new Model.Database();
                myDatabase.ReturnConnection();

                string command = "SELECT * FROM Ingredient WHERE ID =" + IDList[i] + ";";
                myDatabase.ExcuteQuery(command);
                OleDbDataReader reader = myDatabase.ExcuteQuery(command);
                reader.Read();
                string IngredientName = reader["Name"].ToString();

                int caseSwitch = Model.Calculation.IngredientCompare(IDList[i],RecipeID,UserID);
                switch (caseSwitch)
                {
                    //No Ingredient in storage   
                    case 0:
                        lbRemind.Text += "There is no " + IngredientName + " in your storage<br/>";
                        break;
                    //Equal amount of ingredient in storage
                    case 1:
                        command = "DELETE * FROM StorageIngredientAmount WHERE (IngredientID =" + IDList[i] + ") AND (OwnerID ="+ UserID +");";
                        myDatabase.ExcuteNonQuery(command);
                        break;
                    //Storage has more amount than recipe needed
                    case 2:

                        myDatabase.ReturnConnection();
                        command = "SELECT * FROM RecipeIngredientAmount WHERE (IngredientID =" + IDList[i] + ") AND (RecipeID =" + RecipeID + ");";
                        myDatabase.ExcuteQuery(command);
                        reader = myDatabase.ExcuteQuery(command);
                        reader.Read();
                        double RecipeAmount = Convert.ToDouble(reader["Amount"]);

                        command = "SELECT * FROM Unit WHERE ID =" + Convert.ToInt32(reader["UnitID"]) + ";";
                        myDatabase.ExcuteQuery(command);
                        reader = myDatabase.ExcuteQuery(command);
                        reader.Read();

                        RecipeAmount = RecipeAmount * Convert.ToDouble(reader["RateToKilogram"]);

                        Model.Calculation.IngredientCase2Calculation(IDList[i], RecipeAmount, UserID);

                        break;
                    // Storage has less amount than recipe needed
                    case 3:

                        double StorageSum = Model.Calculation.IngredientAmountSum(IDList[i],UserID);
                        myDatabase.ReturnConnection();
                        command = "SELECT * FROM RecipeIngredientAmount WHERE (IngredientID =" + IDList[i] + ") AND (RecipeID =" + RecipeID + ");";
                        myDatabase.ExcuteQuery(command);
                        reader = myDatabase.ExcuteQuery(command);
                        reader.Read();
                        double RecipeAmount1 = Convert.ToDouble(reader["Amount"]);

                        command = "SELECT * FROM Unit WHERE ID =" + Convert.ToInt32(reader["UnitID"]) + ";";
                        myDatabase.ExcuteQuery(command);
                        reader = myDatabase.ExcuteQuery(command);
                        reader.Read();

                        RecipeAmount1 = RecipeAmount1 * Convert.ToDouble(reader["RateToKilogram"]);
                        string UnitName = reader["Name"].ToString();

                        double remain = RecipeAmount1 - StorageSum;

                        //Edit database
                        command = "DELETE * FROM StorageIngredientAmount WHERE (IngredientID =" + IDList[i] + ") AND (OwnerID =" + UserID + ");";
                        myDatabase.ExcuteNonQuery(command);
                        //Reminder message
                        lbRemind.Text += "You need " + remain + " " + UnitName +"s of " + IngredientName + " more for this recipe<br/>";
                        break;
                }
            }

                }
            }
    }
}