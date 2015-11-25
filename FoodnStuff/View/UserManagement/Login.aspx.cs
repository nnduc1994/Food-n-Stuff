using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodnStuff;

namespace FoodnStuff.View.UserManagement
{
    public partial class Login : System.Web.UI.Page
    {
        FoodnStuff.Model.UserManagement UM = new Model.UserManagement();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition { Path = "~/scripts/jquery-2.1.1.min.js" });
      
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                string userID = UM.Login(TextBox1.Text, TextBox2.Text);
                Response.Cookies["UserLogIn"]["UID"] = userID;
                if (Session["UID"] == null){
                    Session["UID"] = userID;
                }
                Response.Cookies["UserLogIn"].Expires = DateTime.Now.AddDays(100);
                Server.Transfer("Edit.aspx", true);
            }
        }
        protected void ValidatePass(object source, ServerValidateEventArgs args)
        {

            if (UM.Login(TextBox1.Text,TextBox2.Text) == "0")
                args.IsValid = false;
            else
                args.IsValid = true;
        }
       
    }
}