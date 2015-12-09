<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="RecipeViewer.aspx.cs" Inherits="FoodnStuff.View.RecipeManagement.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container">
    <div class="row">
        <div class="col-md-offset-2 col-md-8 sub-container">
                <h1>RECIPE DETAILS</h1>
                <hr />
                <br />
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-7">
                            <h2><asp:Label ID="lbRecipeName" runat="server" Text="<q>Recipe Name</q>"></asp:Label></h2>
                            <asp:Image ID="Image1" runat="server" class="star"/>
                            <br /><br />
                            <asp:Image ID="imgRecipe" runat="server" ImageUrl="~/Content/img/placeholder.jpg" style="max-width:100%;max-height:100%;"/>
                        </div>
                    </div>
                    <!--end div row recipe name -->
                    <br />
                        <div class="row">
                            <div class="col-md-12">
                                <label>Ingredient(s)</label><br />
                                <asp:Label ID="lbIngredient" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <!--end of div rows ingredients-->
                        <label>Instruction<br /></label><br />
                        <asp:Label ID="lbInstruction" runat="server" Text=""></asp:Label>
                        <br /><br />
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Calculate Cost" class="btn btn-lg btn-danger"/>
            
                        <asp:Button ID="Button3" runat="server" Text="Save" class="btn btn-lg btn-info" OnClick="Button3_Click" />
                        <br />
                        <h4>Add to your eating plan</h4>


                        <div class="form-group">
                                <asp:TextBox ID="TextBox2" runat="server" class="form-control" style="width:30%;" placeholder="pick a date" ></asp:TextBox>
                                <br />
                                <asp:Button ID="Button4" runat="server" Text="Add to my plan" class="btn btn-lg btn-success " style="width:30%;" OnClick="Button4_Click" />
                        </div>
                    
            
                <hr />
                <i>What do you think about this Recipe? Give us your rating (from 1 to 5)</i>
                <asp:TextBox ID="TextBox1" runat="server" class="form-control rate-box"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Rate" class="btn btn-info btn-sm" OnClick="Button1_Click"/>
                <asp:Label ID="Label1" runat="server" Text="Label" style="display: none;"></asp:Label>
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
    .star {
        width:50%;
    }
    .rate-box {
        width:17%;
        margin-bottom: 10px;
    }
</style>

    </asp:Content>