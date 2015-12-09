<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/View/Shared/Site1.Master"  CodeBehind="Plan.aspx.cs" Inherits="FoodnStuff.View.UserManagement.Plan" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/moment.min.js"></script>
    <script src="../../Scripts/fullcalendar.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Scripts/fullcalendar.css" />

    <div class="container">
    <div class="row">
        <div class="col-md-offset-1 col-md-10 sub-container">
                <h1>My Eating Plan</h1>
                <hr />
                <br />
                <div class="form-group">
                    <div runat="server" id ="wrapper"></div>
                  </div> 
                  <div id="calendar"></div>
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
    <script>
        <% foreach (var a in planList) {
        }%>
        var myCalendar = $('#calendar');
        myCalendar.fullCalendar({
           events
        })
    </script>
</asp:Content>