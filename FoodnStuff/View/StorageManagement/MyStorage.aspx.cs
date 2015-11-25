using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodnStuff.Model;

namespace FoodnStuff.View.StorageManagement
{
    public partial class MyStorage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UID"] != null) {
                int userID = Convert.ToInt16(Session["UID"]);
                List<Ingredient> ingredientList = Model.StorageManagement.GetAllStorageIngredient(userID);
                foreach (Ingredient ingre in ingredientList) {
                    Label1.Text += "¤ " + ingre.Amount + " " + ingre.Unit + " " + ingre.Name + " Expried date: " + ingre.ExpiredDay + "<br />";
                }
            }
        }
    }
}