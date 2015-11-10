<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="FoodnStuff.View.RecipeManagement.Create" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-offset-2 col-md-8 sub-container">
            <form id="form1" runat="server">
                <h1>CREATE NEW RECIPE</h1>
                <hr />
                <br />
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-5">
                            <label>Recipe Name:</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!--end div row recipe name -->
                    <br />
                    <div class="row">
                        <div class="col-md-5">
                            <label>Ingredient 1 ( at the moment recipe only content 2 ingredient):</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div><!--end div row ingre1 -->
                     <div class="row">
                        <div class="col-md-5">
                            <label>Ingre 1 amount:</label>
                        </div>
                        <div class="col-md-6">
                            hard code at the moment unit will be pound
                            <asp:TextBox ID="TextBox4" runat="server" class="form-control" ></asp:TextBox>
                        </div>
                    </div>
                    <!--end div row Unit -->
                    
                    <br />
                     <div class="row">
                        <div class="col-md-5">
                            <label>Ingredient 2 ( at the moment recipe only content 2 ingredient):</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!--end div row ingre2 -->

                     <div class="row">
                        <div class="col-md-5">
                            <label>Ingre 2 amount:</label>
                        </div>
                        <div class="col-md-6">
                            hard code at the moment unit will be pound
                            <asp:TextBox ID="TextBox6" runat="server" class="form-control" ></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    
                     <div class="row">
                        <div class="col-md-5">
                            <label>Instruction</label>
                        </div>
                        <div class="col-md-6">
           
                            <asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Create Recipe" class="btn btn-lg btn-danger"  />
                </div>
                <!--end div form-group-->
            </form>
        </div>
        <!--end div col-md-7-->
    </div>
        </div>
    <!--end div row first -->
    <style>
          .btn-danger {
          background-color:#FD7E2D;
        }
          
           .container {
         
           padding-top: 10%;
            padding-bottom: 5%;
        }
        .sub-container {
            background-color:white;
            padding-top:3%;
            border: 3px solid;
            border-radius: 30px;
            padding-left:3%;
            padding-bottom: 2%;
        }
         h1 {
            font-size: 400%;
            color: #FD7E2D;
            font-family: 'Times New Roman', Times, serif;
        }
    </style>
</asp:Content>
