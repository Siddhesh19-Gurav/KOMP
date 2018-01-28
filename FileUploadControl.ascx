<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUploadControl.ascx.cs" Inherits="PeraFin.FileUploadControl" %>
      <link href="Styles/uploadify.css" rel="stylesheet" type="text/css" />       

<%--Javascript--%>
        <script src="Scripts/jquery.uploadify.js" type="text/javascript"></script>
<script type="text/javascript">

    var FolderName = "<%=UploadInFolder%>";
    //var FolderName = "";

    function SetPictureCommon(event, id) {

       
        if (PropertyPic.indexOf(event) == -1) {

            PropertyPic = (PropertyPic == '') ? event : PropertyPic + "$" + event;
            
            //                    $("img[src*='defPr.png']").parent().remove();                  
            //                    $("#dipPics").append("<div id='div"+id+"' style='float:left; overflow:hidden; width:80px;height:80px' class='RoundCorner' onmouseout=HideRemoveButton('div"+id+"')  onmouseover=ShowRemoveButton('div"+id+"') >"+
            //                    "<img style='width:auto;height:80px' src='../images/Project/"+event+"' />"+
            //                    "<input type='button' style='display:none;position:absolute;margin-left:-20px' onclick=Remove('"+event+"') value='Remove' />"+
            //                    "</div>");



            if (FolderName == "SubProduct") {
             
                SetPicturesNews("dipPics", id, "../Images/" + FolderName + "/thumbs/thumbs_" + event, event);
             
            }
            else
                SetPicturesProject("dipPics", id, "../Images/" + FolderName + "/thumbs/thumbs_" + event, event);                

        }
    }



    function SetPictureOnSelect(ContainerDivID, InnerDivId, FullPicPath, PicNameOnly) {

        SetPicturesProject(ContainerDivID, InnerDivId, FullPicPath, PicNameOnly);
    }


    function SetPicturesProject(ContainerDivID, InnerDivId, FullPicPath, PicNameOnly) {

        $("#imgProperty").attr("src", FullPicPath);
//                         $("#ltrlImage").append("<div id='" + PicNameOnly + "' ><a rel='selectedGroup' class='aaa' title='PicNameOnly' href='" + FullPicPath + "'>" +
//                         "<img src='" + FullPicPath + "' width='40' height='30' /></a><input id='chk" + PicNameOnly + "' type='checkbox' /></div>");
                         $("#hdnImageNws").val(PicNameOnly);
                     

    }


    function SetPicturesNews(ContainerDivID, InnerDivId, FullPicPath, PicNameOnly) {
        if (InnerDivId == "1") {
            $("#" + ContainerDivID).html('');
        }

        $("#dipPics img[src*='textbg.png']").parent().remove();
        $("#" + ContainerDivID).html("<div id='div" + InnerDivId + "' style='float:left;position:relative; overflow:hidden; width:299px;height:290px' class='RoundCorner' onmouseout=HideRemoveButton('div" + InnerDivId + "')  onmouseover=ShowRemoveButton('div" + InnerDivId + "') >" +
                    "<img style='width:299px;height:290px' src='" + FullPicPath + "' />" +
                    "<input type='button' style='display:none;position:absolute;top:0;left:0px;' onclick=RemoveProjectPic('" + PicNameOnly + "') value='Remove' />" +
                    "</div>");
        $("#hdnImageNws").val(PicNameOnly);
       
    }


    function HideRemoveButton(ctrId) {
        $("#" + ctrId + " input").hide();
    }

    function ShowRemoveButton(ctrId) {
        $("#" + ctrId + " input").show();
    }

    function RemoveProjectPic(pic) 
    {
      
        PropertyPic = PropertyPic.replace("$" + pic, '');
        PropertyPic = PropertyPic.replace(pic + "$", '');
        PropertyPic = PropertyPic.replace(pic, '');
        $("img[src*='" + pic + "']").parent().remove();

        if (PropertyPic == "") 
        {
            $("#dipPics").append("<div style=' float:left; overflow:hidden; width:80px;height:80px'><img id='imgProperty'  style='width:auto;height:80px' src='../images/Property/defPr.png'  /></div>");
        }

    }




    function guid() {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
               .toString(16)
               .substring(1);
        }
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
         s4() + '-' + s4() + s4() + s4();
    }

//    $(function () {

//    });


    $(document).ready(function () {
        setTimeout(function () {
            $("#<%=file_upload.ClientID%>").uploadify({
                'buttonText': 'Select Files',
                'fileSizeLimit': '3MB',
                'swf': 'uploadify.swf',
                'uploader': 'Uploader.ashx',
                'cancelImg': '../cancel.png',
                'buttonText': 'Select Files',
                'fileDesc': 'Image Files',
                'fileExt': '*.jpg;*.jpeg;*.gif;*.png',
                'multi': true,
                'auto': true
            });
        }, 0);
    });






</script>


       

       <div style="width:299px;height:290px" >

       <div style=" float:left; overflow:hidden; width:299px;height:290px" id="dipPics"  >
            <div style="float:left; overflow:hidden; width:299px;height:290px"><img id="imgProperty" style="width:299px;height:auto" src="images/textbg.png"  /></div>
       </div>
    


    <div style="width: auto; height:auto;  margin-left:3px; float:left ;cursor:pointer; margin-top:5px;"  id="Div19"  >
        <asp:FileUpload ID="file_upload" runat="server" />
    </div>	
    
      
    <%--  <div style="width:80px;height:29px; margin-top:50px; float:left ;cursor:pointer"  id="Div18" onclick="CancelUploadAction();" >
        <div   style=" clear:both;  width:80px;height:29px;float:right; color:White; font-family:Myriad Pro;font-size:18px; font-weight:bold; text-align:center;  background-image:url(images/btnUploadCancel1.png)"  ></div>
      </div>--%>	

</div>
