<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="FoodnStuff.View.UserManagement.Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-offset-3 col-md-6 sub-container">
            <form id="form1" runat="server">
                <h1>EDIT PROFILE</h1>
                <hr />
                <br />
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-5">
                            <label>User Name:</label>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="Label1" runat="server" Text="User Name here"></asp:Label>
                        </div>
                    </div>
                    <!--end div row username -->
                    <br />
                    <div class="row">
                        <div class="col-md-5">
                            <label>Name:</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!--end div row Name -->
                    <br />
                     <div class="row">
                        <div class="col-md-5">
                            <label>Email:</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="Add mail in correct format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <br />
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please, write another mail" OnServerValidate="ValidateEmail"></asp:CustomValidator>
                        </div>
                    </div>
                    <!--end div row Email -->
                    <br />
                     <div class="row">
                        <div class="col-md-5">
                            <label>New Password (leave empty if you don't want to change):</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox4" runat="server" class="form-control" type="password"></asp:TextBox>
                        </div>
                    </div>
                    <!--end div row Password -->
                    <br />
                    <asp:Button ID="Button4" runat="server" class="btn btn-lg btn-danger" Text="Trigger Reminder" OnClick="Button4_Click" />
                    <asp:Button ID="Button5" runat="server" class="btn btn-lg btn-danger" Text="My Storage" OnClick="Button5_Click" />
                    <br /><br /><br />
                    <asp:Button ID="Button1" runat="server" Text="Update Info" class="btn btn-lg btn-danger" OnClick="Button1_Click1" />
                    <asp:Button ID="Button2" runat="server" Text="LogOut" class="btn btn-lg btn-danger" OnClick="Button2_Click" />
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
