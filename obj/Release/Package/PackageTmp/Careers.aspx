<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Careers.aspx.cs" Inherits="KitchenOnMyPlate.Careers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script src="Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>--%>

	

    <script src="Scripts/ajaxfileupload.js" type="text/javascript"></script>
<script type="text/javascript" src="Scripts/jsManageJob.js"></script>

<script type="text/javascript">

    var pictureLogo = '';
    function ajaxFileUploadCV() {

//        fileToUploadCV.fi
        alert('1');
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
//        if ($('#' + FileID).val() == '') {
//            alert("No File Choosen.");
//            return false;
//        }
//        var ext = $('#' + FileID).val().match(/\.(.+)$/)[1];
//        switch (ext.toLowerCase()) {
//            case 'doc':
//            case 'docx':
//            case 'rtf':
//            case 'pdf':
//            case 'gif':
//                $('#buttonUpload').attr('disabled', false); $('#buttonUploadLogo').attr('disabled', false);
//                break;
//            default:
//                $('#' + FileID).val('');
//                alert('This is not an allowed file type.');
//                return false;
//        }
//        return true;
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
	          <img src="images/banner/career.jpg" alt="">
	          
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
                        <h1 class="page-titleMain">Join Kitchen On My Plate-KOMP</h1>
                        </article>
                  <div class="col-ms-12">
                  	<p>We are looking for talented and motivated people to build a passionate and winning team contributing towards the success of the company and delivering on our vision. If you are interested and excited to be part of KOMP journey, fill in the details below and attach your resume.
</p>
                   

<!--Contact Start-->
   
        
       
       <script type="text/javascript">

           $(function () {
               $("#sendBtncc").click(function () {


                   var name = $("#nameC").val();
                   var email = $("#emailC").val();
                   var mobile = $("#txtCphone").val();

                   var messaging = $("#messagingC").val();


                   if (name == '' || name == 'Your name') {
                       alert('Please enter name.');
                       $("#nameC").focus();
                       return false;
                   }
                   if (mobile == '' || mobile == 'Mobile') {
                       alert('Please enter contact number.');
                       $("#txtCphone").focus();
                       return false;
                   }
                   if (email == '' || email == 'Email ID') {
                       alert('Please enter email address.');
                       $("#emailC").focus();
                       return false;
                   }
                   if (messaging == '' || messaging == 'Message') {
                       alert('Please enter message.');
                       $("#messagingC").focus();
                       return false;
                   }



                   $.ajax({
                       type: "POST",
                       url: "KompServices.asmx/SendMsgToAgent",
                       contentType: "application/json; charset=utf-8",
                       data: "{name:'" + name + "',mobile:'" + mobile + "',email:'" + email + "',message:'" + messaging + "',agentId:0,propertyId:0}",
                       dataType: "json",
                       success: function (w) {

                           alert("Thank You for sending message, we will contact you as early as possible");
                           $("#nameC,#emailC,#txtCphone,#messagingC").val('');
                           //$("#bmsgC").fadeIn(2000, function () { $("#bmsgC").fadeOut(2000) })
                       },
                       error: function (w) { alert(w.d) }
                   });
               });
           });
</script>
   


       
			     <div class="contact-form_grid" style="float:left; text-align:left">

              
                    <div style="clear:both" ></div> 
                    
                     <asp:HiddenField ID="hdnCV" runat="server" />
                    
                    
                    <div class="divider" style="margin-top:0px; margin-bottom:1px; "></div>
                   
                      		<div style="clear:both" ></div>


                   
       <div style="clear:both" ></div>
        <%--<article class="page-art">
        <h1 class="page-titleSmallBlack" style="text-transform:uppercase" > If you are interested and excited to be part of KOMP journey, fill in the details below and attach your resume.</h1>        
        </article>--%>
            
				   <div class="ContectMsg" style="width:100%;padding-left:0px">                      
                     <div style="width:48%;height:auto; float:left;padding-right:25px;" >
                    
                     <h3 class="ContactLabel">FULL NAME<em style="color:Red">*</em></h3>
					    <input type="text" id="txtCname" runat="server" clientidmode="Static" maxlength="50"  class="textbox" placeholder="Enter your full name here.." />
                        
                        <h3 class="ContactLabel">EMAIL ADDRESS<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox EmailClass" id="txtCemail" runat="server" clientidmode="Static" maxlength="60"  placeholder="Enter your email address here.." />

                        <h3 class="ContactLabel">ATTACH YOUR RESUME<em style="color:Red">*</em></h3>
                        
                        
                         <asp:FileUpload ID="FileUpload1" runat="server" />                         
                         <asp:Label ID="lblCVName" runat="server" Text=""></asp:Label>
                         <div style="clear:both" ></div>
                         <asp:Button ID="Button2" class="proceed" style="float:left; margin-left:0px;padding:0.5em 1em 0.5em 1em"  runat="server" Visible="true" onclick="LinkButton1_Click"  Text="UPLOAD" />

                         <input type="button" class="proceed" style="float:left; margin-left:0px;padding:0.5em 1em 0.5em 1em" id="Button1" Visible="false" onclick="LinkButton1_Click" runat="server" value="UPLOAD"/>

                         <%--<asp:LinkButton ID="LinkButton1"  runat="server" onclick="LinkButton1_Click">Upload</asp:LinkButton><br />--%>
                         
                         <br />
                         <div style="clear:both" ></div>
                        <span style='clear:both;font-size:13px'>Supported Formats: doc, docx, rtf, pdf. Max size: 400 KB</span>  <br />
                     </div>
                       
                     <div style="width:48%;height:auto; float:left;padding-left:25px;" >
                     
                     <h3 class="ContactLabel">CONTACT NUMBER<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox NumberClass" id="txtCphone" runat="server" clientidmode="Static" maxlength="10" placeholder="Enter your contact number here.." />
                                            
                        <h3 class="ContactLabel">CHOOSE THE ROLE YOUR ARE APPLYING FOR<em style="color:Red">*</em></h3>
					    <select id='ctl00_MainContent_drpCategory' runat="server" clientidmode="Static" style="width:100%;padding:0.45em;border:1px solid #E4E4E4" >
                        <option value='0'>-Select Role-</option>
                       <option value='1'>Kitchen Manager</option>
                        <option value='2'>Corporate Relationship Manager</option>
                        <option value='3'>Marketing Executive</option>
                        <option value='4'>Chef</option>
                        <option value='5'>Cook</option>
                        <option value='6'>Front Office Assistant</option>
                        <option value='7'>Taste & Quality Assurance Executive</option>
                        <option value='8'>Nutritionist</option>
                        <option value='9'>Accountant </option>
                        <option value='10'>HR Executive</option>
                        <option value='11'>Stock & Inventory Executive</option>
                        <option value='12'>Logistics Executive</option>
                        
                        </select>
                     </div>

                  <div style=" clear:both; width:100%;height:auto;" >
                     
                     <%--<input id="chkAgree" type="checkbox" /><label for="chkAgree" >I agree to</label> <asp:Label ID="lblSite" runat="server" ></asp:Label>'s <a href="javascript:void()" onclick="OpernTerms()" target="_blank">Terms &amp; Conditions</a>--%>
                        <input type="button" class="proceed" style="float:right; margin-right:15px;" id="sendBtn1" onclick="Save();" value="SEND"/>
                     </div>
                      <div style="clear:both" ></div>
					 
				   </div>
                   <div style="clear:both" ></div>
                   
                   <div style="clear:both" ></div>
			      </div>
   			  
              <div style="clear:both" ></div> 

        <!--Contact End-->

                   </div>
                      
     </div>           
     <!--container end here-->
</asp:Content>
