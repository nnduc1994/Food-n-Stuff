using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodnStuff;
using FoodnStuff.Model;
using System.Reflection;

namespace FoodnStuff.View.UserManagement
{
    public partial class Register : System.Web.UI.Page
    {
        FoodnStuff.Model.UserManagement UM = new Model.UserManagement();
        //dont asked me why, I have tryed use FoodnStuff.Model.UserManagement.Function
        //                               but this think dont work at all, so I crated a new obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition{ Path= "~/scripts/jquery-2.1.1.min.js"});
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (this.IsValid)
                UM.Register(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text);
        }
        protected void ValidateUname(object source, ServerValidateEventArgs args)
        {   
           
            if (UM.CheckForUname(TextBox1.Text)==true)
               args.IsValid =  false;
           else
               args.IsValid = true;
        }
        protected void ValidateEmail(object source, ServerValidateEventArgs args)
        {
            if (UM.CheckForEmail(TextBox3.Text) == true)
                args.IsValid = false;
            else
                args.IsValid = true;
        }
    }
}