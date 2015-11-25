using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodnStuff.View.StorageManagement
{
    public partial class AddIngredient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<FoodnStuff.Model.Unit> unitList = Model.UnitManagement.ListAllUnit();
            for (int a = 0; a < unitList.Count; a++)
            {
                DropDownList1.Items.Add(unitList[a].Name);
                DropDownList1.Items[DropDownList1.Items.Count - 1].Value = unitList[a].ID.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["UID"] != null) {
                int userID = Convert.ToInt16(Session["UID"]);
                if (Request["AmountOfIngredient"] != null) {
                    int amountIngredient = Convert.ToInt16(Request["AmountOfIngredient"]);
                    for (int i = 1; i <= amountIngredient; i++)
                    {
                        if (Request["IngredientName" + i] != null && Request["IngredientAmount" + i] != null && Request.Form["AmountUnit" + i] != null && Request.Form["ExpiredDate" + i] != null)
                        {
                            Model.StorageManagement.AddIngredientToStorage(userID, Request["IngredientName" + i], double.Parse(Request["IngredientAmount" + i]), Convert.ToInt16(Request.Form["AmountUnit" + i]), Request.Form["ExpiredDate" + i].ToString());
                        }
                    }
                }
            }
            
        }
    }
}