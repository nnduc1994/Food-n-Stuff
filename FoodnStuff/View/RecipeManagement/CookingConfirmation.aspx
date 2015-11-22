<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="CookingConfirmation.aspx.cs" Inherits="FoodnStuff.View.RecipeManagement.CookingConfirmation" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container">
    <div class="row">
        <div class="col-md-offset-2 col-md-8 sub-container">
            <form id="form1" runat="server">
                <h1>Cooking Confirmation</h1>
                <hr />
                <br />
                <div class="form-group">
                    <asp:Label ID="lbRecipeName" runat="server" Text="Recipe Name"></asp:Label>
                    <div class="row">
                        <div class="col-md-6">
                            <h3>Recipe Ingredient </h3>
                            <asp:Label ID="lbRecipeIngredient" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <h3>Available ingredient in Storage </h3>
                            <asp:Label ID="lbAvailableIngredient" runat="server" Text=""></asp:Label><br />
                        </div>
                        <asp:Button ID="Button1" runat="server" Text="Cook now!" class="btn btn-lg btn-danger" OnClick="Button1_Click" />
                    </div>
               </div> 
            </form>
        </div>
        <!--end of div sub-container-->       
    </div>
    <!--end of div row group-->
</div>

                            
<style>    
    .container {
        padding-top: 10%;
        padding-bottom: 5%;
    }

    .sub-container {
        background-color: white;
        padding-top: 3%;
        border: 3px solid;
        border-radius: 30px;
        padding-left: 3%;
        padding-bottom: 2%;
        border-color:#FD7E2D;
    }

    q {
        quotes: "«" "»";
    }

    label{
        font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        font-size:24px;
    }

    h1 {
        font-size: 400%;
        color: #FD7E2D;
        font-family: 'Times New Roman', Times, serif;
    }
    h2{

    }

    .rating {
        unicode-bidi: bidi-override;
        direction: rtl;
        font-size:24px;
    }
    .rating > span {
        display: inline-block;
        position: relative;
        width: 1.1em;
    }
    .rating > span:hover:before,
    .rating > span:hover ~ span:before {
        content: "\2605";
        position: absolute;
    }
</style>
    </asp:Content>