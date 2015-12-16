using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodnStuff.Model;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

namespace FoodnStuff.View.SearchResultManagement
{
    public partial class Result : System.Web.UI.Page
    {
        public List<Recipe> recipeList = new List<Recipe>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("Sort");
                DropDownList1.Items[0].Value = "0";
                DropDownList1.Items.Add("By Rating");
                DropDownList1.Items[1].Value = "1";
                DropDownList1.Items.Add("By Duration");
                DropDownList1.Items[2].Value = "2";

                string queryString = "";

                if (Request["hint"] != null)
                {
                    queryString = Request["hint"];
                    Label1.Text = queryString;
                }
                else
                {
                    queryString = null;
                }

                if (Request["hint"] != null) {
                    recipeList = Model.RecipeManagement.getRecipe(null, queryString);
                }

                if (Request["CategoryID"] != null && Request["hint"] == null) {
                    List<int> CategoryIdList = new List<int>();
                    CategoryIdList = Model.RecipeManagement.GetRecipeIDBelongToCategory(Convert.ToInt16(Request["CategoryID"]));
                    if (CategoryIdList.Count > 0) {
                        List<Recipe> subList = new List<Recipe>();
                        foreach (int i in CategoryIdList) {
                            subList = Model.RecipeManagement.getRecipe(i, null);
                            recipeList.Add(subList[0]);
                        }
                    }
                }


            }
           
            if (IsPostBack)
            {
                string queryString = "";

                if (Request["hint"] != null)
                {
                    queryString = Request["hint"];
                    Label1.Text = queryString;
                }
                else
                {
                    queryString = null;
                }
                if (Request["hint"] != null)
                {
                    recipeList = Model.RecipeManagement.getRecipe(null, queryString);
                }

                if (Request["CategoryID"] != null && Request["hint"] == null)
                {
                    List<int> CategoryIdList = new List<int>();
                    CategoryIdList = Model.RecipeManagement.GetRecipeIDBelongToCategory(Convert.ToInt16(Request["CategoryID"]));
                    if (CategoryIdList.Count > 0)
                    {
                        List<Recipe> subList = new List<Recipe>();
                        foreach (int i in CategoryIdList)
                        {
                            subList = Model.RecipeManagement.getRecipe(i, null);
                            recipeList.Add(subList[0]);
                        }
                    }
                }
                if (DropDownList1.SelectedValue == "1")
                {
                    recipeList = recipeList.OrderByDescending(x => x.Vote).ToList();
                }
                else if(DropDownList1.SelectedValue == "2") {
                    recipeList = recipeList.OrderBy(x => x.Duration).ToList();
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string hint = TextBox1.Text;
            Response.Redirect("/View/SearchResultManagement/Result.aspx?hint=" + hint);

        }
    }
    }
