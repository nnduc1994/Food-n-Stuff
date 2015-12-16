<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="CookingConfirmation.aspx.cs" Inherits="FoodnStuff.View.RecipeManagement.CookingConfirmation" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="banner">
        <div class="grey-filter">
            <div class="row">
                    <div class="container text-center" style="padding-top:60px; color:white; ">
                         <h3 style="font-size:300%;">Cooking Confirmation</h3>
                    </div>
                      <!--end div col-md-7 ( text box and button) -->
            </div>
        </div>
    </div>
<div class="container">
    <div class="row">
                <br />
                <div class="form-group">
                    <asp:Label ID="lbRecipeName" runat="server" Text="Recipe Name" style="font-size:180%; color:#F39353;"></asp:Label><br />
                    Total Price: <asp:Label ID="lbRecipePrice" runat="server" Text="Recipe Price"></asp:Label> euros
                    <div class="row">
                        <div class="col-md-6">
                            <h3>Recipe Ingredient </h3>
                            <asp:Label ID="lbRecipeIngredient" runat="server" Text=""></asp:Label>
                              <h3>Reminder </h3>
                            <asp:Label ID="lbRemind" runat="server" Text=""></asp:Label><br />
                            <h3>Total expected cost:</h3>
                            <asp:Label ID="lbTotalCost" runat="server" Text=""></asp:Label> euro(s)
                        </div>
                        <div class="col-md-6">
                            <h3>Available ingredient in Storage </h3>
                            <asp:Label ID="lbAvailableIngredient" runat="server" Text=""></asp:Label><br />
                            <asp:CheckBox ID="CheckBox1" runat="server" /> Email Reminder <br /><br />
                        <asp:Button ID="Button1" runat="server" Text="Cook now!" class="btn btn-lg btn-danger" OnClick="Button1_Click" /><br />

                        </div>
                          
                    </div>
               </div> 
        </div>
        <!--end of div sub-container-->       
    <!--end of div row group-->
</div>

                            
<style>    
           .banner {
            min-height:220px;
            min-width:100%;
            background-size: cover;
            background-image:url('../../Content/img/banner2.jpg');
        }
    .grey-filter {
               background-color:rgba(19, 19, 19, 0.6);
        min-height: 220px !important;
        min-width: 100%;
    }
</style>
    </asp:Content>