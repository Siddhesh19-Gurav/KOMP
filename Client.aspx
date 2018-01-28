<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="KitchenOnMyPlate.Client" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script src="Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>--%>

	

    <script src="Scripts/ajaxfileupload.js" type="text/javascript"></script>
<script type="text/javascript" src="Scripts/jsManageJob.js"></script>

<script type="text/javascript">

    var pictureLogo = '';
    function ajaxFileUploadCV() {

        fileToUploadCV.fi
        
        if (!fileValidation('fileToUploadCV')) {
            return false;
        }

        ////        $("#loadingLogo").ajaxStart(function () {
        ////            $(this).show();
        ////        }).ajaxComplete(function () {

        ////            return false;
        ////            // $(this).hide();
        ////        });


        //  $("#ImgProgress img").css("margin-top", "2px");

        //$("#ImgProgress").height("600px").show();

        //  alert('2');

        $.ajaxFileUpload(
    {
        url: '<%= ResolveUrl("AjaxFileUploader.ashx")%>',
        secureuri: false,
        fileElementId: 'fileToUploadCV',
        dataType: 'json',
        data: { name: 'CV', id: 'id' },
        success: function (data, status) {

            alert('3');
            if (typeof (data.error) != 'undefined') {
                if (data.error != '') {
                    alert(data.error);
                } else {
                    cvUploadFile = data.msg;
                    $("#sCVName").html(data.msg).show();
                    //$("#loadingLogo").attr("src", "images/CoachingLogo/" + data.msg);
                    $("#ImgProgress").height("600px").hide();
                }
            }
            return false;
        },

        error: function (data, status, e) {
            alert(e);
        }
    }
    );

        return false;
    }

    function fileValidation(FileID) {
        if ($('#' + FileID).val() == '') {
            alert("No File Choosen.");
            return false;
        }
        var ext = $('#' + FileID).val().match(/\.(.+)$/)[1];
        switch (ext.toLowerCase()) {
            case 'doc':
            case 'docx':
            case 'rtf':
            case 'pdf':
            case 'gif':
                $('#buttonUpload').attr('disabled', false); $('#buttonUploadLogo').attr('disabled', false);
                break;
            default:
                $('#' + FileID).val('');
                alert('This is not an allowed file type.');
                return false;
        }
        return true;
    }

function button1_onclick() {

}

</script>
<input id="hdnCoachingId" type="hidden" value="0"  />

                <!--SLIDERNEWSTRT-->
                <div id="divSlider" runat="server" >
<!---/End-Animation---->
                <link rel="stylesheet" type="text/css" href="Styles/slider.css" />
                <link rel="stylesheet" type="text/css" href="Styles/animate.css" />         
                <div class="slider">
	    <div class="callbacks_container">
	      <ul class="rslides" id="slider">
	        <li>
	          <img src="images/banner/Client.jpg" alt="komp client">
	          
                 <%--<div class="caption wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>EAT HEALTHY.</span></h3>
	          </div>

              <div class="caption1 wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>SKIP THE DIET.</span></h3>
	          </div>--%>

	        </li>	       

	      </ul>
	  </div>
  </div>

                <%--    <div class="Tiffin">
                        <img style="margin-left:-5px;" src="images/banner/tiffin.png" alt=""/>                        
                      </div>

                      <div class="TiffinLeftText">                        
                        <img style="margin-left:25px;float:left" src="images/banner/qtL.png" alt=""/><span style="color:#451F0B;font-size:26px; font-weight:bolder;font-family:'ZapfElliptical711BT Bold'; float:left;margin-top:-5px;" >We Offer you the</span> <br/> 
                                                                                                <span style=" clear:both; margin-left:140px;color:#451F0B;font-size:26px; font-weight:bolder;font-family:'ZapfElliptical711BT Bold';float:left;margin-top:-5px" >Best test at Great Price</span><img style="margin-left:2px;float:left" src="images/banner/qtR.png" alt=""/>
                      </div>--%>
                      </div>
                <!--SLIDERNEWEND-->

<!--container end here-->
      <div class="row faq">
        <div style="clear:both" ></div>
         <article class="page-art">
                        <h1 class="page-titleMain">OUR CLIENTS</h1>
                        </article>
                  <div class="col-ms-12">
                  	<p>We are delighted to offer our valued clients with the goodness of our food and customized menus especially designed for them. We believe in building long term relationships through our appetizing meals and high quality standard of service.<br />
</p>
                   

<!--Contact Start-->
   
        
       
    


       
			     <div class="contact-form_grid" style="float:left; text-align:left">

              
                    <div style="clear:both" ></div> 
                    
                     <asp:HiddenField ID="hdnCV" runat="server" />
                    
                    
                    <div class="divider" style="margin-top:0px; margin-bottom:1px; "></div>
                   
                      		<div style="clear:both" ></div>

                            <div style="width:25%;float:left;">
                            <div><img alt="c1" src="images/clients/c1.jpg"/></div>                            
                            </div>

                            <div style="width:25%;float:left;padding-left:5px;padding-right:5px">
                            <div><img alt="c1" src="images/clients/c2.jpg"/></div>                            
                            </div>

                            <div style="width:25%;float:left;padding-left:5px;padding-right:5px">
                            <div><img alt="c1" src="images/clients/c3.jpg"/></div>                            
                            </div>

                            <div style="width:25%;float:left;padding-left:5px;padding-right:5px">
                            <div><img alt="c1" src="images/clients/c4.jpg"/></div>                            
                            </div>
                                 <div style="clear:both;height:20px" ></div> 

                            <div style="width:25%;float:left;">
                            <div><img alt="c1" src="images/clients/c5.jpg"/></div>                            
                            </div>
                            <div style="width:25%;float:left;padding-left:5px;padding-right:5px">
                            <div><img alt="c1" src="images/clients/c6.jpg"/></div>                            
                            </div>
                            <div style="width:25%;float:left;padding-left:5px;padding-right:5px">
                            <div><img alt="c1" src="images/clients/c7.jpg"/></div>                            
                            </div>
                            <div style="width:25%;float:left;padding-left:5px;padding-right:5px">
                            <div><img alt="c1" src="images/clients/c8.jpg"/></div>                            
                            </div>

                            

                            
           
                   <div style="clear:both" ></div>
			      </div>
   			  
              <div style="clear:both" ></div> 

        <!--Contact End-->

                   </div>
                      
     </div>           
     <!--container end here-->
</asp:Content>
