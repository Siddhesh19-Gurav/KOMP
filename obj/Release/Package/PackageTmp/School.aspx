<%@ Page Title="School Catering Services in Mumbai |School Lunch Services – Kitchenonmyplate.com" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="School.aspx.cs" Inherits="KitchenOnMyPlate.School" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="description" content="Kichenonmyplate.com - offers school catering services in Mumbai. The school can tie up with us in providing healthy school lunch. We will make sure the kids enjoy the food and stay healthy." />
<meta name="keywords" content="School Catering, School Catering Services in Mumbai, School Lunch Services, School Lunch Services Mumbai, School Meal Services, Mumbai School Catering Services, School Event Caterers" />


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
	          <img src="images/banner/School Catering.jpg" alt="school catering">
	          
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
                        <h1 class="page-titleMain">SCHOOL CATERING</h1>
                        
                  <div class="col-ms-12">

                  <div style="width:100%; height:auto;" >
                 

                  	<p style="text-align: justify;text-justify: inter-word;" >

                      <div class="CatPhotoLeft"  >
                          <img src="images/abbg.png" style="position:absolute; right:-1px;top:-3px;" />
                          <img alt="komp logo" title="komp logo" style="float:right" class="AboutImg" src="images/School_catering_inside_images.jpg"></img>
                          <div style="width:auto;height:10px"></div>
                          </div>

                  We are not surprised when a mother tells us that her child is very fussy about food and it’s a task to make him/her eat well at school. Children are perhaps the most difficult to please when it comes to food. But food is energy and it is important for growing children to be physically fit and healthy. <br /><br />
Does that mean the same old un-appetizing sandwiches, paratha or biscuits every day? Nope. We at Kitchen On My Plate (KOMP) understand that children need a balance - balance of taste, smell, colour and nutrients and not to forget an essential part- variety.  For us, nutritious food also means tasty food. We prepare healthy, tasty and visually attractive meals for children that they would look forward to eating every day. We have mouth-watering recipes that will make even the greens palatable. <br /><br />
Under this service head, the school can tie up with KOMP in providing healthy school lunch. We will make sure the kids enjoy the food and stay healthy. <br /><br />
School authorities can contact us to discuss plans, menus and specific nutritional requirements for this meal service. 

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
                       swal('Please enter school location.');
                       $("#txtLocation").focus();
                       return false;
                   }

                   if (voOfPPL == '') {
                       swal('Please enter approximate student count.');
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
                       data: "{name:'" + name + "',mobile:'" + mobile + "',email:'" + email + "',message:'" + messaging + "',compName:'School : " + compName + "',location:'" + location + "',noofpeople:'" + voOfPPL + "',besttimetocall:'" + bSTTimeToCallU + "'}",
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
        <h1 class="page-titleSmallBlack" style="text-transform:uppercase; padding-left:0px; " > School Catering Enquiry Form: </h1>
        </article>
        
       <div style="clear:both" ></div>

				   <div  class=""  style="width:100%;margin-top:15px">
                     
                     <div class="leftCatCon" >
                     <h3 class="ContactLabel">Name:<em style="color:Red">*</em></h3>
					    <input type="text" id="txtCname" runat="server" clientidmode="Static" maxlength="50"  class="textbox" placeholder="Enter your full name here.." />

                        <h3 class="ContactLabel">Your School Location:<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="txtLocation" runat="server" clientidmode="Static" maxlength="50"  placeholder="Enter your school location here.." />
                        
                        <h3 class="ContactLabel">Email<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox EmailClass" id="txtCemail" runat="server" clientidmode="Static" maxlength="50"  placeholder="Enter your email address here.." />

                        <h3 class="ContactLabel">Your Requirements<em style="color:Red">*</em></h3>
                        <textarea  class="textbox" id="messagingC" placeholder="Enter your requirements here.."></textarea>

                     </div>
                       
                     <div class="rightCatCon">
                     
                        <h3 class="ContactLabel">School Name:<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="txtCompName" runat="server" clientidmode="Static" maxlength="70" placeholder="Enter school name here.." />

                           <h3 class="ContactLabel">Catering Approximate Student Count:<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox NumberClass" id="txtNoOfPPL" runat="server" clientidmode="Static" maxlength="4" placeholder="Enter approximate student count here.." />


                        <h3 class="ContactLabel">Contact Number<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="txtCphone" runat="server" clientidmode="Static" maxlength="10" placeholder="Enter contact number here.." />


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
              <%--    <div style="width:30%; height:auto;float:left;" >

                  <div class='fb-like-box' data-href='https://www.facebook.com/kitchenonmyplate' data-width='90%' data-height='280' data-colorscheme='light' data-show-faces='true' data-header='true' data-stream='false' data-show-border='true'></div>
                  <div style="clear:both;height:10px" ></div>



                  </div>
--%>
                   </div>
                      
     </div>           
     <!--container end here-->
</asp:Content>
