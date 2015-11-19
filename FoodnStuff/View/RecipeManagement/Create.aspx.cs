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
            int id;
            if (Request.Cookies["UserLogIn"] != null)
            {
                if (Request.Cookies["UserLogIn"]["UID"] != null)
                {
                    String ID = Request.Cookies["UserLogIn"]["UID"].ToString();
                    id = Convert.ToInt32(ID);
                }
            }
            else {
                id = 0;
            }

        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}