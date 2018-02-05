<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PaymentAndDelivery.aspx.cs" Inherits="KitchenOnMyPlate.PaymentAndDelivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<style>
    .row.faq a{ color:#4b220c;}
      .msg_head
    {
      
        cursor: pointer; 
        padding-bottom:15px;        
        border-bottom: 1px solid #c8c6c6;
        text-align:justify;
        
    }
    
    .msg_head em{ font-family:Verdana; font-weight:bold; background-color:#F16822;color:#4b220c;margin-right:10px; width:25px; }
    
       .msg_body 
        {
            padding-top:15px;
            padding-bottom:5px;
            margin-left:34px !important;
            text-align:justify;
        }
        
</style>

<script type="text/javascript">
    $(function () {

        $(".msg_body").hide();

        //        $(".msg_head em").html("&nbsp;");
        //        $(".msg_head").addClass("pls");


        $(".msg_head").click(function () {

            if ($(this).next(".msg_body").is(':hidden')) {

                $(".msg_head .toggl").addClass("pls");
                $(".msg_head .toggl").removeClass("mns");
                $(".msg_body").hide();

                $(this).find(".toggl").removeClass("pls");
                $(this).find(".toggl").addClass("mns");
                //$(this).find("em").html('-');
            }
            else {
                //$(this).find("em").html('+');
                $(this).find(".toggl").removeClass("mns");
                $(this).find(".toggl").addClass("pls");
            }

            $(this).next(".msg_body").slideToggle(400, function () { });

        });
    });
</script>

                <!--SLIDERNEWSTRT-->
                <div id="divSlider" runat="server" >
<!---/End-Animation---->
                <link rel="stylesheet" type="text/css" href="Styles/slider.css" />
                <link rel="stylesheet" type="text/css" href="Styles/animate.css" />         
                <div class="slider">
	    <div class="callbacks_container">
	      <ul class="rslides" id="slider">
	        <li>
	          <img src="images/banner/payment and devilery.jpg" alt="">
	          
           <%--<div class="caption wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3>EAT HEALTHY.</h3>
	          </div>

              <div class="caption1 wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3>SKIP THE DIET.</h3>
	          </div>--%>

	        </li>	       

	      </ul>
	  </div>
  </div>

                    <%--<div class="Tiffin">
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
                        <h1 class="page-titleMain">PAYMENT & DELIVERY FAQ<span style="text-transform:lowercase" >s</span> </h1>                        
                        </article>
                  <div class="col-ms-12">
                  	
<div  class='msg_head' ><strong><div class="toggl pls" ></div>How can I pay for my KOMP Meals? Do you have different payment modes?</strong></div>
<p class='msg_body'>KOMP offers multiple payment modes which are safe, easy and secured. You can pay online at www.kitchenonmyplate.com through Credit Card, Debit Card, Net Banking or pay offline by NEFT, Cash & Cheque.<br /><br />
<span style="font-weight:bold;text-decoration:underline">Online Payment:</span> Our Credit, Debit Card & Net Banking Payments are powered through CC Avenue – for secured online payments. <br />
<span style="font-weight:bold;text-decoration:underline">Offline Payment:</span> NEFT funds Transfer, Cash Pick up, Cheque & Cash deposit:<br /><br />
<span style="font-weight:bold;">Bank details for Offline Payments:</span><br />

<span style="font-weight:bold;">Bank:</span>  KOTAK MAHINDRA BANK<br />
<span style="font-weight:bold;">Branch address:</span> DINDOSHI MALAD (EAST)<br />
<span style="font-weight:bold;">City:</span>City: MUMBAI<br />
<span style="font-weight:bold;">Account Number:</span> 7911547099<br />
<span style="font-weight:bold;">IFSC code:</span> KKBK0000646<br />
<span style="font-weight:bold;">Beneficiary A/c Type:</span> CURRENT<br />
<span style="font-weight:bold;">Full Name of beneficiary (Pay to Name):</span> KITCHEN ON MY PLATE
</p><br>

<div  class='msg_head' ><strong><div class="toggl pls" ></div>Is there any fee on making online payments?</strong></div>
<p class='msg_body'>Yes, all Credit Card / Debit Card / Net Banking transactions through our online payment gateway - CC Avenue will attract an extra charge on the total billed amount.</p><br>

<div  class='msg_head' ><strong><div class="toggl pls" ></div>How will I know my payment has been credited to KOMP?</strong></div>
<p class='msg_body'>You will receive a payment confirmation SMS on your mobile number or email to your email address registered with KOMP.</p><br>

<div  class='msg_head' ><strong><div class="toggl pls" ></div>When does my meal plan start?</strong></div>
<p class='msg_body'>KOMP to receive the payment for meal orders by 4 pm at least a day before to your meal start date. The meal delivery for any payment received after 4 pm will start a day later. </p><br>

<div  class='msg_head' ><strong><div class="toggl pls" ></div>When & Where Does KOMP Deliver In Mumbai? </strong></div>
<p class='msg_body'>KOMP Meal delivery days are - Monday to Saturday. 
Our lunch & dinner meals get delivered in Western Line, Central Line & Harbour Line. 
We cover almost all areas in Mumbai, still to confirm whether your delivery location falls in our delivery service area, you can simply check it on 
<a href="/">kitchenonmyplate.com.</a> Just select your meal plan and enter your delivery area pin code.


 </p><br>
<div  class='msg_head' ><strong><div class="toggl pls" ></div>Will I keep getting the same meal under each plan? </strong></div>
<p class='msg_body'>Certainly not. We spare a lot of time and effort on our meal planning to offer you maximum variety under each plan, every month. </p><br>

<div  class='msg_head' ><strong><div class="toggl pls" ></div>Is there any security deposit I need to pay in advance?</strong></div>
<p class='msg_body'>No, there is no such deposit. However, you have to pay for your meals in advance.</p><br>

<div  class='msg_head' ><strong><div class="toggl pls" ></div>Can I get my lunch delivered at my office and my dinner at home?</strong></div>
<p class='msg_body'>Yes, as long as your office and home are covered in our delivery areas. </p><br>

<div  class='msg_head' ><strong><div class="toggl pls" ></div>How much is the delivery charge?</strong></div>
<p class='msg_body'>Rs. 75/- for 2 days trial meal plan <br/> Rs. 300/- for 10 days meal plan <br/> Rs.600/- for 22 days meal plan <br/> Above delivery charges are separate and not inclusive of the KOMP Meal prices. </p><br>

<div  class='msg_head'><strong><div class="toggl pls" ></div>I would like to make Cash Payment for my Meal?</strong></div>
<p class='msg_body'>Yes, we also have that option available for you. You can directly deposit cash payment for your meal. For our customer’s convenience we have even tied up with a third party Cash Pick-up service. Please note Cash Pick-up is a chargeable service. The fee for Cash Pick-up service will vary depending on the total billed amount based on the meal plan chosen. </p><br>

<div  class='msg_head'><strong><div class="toggl pls" ></div>Do you also Deliver during Weekend and Holidays?</strong></div>
<p class='msg_body'>KOMP does deliver on Saturday and some selected holidays only which can be checked in the calendar while placing the order. We do not deliver on Sunday.</p><br>

<div  class='msg_head'><strong><div class="toggl pls" ></div>How will I know before Placing Order, whether you Deliver in my Area or not?</strong></div>
<p class='msg_body'>We cover almost all areas in Mumbai, still to confirm whether your delivery location falls in our delivery service area, you can simply check it on kitchenonmyplate.com. Just select your meal plan and enter your delivery area pin code. Alternatively, you can fill our online enquiry form or call us.</p><br>

<div  class='msg_head' ><strong><div class="toggl pls" ></div>What are your Lunch & Dinner Delivery timings?</strong></div>
<p class='msg_body'>We deliver Lunch between 12:30 PM to 1:30 PM and Dinner between 7:00 PM to 9 PM. If this happens to be your first delivery it might take a little longer.</p><br>

<div  class='msg_head' ><strong><div class="toggl pls" ></div>Do you also deliver during week end and holidays?</strong></div>
<p class='msg_body'>KOMP does deliver on Saturday and Bank Holidays. We do not deliver on Sunday.</p><br>

<div  class='msg_head' ><strong><div class="toggl pls" ></div>How would I know before placing order whether you deliver in my area or not?</strong></div>
<p class='msg_body'>CWe cover almost all areas in Mumbai, still to confirm whether your delivery location falls in our delivery service area, you can simply check it on kitchenonmyplate.com. Alternatively, you can fill our online enquiry form or call us.</p><br>

<div  class='msg_head' ><strong><div class="toggl pls" ></div>Do you also deliver breakfast?</strong></div>
<p class='msg_body'>Currently, KOMP delivers only lunch and dinner. However, we would let you know once we start KOMP's breakfast service. </p><br>



 


                   </div>
                      
     </div>           
     <!--container end here-->
</asp:Content>
