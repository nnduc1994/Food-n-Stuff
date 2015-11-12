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
                            <label>Number of ingredient(s):</label>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="amount" runat="server" class="form-control" ></asp:TextBox>
                        </div>      
                        <div class="col-md-2">
                            <p onclick="Add_Onclick()">Add</p>
                        </div>
                    </div>
                    <br />
                                            <input name="AmountOfIngredient" id="TotalNumberOfIngredient" type="hidden"/>

                    <div id="Ingredients-container">
                    </div>
                    <br />
                     <div class="row">
                        <div class="col-md-5">
                            <label>Instruction</label>
                            <label>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            </label>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
           
                            <asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Create Recipe" class="btn btn-lg btn-danger" OnClick="Button1_Click"  />
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

    <script>
        function Add_Onclick() {
           
            var amountIngredients = document.getElementById("ContentPlaceHolder1_amount").value;
            var container = document.getElementById("Ingredients-container");

            var amountInput = document.getElementById("TotalNumberOfIngredient");
            amountInput.value = amountIngredients;

            container.innerHTML = "";
            var title = document.createElement("h3");
            title.textContent = "Ingredient(s)";
            container.appendChild(title);
            for (var i = 1; i <= amountIngredients; i++) {
                var rowDiv = document.createElement("div");
                rowDiv.style.cssText = "padding-bottom:2%;";
                rowDiv.className = "row";
                var divColMd5 = document.createElement("div");
                divColMd5.className = "col-md-5";
                var label = document.createElement("label");
                label.textContent = "Ingredient Name:";
                var divColMd5Second = document.createElement("div");
                divColMd5Second.className = "col-md-6";
                var textboxName = document.createElement("input");
                textboxName.type = "text";
                textboxName.className = "form-control";
                textboxName.name = "IngredientName" + i;
                divColMd5Second.appendChild(textboxName);
                divColMd5.appendChild(label);
                rowDiv.appendChild(divColMd5);
                rowDiv.appendChild(divColMd5Second);


                var rowDivSecond = document.createElement("div");
                rowDivSecond.className = "row";
                rowDivSecond.style.cssText = "padding-bottom:2%;";
                rowDivSecond.className = "row";
                var divColMd5Amount = document.createElement("div");
                divColMd5Amount.className = "col-md-5";
                var labelAmount = document.createElement("label");
                labelAmount.textContent = "Amount:";
                var divColMd5SecondAmount = document.createElement("div");
                divColMd5SecondAmount.className = "col-md-6";
                var textboxAmount= document.createElement("input");
                textboxAmount.type = "text";
                textboxAmount.className = "form-control";
                textboxAmount.name = "IngredientAmount" + i;
                divColMd5SecondAmount.appendChild(textboxAmount);
                divColMd5Amount.appendChild(labelAmount);
                rowDivSecond.appendChild(divColMd5Amount);
                rowDivSecond.appendChild(divColMd5SecondAmount);

                container.appendChild(rowDiv);
                container.appendChild(rowDivSecond);
            }
        }
    </script>
</asp:Content>
