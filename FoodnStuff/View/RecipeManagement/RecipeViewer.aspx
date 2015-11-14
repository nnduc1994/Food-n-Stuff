<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="RecipeViewer.aspx.cs" Inherits="FoodnStuff.View.RecipeManagement.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container">
    <div class="row">
        <div class="col-md-offset-2 col-md-8 sub-container">
            <form id="form1" runat="server">
                <h1>RECIPE VIEWER</h1>
                <hr />
                <br />
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-7">
                            <h2><asp:Label ID="lbRecipeName" runat="server" Text="<q>Recipe Name</q>"></asp:Label></h2>
                        </div>
                        <div class="col-md-5">
                            <div class="rating"><span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
                            </div>
                        </div>
                    </div>
                    <!--end div row recipe name -->
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <label>Ingredient(s)</label>
                        </div>
                    </div>
                    
                    <div class ="row">
                        <div class ="col-md-5">
                            <asp:Label ID="lbIngredient" runat="server" Text="<q>Ingredient</q>"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lbAmount" runat="server" Text="<q>Amount</q>"></asp:Label>
                        </div>
                    </div>
                    <!--end of div rows ingredients-->
                    <div class="container-fluid">
                        <asp:TextBox ID="txtbInstruction" runat="server" CssClass="form-control" ReadOnly="true">Instructions</asp:TextBox>
                    </div>
                    <!--end of div instruction-->
                </div>
                <!--end div form group-->
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