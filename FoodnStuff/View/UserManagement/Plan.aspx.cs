using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodnStuff.Model;
using System.Text;

namespace FoodnStuff.View.UserManagement
{
    public partial class Plan : System.Web.UI.Page
    {
        public List<PlanRecipe> planList = new List<PlanRecipe>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UID"] != null) {
                int userId = Convert.ToInt16(Session["UID"]);
                 planList = Model.PlanManagement.GetPlanRecipe(userId);
                StringBuilder myScript = new StringBuilder();
                myScript.Append("<script>");
                myScript.Append("var events=[];");
                foreach(var meal in planList)
                {
                    myScript.Append("var myEvent ={ title:" + "'" + meal.RecipeName + "'" +", start: new Date(" + "'" +meal.CookingDate + "'" + ")};");
                    myScript.Append("events.push(myEvent);");
                }
                myScript.Append("</script>");
                Response.Write(myScript.ToString());
            }
        }
    }
}