<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FoodnStuff.View.UserManagement.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-offset-3 col-md-6 sub-container">
                <h1>REGISTER</h1>
                <hr />
                <br />
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-3">
                            <label>User Name:</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please, write another UserName" OnServerValidate="ValidateUname"></asp:CustomValidator>
                        </div>
                    </div>
                    <!--end div row username -->
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <label>Name:</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please, add your name here"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <!--end div row Name -->
                    <br />
                     <div class="row">
                        <div class="col-md-3">
                            <label>Email:</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please, write another Email" OnServerValidate="ValidateEmail"></asp:CustomValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please, write Email in correct format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <!--end div row Email -->
                    <br />
                     <div class="row">
                        <div class="col-md-3">
                            <label>Password:</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox4" runat="server" class="form-control" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please, write password"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <!--end div row Password -->
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Register" class="btn btn-lg btn-danger" OnClick="Button1_Click1" />
                </div>
                <!--end div form-group-->
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
