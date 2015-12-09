using FoodnStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FoodnStuff.View.UserManagement
{
    public partial class WishList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UID"] != null) {
                int userID = Convert.ToInt16(Session["UID"]);
                List<WishListRecipe> wishList = Model.WishListManagement.GetWishListRecipe(userID);
                foreach (var recipe in wishList) {
                    HtmlGenericControl recipeContentDiv = new HtmlGenericControl("div");
                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("href", "/View/RecipeManagement/RecipeViewer.aspx?RecipeID=" + recipe.RecipeId);
                    HtmlGenericControl RecipeName = new HtmlGenericControl("p");
                    RecipeName.InnerText = "¤ " + recipe.RecipeName;
                    a.Controls.Add(RecipeName);
                    recipeContentDiv.Controls.Add(a);
                    wrapper.Controls.Add(recipeContentDiv);
                }

            }
        }
    }
}