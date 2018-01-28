<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePhotos.aspx.cs" Inherits="PeraFin.ManagePhotos" %>--%>
<%@ Page Title="Manage Photos" Language="C#" MasterPageFile="SiteSamarth.master" AutoEventWireup="true"    CodeBehind="ManagePhotos.aspx.cs" Inherits="PeraFin.ManagePhotos" %>
<%@ Register src="FileUploadControl.ascx" tagname="FileUploadControl" tagprefix="uc1" %>



<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="ContentPage" >
    <div class="CenterContainerMostOut" >
        <div class="CenterContainerOut" >
          <div class="CenterContainer" >

    <title>Manage Photos</title>
<style>
                p {
        padding: 0 0 1em;
        }
        .msg_list 
        {
        	width:610px;
        margin: 0px;
        padding: 0px;       
        }
        .msg_head {
        padding: 5px 10px;
        cursor: pointer;
        font-family:Arial;
        font-size:12px;
        font-weight:bold;
        position: relative;        
        margin:1px;
        background-image:url(images/3.png);background-repeat:repeat;      
        }
        .msg_body 
        {
        width:auto;
        height:auto;
        padding: 5px 10px 15px;
        background-color:#FAE8ED;
        font-family:lucida grande, tahoma, verdana, arial, sans-serif;font-size:13px;
        }
        
        .smallbutton
        {
         font-size:11px;	
         cursor:pointer;
        }
    </style>
    <script src="Scripts/jsFancy/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script src="Scripts/jsFancy/jquery.MultiFile.js" type="text/javascript"></script>
    <link href="Scripts/jsFancy/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jsFancy/jquery.fancybox-1.2.1.js" type="text/javascript"></script>         
    
    
    <script type="text/javascript">
        function GetFiles() {
            var folderName = $("#<%=Folders.ClientID%>").val();
            FolderName = folderName;
            $("#folderAction").hide();
            if (folderName != "0")
                $.ajax({
                    type: "POST",
                    url: "PerafinServices.asmx/GetFilesWithCheckBox",
                    contentType: "application/json; charset=utf-8",
                    data: "{imageFolder:'" + folderName + "',group:'selectedGroup'}",
                    dataType: "json",
                    success: function (result) {


                        $("#ltrlImage").html(result.d);
                        $("#folderAction").show();

                        $("a.fancy").fancybox();
                    },
                    error: function () { }
                });
        }

        function GetFilesForTitle() {
            var folderName = $("#<%=DropDownList1.ClientID%>").val();

            if (folderName != "0")
                $.ajax({
                    type: "POST",
                    url: "PerafinServices.asmx/GetFilesForTitle",
                    contentType: "application/json; charset=utf-8",
                    data: "{imageFolder:'" + folderName + "',group:'selectedGroup'}",
                    dataType: "json",
                    success: function (result) {
                        $("#literalTitleImage").html(result.d);
                    },
                    error: function () { }
                });
        }


        $(function () {

            $('.footer').hide();
            $("#btnDelete").click(function () { DeleteFiles() });
            $("#lstEvents").click(function () { $("#txtEvent").val($('#lstEvents option:selected').text()); $('#btnSubmit').val("Update"); });
            $("#btnNewEvent").click(function () {
                $("#txtEvent").val(''); $("#txtEvent").focus(); $("#lstEvents").val(1);

                $('#btnSubmit').val("Create");
            });

            $("#btnSubmit").click(function () { SaveEvent() });
            $("#btnDeleteEvent").click(function () { DeleteEvent() });

            $("#btnSaveTitle").click(function () { SaveTitle() });



        });

        function DeleteEvent() {
            var eventId = $('#lstEvents option:selected').val();
            if (eventId == undefined) {
                alert("Select an event from list to delete!");
                return false;
            }
            if (confirm("Are you sure want to delete?")) {
                if (confirm("Make sure. All contents and folders of this event would be removed from the system?")) {
                    $.ajax({
                        type: "POST",
                        url: "PerafinServices.asmx/DeleteEvent",
                        contentType: "application/json; charset=utf-8",
                        data: "{eventId:'" + eventId + "'}",
                        dataType: "json",
                        success: function (result) {
                            if (result.d) {
                                $('#lstEvents option:selected').remove();
                                alert("Deleted Successfully");
                            }
                            else
                            { alert("Problem to delete!"); }
                        },
                        error: function () { }
                    });
                }
            }
        }
        function SaveEvent() {
            if ($("#txtEvent").val() != "") {
                var eventId = $('#lstEvents option:selected').val();
                if ($('#btnSubmit').val() == "Create") {
                    eventId = "0";
                }
                $.ajax({
                    type: "POST",
                    url: "PerafinServices.asmx/SaveEvent",
                    contentType: "application/json; charset=utf-8",
                    data: "{eventId:'" + eventId + "',eventName:'" + $("#txtEvent").val() + "'}",
                    dataType: "json",
                    success: function (result) {
                        if (result.d > 0)//New event id i.e. newely added item
                        {
                            $('#lstEvents').append("<option value=" + result.d + " >" + $("#txtEvent").val() + "</option>");
                            window.location = "ManagePhotos.aspx";
                        }
                        else {
                            $('#lstEvents option:selected').text($("#txtEvent").val());
                        }

                        alert("Saved Successfully");
                    },
                    error: function () { }
                });
            }
        }



        function DeleteFiles() {
            var folderName = $("#<%=Folders.ClientID%>").val();
            var checkBoxes = $("input:checked");
            var files = "";
            for (var i = 0; i < checkBoxes.length; i++) {
                files = (i == 0) ? checkBoxes[i].id.replace("chk", "") : files + "," + checkBoxes[i].id.replace("chk", "");
            }

            if (files.length > 0) {//Start If
                $.ajax({
                    type: "POST",
                    url: "PerafinServices.asmx/DeleteFiles",
                    contentType: "application/json; charset=utf-8",
                    data: "{files:'" + files + "',folderName:'" + folderName + "'}",
                    dataType: "json",
                    success: function (result) {
                        $("#ltrlImage").html(result.d);
                        alert("Deleted Successfully");
                    },
                    error: function () { }
                });
            }
            else {
                alert("Select File(s).");
            }
        }

        //////////////////////////////////////Move Up/down

        function MoveDown() {
            var selectedOption = $('#<%=lstMainMenu.ClientID%> > option:selected');
            var nextOption = $('#<%=lstMainMenu.ClientID%> > option:selected').next("option");
            if ($(nextOption).text() != "") {
                $(selectedOption).remove();
                $(nextOption).after($(selectedOption));
            }
        }
        function MoveUp() {
            var selectedOption = $('#<%=lstMainMenu.ClientID%> > option:selected');
            var prevOption = $('#<%=lstMainMenu.ClientID%> > option:selected').prev("option");

            if ($(prevOption).text() != "") {
                $(selectedOption).remove();
                $(prevOption).before($(selectedOption));
            }
        }

        function MainMenuOrder() {

            var items = $('#<%=lstMainMenu.ClientID%> > option');
            var folders = '';
            for (i = 0; i < items.length; i++) {
                if (folders == '') {
                    folders = items[i].value;
                }
                else {
                    folders = folders + '^' + items[i].value; // alert( items[i].value);
                }
            }

            $.ajax({
                type: "POST",
                url: "PerafinServices.asmx/SaveFolderOrder",
                contentType: "application/json; charset=utf-8",
                data: "{folders:'" + folders + "'}",
                dataType: "json",
                success: function (result) { alert("Saved Successfully!"); },
                error: function (result1) { }
            });
            return false;
        }

        function SetAnimation() {
            $("div.msg_body").hide();

            $(".msg_body:first").show();

            //toggle the componenet with class msg_body  
            $(".msg_head").click(function () {

                if (!$(this).next(".msg_body").is(':visible')) {
                    $("div.msg_body").hide();
                    $(this).next(".msg_body").slideToggle(600, function () { });
                    //$("#divHotels,#ctl00_MainContent_literalDives").fadeIn(1000);                  
                }
                else {
                    $("div.msg_body:visible").animate({ height: "toggle" }, 600, function () { });
                    //$("#divHotels,#ctl00_MainContent_literalDives").fadeOut();

                }

            });
        }

        $(function () { SetAnimation(); });


        function SaveTitle() {


            var folderName = $("#<%=DropDownList1.ClientID%>").val();
            var totalFiles = $("#divImages img");
            var totalTitles = $("#divImages textarea");

            for (var i = 0; i < totalFiles.length; i++) {

                var file = totalFiles[i].id;
                var title = $(totalTitles[i]).val();
                $.ajax({
                    type: "POST",
                    url: "PerafinServices.asmx/SaveTitle",
                    contentType: "application/json; charset=utf-8",
                    data: "{imageFile:'" + file.replace("img", "") + "',title:'" + title + "',folderName:'" + folderName + "'}",
                    dataType: "json",
                    success: function (result) {
                        alert("Saved Successfully");
                    },
                    error: function () { }
                });

            }
        }

        //////////////////////////////////////////////
    </script>

    <script type="text/javascript">
        var PropertyPic = '';

        function PeraImage() {
            var Id;
            var Directory;
            var FileName;
            var Detail;
        }


        function Save() {

        

            var FirstPic = '';
            var splitPic = PropertyPic.split("$");
            var PictureList = new Array();
            var Folders = $("#<%=Folders.ClientID%> option:selected").html();

            for (var i = 0; i < splitPic.length; i++) {

                if (i == 0)
                    FirstPic = splitPic[i];
                var projectPictureObj = new PeraImage();
                projectPictureObj.Id = 0;
                projectPictureObj.Directory = Folders;
                projectPictureObj.FileName = splitPic[i];
                projectPictureObj.Detail = '';
                PictureList.push(projectPictureObj); //Add to list
            }






            $("#ImgProgress").show();


            $.ajax
                  ({
                      type: "POST",
                      url: "PerafinServices.asmx/SaveEventNPics",
                      data: "{peraImageList: " + JSON.stringify(PictureList) + "}",
                      contentType: "application/json",
                      dataType: "json",
                      success: function (data) {


                          for (var i = 0; i < splitPic.length; i++) {

                              $("#ltrlImage").html() = $("#ltrlImage").html + "<div id='" + splitPic[i] + "' ><a rel='selectedGroup' class='aaa' title='" + splitPic[i] + "' href='" + Folders + "/" + splitPic[i] + "'>" +
                         "<img src='" + folderName + "/" + fileName.Name + "' width='40' height='30' /></a><input id='chk" + splitPic[i] + "' type='checkbox' /></div>";


                          }



                          //                          $(".msg_body:first").hide();
                          //                          $("#ImgProgress,#imgFree,#imgPostHeader").hide();
                          //                          alert('You have successfully posted.');
                          //                          window.location.href = "Default.aspx?Q=123456789";

                      },
                      error: function (res) { alert("During Project Load -" + res.status + ' ' + res.statusText); }
                  });
        }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="divShow" style="width:700px; height:auto; margin:0 auto; font-family:Verdana;font-size:12px;" >     
    
    <p class='msg_head'> Add/Remove Photos </p>
    <div id="Div1"  class='msg_body' style="background-color:#D7DBF5">Select Folder to add/delete photos:
        <asp:DropDownList AutoPostBack="true" ID="Folders" runat="server" >        
        </asp:DropDownList> 
        
        <div id="folderAction" style="display:none" >
            <div style="background-color:#F5F5ED" id="ltrlImage"></div>
          <div style="background-color:#E8E4ED" >Add Photo: Click choose file to browse photo. More than one photo you can upload. Finally click on Upload All
             <%--<asp:FileUpload ID="FileUpload1" runat="server" class="multi" /> --%>
             <uc1:FileUploadControl ID="FileUploadControl1"  UploadInFolder="Project"  runat="server" />
        <br />
        <asp:Button ID="btnUpload" Visible="false"  runat="server" Text="Upload All" 
            onclick="btnUpload_Click" OnClientClick = "return Save();" />
            </div>            
          <div style="background-color:#DED5D7" >
          Delete Photos: Select above file(s) to delete <br />
          <input  type= "button" id="btnDelete"  value="Delete Files" />
          </div>
        </div>
     </div>
     
       <p class='msg_head'> Set Titels of Events Photos </p>
    <div id="divImages"  class='msg_body' style="background-color:#D7DBF5">Select Folder to set titles:
        <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server" >        
        </asp:DropDownList> 
        
      
            <div style="background-color:#F5F5ED;width:auto;height:auto" id="literalTitleImage"></div>
            <input  type= "button" id="btnSaveTitle"  value="Save" />
       
     </div>
        
      <p class='msg_head' style="display:none" > Set Sequence of Events</p>
        <div id='divMenuOrder' class='msg_body' style="background-color:#E0D7DA; display:none">
        <table><tr><td>
        <table><tr><td>            
        <asp:ListBox ID="lstMainMenu" Height="150px"   runat="server"></asp:ListBox>
        </td>
         <td>
             <asp:ImageButton ID="imgUp" OnClientClick="MoveUp();return false;" ImageUrl="~/Images/arrowUp.GIF" runat="server" /><br />
             <asp:ImageButton ID="imgDown" OnClientClick="MoveDown();return false;" ImageUrl="~/Images/arrowDown.GIF" runat="server" />
         </td>
         </tr>
         <tr><td colspan="2" >                         
                    <input id="btnOrder" type="button" class="btn" onclick="return MainMenuOrder()" value="Submit" /> 
                
         </td></tr>
         </table>
            </td><td valign="top">To change the order of menu, Select a menu <br/>move up/down and save it!</td></tr></table>
        </div>
        
       <p class='msg_head'> Add/Edit/Delete Events</p>
        <div id='div2' class='msg_body' style="background-color:#D7DBF5">
        <table width="100%" ><tr><td>
        <table  width="100%"><tr><td>            
        <asp:ListBox ID="lstEvents" Height="150px" runat="server"></asp:ListBox>
        </td>
         <td>             
         </td>
         </tr>
          <tr><td colspan="2" >                        
               <input id="btnNewEvent" type="button" value="New Event"  /> <input id="txtEvent" type="text" />
                
         </td></tr>
         <tr><td colspan="2" >                         
                    <input id="btnSubmit" type="button" class="btn"  value="Create" /> 
                
         </td></tr>
          <tr style="background-color:#D5EDE2"><td colspan="2" >                         
          Delete Event: Select Event from List and Cliek to Delete
                    <input id="btnDeleteEvent" type="button" class="btn" value="Delete" />                 
         </td></tr>
         </table>
            </td><td valign="top">Add/Edit/Delete Events!</td></tr></table>
        </div>

       <div style="width:662px;height:40px; margin:0 auto; margin-left:53px">
             <a href="Masters/CMS.aspx" style="margin:0 auto; color:Blue" >Cancel</a>
        </div>

    </div>

  

     


   </div>

        </div>
    </div>
 </div>
 </asp:Content>