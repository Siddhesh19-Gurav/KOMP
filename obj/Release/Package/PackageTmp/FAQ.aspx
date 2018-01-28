<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="KitchenOnMyPlate.FAQ" %>
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
	          <img src="images/banner/FAQ.jpg" alt="komp faq">
	          
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

              <%--      <div class="Tiffin">
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
                        <%--<h1 class="page-titleMain">FREQUENTLY ASKED QUESTIONS (FAQ)</h1>--%>
                        <h1 class="page-titleMain">FAQ<span style="text-transform:lowercase" >s</span></h1>
                        </article>
                  <div class="col-ms-12">
                  	
<div  class='msg_head' ><strong><div class="toggl pls" ></div> How does Kitchen On My Plate work?</strong></div>
<p class='msg_body'>You can check out <a href="HowItWorks.aspx">How it Works</a> to know how KOMP works, which is simple and easy. You can know more about our meal plans on our website <a href="http://www.kitchenonmyplate.com">www.kitchenonmyplate.com</a> or from our <a href="https://web.facebook.com/kitchenonmyplate"><img src="images/icon-fb.png"/></a>. You can choose a meal package as per your preference and select the delivery date. You will have to make your payment in advance. After we receive your payment the meals will start getting delivered to you.
</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>How is KOMP different from any other Tiffin Service?</strong></div>
<p class='msg_body'>KOMP doesn't like to comment on the competition, but we'd like to assure you that our meals are Healthy, Hygienic, Nutritious, Fresh and Tasty.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>What Type of Meals can I Order from KOMP site?</strong></div>
<p class='msg_body'>We have variety of Vegetarian and Non-Vegetarian meals available for our customers.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Do I have to Book a Meal Plan for a Minimum Number of days?</strong></div>
<p class='msg_body'>Apart from our 2 days trial meal plan. You could either book a meal plan for 10 days, which is valid for 15 working days, after which you have to re-book for continuance. Or you could book a meal plan for 22 days, which is valid for 35 working days.</p><br>

<div  class='msg_head'><strong><div class="toggl pls" ></div>Do you have a trial meal plan?</strong></div>
<p class='msg_body'>We have a 2 days trial meal plan.</p><br>


<div  class='msg_head'><strong><div class="toggl pls" ></div>What do you mean by Validity?</strong></div>
<p class='msg_body'>The time period given to complete all your meals based on a 10 or 22 day meal plan opted by you at the time of placing the order.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Will I keep getting the same Meal under each Plan? </strong></div>
<p class='msg_body'>Certainly not. We dedicate a lot of time and effort on our meal planning to offer you maximum variety under each plan, every month. </p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Can I Swap my Meals between Lunch and Dinner?</strong></div>
<p class='msg_body'>Sorry, we don’t allow that for logistical reasons. </p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Can I choose Vegetarian and Non-Vegetarian Meals at the same time during my Meal Plan period?</strong></div>
<p class='msg_body'>Yes, you can by choosing from our “V-NV” option in Traditional Indian Plate & Customized Tiffin meal services.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>I eat only Vegetarian food and KOMP serves both Vegetarian and Non-Vegetarian. What measures do you take to ensure Vegetarian Meals have been prepared separately from Non-Vegetarian Meals?</strong></div>
<p class='msg_body'>We understand your concern and keeping this in mind, we have kept two completely separate sections in our kitchen set-up for Vegetarian and Non- Vegetarian meals, including the utensils, saucepans, ladles, cutting boards, knives etc. </p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Do I get to Customise my Dinner Meals as offered with your Lunch Service?</strong></div>
<p class='msg_body'>Not at present. However, we have an option of “V-NV” available in our Dinner Service to alternate between our Traditional Indian Plate Veg and Non-Veg meals, especially designed for those customers who want to relish Veg as well as Non-Veg dishes in their meals throughout the month.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>When does my Meal Plan start?</strong></div>
<p class='msg_body'>KOMP to receive the payment for meal orders by12 pm at least a day before to your meal start date. The meal delivery for any payment received after 12 pm will start a day later. </p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Can I pause (hold) my remaining Meals?</strong></div>
<p class='msg_body'>Yes, you may pause your Lunch/ Dinner meal service for a given day(s) by sending us SMS before 1 pm the previous day. So if you plan to pause a meal let’s say on 6th of April then we should receive the “Pause a Meal” notification via SMS before 1 pm 5th of April for us to successfully pause your meal the next day. Number of Meals paused during the “Pause a Meal” still to be consumed within the validity period of that meal plan. Once the validity period is over the Paused Meals if not consumed till then will expire.  This is the reason we give 15 working days for 10 day meal and 35 working days for 22 day meal so you have the flexibility to consume your meals within these days.</p><br>

<div  class='msg_head'><strong><div class="toggl pls" ></div>When & Where does KOMP Deliver in Mumbai?</strong></div>
<p class='msg_body'>KOMP Meal delivery days are - Monday to Saturday. <br />
Our lunch & dinner meals get delivered in Western Line, Central Line & Harbour Line. We cover almost all areas in Mumbai, still to confirm whether your delivery location falls in our delivery service area, you can simply check it on kitchenonmyplate.com. Just select your meal plan and enter your delivery area pin code.

</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Can I get my Lunch Delivered at my Office and my Dinner at Home?</strong></div>
<p class='msg_body'>Yes, as long as your office and home are covered in our delivery areas. </p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>What are your Lunch & Dinner Delivery timings?</strong></div>
<p class='msg_body'>We deliver Lunch between 12:30 PM to 1:30 PM and Dinner between 7:00 PM to 9 PM. If this happens to be your first delivery it might take a little longer.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Do you also Deliver Breakfast?</strong></div>
<p class='msg_body'>Currently KOMP delivers only lunch and dinner. However, we will let you know once we start KOMP's breakfast service.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Can I order Dinner too?</strong></div>
<p class='msg_body'>Yes, you can. We will be happy to serve you if your area falls in our delivery area. 
</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Do you also Deliver during Weekend and Holidays?</strong></div>
<p class='msg_body'>KOMP does deliver on Saturday and some selected holidays only which can be checked in the calendar while placing the order. We do not deliver on Sunday.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>How will I know before Placing Order, whether you Deliver in my Area or not?</strong></div>
<p class='msg_body'>We cover almost all areas in Mumbai, still to confirm whether your delivery location falls in our delivery service area, you can simply check it on kitchenonmyplate.com. Just select your meal plan and enter your delivery area pin code. Alternatively, you can fill our online enquiry form or call us.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>How much is the delivery charge?</strong></div>
<p class='msg_body'>Rs. 75/- for 2 days trial meal plan <br/> Rs. 300/- for 10 day meal plan<br/>
Rs. 600/- for 22 day meal plan<br/>
Above delivery charges are separate and not inclusive of the KOMP Meal prices. 
 </p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>What are your Delivery Areas?</strong></div>
<p class='msg_body'>
Our lunch & dinner meals get delivered in Western Line, Central Line & Harbour Line. We cover almost all areas in Mumbai, 
still to confirm whether your delivery location falls in our delivery service area, you can simply check it on <a href="http://www.kitchenonmyplate.com" >kitchenonmyplate.com</a> Just select your meal plan and enter your delivery area pin code.
</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Do you Deliver in Disposable Containers?</strong></div>
<p class='msg_body'>Yes, your meal is delivered in a hygienic disposable paper bag/box which contains disposable and microwavable containers.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Can I use the same Containers to Heat my Food?</strong></div>
<p class='msg_body'>Yes, the containers are microwavable and can be heated for around 30 seconds.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Will my Food be Hot when it is Delivered?</strong></div>
<p class='msg_body'>No. It needs to be heated.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>How can I Pay for my KOMP Meals? Do you have different Payment Modes?</strong></div>
<p class='msg_body'>KOMP offers multiple payment modes which are safe, easy and secured. You can pay online at <a href="http://www.kitchenonmyplate.com" >www.kitchenonmyplate.com</a>  through Credit Card, Debit Card, Net Banking or pay offline by NEFT, Cash & Cheque.<br />
<span style="font-weight:bold;text-decoration:underline">Online Payment:</span> Our Credit, Debit Card & Net Banking Payments are powered through CC Avenue – for secured online payments. <br />
<span style="font-weight:bold;text-decoration:underline">Offline Payment:</span> NEFT funds Transfer, Cash Pick up, Cheque & Cash deposit:<br />
<span style="font-weight:bold;">Bank details for Offline Payments:</span>
<br /><br />
<span style="font-weight:bold;">Bank:</span>  KOTAK MAHINDRA BANK<br />
<span style="font-weight:bold;">Branch address:</span> DINDOSHI MALAD (EAST)<br />
<span style="font-weight:bold;">City:</span> MUMBAI<br />
<span style="font-weight:bold;">Account Number:</span> 7911547099<br />
<span style="font-weight:bold;">IFSC code:</span> KKBK0000646<br />
<span style="font-weight:bold;">Beneficiary A/c Type:</span> CURRENT<br />
<span style="font-weight:bold;">Full Name of beneficiary (Pay to Name):</span> KITCHEN ON MY PLATE

          </p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>Is there any fee for making online payments?</strong></div>
<p class='msg_body'>Yes, all Credit Card / Debit Card / Net Banking transactions through our online payment gateway - CC Avenue will attract an extra charge on the total billed amount.</p><br>

<div  class='msg_head'><strong><div class="toggl pls" ></div>I would like to make Cash Payment for my Meal?</strong></div>
<p class='msg_body'>Yes, we also have that option available for you. You can directly deposit cash payment for your meal. For our customer’s convenience we have even tied up with a third party Cash Pick-up service. Please note Cash Pick-up is a chargeable service. The fee for Cash Pick-up service will vary depending on the total billed amount based on the meal plan chosen. </p><br>

<div  class='msg_head'><strong><div class="toggl pls" ></div>Is there any security deposit I need to pay in advance?</strong></div>
<p class='msg_body'>No, there is no such deposit. However, you have to pay for your meals in advance.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>How will I know my payment has been credited to KOMP?</strong></div>
<p class='msg_body'>You will receive a payment confirmation SMS on your mobile number or email to your email address registered with KOMP.</p><br>
<div  class='msg_head'><strong><div class="toggl pls" ></div>How can I leave feedback for your service?</strong></div>
<p class='msg_body'>You can fill the <a href="http://www.kitchenonmyplate.com">Feedback Form</a> or you can also email us at <a href="mailto:support@kitchenonmyplate.com">support@kitchenonmyplate.com</a>.</p><br>


                   </div>
                      
     </div>           
     <!--container end here-->
</asp:Content>
