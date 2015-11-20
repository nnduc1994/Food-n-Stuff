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
                               <strong><label>Recipe Name:</label></strong> 
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <!--end div row recipe name -->
                        <br />
                        <div class="row">
                            <div class="col-md-5">
                                <strong><label>Ingredients</label></strong>
                            </div>

                        </div>
                        <br />
                        <input name="AmountOfIngredient" id="TotalNumberOfIngredient" type="hidden" />
                        <div id="Ingredients-container"></div>
                        <div class="row">
                            <div class="col-md-5">
                                <a onclick="Add_Onclick()">Click here to add more ingredient</a>
                            </div>
                        </div>
                        <br />
                          
                        
                        <div class="row">
                            <div class="col-md-5">
                                 <button class="btn-danger btn-sm upload_btn" type="button" style="width:70%;"> Upload Photo</button>
                                <input id="pictureUpload" name="UploadedFile" type='file' style=" display:none;" runat="server"/>
            
                            </div>
                            <div class="col-md-6">
                                 
                                <output id="previewPicture">
                                    <span>
                                        <img class="thumb" src="../../Content/img/placeholder.jpg" />
                                    </span>
                                </output>
                            </div>
                        </div> <!--end div row for preview Picture -->
                        <br />

                           <div class="row">
                            <div class="col-md-5">
                                <strong><label>Instruction</label></strong>
                            </div>
                            <div class="col-md-6">

                                <asp:TextBox ID="TextBox5" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>


                        <asp:Button ID="Button1" runat="server" Text="Create Recipe" class="btn btn-lg btn-danger" OnClick="Button1_Click" />
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
            background-color: #FD7E2D;
       
        }

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
        }

        h1 {
            font-size: 400%;
            color: #FD7E2D;
            font-family: 'Times New Roman', Times, serif;
        }
        a:hover {
            cursor : pointer;
       
        }
        .ajaxOption:hover {
            cursor:pointer;
        }

        .thumb {
        max-width: 100%;
        max-height: 400px;
        min-width: 100%;
        min-height: 100%;
        min-height:150px;
    }

    </style>

    <script>

        //Use for binding to button 
        $('.upload_btn').bind("click", function () {
            $('#ContentPlaceHolder1_pictureUpload').click();
            document.getElementById('ContentPlaceHolder1_pictureUpload').addEventListener('change', handleFileSelect);
        });

        ///Use broswer local storage to display review picture
        function handleFileSelect(evt) {
            var files = evt.target.files;

            var output = [];
            for (var i = 0, f; f = files[i]; i++) {

                // Only process image files.
                if (!f.type.match('image.*')) {
                    continue;
                }

                var reader = new FileReader();

                reader.onload = (function (theFile) {
                    return function (e) {
                        var span = document.createElement('span');
                        span.innerHTML = ['<img class="thumb" s src="' + e.target.result + '"/>'];
                        ///document.getElementById('previewPicture').replaceWith(span, null);
                        replaceElement(span);
                    };
                })(f);
                reader.readAsDataURL(f);

            }

        }

        ///Replace Element by new Element
        function replaceElement(replaceElement) {
                var ParentElement = $("#previewPicture");
                if (ParentElement.find("img").length > 0) {
                    $("#previewPicture img:last-child").remove()
                }
                ParentElement.append(replaceElement);
            }
 


        ///Use for Ajax call
        var amountOfIngredient = 0;
        var a;
        function Add_Onclick() {
            amountOfIngredient = amountOfIngredient + 1;
            var container = document.getElementById("Ingredients-container");

            var totalIngredient = document.getElementById("TotalNumberOfIngredient")
            totalIngredient.value = amountOfIngredient;

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
            textboxName.name = "IngredientName" + amountOfIngredient;
            textboxName.id = "IngredientName" + amountOfIngredient;
            textboxName.setAttribute("autocomplete","off");
            textboxName.addEventListener("keydown", function () {
                ingredientChange(this.value, amountOfIngredient);
            })
            //Ajax list come here
            var ajaxDiv = document.createElement("div");
            ajaxDiv.id = "ajaxDIv" + amountOfIngredient;

            ////Out focus remove suggestion
            //textboxName.addEventListener("focusout", function () {
            //    ajaxDiv.style.visibility = "hidden";
               
            //})
            //textboxName.addEventListener("focus", function () {
            //    ajaxDiv.style.visibility = "visible";

            //})

            divColMd5Second.appendChild(textboxName);

            divColMd5Second.appendChild(ajaxDiv);

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
            var textboxAmount = document.createElement("input");
            textboxAmount.type = "text";
            textboxAmount.className = "form-control";
            textboxAmount.name = "IngredientAmount" + amountOfIngredient;
            divColMd5SecondAmount.appendChild(textboxAmount);
            divColMd5Amount.appendChild(labelAmount);
            rowDivSecond.appendChild(divColMd5Amount);
            rowDivSecond.appendChild(divColMd5SecondAmount);

            container.appendChild(rowDiv);
            container.appendChild(rowDivSecond);
        }

        //Calling Ajax
        function ingredientChange(hint, num) {
           
            var url = "../Shared/AjaxIngredientSuggestion.aspx?hint=" + hint;

            loadXMLDoc(url, function () {
                if (req.readyState == 4 && req.status == 200) {//update field with responseText value
                    ingredientList = JSON.parse(req.responseText);
                    var nameList = [];
                    for (var u = 0; u < ingredientList.length; u++) {
                        nameList.push(ingredientList[u].Name);
                    }
                    var AjaxDiv = createSuggestionHTML(nameList,num);
                    var mainDiv = document.getElementById("ajaxDIv" + num);
                    mainDiv.innerHTML = "";
                    mainDiv.appendChild(AjaxDiv);
                }
            });

        }

        function loadXMLDoc(url, myfunc) {
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                req = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                req = new ActiveXObject("Microsoft.XMLHTTP");
            }
            req.onreadystatechange = myfunc;
            req.open("GET", url, true);
            req.send();
        }

        function createSuggestionHTML(list, num) {
            //Ajax list come here
            var ajaxDiv = document.createElement("div");

            if (list.length > 0) {
                ajaxDiv.style.cssText = "border:solid 1px;"
                var ajaxSelect = document.createElement("textbox");
                ajaxSelect.style.cssText = "width: 100%;"

                //Create option
                for (var a = 0; a < list.length; a++) {
                    var ajaxOption = document.createElement("option");
                    ajaxOption.className = "ajaxOption";
                    ajaxOption.value = list[a];
                    ajaxOption.innerHTML = list[a];
                    ajaxOption.addEventListener("click", function () {
                        var textbox = document.getElementById("IngredientName" + num);
                        textbox.value = this.value;
                        document.getElementById("ajaxDIv" + num).innerHTML = "";
                    });
                    ajaxSelect.appendChild(ajaxOption);
                }

                //append select to ajaxDiv
                ajaxDiv.appendChild(ajaxSelect);
            }
            return ajaxDiv;
        }



    </script>
</asp:Content>
