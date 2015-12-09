using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodnStuff;

namespace FoodnStuff.View.UserManagement
{
    public partial class Edit : System.Web.UI.Page
    {
        FoodnStuff.Model.UserManagement UM = new Model.UserManagement();
       static string id,name;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition { Path = "~/scripts/jquery-2.1.1.min.js" });
      
            if (Request.Cookies["UserLogIn"] != null)
            {
                if (Request.Cookies["UserLogIn"]["UID"] != null)
                {
                    String ID = Request.Cookies["UserLogIn"]["UID"].ToString();
                    id = ID;
                    name = UM.getData("UserName",ID);
                    Label1.Text = name;
                    if (TextBox2.Text == "")
                    {
                        TextBox2.Text = UM.getData("Name", ID);
                        TextBox3.Text = UM.getData("Email", ID);
                    }
                }
            }
        }
        protected void ValidateEmail(object source, ServerValidateEventArgs args)
        {
           
            if (UM.CheckForEmail(TextBox3.Text) == true)
                args.IsValid = false;
            else
                args.IsValid = true;
            if (TextBox3.Text == UM.getData("Email", id))
            {
                args.IsValid = true;
            }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
           if (this.IsValid) {
               UM.EditProfile(id, TextBox2.Text, name, TextBox3.Text, TextBox4.Text);
                 }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/StorageManagement/MyStorage.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Session["UID"] != null) {
                int userID = Convert.ToInt16(Session["UID"]);
                Model.Email.sendRemindEmail(userID);
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/View/UserManagement/CookingHistory.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/UserManagement/WishList.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserLogIn"]["UID"] != null) {
                Response.Cookies["UserLogIn"].Expires = DateTime.Now.AddDays(-1);
            }
       
            Server.Transfer("Login.aspx", true);
        }
    }
}