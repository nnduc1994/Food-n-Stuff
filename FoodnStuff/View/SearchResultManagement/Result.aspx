<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="FoodnStuff.View.SearchResultManagement.Result" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%
        int NumberRecordPerRow = 3;
        int NumberRows = recipeList.Count() / NumberRecordPerRow;
        if (NumberRows * NumberRecordPerRow < recipeList.Count())
        {
            NumberRows = NumberRows + 1;
        }
      
    %>
    <asp:Label ID="Label1" runat="server" Text="Label" style="display:none;"></asp:Label>
 <div class="banner">
        <div class="grey-filter">
            <div class="row">
                    <div class="container text-center" style="padding-top:10px;padding-bottom:15px;">
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
                <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" style="width:200px; margin-bottom:30px;" AutoPostBack="True"></asp:DropDownList>
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
                                                        <img src="../../Content/star/star.png" class="vote-img"/>
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
            min-height:120px;
            min-width:100%;
            background-size: cover;
            background-image:url('../../Content/img/banner2.jpg');
        }
    .grey-filter {
               background-color:rgba(19, 19, 19, 0.6);
        min-height: 120px !important;
        min-width: 100%;
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
       
</style>
    </asp:Content>