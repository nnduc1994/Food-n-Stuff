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
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryString = "";
            if (Request["hint"] != null)
            {
                queryString = Request["hint"];
            }
            else
            {
                queryString = null;
            }

            List<Recipe> recipeList = Model.RecipeManagement.getRecipe(null, queryString);

            int numberRecordPerRow = 3;
            int numberRows = recipeList.Count();
            if (numberRows * numberRecordPerRow < recipeList.Count())
            {
                numberRows = numberRows + 1;
            }

            for (int i = 0; i < numberRows; i++)
            {
                HtmlGenericControl row = new HtmlGenericControl("div");
                row.Attributes.Add("class", "row");
                for (int j = 0; j < numberRecordPerRow; j++)
                {

                    if ((i * numberRecordPerRow + j) < recipeList.Count)
                    {
                        HtmlGenericControl a = new HtmlGenericControl("a");
                        a.Attributes.Add("href", "/View/RecipeManagement/RecipeViewer.aspx?RecipeID=" + recipeList[i* numberRecordPerRow+j].ID);
                        a.Attributes.Add("class", "a-container");
                        HtmlGenericControl divItem = new HtmlGenericControl("div");
                        divItem.Attributes.Add("class", "col-md-3 item");
                        HtmlGenericControl img = new HtmlGenericControl("img");
                        img.Attributes.Add("class", "thumb thumbnail");
                        img.Attributes.Add("src", recipeList[i * numberRecordPerRow + j].PicturePath);
                        divItem.Controls.Add(img);
                        HtmlGenericControl detailsDiv = new HtmlGenericControl("div");
                        detailsDiv.Attributes.Add("class", "div-details");
                        HtmlGenericControl title = new HtmlGenericControl("label");
                        title.InnerText = recipeList[i * numberRecordPerRow + j].Name;
                        title.Attributes.Add("class", "recipe-name");

                        //Get vote
                        HtmlGenericControl vote = new HtmlGenericControl();
                        vote.InnerText = recipeList[i * numberRecordPerRow + j].Vote.ToString();

                        detailsDiv.Controls.Add(vote);
                        detailsDiv.Controls.Add(title);

                        HtmlGenericControl ingredientText = new HtmlGenericControl("p");
                        ingredientText.InnerText = "Ingredients";
                        detailsDiv.Controls.Add(ingredientText);

                        HtmlGenericControl ingredientWrapper = new HtmlGenericControl("div");

                        //If more than 5 ingredients in the ingredient list
                        if (recipeList[i * numberRecordPerRow + j].IngredientList.Count > 3)
                        {
                            for (int u = 0; u < 3; u++)
                            {
                                HtmlGenericControl ingredientParagraph = new HtmlGenericControl("p");
                                ingredientParagraph.InnerText = recipeList[i * numberRecordPerRow + j].IngredientList[u].Amount + " " + recipeList[i * numberRecordPerRow +j].IngredientList[u].Unit + " " + recipeList[i * numberRecordPerRow + j].IngredientList[u].Name;
                                ingredientWrapper.Controls.Add(ingredientParagraph);

                                if (u == 2 && u < recipeList[i * numberRecordPerRow + j].IngredientList.Count)
                                {
                                    HtmlGenericControl threeDots = new HtmlGenericControl("p");
                                    threeDots.InnerText = "Read More";
                                    ingredientWrapper.Controls.Add(threeDots);
                                }
                            }
                        }
                        else
                        {
                            for (int u = 0; u < recipeList[i * numberRecordPerRow + j].IngredientList.Count; u++)
                            {
                                HtmlGenericControl ingredientParagraph = new HtmlGenericControl("p");
                                ingredientParagraph.InnerText = recipeList[i * numberRecordPerRow + j].IngredientList[u].Amount + " "+ recipeList[i * numberRecordPerRow + j].IngredientList[u].Unit + " " + recipeList[i * numberRecordPerRow + j].IngredientList[u].Name;
                                ingredientWrapper.Controls.Add(ingredientParagraph);
                            }
                        }

                            detailsDiv.Controls.Add(ingredientWrapper);

                            HtmlGenericControl CreatedByText = new HtmlGenericControl("p");
                            CreatedByText.InnerText = "Created by " + recipeList[i * numberRecordPerRow + j].AuthorName;
                            detailsDiv.Controls.Add(CreatedByText);

                            divItem.Controls.Add(detailsDiv);
                            a.Controls.Add(divItem);

                            row.Controls.Add(a);
                        }
                    }

                    wrapper.Controls.Add(row);
                }


            }
        }
    }
