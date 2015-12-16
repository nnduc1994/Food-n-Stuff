<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="RecipeViewer.aspx.cs" Inherits="FoodnStuff.View.RecipeManagement.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="banner" style="background-image:url('<%=mRecipe.PicturePath%>')">
        <div class="grey-filter">
            <div class="row">
                    <div class="container text-center" style="padding-top:60px;">
                         <h1><%=mRecipe.Name %></h1>
                    </div>
                      <!--end div col-md-7 ( text box and button) -->
            </div>
        </div>
    </div><!--end div banner -->
    <div class="container">
       <div class="important-details">
           <div class="row">
               <div class="col-md-3">
                    <h4>Created by: <%=mRecipe.AuthorName %></h4>
                   <h4>Duration: <%=mRecipe.Duration %> Minutes</h4>
                    <%for(int p=1; p <= mRecipe.Vote; p++) { %> 
                         <img src="../../Content/star/star.png" class="vote-img"/>
                    <%} %>
               </div>
               <div class="col-md-6">
                    <i>What do you think about this Recipe? Give us your rating (from 1 to 5)</i>
                   <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" style="width:20%;margin-bottom:10px;"></asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="Rate" class="btn btn-info btn-sm" OnClick="Button1_Click"/>
               </div>
           </div>
        </div>
        <div class="ingredient-list">
            <div class="table-responsive">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>Ingredient</th>
                            <th>Amount</th>
                            <th>Unit</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%foreach(var ingredient in mRecipe.IngredientList) { %>
                            <tr>
                                <td><%=ingredient.Name %></td>
                                <td><%=ingredient.Amount %></td>
                                <td><%=ingredient.Unit %></td>
                            </tr>
                        <%} %>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="instruction">
            <h3>Instruction</h3>
            <p><%= mRecipe.Instruction %></p>
        </div>
         <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Calculate Cost" class="btn btn-lg btn-danger"/>
            
                        <asp:Button ID="Button3" runat="server" Text="Save" class="btn btn-lg btn-info" OnClick="Button3_Click" />
                        <br />
                        <h4>Add to your eating plan</h4>


                        <div class="form-group">
                                <asp:TextBox ID="TextBox2" runat="server" class="form-control" style="width:30%;" placeholder="pick a date" ></asp:TextBox>
                                <br />
                                <asp:Button ID="Button4" runat="server" Text="Add to my plan" class="btn btn-lg btn-success " style="width:30%;" OnClick="Button4_Click" />
                        </div>
                                    <asp:Label ID="Label1" runat="server" Text="Label" style="display: none;"></asp:Label>
    </div>



                            
<style>
    .important-details {
        padding-top:50px;
    }
          .banner {
            min-height: 520px;
            min-width:100%;
            background-size: cover;
        }
              .grey-filter {
               background-color:rgba(19, 19, 19, 0.6);
        min-height: 520px !important;
        min-width: 100%;
    }
                h1 {
                    padding-top:100px;
            font-size: 500%;
            color: white;
            font-family: 'Benton Sans', 'Helvetica Neue', Helvetica, Roboto, Arial, sans-serif;
        }
            .vote-img {
            max-width:100%;
            height:20px;

        }
</style>

    </asp:Content>