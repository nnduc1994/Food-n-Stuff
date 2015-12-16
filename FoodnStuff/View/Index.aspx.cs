using FoodnStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodnStuff.View
{
    public partial class Index : System.Web.UI.Page
    {
        public List<Recipe> recipeList;
        public List<Category> categoriesList;
        protected void Page_Load(object sender, EventArgs e)
        {
            recipeList = Model.RecipeManagement.getRecipe(null, null);
            categoriesList = Model.RecipeManagement.GetAllCategory();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string hint = TextBox1.Text;
            Response.Redirect("/View/SearchResultManagement/Result.aspx?hint=" + hint);

        }
    }
}