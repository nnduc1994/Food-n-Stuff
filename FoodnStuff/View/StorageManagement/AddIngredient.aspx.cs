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

        }
    }
}