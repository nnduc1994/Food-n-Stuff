using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodnStuff.Model;

namespace FoodnStuff
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM UserTable Where UserName='nnduc1994'";
            var reader = myDatabase.ExcuteQuery(command);
            reader.Read();
            string a = reader["Name"].ToString();
            string b = reader["Email"].ToString();
            string c;
        }


    }
}