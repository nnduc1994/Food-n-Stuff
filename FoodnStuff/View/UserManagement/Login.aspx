<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FoodnStuff.View.UserManagement.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-offset-3 col-md-6 sub-container">
            <form id="form2" runat="server">
                <h1>LOGIN</h1>
                <hr />
                <br />
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-3">
                            <label>User Name:</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!--end div row username -->
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <label>Password:</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox2" runat="server" type="password" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!--end div row password -->
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Check input Parameters" OnServerValidate="ValidatePass"></asp:CustomValidator>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-lg btn-danger" OnClick="Button1_Click"/>
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
            height: 100%;
            padding-top: 5%;
            
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
