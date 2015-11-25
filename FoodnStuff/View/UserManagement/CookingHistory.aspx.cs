using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodnStuff.Model;
using System.Web.UI.HtmlControls;

namespace FoodnStuff.View.UserManagement
{
    public partial class CookingHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UID"] != null) {
                List<HistoryRecipe> recipeList = RecipeHistoryManagement.GetRecList(Convert.ToInt16(Session["UID"]));
                List<DateTime> availableDate = new List<DateTime>();
                foreach (var reci in recipeList) {
                    if (!availableDate.Contains(reci.CookingDate)) {
                        availableDate.Add(reci.CookingDate);
                    }
                }

                availableDate = availableDate.OrderByDescending(o => o.Date).ToList();

                foreach (DateTime day in availableDate) {
                    List<HistoryRecipe> recipeList1 = recipeList.Where(o => o.CookingDate == day).ToList();
                    HtmlGenericControl DateText = new HtmlGenericControl("h3");
                    DateText.InnerText = day.ToShortDateString();
                    wrapper.Controls.Add(DateText);
                    foreach (var re in recipeList1) {
                        HtmlGenericControl a = new HtmlGenericControl("a");
                        a.Attributes.Add("href", "/View/RecipeManagement/RecipeViewer.aspx?RecipeID=" + re.RecipeID);
                        HtmlGenericControl RecipeName = new HtmlGenericControl("p");
                        RecipeName.InnerHtml = "¤ " + re.Name;
                        a.Controls.Add(RecipeName);
                        wrapper.Controls.Add(a);
                    }
                }

            }
        }
    }
}