<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="FoodnStuff.View.SearchResultManagement.Result" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
   <div runat="server" id="wrapper" class="col-md-offset-2">
   </div>
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
    .thumb {
        padding-left:0px;
        margin-left: 0px;
        width:100%;
        min-height:179px;
    }
    .recipe-name {
        color: #FD7E2D;
    }
    .item {
       background-color:white;
       margin-right: 3%;
       border: solid 2px;
       padding: 0 0 0 0px;
       margin-bottom:3%;
       min-height:450px;
       max-height:450px;
    }
    hr {
      font-size:50px;
    }
    .div-details {
       padding-left:3%;
       padding-right:3%;
    }
    .a-container {
        color: #0060B6;
        text-decoration:none;
    }
</style>
    </asp:Content>