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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Control myControl = LoadControl("~/View/Recipe Searcher/RecipeControl.ascx");
            if(myControl != null)
            {
                ((Recipe_Searcher.WebUserControl1)myControl).Image1.ImageUrl = "http://500.co/wp-content/uploads/2015/02/love.png";
                Panel1.Controls.Add(myControl);
            }

        }
    }
}