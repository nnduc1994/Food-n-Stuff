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
                if (Request.Cookies["UserLogIn"]["UID"] != null || Session["UID"] != null)
                {
                    String ID = Request.Cookies["UserLogIn"]["UID"].ToString();

                    Session["UID"] = ID;
                    Session["Role"] = UM.getData("RoleId", ID);
                    Session["Uname"] = UM.getData("Name", ID);
                }
            }

            if (Session["UID"] != null) {
                HyperLink1.Text = "Welcome, " + Session["Uname"].ToString();
                HyperLink1.NavigateUrl = "/View/UserManagement/Edit.aspx";
                Button1.Text = "Logout";
            }
            if (Session["UID"] == null){
                HyperLink1.Text = "Login";
                HyperLink1.NavigateUrl = "/View/UserManagement/Login.aspx";
                Button1.Text = "Register";
            }
        }

        public void LogOut() {
            Session.Clear();
            Response.Cookies["UserLogIn"].Expires = DateTime.Now.AddDays(-1);
        }

        protected void Button1_Click(object sender, EventArgs e) {
            if (Session["UID"] != null) {
                LogOut();
            }
            else
                Response.Redirect("/View/UserManagement/Register.aspx");
        }

    }
}