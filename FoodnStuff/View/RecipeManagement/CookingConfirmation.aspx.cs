using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodnStuff.View.RecipeManagement
{
    public partial class CookingConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["RecipeID"] != null && Session["UID"] != null) {
                //Use this to call or calculate as you wish
                int RecipeID = Convert.ToInt16(Request["RecipeID"]);
                int UserID = Convert.ToInt16(Session["UID"]);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Use this function to calculate
        }
    }
}