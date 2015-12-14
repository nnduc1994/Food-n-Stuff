using System;
using System.Collections.Generic;
using System.IO;
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
            List<FoodnStuff.Model.Unit> unitList = Model.UnitManagement.ListAllUnit();
            for (int a = 0; a < unitList.Count; a++)
            {
                DropDownList1.Items.Add(unitList[a].Name);
                DropDownList1.Items[DropDownList1.Items.Count - 1].Value = unitList[a].ID.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (Session["UID"] != null)
            {
                String ID = Session["UID"].ToString();
                id = Convert.ToInt32(ID);
            }

            if (id > 0)
            {
                int redirectID = 0;

                //If missing info, dont create recipe
                if (TextBox1 != null && TextBox5 != null)
                {
                    redirectID = Model.RecipeManagement.CreateRecipe(TextBox1.Text, TextBox5.Text, id,Convert.ToInt32(TextBox6.Text));
                }
                if (Request["AmountOfIngredient"] != null)
                {
                    int amountIngredient = Convert.ToInt16(Request["AmountOfINgredient"]);
                    for (int i = 1; i <= amountIngredient; i++)
                    {
                        if (Request["IngredientName" + i] != null && Request["IngredientAmount" + i] != null && Request.Form["AmountUnit" + i] != null)
                        {
                            Model.RecipeManagement.AddIngredientToRecipe(Request["IngredientName" + i].ToString().ToLower(), double.Parse(Request["IngredientAmount" + i]), int.Parse(Request.Form["AmountUnit" + i]));
                        }
                    }
                }

                if (Request.Files != null)
                {
                    HttpPostedFile file = Request.Files[0];
                    string pictureName = id.ToString() + "1" + System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/user_upload"), pictureName);
                    file.SaveAs(path);

                    //Write to datbase
                    Model.RecipeManagement.AddRecipePicture((Path.Combine("/Content/user_upload", pictureName)).Replace("\\", "/"));
                }
                Response.Redirect("/View/RecipeManagement/RecipeViewer.aspx?RecipeID=" + redirectID);

            }
        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}