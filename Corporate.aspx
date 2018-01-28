<%@ Page Title="Corporate Catering | Corporate Catering Service in Mumbai | Kitchenonmyplate.com" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Corporate.aspx.cs" Inherits="KitchenOnMyPlate.Corporate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="description" content="KOMP have a dedicated corporate catering team committed to providing fresh, delicious and healthy food. We can also provide our professional serving staff and complete buffet/catering setup to serve the meals." />
    <meta name="keywords" content="Corporate Catering Service in Mumbai, Corporate Catering, Corporate Caterers in Mumbai, Caterers in Mumbai, Corporate Tiffin Service, Catering Services in Mumbai, Corporate Lunch Services Mumbai, Evergreen caterers in Mumbai, Social Catering, Outdoor Catering, Catering Services in Mumbai, Top Caterers in Mumbai, Corporate Event Caterers" />

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
	          <img src="images/banner/Corporate Catering.jpg" alt="komp copoprate catering">
	          
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
                        <h1 class="page-titleMain">CORPORATE CATERING</h1>
                     

                  <div style="width:100%;" >
                 


                  	<p style="text-align: justify !important;text-justify: inter-word !important;" >
                     <div class="CatPhotoLeft"  >
                 <img src="images/abbg.png" style="position:absolute; right:-1px;top:-3px;" />         
                          <img alt="komp logo" title="komp logo" style="float:right" class="AboutImg" src="images/cororate_catering_inside.jpg"></img>
                          
                          </div>

                    Whether to build relationships over lunch or offer employees a healthy, well balanced, delicious meals - Kitchen On My Plate can do this with ease. At KOMP we have a dedicated team to understand the dietary needs of each of our corporate clients and prepare customized menus based on the awesome selections of healthy offerings, keeping in mind the taste and company culture. <br /><br />

<%--We understand that employees want meals that are not only tasty and healthy, but also offer a variety. We at KOMP believe in making healthy food tasty and varied as well. Yes, each meal served is different from the other, leaving them excited and waiting for their next meal. Our exceptional food menu, including an array of options, fosters employee relationship while they relish our lunches in your office cafeterias. It will also help them a step further in achieving their health and wellness goals. The fact is, maintaining a healthy lifestyle is not only being physically active, but needs to be coupled with nutritious diet as well. All our dishes are prepared using fresh and best quality ingredients. The meals, which are low on salt and oil content, are prepared in our base-kitchen and delivered at your office.<br /><br />--%>

Your staff can eat and enjoy our meals throughout the day – breakfast, lunch, snacks and dinner that is satisfying as well as nutritious. We make sure your employees feel light and healthy after every meal.<br /><br />

Make your cafeteria/pantry a place for employees to share and bond. We assure you that your employees will cherish the food and the times shared together, and you will smile with satisfaction for using this as an opportunity for corporate branding or a powerful employee retention tool.<br /><br />

We are equipped to run your cafeteria on contract basis, catering to any group size and providing on-time delivery of the meal service. On request, we can also provide our professional serving staff and complete buffet/catering setup to serve the meals.<br /><br />

We invite you to explore the goodness of our meals. Please contact us online or call us to know more about the menu and packages we can offer & design for you.<br /><br />

Making workplace happier & healthier…

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
                       swal('Please enter company number.');
                       $("#txtCompName").focus();
                       return false;
                   }


                   if (location == '') {
                       swal('Please enter office location.');
                       $("#txtLocation").focus();
                       return false;
                   }

                   if (voOfPPL == '') {
                       swal('Please enter approximate staff count.');
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
                       data: "{name:'" + name + "',mobile:'" + mobile + "',email:'" + email + "',message:'" + messaging + "',compName:'Company : " + compName + "',location:'" + location + "',noofpeople:'" + voOfPPL + "',besttimetocall:'" + bSTTimeToCallU + "'}",
                       dataType: "json",
                       success: function (w) {

                           swal("Thank You for submitting your request, one of our representatives  will contact you soon.");
                           $("#txtCname,#txtCompName,#txtLocation,#txtNoOfPPL,#txtCemail,#txtCompName,#txtCphone,#messagingC,#txtBSTTimeToCallU").val('');
                           IsClickable = false;
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
        <h1 class="page-titleSmallBlack" style="text-transform:uppercase; padding-left:0px; " > Corporate Catering Enquiry Form: </h1>
        </article>
            
                          <%--<div class="ProcessBox" style="height:auto">--%>
       <div style="clear:both" ></div>

				   <div  class=""  style="width:100%;margin-top:15px">
                     
                     <div class="leftCatCon">
                     <h3 class="ContactLabel">Name:<em style="color:Red">*</em></h3>
					    <input type="text" id="txtCname" runat="server" clientidmode="Static" maxlength="50"  class="textbox" placeholder="Enter your full name here.." />

                        <h3 class="ContactLabel">Your Office Location:<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="txtLocation" runat="server" clientidmode="Static" maxlength="50"  placeholder="Enter your office location here.." />
                        
                        <h3 class="ContactLabel">Email<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox EmailClass" id="txtCemail" runat="server" clientidmode="Static" maxlength="50"  placeholder="Enter your email address here.." />

                        <h3 class="ContactLabel">Your Requirements<em style="color:Red">*</em></h3>
                        <textarea  class="textbox" id="messagingC" placeholder="Enter your requirements here.."></textarea>

                     </div>
                       
                     <div class="rightCatCon">
                     
                        <h3 class="ContactLabel">Company Name:<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="txtCompName" runat="server" clientidmode="Static" maxlength="70" placeholder="Enter company name here.." />

                           <h3 class="ContactLabel">Approximate Staff Count:<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox NumberClass" id="txtNoOfPPL" runat="server" clientidmode="Static" maxlength="4" placeholder="Enter Approximate Staff Count here.." />


                        <h3 class="ContactLabel">Contact Number<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="txtCphone" runat="server" clientidmode="Static" maxlength="10" placeholder="Enter contact number here.." />


                        <h3 class="ContactLabel">Best Time To Call You:</h3>
					    <input type="text" class="textbox" id="txtBSTTimeToCallU" runat="server" clientidmode="Static" maxlength="30" placeholder="Enter best time to call you.." />                                            
                 
                        <input type="button" class="proceed" style="float:right" id="sendBtn" value="SUBMIT"/>

                     </div>
                                       
                      <div style="clear:both" ></div>
					 
				   </div>

  <div style="clear:both" ></div>
                <%--   </div>--%>
			      </div>
   			  
              <div style="clear:both" ></div> 

        <!--Contact End-->

         </div>
                  <%--<div style="width:30%; height:auto;float:left;" >

                  <div class='fb-like-box' data-href='https://www.facebook.com/kitchenonmyplate' data-width='90%' data-height='280' data-colorscheme='light' data-show-faces='true' data-header='true' data-stream='false' data-show-border='true'></div>
                  <div style="clear:both;height:10px" ></div>



                  </div>--%>

                      
     </div>           
     <!--container end here-->
</asp:Content>
