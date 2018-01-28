<%@ Page Title="Event Catering Services | Birthday, Wedding Event Catering Services Mumbai – KOMP" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="KitchenOnMyPlate.Event" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="description" content="KOMP Event Catering services in Mumbai, We cater to a variety of events, such as weddings, kids’ birthday parties, conferences and other occasions that call for multi-cuisine, theme-based meal planning." />
    <meta name="keywords" content="Event Catering Services, event catering company, party catering services, event Management Company, special event catering, outdoor catering, Wedding Event Catering Services, Birthday Event Catering Services, Event Catering Services Mumbai" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
	          <img src="images/banner/Events Catering.jpg" alt="komp event">    
	          
        <%--      <div class="caption wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>EAT HEALTHY.</span></h3>
	          </div>

              <div class="caption1 wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>SKIP THE DIET.</span></h3>
	          </div>--%>

	        </li>	       

	      </ul>
	  </div>
  </div>

             <%--       <div class="Tiffin">
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
                        <h1 class="page-titleMain">EVENT CATERING</h1>
                        
                  <div class="col-ms-12">

                  <div style="width:100%; height:auto;" >
                 

                  	<p style="text-align: justify;text-justify: inter-word;" >

                      <div class="CatPhotoLeft"  >
                          <img src="images/abbg.png" style="position:absolute; right:-1px;top:-3px;" />
                          <img alt="komp logo" title="komp logo" style="float:right" class="AboutImg" src="images/event_catering_inside_image.jpg"></img>
                          
                          </div>

                  Food can either make or break an event. Be it a wedding or a business conference, people are quite keen about the food served there. At KOMP, we want to give you a wide option of delicious, hygienically prepared meals that your guests will love. And that includes a hassle-free delivery and service. <br /><br />
Whether an event is a simple gathering or an elegant celebration KOMP will exceed your expectations, transforming your event into a memorable experience. Choose from our extensive variety of starters, soups, salads, mains and desserts and enjoy the taste of goodness. Be prepared to receive many compliments from your guests later for the lip-smacking food!<br /><br />
We cater to a variety of events, such as weddings, kids’ birthday parties, conferences and other occasions that call for multi-cuisine, theme-based meal planning. Since we are already in the business, with a supply chain in place and have professional staff at our disposal, the service that you get from KOMP will not just be above-the-cut but also budget-friendly. 
                    </p>
                   

<!--Contact Start-->
   
        
       
       <script type="text/javascript">
           var IsClickable = true;
           $(function () {
               $("#sendBtn").click(function () {

                   if (!IsClickable) {
                       return false;
                   }

                   var name = $("#txtCname").val();
                   var compName = $("#txtCompName").val();
                   var location = $("#txtLocation").val();
                   var email = $("#txtCemail").val();
                   var mobile = $("#txtCphone").val();
                   var messaging = $("#messagingC").val();

                   var voOfPPL = $("#txtNoOfPPL").val();
                   var bSTTimeToCallU = $("#txtBSTTimeToCallU").val();



                   if (name == '') {
                       swal('Please enter name.');
                       $("#txtCname").focus();
                       return false;

                   }

                   if (compName == '') {
                       swal('Please enter Occasion/Even name.');
                       $("#txtCompName").focus();
                       return false;
                   }


                   if (location == '') {
                       swal('Please enter event location.');
                       $("#txtLocation").focus();
                       return false;
                   }

                   if (voOfPPL == '') {
                       swal('Please enter Approximate Guest Count.');
                       $("#txtNoOfPPL").focus();
                       return false;
                   }

                   if (email == '') {
                       swal('Please enter email address.');
                       $("#txtCemail").focus();
                       return false;
                   }

                   if (mobile == '') {
                       swal('Please enter contact number.');
                       $("#txtCphone").focus();
                       return false;
                   }

                   if (mobile.length < 10) {
                       swal('Mobile number must be 10 digits');
                       $("#txtCphone").focus();
                       return false;
                   }






                   if (messaging == '') {
                       swal('Please enter message.');
                       $("#messagingC").focus();
                       return false;
                   }

                   IsClickable = false;
                   
                   $.ajax({
                       type: "POST",
                       url: "KompServices.asmx/CorporateMessage",
                       contentType: "application/json; charset=utf-8",
                       data: "{name:'" + name + "',mobile:'" + mobile + "',email:'" + email + "',message:'" + messaging + "',compName:'Event : " + compName + "',location:'" + location + "',noofpeople:'" + voOfPPL + "',besttimetocall:'" + bSTTimeToCallU + "'}",
                       dataType: "json",
                       success: function (w) {

                           swal("Thank You for submitting your request, one of our representatives  will contact you soon.");
                           $("#txtCname,#txtCompName,#txtLocation,#txtNoOfPPL,#txtCemail,#txtCompName,#txtCphone,#messagingC,#txtBSTTimeToCallU").val('');
                           IsClickable = true;
                           //$("#bmsgC").fadeIn(2000, function () { $("#bmsgC").fadeOut(2000) })
                       },
                       error: function (w) { swal(w.d) }
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
        <article class="page-art">
        <h1 class="page-titleSmallBlack" style="text-transform:uppercase; padding-left:0px; " > Event Catering Enquiry Form: </h1>
        </article>
            
              
       <div style="clear:both" ></div>
				   <div  class=""  style="width:100%;margin-top:15px">
                     
                     <div class="leftCatCon">
                     <h3 class="ContactLabel">Name:<em style="color:Red">*</em></h3>
					    <input type="text" id="txtCname" runat="server" clientidmode="Static" maxlength="50"  class="textbox" placeholder="Enter your full name here.." />

                        <h3 class="ContactLabel">Event Location:<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="txtLocation" runat="server" clientidmode="Static" maxlength="50"  placeholder="Enter your event location here.." />
                        
                        <h3 class="ContactLabel">Email<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox EmailClass" id="txtCemail" runat="server" clientidmode="Static" maxlength="50"  placeholder="Enter your email address here.." />

                        <h3 class="ContactLabel">Your Requirements<em style="color:Red">*</em></h3>
                        <textarea  class="textbox" id="messagingC" placeholder="Enter your requirements here.."></textarea>

                     </div>
                       
                     <div class="rightCatCon">
                     
                        <h3 class="ContactLabel">Occasion / Event:<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="txtCompName" runat="server" clientidmode="Static" maxlength="70" placeholder="Enter Occasion / Event name here.." />

                           <h3 class="ContactLabel">Approximate Guest Count:<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox NumberClass" id="txtNoOfPPL" runat="server" clientidmode="Static" maxlength="4" placeholder="Enter Approximate Guest Count here.." />


                        <h3 class="ContactLabel">Contact Number<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="txtCphone" runat="server" clientidmode="Static" maxlength="10" placeholder="Enter contact number. here.." />


                        <h3 class="ContactLabel">Best Time To Call You:</h3>
					    <input type="text" class="textbox" id="txtBSTTimeToCallU" runat="server" clientidmode="Static" maxlength="30" placeholder="Enter best time to call you.." />                                            
                 
                        <input type="button" class="proceed" style="float:right" id="sendBtn" value="SUBMIT"/>

                     </div>
                                       
                      <div style="clear:both" ></div>
					 
				   </div>
                     <div style="clear:both" ></div>
                   </div>
                   
              <div style="clear:both" ></div> 

        <!--Contact End-->

         </div>
                  <%--<div style="width:30%; height:auto;float:left;" >

                  <div class='fb-like-box' data-href='https://www.facebook.com/kitchenonmyplate' data-width='90%' data-height='280' data-colorscheme='light' data-show-faces='true' data-header='true' data-stream='false' data-show-border='true'></div>
                  <div style="clear:both;height:10px" ></div>



                  </div>--%>

                   </div>
                      
     </div>           
     <!--container end here-->
</asp:Content>
