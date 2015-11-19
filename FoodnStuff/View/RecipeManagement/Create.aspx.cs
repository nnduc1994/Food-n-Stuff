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
            int id = 0;
            if (Request.Cookies["UserLogIn"] != null)
            {
                if (Request.Cookies["UserLogIn"]["UID"] != null)
                {
                    String ID = Request.Cookies["UserLogIn"]["UID"].ToString();
                    id = Convert.ToInt32(ID);
                }
            }
          

            if (id > 0) {
                //If missing info, dont create recipe
                if (TextBox1 != null && TextBox5 != null) {
                    Model.RecipeManagement.CreateRecipe(TextBox1.Text, TextBox5.Text, id);
                }
                if (Request["AmountOfIngredient"] != null)
                {
                    int amountIngredient = Convert.ToInt16(Request["AmountOfINgredient"]);
                    for (int i = 1; i <= amountIngredient; i++)
                    {
                        if (Request["IngredientName" + i] != null && Request["IngredientAmount" + i] != null)
                        {
                            Model.RecipeManagement.AddIngredientToRecipe(Request["IngredientName" + i].ToString().ToLower(), double.Parse(Request["IngredientAmount" + i]), 1);
                        }
                    }
                }

            }
        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}