using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodnStuff.Model;
using Newtonsoft.Json;

namespace FoodnStuff.View.Shared
{
    public partial class AjaxIngredientSuggestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string hint;
            if (Request["hint"] != null)
            {
                hint = Request["hint"].ToString();
                List<string> availableIngredients = Model.RecipeManagement.GetAvailableIngredientByName(hint);
                List<AjaxIngredient> ajaxList = new List<AjaxIngredient>();
                foreach (string s in availableIngredients)
                {
                    AjaxIngredient a = new AjaxIngredient();
                    a.Name = s;
                    ajaxList.Add(a);
                }
                string jsonString = JsonConvert.SerializeObject(ajaxList);
                Response.Clear();
                Response.Write(jsonString);
                Response.End();
            }
            else {
                Response.Clear();
                Response.Write("");
                Response.End();
            }
          
        }
        public class AjaxIngredient {
            public string Name { get; set; }
        }
    }
}