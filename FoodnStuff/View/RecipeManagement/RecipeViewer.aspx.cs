using System;
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
        Model.Recipe mRecipe = new Model.Recipe();
        public bool AddToWishListYet;

        protected void Page_Load(object sender, EventArgs e)
        {
            //int recipeID = 3;
            if (Request["RecipeID"] != null)
            {
                int recipeID = Convert.ToInt32(Request["RecipeID"]);
                mRecipe = Model.RecipeManagement.getRecipe(recipeID)[0];
                lbRecipeName.Text = mRecipe.Name;
                imgRecipe.ImageUrl = mRecipe.PicturePath;

                for (int i = 0; i < mRecipe.IngredientList.Count; i++)
                {
                    lbIngredient.Text += mRecipe.IngredientList[i].Name + " - Amount: " + mRecipe.IngredientList[i].Amount + " " + mRecipe.IngredientList[i].Unit + "s<br/>";
                }
                lbInstruction.Text = mRecipe.Instruction;
                Image1.ImageUrl = "/Content/star/" + mRecipe.Vote.ToString() + ".png";
                Label1.Text = recipeID.ToString();
                if (Session["UID"] != null) {
                    int userID = Convert.ToInt16(Session["UID"]);
                    AddToWishListYet = Model.WishListManagement.CheckAdded(recipeID, userID);
                    if (AddToWishListYet != false) {
                        Button3.Attributes.Add("style", "display:none");
                    }
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/RecipeManagement/CookingConfirmation.aspx?RecipeID=" + mRecipe.ID);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["UID"] != null) {
                int userID = Convert.ToInt16(Session["UID"]);
                Model.VoteManagement.CreateVote(userID, Convert.ToInt16(Label1.Text),Convert.ToInt16(TextBox1.Text) );
                Response.Redirect("/View/RecipeManagement/RecipeViewer.aspx?RecipeID=" + Label1.Text);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["UID"] != null) {
                int userID = Convert.ToInt16(Session["UID"]);
                Model.WishListManagement.AddToWishList(Convert.ToInt16(Label1.Text), userID);
                Response.Redirect("/View/RecipeManagement/RecipeViewer.aspx?RecipeID=" + Label1.Text);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Session["UID"] != null) {
                int userId = Convert.ToInt16(Session["UID"]);
                int recipeId = Convert.ToInt16(Label1.Text);
                Model.PlanManagement.AddPlan(recipeId, userId,Convert.ToDateTime(TextBox2.Text));
            }
        }
    }
}