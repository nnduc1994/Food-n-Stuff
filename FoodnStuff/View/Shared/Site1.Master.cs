using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodnStuff;

namespace FoodnStuff.View.Shared
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        FoodnStuff.Model.UserManagement UM = new Model.UserManagement();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserLogIn"] != null)
            {
                if (Request.Cookies["UserLogIn"]["UID"] != null)
                {
                    String ID = Request.Cookies["UserLogIn"]["UID"].ToString();

                    Session["UID"] = ID;
                    Session["Role"] = UM.getData("RoleId", ID);
                    Session["Uname"] = UM.getData("UserName", ID);
                    Label1.Text = "Hello, " + Session["Uname"].ToString();
                    //Add here code to show Welcome message on panel
                }
            }
            else
            {
                //Add here code to show Reg and login buttons on panel
            }
        }

        public void LogOut() {
            Session.Clear();
            Response.Cookies.Clear();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Register.aspx", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx", true);
        }
    }
}