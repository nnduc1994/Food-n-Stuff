<%@ Page Title="Recipe Searcher" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FoodnStuff.View.Index" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        int NumberRecordPerRow = 3;
        int NumberRows = recipeList.Count() / NumberRecordPerRow;
        if (NumberRows * NumberRecordPerRow < recipeList.Count())
        {
            NumberRows = NumberRows + 1;
        }
        string className = "";
        int row =0;
    %>
    <div class="banner">
        <div class="grey-filter">
            <div class="row">
                    <div class="container text-center" style="padding-top:60px;">
                         <h1>Food n' Stuff</h1>
                    <h3 class="sub-title">Recipe library, meal planning and many more</h3>
                    </div>
                      <!--end div col-md-7 ( text box and button) -->
            </div>
        </div>
    </div><!--end div banner -->
    <div class="container">
                <div class="searchbox">
                     <div class="form-group col-md-4 col-md-offset-3">
                    <div class="input-group"> <span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>
                         <asp:TextBox ID="TextBox1" runat="server" class="form-control search" placeholder="Recipe Name"></asp:TextBox>
                    </div>
                    </div>
                    <div class="col-md-2">
                         <asp:Button ID="Button2" runat="server" Text="Let's Eat" class="btn btn-danger " OnClick="Button1_Click" />
                    </div>
                </div>
                 <h2>Popular Recipe</h2>
                   <% for (int i = 0; i < NumberRows; i++)
                       { %>
                      <div class="row wrapper">
                         
                          <% for (int j = 0; j < NumberRecordPerRow; j++) { %>
                             <%if ((i * NumberRecordPerRow + j) < recipeList.Count()){%>
                                <a  href="/View/RecipeManagement/RecipeViewer.aspx?RecipeID=<%=recipeList[(i * NumberRecordPerRow + j)].ID %>">
                                <div class="col-md-4">
                                    <div style="background-image:url('<%=recipeList[i * NumberRecordPerRow + j].PicturePath %>')" class="img-responsive thumbnail recipeImage"/>
                                        <div class="grey-filter2">
                                            <h3 class="recipeTitle"><%=recipeList[i * NumberRecordPerRow + j].Name %></h3>
                                             <div class="duration">
                                                    <p class="duration-text"><span class="glyphicon glyphicon-time"></span>&nbsp;<%=recipeList[i * NumberRecordPerRow + j].Duration %> Minutes</p>
                                                </div>
                                               <div class="vote">
                                                    <%for(int p=1; p <= recipeList[i * NumberRecordPerRow + j].Vote; p++) { %> 
                                                        <img src="../Content/star/star.png" class="vote-img"/>
                                                    <%} %>
                                                </div>
                                               
                                            <div class="Ingredient">
                                                <%if (recipeList[i * NumberRecordPerRow + j].IngredientList.Count() > 6){ %>
                                                    <ul>
                                                    <%for (int l = 0; l < 6; l++){ %>
                                                       <li><%=recipeList[i * NumberRecordPerRow + j].IngredientList[l].Amount %> <%=recipeList[i * NumberRecordPerRow + j].IngredientList[l].Unit %> <%=recipeList[i * NumberRecordPerRow + j].IngredientList[l].Name %></li>
                                                    <%} %>
                                                        <li><strong>Still More</strong></li>
                                                        </ul>
                                                <%} %>

                                                <%else{ %>
                                                    <ul>
                                                         <%for (int l = 0; l < recipeList[i * NumberRecordPerRow + j].IngredientList.Count(); l++){ %>
                                                       <li><%=recipeList[i * NumberRecordPerRow + j].IngredientList[l].Amount %> <%=recipeList[i * NumberRecordPerRow + j].IngredientList[l].Unit %> <%=recipeList[i * NumberRecordPerRow + j].IngredientList[l].Name %></li>
                                                        <%} %>
                                                    </ul>
                                                <%} %>
                                            </div>
                                        </div>
                                    </div>
                                    </a>
                                </div>
                             <%} %>
                          <% } %>
                      
                      </div>
                   <% } %>
               
            <h2 style="color:black">Discover by category</h2>
            <div class="category wrapper" style="margin-left:0%; margin-right:1%; padding-top:30px;">
                    <%for(int m=0; m < categoriesList.Count; m++) { %>
                        <%row++; if (row == 1) { className = "col-md-8"; } %>
                        <div class="<%=className %>" >
                            <div class="category" style="background-image:url('<%=categoriesList[m].ImagePath%>')">
                                <div class="grey-filter3">
                                    <h1 class="categoryTitle"><%=categoriesList[m].Name %></h1>
                                </div>
                            </div>
                        </div>
                        <% className = "col-md-4"; if (row == 6) { row = 0; } %>
                    <%} %>
            </div>
    <style>
     

        h1 {
            font-size: 300%;
            color: white;
            font-family: 'Benton Sans', 'Helvetica Neue', Helvetica, Roboto, Arial, sans-serif;
        }

        .sub-title {
            font-size:150%;
            color: white;
            font-family: 'Benton Sans', 'Helvetica Neue', Helvetica, Roboto, Arial, sans-serif;
        }

        .btn-danger {
            background-color: #FD7E2D;
                        height:50px;

        }

        .banner {
            min-height: 320px;
            min-width:100%;
            background-size: cover;
        }
        .searchbox{
           margin-top:20px;
           margin-bottom: 130px;
        }
        .search{
            height:50px;
            margin-bottom:0px !important;
            padding-bottom:0px !important;
        }
        .recipeImage {
            min-height:200px;
            background-size:cover;
            min-width:100%;
            background-repeat: no-repeat;
            padding: 0px 0px 0px 0px;
        }
        .grey-filter2{
            min-height:200px;
            background-color:rgba(19, 19, 19, 0.35);
            text-align:center;
        }
          

        .recipeTitle {
            color:white;
            margin-top:0px;
            margin-bottom:0px;
            font-family: 'Benton Sans', 'Helvetica Neue', Helvetica, Roboto, Arial, sans-serif;
            padding-top:75px;
              
        }
        .Ingredient {
            display:none;
        }
         .Ingredient ul {
              margin-bottom:0px;  
              padding-top:7px;
              padding-bottom:5px;
          }

        .Ingredient ul li {
            color:white;
            list-style-type: none;
            font-size: 120%;
            padding-bottom:0px;
            margin-bottom:0px;
        }
          .recipeImage:hover .Ingredient{
               display:block;
            }
        .recipeImage:hover .recipeTitle {
            display:none;
        }
        .recipeImage:hover .vote {
            display:none;
        }
        .recipeImage:hover .duration {
            display:none;
        }
        .vote-img {
            max-width:100%;
            height:20px;

        }
        .duration-text {
            color:white;
            font-size: 110%;
            margin-bottom:0px;
        }
        .vote{
            padding-top:5px;
        }
        .wrapper a{
            text-decoration:none;
        }
        .category {
            min-height:250px;
            background-size:cover;
            min-width:100%;
            background-repeat: no-repeat;
            padding: 0px 0px 0px 0px;
            margin-bottom: 20px;
           
        }
        .grey-filter3 {
                min-height:250px;
            background-color:rgba(19, 19, 19, 0.5);
            text-align:center;
        }
        .categoryTitle {
            padding-top:80px;
        }
        .category wrapper {
            margin-top:120px;
        }
    </style>

    <script>
                $(function () {
                    var banner = $(".banner");
                    var backgroundList = ["background:url('../../Content/img/banner.jpg');", "background:url('../../Content/img/banner2.jpg');", "background:url('../../Content/img/banner3.jpg');"];
                    var current = 0;
                    function nextBackground() {
                        banner.fadeOut(400, function () {
                            var style = backgroundList[current = ++current % backgroundList.length] + "background-size:cover; width: 100%; min-height:320px;";
                            banner.attr('style', style)
                            banner.fadeIn(400);
                            setTimeout(nextBackground, 5500);
                        })
                    };

                    setTimeout(nextBackground, 0);
                    banner.css('background', backgroundList[0]);
                });
            </script>
</asp:Content>
