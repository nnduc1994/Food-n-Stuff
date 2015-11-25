<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/View/Shared/Site1.Master"  CodeBehind="CookingHistory.aspx.cs" Inherits="FoodnStuff.View.UserManagement.CookingHistory" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-offset-3 col-md-6 sub-container">
            <form id="form1" runat="server">
                <h1>Cooking History</h1>
                <hr />
                <br />
                <div class="form-group">
                    <div runat="server" id ="wrapper"></div>
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