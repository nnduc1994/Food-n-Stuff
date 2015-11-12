using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodnStuff.View.RecipeManagement
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = 1;
            if (Request.Cookies["UserLogIn"] != null)
            {
                if (Request.Cookies["UserLogIn"]["UID"] != null)
                {
                    String ID = Request.Cookies["UserLogIn"]["UID"].ToString();
                    id = Convert.ToInt32(ID);
                }
            }
            double amount1 = Convert.ToDouble(TextBox4.Text);
            double amount2 = Convert.ToDouble(TextBox9.Text);

            Model.RecipeManagement.CreateRecipe(TextBox1.Text, TextBox5.Text, id);
            Model.RecipeManagement.AddIngredientToRecipe(TextBox2.Text, amount1, 1);
            Model.RecipeManagement.AddIngredientToRecipe(TextBox3.Text, amount2, 1);
        }
    }
}