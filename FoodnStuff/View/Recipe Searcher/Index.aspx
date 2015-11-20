<%@ Page Title="Recipe Searcher" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FoodnStuff.View.Index" %>

<%@ Register src="RecipeControl.ascx" tagname="RecipeControl" tagprefix="uc1" %>
<%@ Reference Control="~/View/Recipe Searcher/RecipeControl.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
        <div class="col-md-offset-3 col-md-7">
        <h1><strong>Food n' Stuff</strong></h1>
        <label>Where cooking never get boring</label>
        <div class="row">
            <form id="form1" runat="server">
                <div class="form-group">
                <div class="col-md-6">
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Recipe Name"></asp:TextBox></div>
                <div class="col-md-4">
                    <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-danger" OnClick="Button1_Click" />
                </div>
                </div>
            </form>
            </div><!--end div col-md-7 -->
        </div><!--end div row second ( text box and button) -->
            
</div><!--end div row first -->
    </div>
    <div class ="container" id ="recipe">
        <div class="sub-container">
            <asp:Panel ID="Panel1" runat="server" class ="panel"></asp:Panel>
        </div>                     
    </div>
    <style>
        .container {
            padding-top: 10%;
            padding-bottom: 5%;
        }        

        h1 {
            font-size: 400%;
            color: #FD7E2D;
            font-family: 'Times New Roman', Times, serif;
        }               

        label {
            font-size: 210%;
            color: white;
            font-family: 'Informal Roman';
        }
        .btn-danger {
          background-color:#FD7E2D;
        }
    </style>    
</asp:Content>
