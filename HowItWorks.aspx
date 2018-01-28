<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HowItWorks.aspx.cs" Inherits="KitchenOnMyPlate.HowItWorks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<input id="hdnCoachingId" type="hidden" value="0"  />

<style>
    .page-art-list li{margin-top:0px;}
</style>

                <!--SLIDERNEWSTRT-->
                <div id="divSlider" runat="server" >
<!---/End-Animation---->
                <link rel="stylesheet" type="text/css" href="Styles/slider.css" />
                <link rel="stylesheet" type="text/css" href="Styles/animate.css" />         
                <div class="slider">
	    <div class="callbacks_container">
	      <ul class="rslides" id="slider">
	        <li>
	          <img src="images/banner/how it work.jpg" alt="">
	          
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
<%--
                    <div class="Tiffin">
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
                        <h1 class="page-title">HOW IT WORKS</h1>
                          <strong>It is very easy to order meals from KOMP.</strong>
                          <br /><br />
                        </article>
                  <div class="col-ms-12">
                     <div class="contact-form_grid" style="text-align:left;color:Black">
                   <div style="clear:both" ></div>
                    <article class="page-art">
                    <h1 class="page-titleSmallBlack" style="text-transform:uppercase; padding-left:0px; border-bottom:0px" > STEP 1: Confirm Your Delivery Area</h1>
                    </article>
            
				               <div style="width:100%">
                     
                                 <div style="width:21%;height:auto; float:left;" class="leftHow" >
                                 <img src="images/howstep1.jpg"/>
                                 </div>
                       
                                 <div style="width:79%;height:auto; padding-left:5px; float:left;" class="rightHow" >
                                 <%--<p style="margin-bottom:1em;font-size:16px;" >You first need to confirm whether KOMP delivers in your area. You can check the delivery area status by one of these four options:</p>--%>
                                 
                                 
                                <p style="margin-bottom:1em;font-size:16px;" > We cover almost all areas in Mumbai, still to confirm whether your delivery location falls in our delivery service area, you can simply check it on kitchenonmyplate.com. Just select your meal plan and enter your delivery area pin code.
                              <%--   <ul class="page-art-list">
                        	<li>Simply fill-out the enquiry form online.</li>
                            <li>You can also call us 9699 699204/ 9699 399204 & leave your details. </li>
                            <li>You can even send SMS with your name, address and email.</li>                                                        
                            
                            <li>Or just dash us an email with your complete details (name, address, contact no.) at info@kitchenonmyplate.com</li>
                            </ul> 
                            After receiving your request, KOMP will check & confirm the status of the delivery are--%>


                                 </div>                     
				               </div>



			                  </div>

                              <div style="height:20px;width:auto;clear:both" >&nbsp;</div>

                              <div class="contact-form_grid" style="text-align:left;color:Black">
                   <div style="clear:both" ></div>
                    <article class="page-art">
                    <h1 class="page-titleSmallBlack" style="text-transform:uppercase; padding-left:0px; border-bottom:0px" > STEP 2: Place Your Order</h1>
                    </article>
            
				               <div style="width:100%">
                     
                                 <div style="width:21%;height:auto; float:left;" class="leftHow" >
                                 <img src="images/howstep2.jpg" />
                                 </div>
                       
                                 <div style="width:79%;height:auto; padding-left:5px; float:left;" class="rightHow" >
                                 <p style="margin-bottom:1em;font-size:16px;">	If your address is within our delivery area. You can then, straightaway log in to the KOMP website and select:
                                 </p>
                                   <ul class="page-art-list">
                                   <li>2 days trial meal plan or 10 or 22 days meal plan.</li>
                                   <li>Choose dates from the calendar.</li>
                                   </ul>
<%--<p style="margin-bottom:1em;font-size:16px">Alternatively, you can call us on XXXXX to help you make a selection & place an order. </p>--%>
<p style="margin-bottom:1em;font-size:16px">Alternatively, you can call us on 9699 699204/ 9699 399204 & place your order. </p>

                                 </div>                     
				               </div>



			                  </div>

                              <div style="height:20px;width:auto;clear:both" >&nbsp;</div>
                              <div class="contact-form_grid" style="text-align:left;color:Black">
                   <div style="clear:both" ></div>
                    <article class="page-art">
                    <h1 class="page-titleSmallBlack" style="text-transform:uppercase; padding-left:0px; border-bottom:0px" > STEP 3: Make Payment</h1>
                    </article>
            
				               <div style="width:100%">
                     
                                 <div style="width:21%;height:auto; float:left;" class="leftHow" >
                                 <img src="images/howstep3.jpg" />
                                 </div>
                       
                                 <div style="width:79%;height:auto; padding-left:5px; float:left;" class="rightHow" >
                                 
                                  <ul class="page-art-list">
                                  <li>Next, make your payment through NEFT, Cheque/Cash deposit, Credit Card, Debit Card, Net Banking or Cash Pick up service.</li>
                                  <li>Once the payment is received by KOMP a payment notification with your chosen meal plan is sent to you welcoming you into the KOMP family. </li>
                                  </ul>
                                  <span><sd style="font-style:italic;font-weight:100px !important">Please Note: KOMP to receive the payment for meal orders by 12 pm at least a day before to your meal start date. The meal delivery for any payment received after 12 pm will start a day later.</sd></span>

                                 </div>                     
				               </div>



			                  </div>
                              <div style="height:20px;width:auto;clear:both" >&nbsp;</div>
                              <div class="contact-form_grid" style="text-align:left;color:Black">
                   <div style="clear:both" ></div>
                    <article class="page-art">
                    <h1 class="page-titleSmallBlack" style="text-transform:uppercase; padding-left:0px; border-bottom:0px" > STEP 4: Your Meal Plan Starts</h1>
                    </article>
            
				               <div style="width:100%">
                     
                                 <div style="width:21%;height:auto; float:left;" class="leftHow" >
                                 <img src="images/howstep4.jpg"  />
                                 </div>
                       
                                 <div style="width:79%;height:auto; padding-left:5px; float:left;" class="rightHow" >
                                 <ul class="page-art-list" style="margin-top:75px"><li>Once you receive the payment confirmation SMS/Email from us, you can expect a delivery of your chosen meal package within the stipulated time frame.</li></ul>
                                 </div>                     
				               </div>



			                  </div>
                              <div style="height:20px;width:auto;clear:both" >&nbsp;</div>
                                    <div class="contact-form_grid" style="text-align:left;color:Black">
                   <div style="clear:both" ></div>
                    <article class="page-art">
                    <h1 class="page-titleSmallBlack" style="text-transform:uppercase; padding-left:0px; border-bottom:0px" > STEP 5: Enjoy your meals</h1>
                    </article>
            
				               <div style="width:100%">
                     
                                 <div style="width:21%;height:auto; float:left;" class="leftHow" >
                                 <img src="images/howstep5.jpg"  />
                                 </div>
                       
                                 <div style="width:79%;height:auto; padding-left:5px; float:left;" class="rightHow" >
                                 <ul class="page-art-list" style="margin-top:75px" ><li>	It is our aim to offer you the taste and comfort of <span style="font-style:italic" >ghar jaisa khana</span>. We are sure you will love our meals, so enjoy to your heart’s content.</li></ul>
                                 </div>                     
				               </div>



			                  </div>
                   </div>
                      
     </div>           
     <!--container end here-->
</asp:Content>
