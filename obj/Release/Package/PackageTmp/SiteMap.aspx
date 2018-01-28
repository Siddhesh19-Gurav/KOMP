<%@ Page Title="Sitemap – Kitchenonmyplate.com" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SiteMap.aspx.cs" Inherits="KitchenOnMyPlate.SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="title" content=" Sitemap – Kitchenonmyplate.com" />
<meta name="description" content="Kitchenonmyplate sitemap to help users to easily navigate through the website." />
    <meta name="keywords" content="Sitemap  Kitchenonmyplate.com, Sitemap" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script src="Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>--%>
    <style>
    .row.faq a{ color:#4b220c;}
    </style>
	

    <script src="Scripts/ajaxfileupload.js" type="text/javascript"></script>
<script type="text/javascript" src="Scripts/jsManageJob.js"></script>

<script type="text/javascript">

    var pictureLogo = '';
    function ajaxFileUploadCV() {

        fileToUploadCV.fi
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
	          <img src="images/banner/site_map.jpg" alt="">
	          
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
                        <h1 class="page-titleMain">SITE MAP</h1>
                        </article>
                  <div class="col-ms-12">
                  	<%--<p>We are delighted to offer our valued clients with the goodness of our food and customized menus especially designed for them. We believe in building long term relationships through our appetizing meals and high quality standard of service.--%><br />
</p>
                   

<!--Contact Start-->
   
        
       
    


       
			     <div class="contact-form_grid" style="float:left; text-align:left">

              
                    <div style="clear:both" ></div> 
                    
                     <asp:HiddenField ID="hdnCV" runat="server" />
                    
                    
                    <div class="divider" style="margin-top:0px; margin-bottom:1px; "></div>
                   
                      		<div style="clear:both" ></div>

                            <div class="SiteSect">
                            <div> 
                            <h2>Main Menu</h2>
                            <ul>                            
                            <li>  <a href="/">Home</a></li>                            
                            <li>  <a href="AboutUs.aspx">About us</a></li>
                            <li>  <a href="ContactUs.aspx">Contact us</a></li>                            
                               
                    <li><a href="concept.aspx">Concept</a></li>
                    <li><a href="WhyChooseUs.aspx">Why Choose Us?</a></li>
                    <li><a href="Careers.aspx">Careers</a></li>
                    <li><a href="Client.aspx">Clients</a></li>
                    <li><a href="Media.aspx">Media</a></li>
                    <li><a href="#">Gallery</a></li>

                </ul>

                  
                            
                            </ul> </div>                            
                            </div>

                            <div style="padding-left:5px;padding-right:5px" class="SiteSect" >
                                <h2>About this site</h2>
                                <ul>
                      <li> <a href="PrivacyPolicy.aspx">Privacy Policy</a></li>
                      <li><a href="TermsNConditions.aspx">Terms & Conditions</a></li>
                      </ul>


                    
                    <h2>Support</h2>
                     <ul>
                    <li>  <a href="HowItWorks.aspx">How it works</a></li>
                    <li>  <a runat="server" id="myact" style="cursor:pointer" onclick=";if( $('#login').css('display')=='none'){ window.location.href='MyOrders.aspx';}else{ $('#aRegister').click();}" >My Account</a></li>
                    <li>  <a href="PaymentAndDelivery.aspx">Payment & Delivery</a></li>
                    <li>  <a href="FAQ.aspx">FAQs</a></li>
                    </ul>
                            </div>

                            <div style="padding-left:5px;padding-right:5px" class="SiteSect">
                              <h2>Services</h2>
                              <ul>
                    <li>  <a href="Service.aspx?il=1&itm=1">Lunch Tiffin Service</a></li>
                   <li>   <a href="Service.aspx?il=1&itm=6">Nutrimeal Lunch</a></li>
                    <li>  <a href="YourOrder.aspx">Customised Tiffin Service</a></li>
                    <li>  <a href="Service.aspx?il=0&itm=1">Dinner Tiffin Service</a></li>
                    <li>  <a href="Service.aspx?il=0&itm=6">Nutrimeal Dinner</a>          </li>          
                    <li>  <a href="Corporate.aspx">Corporate Catering</a></li>
                    <li>  <a href="School.aspx">School Catering</a></li>
                    <li>  <a href="Event.aspx">Event Catering</a></li>
                    </ul>

                            </div>

                            
                                 <div style="clear:both;height:20px" ></div> 

                            

                            
           
                   <div style="clear:both" ></div>
			      </div>
   			  
              <div style="clear:both" ></div> 

        <!--Contact End-->

                   </div>
                      
     </div>           
     <!--container end here-->
</asp:Content>
