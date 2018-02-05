 <%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="KitchenOnMyPlate.Service" %>
<%@ Register src="Controls/PaymentMethod.ascx" tagname="PaymentMethod" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="Styles/themes/base/jquery.ui.all.css" />	
    <script src="Scripts/ui/jquery-1.8.2.js"></script>
	<script src="Scripts/ui/jquery.ui.core.js"></script>
	<script src="Scripts/ui/jquery.ui.widget.js"></script>
	<script src="Scripts/ui/jquery.ui.datepicker.js"></script>
	<%--<link rel="stylesheet" href="../demos.css">--%>

   <%--Multi date picker --%>
    <script src="Scripts/jquery-ui.multidatespicker.js" type="text/javascript"></script>
    <link href="Styles/MultiDateCalender/mdp.css" rel="stylesheet" type="text/css" />

    <style>
        /* Login box start*/
.BorderBlue
{
     border:1px solid #75BDC7;
    }

.loginBox
{
  clear:both;   background-color: transparent Aqua; height:auto; font-size:12px; font-family:Arial; display:none; 
  margin:2px;margin-top:9px;  
    }

div.RoundCorner8
{
border-radius: 8px; 
-moz-border-radius: 8px; 
-webkit-border-radius: 8px; 
border: 1px solid #B4B9C2;
}

    
    .RegisterControl
    {
       clear:both;
       height:40px;
        }
        
.SearchTxt
{ 
     font-family:Verdana;
     font-size:14px;
    font-weight:bold;
    color:#575757;
    
  }
  
      .findPropertyOuter
     {         
         clear:both; margin-top:22px; float:right; margin-right:12px;
         cursor:pointer; width:108px; height:37px;         
           background-color:#244C86;           
           font-family:Myriad Pro;font-size:22px;
           font-weight:bold;
           color:White; 
         border-radius: 3px; 
        -moz-border-radius: 3px; 
         -webkit-border-radius: 3px; 
     }    
     
       .findPropertyOuter div
     {
         display:inline-block; vertical-align:middle; text-align:center; width:100px; margin:0 auto;
     }    
     
    .findPropertyOuter:hover
     {   
         clear:both; margin-top:22px; float:right; margin-right:12px;
          cursor:pointer; width:108px; height:37px;         
           background-color:#5282D1;           
           font-family:Myriad Pro;font-size:22px;
           font-weight:bold;
           color:White; 
         border-radius: 3px; 
        -moz-border-radius: 3px; 
         -webkit-border-radius: 3px; 
         
    box-shadow:2px 4px 12px #757380;
     }

.findPropertyInner
{
width: 107px; margin:0 auto;height:22px; margin-top:4px;
}

ui-datepicker-inline ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all ui-datepicker-multi ui-datepicker-multi-4 {
    width:100% !important;
}
  
  /* Login box start*/
  
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
	          <img src="images/banner/5.png" runat="server" id="imgB"  alt="KOMP TIFFIN SERVICE">
	          
        <%--     <div class="caption wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>EAT HEALTHY.</span></h3>
	          </div>

              <div class="caption1 wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>SKIP THE DIET.</span></h3>
	          </div>--%>

	        </li>	       

	      </ul>
	  </div>
  </div>

             <%--       <div class="Tiffin" style="margin-top:-43px;float:right; width:auto;">
                        <img style="margin-left:-5px;" src="images/banner/sl1.png" alt=""/>                        
                      </div>--%>

                      
                      </div>
                <!--SLIDERNEWEND-->
<!--container end here-->
      <div class="row faq">
      <div style="clear:both" ></div>
      <article class="page-art FistArt">
                        <h1 class="page-titleMain" runat="server" id="mainHdr" >LUNCH TIFFIN SERVICE</h1>                                                
                        </article>
                  <div class="col-ms-12">
                  
                  <p class="FistArt" runat="server" id="lunch" visible="false" ><%--Lunch is the most important meal of the day and people like to make elaborate plans and menu for this meal. But what do you do when you are too busy to even cook or cooking doesn’t interest you? Allow KOMP to take care of your lunch. You can just order online with a click of a mouse or call us up. Now with our easy subscription plans, affordable price, a varied daily menu and hygienic packaging options, you can either go for a set menu or virtually design your own meal at KOMP by opting for our customised tiffin service plans.--%>
                  <%--<br /> <br />--%> <span class="page-titleSmall">TRADITIONAL INDIAN PLATE (VEG/ NON-VEG/ V-NV)</span> <br />
                  The Traditional Indian Plate offers a complete meal of chapatis, dal, rice, salad, raita with an option to choose from a Veg or Non-Veg curry dish. Further, as per your preference &amp; taste we have also included a choice of additional Veg dish and desserts in our meal plan. <br /><br />
                  Also, if you wish to have both Veg &amp; Non-Veg in same meal plan in our Traditional Indian Plate meals, then you can opt for our “V-NV” plan, especially designed for those customers who want to relish Veg (V) as well as Non-Veg (NV) dishes in their meals throughout the month. In V-NV meal plan Non Veg is served on Wednesday &amp; Friday and rest of the days Veg is served. <br /><br />
                   You get unlimited variety in your meals by selecting one of the below plans catering to your own preference: <%--“TAKE-IN-TURN” TAB under meal plans to be changed to V-NV--%>

                  </p>
                  <p class="FistArt" runat="server" id="dinner" visible="false" >Now you not only get unlimited variety in your lunch, but in your dinner meals as well by selecting one of the below plans catering to your own preference.
                  <br /> <br /> <span class="page-titleSmall">TRADITIONAL INDIAN PLATE (VEG/ NON-VEG/ V-NV)</span> <br />
                  The Traditional Indian Plate offers a complete meal of chapatis, dal, rice, salad, raita with an option to choose from a Veg or Non-Veg curry dish. <br /><br />
Further, as per your preference & taste, we have also included a choice of additional Veg dish and desserts in our meal plans.         The meal plans are - Essential, Classic & Grand.<br /><br />
If you wish to alternate between our Traditional Indian Plate Veg and Non-Veg meals, then you can opt for our “V-NV” plan, especially designed for those customers who want to relish Veg as well as Non-Veg dishes in their meals throughout the month. <br /><br />
                  </p>
                  <p class="FistArt" runat="server" id="dinnerNutri" visible="false">In the earlier days, they used to say, breakfast like a king and dine like a pauper. But that does not mean you have to starve yourself. The idea here is to have a light dinner, which is easy to digest and yet pack you with enough essential nutrients. <br /><br />
We at KOMP understand that cooking at night after a long day at work can be quite tiresome for busy professionals. Hence, we have come up with Nutrimeals plans. <br /> <br /> 

<span class="page-titleSmall">Nutrimeal Plate</span> <br />
You will have the choice of Veg & Non-Veg set meals which will vary all month round. Our nutritious dinner menu is specially designed keeping in mind our body’s need for fibre, proteins and vitamins; not to forget health and low-fat!<br /><br />
We do not, however, believe in cost-cutting and passing of ordinary stuff as a healthy meal. We use premium quality ingredients and rice-bran oil for cooking the meals, and make sure we offer you a healthy diet at a very affordable price. We include ingredients as multi-grain, oats, salads and soups to satisfy your tummy as well as taste buds. We want to see you healthy and happy with your meals.<br /><br />

Choose from our following packages to enjoy a tasty meal.
</p>

<p class="FistArt" runat="server"  id="lunchNutri" visible="false" ><%--Here also customer can relish Veg and Non-Veg meals and can opt for a V-NV Meal where you are served both Veg and Non-Veg meals in the same meal plan. In V-NV meal plan Non Veg is served on Wednesday & Friday and rest of the days Veg is served.We cherish the satisfaction you feel after every healthy meal. Choose from our following packages for a tasty meal. --%>
<%--<br /> <br /> --%><span class="page-titleSmall">Nutrimeal Plate</span> <br /> Whether the convenience of hotel food or goodness of nutritious food? Calorie counting or giving in to taste buds? Now you can choose both, health bhi aur taste bhi! We have just the right kind of meals for you – packed with the goodness of multi-grain, pulses, soups and seasonal fruits. We use premium quality ingredients and rice-bran oil for cooking the meals, and make sure we offer you a healthy diet at a very affordable price. <br /><br />
Here also customer can relish Veg and Non-Veg meals and can opt for a V-NV Meal where you are served both Veg and Non-Veg meals in the same meal plan. In V-NV meal plan Non Veg is served on Wednesday &amp; Friday and rest of the days Veg is served.
</p>



<div id="divItem" runat="server" ></div>
<!--Note start-->
<%--<div id="3382" class="" style="display:block!important;clear: both;width: 100%;height: auto;border: 1px solid #c8c6c6;border-bottom: 0px !important;font-family: RobotoBlack;">
<div class="leftsubDetails">
<div style="clear:both"></div>
<div class="subProductDetails">
<span style="font-size:13px; " >*Meal Prices are inclusive of all Taxes.  <br />
*Delivery Charges extra:  10 Days – Rs. 300  |  22 Days – Rs. 600
</span>
</div>
</div>
<div style="clear:both;"></div>
</div>--%>
<!--Note start-->

<div style='width:100%;height:1px;border-top:1px solid #c8c6c6 !important;' class="FistArt">&nbsp;</div>
                      

<a id="btnWeekly" runat="server" clientidmode="Static" href="../#weeklyPlanDiv" style="float: none;margin-left:35%;color:#4b220c"><input type="button" class="proceed" style="float:none;" runat="server" id="btnWeeklyM" clientidmode="Static" value="SAMPLE MENU"/></a>

<br class="FistArt" />
<div style="clear:both" ></div>
  <div id="weeklyPlanDiv"  style="border:1 solid #eeeeee; width:80%; height:auto; background-color:#fff !important;display:none;  background:#fff;   background-color:#fff !important;      border-radius: 3px !imortant; -moz-border-radius: 3px !imortant; -webkit-border-radius: 3px !imortant;box-shadow:1px 1px 4px #757380;" >

  <span style='' class='hidemodal' >X</span>
<h3 class="page-titleSmall pt" style="text-align:center; text-transform:none;color:#4b220c; background-color:#c8c6c6; padding-top:15px;padding-bottom:15px !important;margin-top:0px;margin-bottom:0px" >&nbsp;<asp:Label ID="lblWEEKLYTEXT" runat="server" Text="OUR VEG & NON-VEG WEEKLY MENU"></asp:Label> </h3>

<table class="text weeklyMenuTable" border="1" width="100%" cellspacing="0" cellpadding="2" align="center" bordercolor="#c8c6c6">
<tbody class="plan" >
<tr valign="middle" bgcolor="#F16822" style="color:#fff;" >
<td align="center" style="border-right-width:4px;border-right-color:#c8c6c6;border-right-style:solid;" ><span><strong>Menu</strong></span></td>
<td align="center"><span><strong>MONDAY</strong></span></td>
<td align="center"><span><strong>TUESDAY</strong></span></td>
<td align="center"><span><strong>WEDNESDAY</strong></span></td>
<td align="center"><span><strong>THURSDAY</strong></span></td>
<td align="center"><span><strong>FRIDAY</strong></span></td>
<td align="center"><span><strong>SATURDAY</strong></span></td>
</tr>
<%--<tr valign="middle" bgcolor="#FFE0CE">
<td align="center" style="border-right-width:4px;border-right-color:#c8c6c6;border-right-style:solid;"><strong></strong></td>
<td align="center"><strong><asp:Label ID="lblDt1" runat="server"></asp:Label> </strong></td>
<td align="center"><strong><asp:Label ID="lblDt2" runat="server"></asp:Label></strong></td>
<td align="center"><strong><asp:Label ID="lblDt3" runat="server"></asp:Label></strong></td>
<td align="center"><strong><asp:Label ID="lblDt4" runat="server"></asp:Label></strong></td>
<td align="center"><strong><asp:Label ID="lblDt5" runat="server"></asp:Label></strong></td>
<td align="center"><strong><asp:Label ID="lblDt6" runat="server"></asp:Label></strong></td>
</tr>--%>
    <asp:Literal ID="ltrlRow" Visible="true"  runat="server"></asp:Literal>

  <tr valign="middle" style="color:#333; font-style:italic; font-size:12px;background-color: #fff" > <td colspan="7"> <span>&nbsp;&nbsp;* Customer shall receive the meal content as per the plan chosen. Menu options are subject to change due to market availability and seasonal demands.</span></td></tr>
</tbody>
</table>
  <%--<div style="clear:both;height:10px;" ></div>--%>
  </div>
  <div style="clear:both" ></div>
  
<div id="divPlans" style="width:100%; display:none;" >



 <div id="divEditable" class="ProcessBox CUSTBOX" style='' >
        <div style="clear:both" ></div>
      
        <article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >01</span>YOUR SELECTED MEAL PLAN 
        <input type="button" class="proceedBack" value="Edit" style="float:right;margin-top:-2px;margin-right:10px;font-size:22px;padding:5px 6px; border-radius: 0em !important;	-webkit-border-radius: 0em !important;	-moz-border-radius: 0em !important;-o-border-radius: 0em !important;" onclick="EditMeals();" />
        </h1>
        
        </article>

        


         <div class="ProcesBoxInner" style="font-family:robotoblack" >
        <div>
         <span class="subProductHeaderVeg" style="font-size:23px;padding-top:0.2em; cursor:default;display:none" ></span><span class="subProductHeader"></span> &nbsp;&nbsp;&nbsp;&nbsp; <span class="plan1" style="color:#43200c" ></span>
        </div>
        <input type="button" class="proceed" value="PROCEED" onclick="ShowMealPlan();" />
        
        
        <div style="clear:both" ></div>
        </div>
      </div>

    <div id="divChkDelieveryArea" class="ChkDelieveryArea ProcessBox CUSTBOX" style='border-top:0px;display:none' >
        <div style="clear:both" ></div>
      
        <article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >02</span>CHECK YOUR DELIVERY AREA</h1>
        </article>
         <div class="ProcesBoxInner" >
             <% if (IsLunch == true)
                 { %>
                    <div>Please enter your pin code for delivery availability</div>        
                    <br />
                <input id="txtPinCode" runat="server" onclick="HideDateBoxes();" clientidmode="Static" class="textbox NumberClass" maxlength="6" autocomplete="off" placeholder="Pincode" type="text" /> <br />
                <input type="button" class="proceed" value="PROCEED" onclick="return CheckArea();" />
             <%}
                 else
                 { %>
                     
             <p>At present our dinner service is available in Andheri East, Andheri West, Vile Parle East, Vile Parle West, Jogeshwari East,  Jogeshwari West, Santa Cruz East, Santa Cruz West, Powai, Ghatkopar.</p>
             <input type="button" class="proceed" value="PROCEED" onclick="AftercheckValid();" />
        <%} %>
        

        <%--<input type="button" class="proceedBack" value="Edit" onclick="EditMeals();" />--%>

        <div style="clear:both" ></div>
        </div>
      </div>

      <div id="divSetDate"  class="ProcessBox CUSTBOX" style="display:none;height:auto;margin-top:0px;border-top:0px;">
        <div style="clear:both" ></div>
        <article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >03</span>SELECT START DATE</h1>        
        </article>
         <div class="ProcesBoxInner" >
         <%--<span>Select Start Date</span><br />--%>
         <div style="display:none">
         <span>We have 3 types of plans</span><br />
        <%--<input type="radio" id="rd1" class="mealplan" planid="1" checked="checked" daysPlan="10" deliveryChrg="300" validaty="15" name="plan" /><span>10 Days Meal Plan (to be consumed in 15 working days)</span> <br />
        <input type="radio" id="rd2" class="mealplan" planid="2" daysPlan="22" validaty="35" deliveryChrg="600" name="plan" /><span>22 Days Meal Plan (to be consumed in 35 working days)</span><br />
        <input type="radio" id="rd3" class="mealplan" planid="3" daysPlan="2" validaty="5" deliveryChrg="75" name="plan" /><span>22 Days Meal Plan (to be consumed in 35 working days)</span><br />--%>
             <input type="hidden" id="hdndaysPlan" />
             <input type="hidden" id="hdnPlanvalidaty" />
             <input type="hidden" id="hdnPlanid" />
             <input type="hidden" id="hdndeliveryChrg" />
        </div>

        <div style="width:90%; text-align:left;margin-left:0px; margin-top:10px; float:left; ">
        
   <%--     <script type="text/javascript">
                        var today = new Date();            
                        $('#disable-dates').multiDatesPicker({                
                            addDisabledDates: [today.setDate(1), today.setDate(3)], numberOfMonths: 3
                        });
        </script>--%>
         </div>

        <input id="txtPossessionDate" style="" onkeypress="return false;" placeholder="select start date" type="text" autocomplete="off" /> <br />
         <br />
          <div style="clear:both" ></div>
      
      
         <input type="button" value="PROCEED" class="proceed"  onclick="DaysSelection();" />
       <%--  <input type="button" class="proceedBack" value="Edit" onclick="EditMeals();" />--%>
       
         <div style="clear:both" ></div>      
        </div>
         <div style="clear:both" ></div>
    </div>

      <div id="divSetDate2"  class="ProcessBox CUSTBOX" style="display:none;height:auto;margin-top:0px;border-top:0px;">
        <div style="clear:both" ></div>
        <article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >04</span>CHOOSE YOUR DATES</h1>        
        </article>
           <div class="ProcesBoxInner" >
           <%--<span style="padding:0 0 10px 25px" ><em style="color:#F26724">*</em>&nbsp;Select <span class="sds" ></span> Meal Delivery Dates (to be consumed in <span class="sdsCon" ></span> working days)</span>--%>
           <span style="padding:0 0 10px 25px" ><em style="color:#F26724; display:none">*</em><span class="sds" ></span> Meals to be consumed within <span class="sdsCon" ></span> working days.</span> <br /> 
           <span style="padding:0 0 0 25px" >If you wish to change the meal delivery dates, click on any pre-selected date in the calendar to choose new date(s). </span>
        <div style="width:90%; text-align:left;margin-left:0px; margin-top:10px; float:left; ">
          
        <div id="disable-dates" class="box" style="float:left;"></div>        
        
         </div>
         
                 
         <br />
          <div style="clear:both" ></div>
         <br />
         <span style="padding:10px 0 0 20px;font-style:italic" ><em style="color:#F26724">*</em>&nbsp;Working days exclude Sundays and public holidays.</span>
         
         
         <input type="button" value="PROCEED"  class="proceed" onclick="SetPriceQuantity();" />            
         <%--<input type="button" class="proceedBack" value="Edit" onclick="$('#divChkDelieveryArea').hide();$('#divPlans,#divSetDate').hide();$('.subItemBox').show(); $('html,body').animate({  scrollTop: $('.subVeg').offset().top}, 1000);showcount=0;IsClickable = true;" />--%>
         
         <div style="clear:both" ></div>
         
        </div>
    </div>
</div>
<div id="divQuantity" class="ProcessBox CUSTBOX" style="display:none;height:auto;margin-top:15px;">
  <article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >05</span>CART</h1>        
        </article>
        <div class ="ProcesBoxInner">
               
<div style="width:100%;" >
        <table id="tableQuantity" class="tbl" cellspacing="1" ><tbody></tbody></table>

        <input type="button" value="CONTINUE SHOPPING" class="proceedBack" style="float:left" onclick="ShowItems();" />

                <input type="button" class="proceed" value="ADD TO CART" onclick="SetCartTotal();" />
                <input type="button" value="BACK" class="proceedBack" style="float:right" onclick="$('#divSetDate2').show();$('#divQuantity').hide(); $('#divPlans').show();$('#divDays').show(); $('.FistArt').show();$('#ContentPlaceHolder1_divItem,.ChkDelieveryArea').show(); EnableDisablePin(); ScrollPage();" />
        </div>
        </div>
        
<%--
   <div style="width:100%">
                    <table id="tableQuantity" width="100%" align="center" cellpadding="5" cellspacing="2">
				    <tbody>															                    
				</tbody></table>

                
</div>--%>

<div style="clear:both" ></div>
</div>

<!--CART TOTAL Start -->
<div id="divCart" class="ProcessBox CUSTBOX" style="display:none;height:auto;margin-top:15px;">
<article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >06</span>CART TOTAL</h1>        
        </article>
        <div class ="ProcesBoxInner">
        <div style="width:100%;" >
                 <table class="tableCart tbl" cellspacing="1" width="100%" align="center" cellpadding="5" >
                 <thead>
                 <tr class='divRow dataHeader' style='background:#F16822;color:#fff;font-family:RobotoBold;font-size:1.2em;' ><td></td><td>ORDER</td><td>PRODUCT</td><td>Total No. Of Meals</td><td align="center">AMOUNT</td></tr>
                 </thead>                 
				<tbody>
				</tbody>  
                <tfoot>              
                <tr class="divRow"><td colspan="4" style="width:70%;" align="right"><span class='priceTotaltxt'>DELIVERY CHARGE &nbsp;&nbsp;&nbsp;</span></td><td style="width:30%;" align="right" ><span id="spCharge" class='priceTotal'></span></td></tr>
                    <tr class="divRow"><td colspan="4" style="width:70%;" align="right"><span class='priceTotaltxt'>TOTAL AMOUNT&nbsp;&nbsp;&nbsp;</span></td><td style="width:30%;" align="right" ><span class='priceTotal GRTOTAL'></span></td></tr>
                    </tfoot>
                
                </table>

                <%--<table class="tbl" cellspacing="1" >
        <tr class="divRow"><td colspan="2">        
        <span class="page-titleSmallBlackNOLEFT">ORDER REVIEW</span>                
        </td></tr>

        <tr class="divRowHeader"><td style="width:70%;">PRODUCT DETAILS</td><td style="width:30%;">ORDER TOTAL</td></tr>
        
        </table>--%>

                
                <input type="button" value="CONTINUE SHOPPING" class="proceedBack" style="float:left" onclick="ShowItems();" />

                <input type="button" class="proceed" value="PROCEED" onclick="ShowPaymentMethod();"/>
                <%--<input type="button" value="BACK" class="proceedBack" style="float:right" onclick="ShowItems();" />--%>
                
</div>
        </div>
   <div style="clear:both" ></div>
</div>
<!--CART TOTAL end -->

<!--PAYMENT METHOD Start -->
<uc1:PaymentMethod ID="PaymentMethod1" runat="server" />
                      
<!--PAYMENT METHOD end -->


<div id="ddd" style="width:100%;height:auto" ></div>


<script  type="text/javascript">
    var loggiedIn = "<%=loggiedIn%>"; // value 1 if user session
    var minDateAdmin = "<%=minDateAdmin%>"; 
    var countRows = 15;
    var maxSelection = 0;
    var selectedSubProductId = 0;    
    var DaysInPlan = 0;
    var ValidUpTo = 0;
    //var PlanName = '';

    var TotalAmount = 0;
    var disabledSpecificDays = <%=this.javaSerial.Serialize(disabledSpecificDays)%>;//["7-18-2015","7-24-2015"];//;
    var RenewRequest = "<%=RenewRequest%>";
    var IsLunch = "<%=IsLunch%>";
    IsLunch=(IsLunch=="False")?"0":"1";
    

    var DeliveryChrg = 0;
    var TrnChrg = "<%=TrnChrg%>"; //in percent    
    var chkCashPickUp = "<%=chkCashPickUp%>"; //
    var chkCashPickUpPers = "<%=chkCashPickUpPers%>"; //in percent

    var orderlst = <%= this.javaSerial.Serialize(orderlst) %>;
    
    

    /** RenewRequest*/
    $(document).ready(function () {
        if (RenewRequest != "") {
            SetSubPID(RenewRequest, DaysInPlan, ValidUpTo, PlanName, DeliveryChrg);
         }
        $("#divPaymentMethod .OrderBox").html("07");
        Page = 'Service';
        $('.TiffinHdrLft').prepend($('p.FistArt').html()+"<br/><br/>");
        $('p.FistArt').html('');

        if(IsLunch!="1")
        {
            $('.AboutImg').attr("src",$('.AboutImg').attr("src").replace(".jpg","1.jpg")); 
        }



        $('#btnWeekly').leanModalCenter({ top: 30, overlay: 0.45, closeButton: ".hidemodal" });




    });

    var showcount = 0;
    function SetSubPID(sclass,id, daysInPlan, validUpTo, planName, deliveryCharges) {

        
        selectedSubProductId = id;
        DaysInPlan = daysInPlan;
        ValidUpTo = validUpTo;
        //PlanName = planName;
        DeliveryChrg = deliveryCharges;

        $("#hdndaysPlan").val(daysInPlan);
        $("#hdnPlanvalidaty").val(validUpTo);
        $("#hdnPlanid").val(id);
        $("#hdndeliveryChrg").val(deliveryCharges);

        //$(".mealplan[daysPlan='" + DaysInPlan + "']").attr("checked", "chected");
        ResetSingleCalender();
//        var maxDate = new Date(); //getDateYymmdd($(this).data("val-rangedate-max"));
        //        maxDate.setDate(maxDate.getDate() + DaysInPlan);
        //alert(validUpTo);
        //var today = new Date();
        //alert(DaysInPlan + "-" + ValidUpTo);

        
        ValidUpTo = parseInt(ValidUpTo) + 4;
        var pdate = "";
        if ($("#txtPossessionDate").val() != '') {
            var dateParts = $("#txtPossessionDate").val().split('/');
            pdate = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
        }
//        alert(pdate);
//        var MaxDt = parseInt(((new Date(pdate)) - (new Date())) / (1000 * 60 * 60 * 24)) + ValidUpTo - 2;
//        alert(MaxDt);
//        $('#disable-dates').multiDatesPicker('destroy');
//        $('#disable-dates').multiDatesPicker({
//            beforeShowDay: disableSpecificDaysAndWeekends, numberOfMonths: 3, minDate: pdate, maxDate: MaxDt, maxPicks: daysInPlan, adjustRangeToDisabled: true
//        });
        //$('#disable-dates').multiDatesPicker('options', { minDate: 4, maxDate: DaysInPlan });
        //$("#disable-dates").multiDatesPicker('maxDate', '10');
//        $('#disable-dates').multiDatesPicker({
//            minDate: 0,
//            maxDate: 30
//        });

        $("#btnWeekly").hide();
        $("#Note3382").hide();
        //$('body').scrollTo($('#divPlans');
        $("input.btnRed").removeClass('btnRedClick');
        $("."+sclass).addClass('btnRedClick');
        //$(".FistArt,.mealP").hide();
        $(".mealP").hide();
       //$("div[mealtype='" + selectedTab + "'].subItemBox").hide();

         
          
      
          //}
         

        IsClickable = false;

        //Start YOUR MEAL PLAN
              $('#divEditable .subProductHeader').html($('#'+id+' .subProductHeader').html().split(')')[0]+")");
            $('#divEditable .plan1').html($("."+sclass).parent().children('.plan').html());        
            
            var veg1 = "";
            var bClass = "";

            if( $('#'+id+' .subProductHeader').html().indexOf('(V)')>-1)
            {
            veg1 = "VEG";
            bClass="Green";
            }
            else if( $('#'+id+' .subProductHeader').html().indexOf('(NV)')>-1)
            {
            veg1 = "NON-VEG";
            bClass="Red";
            }
            else if( $('#'+id+' .subProductHeader').html().indexOf('(TITL)')>-1)
            {
            veg1 = "V-NV";
            bClass="Blue";
            }

            //alert(veg1 +" - "+bClass);
            $('.subProductHeaderVeg').removeClass('Green').removeClass('Red').removeClass('Blue');
            $('.subProductHeaderVeg').html(veg1).addClass('subVeg1').addClass(bClass);
            
        //End YOUR MEAL PLAN

        if (showcount == 0) 
        {        
      
        

            $('#ContentPlaceHolder1_divItem').show();
            $('#divPlans,#divEditable').show();
            $('#divSetDate2').hide();
            //ScrollPage();

        }
        else {
            $('#divPlans').show();
            
//            $('#divEditable .subProductHeader').html($('#'+id+' .subProductHeader').html().split(')')[0]+")");
//            $('#divEditable .plan1').html($('#'+id+' .plan').html());        
//            var veg1 = ($('#'+id+' .subProductHeader').html().indexOf('(V)')>-1)?"Veg":"Non-Veg";        

            $('#ContentPlaceHolder1_divItem').show();
            $('#divPlans,#divEditable').show();
            $('#divSetDate2').hide();
            

           // $('#divChkDelieveryArea').hide();         

        }

       //ScrollPage();       
       $(".subVeg,div[mealtype='" + selectedTab + "'].subItemBox").slideToggle(1000, function () {   });
       
       setTimeout(function() {  ScrollPage();      }, 1100);       
       
       // $("#divHotels,#ctl00_MainContent_literalDives").fadeIn(0); 
       
        
    }

    function ShowMainMenu() {
        $('#ContentPlaceHolder1_divItem').show();
        $('#divPlans').hide();
    }

    function SetDays() {

//        if ($('#txtPossessionDate').val() == "") {
//            alert('Please select starting date!');
//            $('#txtPossessionDate').focus();
//            return false;
//        }

//        if ($('.mealplan:checked').length == 0) {
//            alert('Please select meal plan!');
//            return false;
        //        }

        if (!ValidateOrderTiffin()) {
            return false;
        }

        var pdate = "";
        if ($("#txtPossessionDate").val() != '') {
            var dateParts = $("#txtPossessionDate").val().split('/');
            pdate = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];            
        }

        var today = pdate;
        var htmlDays = '';


        countRows = ValidUpTo;
        maxSelection = DaysInPlan;

//         countRows = parseInt($('.mealplan:checked').attr("validaty"));
//         maxSelection = parseInt($('.mealplan:checked').attr("daysPlan"));

         //Setting here total amount and plan        
         
         TotalAmount = maxSelection * GetItenPrice(selectedSubProductId);
         


        if (countRows > 0) {
            $('#divPlans').hide();
            $('#divDays').show();
            $('#tableDays tbody').append("<tr><td width='10%'><b>No.</b></td><td><b>Dates</b></td><td><b>Product Name</b></td><td><b>Varity</b></td></tr>");
           }

        for (var i = 1; i <= countRows; i++) 
        {            
            //var tomorrow.setDate(tomorrow.getDate() + 1);
            var nextDay = new Date(pdate);
            nextDay.setDate(nextDay.getDate() + i - 1);

            /////            
            var dd = nextDay.getDate();
            var mm = nextDay.getMonth() + 1; //January is 0!
            var yyyy = nextDay.getFullYear();
            if (dd < 10) 
            {
                dd = '0' + dd
            }
            if (mm < 10) {
                mm = '0' + mm
            }
            var dateshow = dd + '/' + mm + '/' + yyyy;
            //////

            $('#tableDays tbody').append("<tr><td>" + i + "</td><td>" + dateshow + "</td><td><input type='checkbox' class='checkDate' id='chk" + i.toString() + "' /></td><td></td>");
            //$('#tableDays tbody').append("<tr><td>" + i + "</td><td>" + dateshow + "</td><td><select name='slmainMenu' submenu='slsubMenu" + i.toString() + "' class='slmainMenu'><option value='0'>select</option></select></td><td><select id='slsubMenu" + i.toString() + "' name='slmainMenu' class='slsubMenu'><option value='0'>select</option></select></td>");
        }

       // SetCalender();
        //SetProductData();
//        $(".slmainMenu").change(function () {

//            var subMenuComboId = $(this).attr("submenu");
//            SetSubProductData($(this).val(), subMenuComboId);
//            $("#" + subMenuComboId).focus();
//        });
        

        loggiedIn = "<%=loggiedIn%>"; // value 1 if user session

    }




    function ShowPlans() {

        $('#divSetDate2').hide();
        $('#divPlans,.ChkDelieveryArea').show();
        ScrollPage();
//        $('html,body').animate({
//            scrollTop: $('#divPlans').offset().top - $('#footer').height() - 35
//        }, 1000);

    }




    function DaysSelection() {
        if ($('#txtPossessionDate').val() == "") {
            swal('Please Select The Start Date!');
            $('#txtPossessionDate').focus();
            return false;
        }

        //ValidUpTo = parseInt($('.mealplan:checked').attr("validaty"));
        //daysInPlan = parseInt($('.mealplan:checked').attr("daysPlan"));
        ValidUpTo = parseInt($('#hdnPlanvalidaty').val());
        daysInPlan = parseInt($('#hdndaysPlan').val());
        DaysInPlan = daysInPlan;
        //ValidUpTo = parseInt(ValidUpTo) + 4;
        $(".sds").html(daysInPlan);
        $(".sdsCon").html(ValidUpTo);

        var pdate = "";
        if ($("#txtPossessionDate").val() != '') {
            var dateParts = $("#txtPossessionDate").val().split('/');
            pdate = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
        }

        //ValidUpTo = parseInt(ValidUpTo) + 4;
        var MaxDt = parseInt(((new Date(pdate)) - (new Date())) / (1000 * 60 * 60 * 24)) + ValidUpTo;

        
        var ShowCalender = 4;
        if (ValidUpTo < 29) {
            ShowCalender = 2;
        }
        else if (ValidUpTo < 60){
            ShowCalender = 3;
        }

        
       // var addExtra = -1;//(new Date(pdate)).getDay()==5?1:1;
        //MaxDt = MaxDt +1;
        //alert(MaxDt);

       var MO = new Date(pdate);//new Date(); //getDateYymmdd($(this).data("val-rangedate-max"));
       MO.setDate(MO.getDate() + MaxDt - parseInt(((new Date(pdate)) - (new Date())) / (1000 * 60 * 60 * 24))+1);       
       
       //alert(new Date(pdate)+" sun "+new Date(MO));

       var cn= countSatSun(new Date(pdate),new Date(MO));

       MaxDt = MaxDt + cn.sun;
       MO = new Date(pdate);
       MO.setDate(MO.getDate() + MaxDt);
       //alert("sun "+cn.sun +"maxdt "+MaxDt);
       //MaxDt = MaxDt + HolidayBetweenRange;
       HolidayBetweenRange = 0;
       
       countHoliday(new Date(pdate),new Date(MO));
       MaxDt = MaxDt + HolidayBetweenRange;        
       
       MO = new Date(pdate);//new Date(); //getDateYymmdd($(this).data("val-rangedate-max"));
       MO.setDate(MO.getDate() + MaxDt - parseInt(((new Date(pdate)) - (new Date())) / (1000 * 60 * 60 * 24))+1);       

       var cn1= countSatSun(new Date(pdate),new Date(MO));
       MaxDt = MaxDt + cn1.sun - cn.sun;

       
       

//       MO = new Date();
//       MO.setDate(MaxDt);       
//alert(MaxDt);
      // alert(MO.getDay());
       //alert(MO.getDay() == 0);

       //alert("holiday "+ HolidayBetweenRange+" maxdt "+MaxDt);
       
       //alert(HolidayBetweenRange);
       //alert("MaxDt:"+MaxDt + "cn.sun"+cn.sun + "addExtra"+addExtra + "disabledSpecificDays"+disabledSpecificDays+" HolidayBetweenRange"+HolidayBetweenRange); 
       
       //alert(MaxDt + " : " + daysInPlan);
        
        //Mahesh old start       
//            $('#disable-dates').multiDatesPicker('resetDates','picked');                 
//                 $('#disable-dates').multiDatesPicker('resetKOMP');
//        $('#disable-dates').multiDatesPicker('destroy');
//        $('#disable-dates').multiDatesPicker({
//            beforeShowDay: disableSpecificDaysAndWeekends, numberOfMonths: ShowCalender, minDate: pdate, maxDate: MaxDt, maxPicks: daysInPlan, adjustRangeToDisabled: true
//        });
//        $('#disable-dates').multiDatesPicker('destroy');
//        $('#disable-dates').multiDatesPicker({
//            beforeShowDay: disableSpecificDaysAndWeekends, numberOfMonths: ShowCalender, minDate: pdate, maxDate: MaxDt, maxPicks: daysInPlan, adjustRangeToDisabled: true
//        });
        //Mahesh old end

        //Mahesh today start
           $('#disable-dates').multiDatesPicker('resetDates','picked');                 
        $('#disable-dates').multiDatesPicker('resetKOMP');
        $('#disable-dates').multiDatesPicker('destroy');

        
        
        var MaxDtRangeOnly = parseInt(((new Date(pdate)) - (new Date())) / (1000 * 60 * 60 * 24)) + daysInPlan;        
       var MORangeOnly = new Date(pdate);//new Date(); //getDateYymmdd($(this).data("val-rangedate-max"));       
       MORangeOnly.setDate(MORangeOnly.getDate() + MaxDtRangeOnly - parseInt(((new Date(pdate)) - (new Date())) / (1000 * 60 * 60 * 24)));              
       var cnRangeOnly= countSatSun(new Date(pdate),new Date(MORangeOnly));       
       HolidayBetweenRange=0;
        countSatSun(new Date(pdate),new Date(MORangeOnly));
         //MORangeOnly = new Date(pdate);
        MORangeOnly.setDate(MORangeOnly.getDate() + cnRangeOnly.sun + HolidayBetweenRange);
        HolidayBetweenRange=0;
        cnRangeOnly= countSatSun(new Date(pdate),new Date(MORangeOnly));

        
        
       
       
       
       var holionlyRange = HolidayBetweenRange;
       //alert(daysInPlan+ ' sun ' + cnRangeOnly.sun+' holid '+holionlyRange);
        
       countSatSun(new Date(pdate),new Date(MO));

        $('#disable-dates').multiDatesPicker({
            beforeShowDay: disableSpecificDaysAndWeekends, numberOfMonths: ShowCalender, minDate: pdate, maxDate: MaxDt, maxPicks: daysInPlan, adjustRangeToDisabled: false,
            mode: 'daysRange',
	autoselectRange: [0,(daysInPlan+cnRangeOnly.sun+holionlyRange)]
        });        

        $('.ui-datepicker-current-day').click();
        $('.ui-datepicker-current-day').click();
        $('#disable-dates').multiDatesPicker({
            beforeShowDay: disableSpecificDaysAndWeekends, numberOfMonths: ShowCalender, minDate: pdate, maxDate: MaxDt, maxPicks: (daysInPlan), adjustRangeToDisabled: false,mode: 'normal'
        });
        //Mahesh today end
         
        $('#divPlans').show();        
        $('#divSetDate2').show();
        //$('.ui-state-highlight').click();
       // $('.ui-state-highlight').click();
        //Mahesh today end
        
        //$('td').removeClass('ui-state-highlight');

        //$('#ContentPlaceHolder1_divItem,#divChkDelieveryArea').hide();
        //$('.ChkDelieveryArea,#ContentPlaceHolder1_divItem').show();
        $('#divPlans').show();
        //$('#divSetDate').hide();
        $('#divSetDate2').show();
        ScrollPage();
//        $('html,body').animate({
//             scrollTop: $('#footer').offset().top - 2*$('#footer').height() + 170//scrollTop: $('#divSetDate2').offset().top - $('#footer').height()*53/100 
        //        }, 1000);
        //$(".ui-datepicker-inline, .ui-datepicker").css("width", "114%;");
    }

function AftercheckValid()
    {
    if(pincode==0)
    {
        pincode="400001"
    }
        swal("Welcome, Kitchen On My Plate meal delivery service is available in your area. Please select your meal start date.");
        $('#ContentPlaceHolder1_divItem,.weeklyMenuTable,.pt').show(); $('#divSetDate').show(); $('#divSetDate2').hide();
        ScrollPage();$('#txtPossessionDate').val(''); 
}
    function ShowQuantity() {
        
        //Back button on login
        $("#ifUserNotLoggedIn").hide();
        $('#divQuantity').show();
        $('.FistArt').hide();

    }


    function SetPriceQuantity() {
    
        if (!ValidateOrderTiffin()) {
            return false;
        }
        //SubItemTotals = 0.00;
        //alert(SubItemTotals);
        order = new Order();
        payment = new Payment();
        orderDTO = new OrderDTO();
        orderDetailList = new Array();
        var today = new Date();
        var htmlDays = '';
        var countRows = 4
        var DeliveryChrgTotal = 0;

        if (countRows > 0) {
            $('#divPlans').hide();
            $('#divDays').hide();
            $('#divQuantity').show();
            $('.FistArt').hide();
            
            // $('#tableQuantity tbody').append("<tr align='left' class='sectiontableheader'><th>Name</th><th>SKU</th><th>Price</th><th>Quantity</th><th>Subtotal</th></tr>");
            
        } 


        var SubTotal = 0;
        
        //Create Object Order and OrderDetails

      
        order.Id = 0;
        order.CustomerId = loggiedIn;
    
        //var pdate = "";
//        if ($("#txtPossessionDate").val() != '') {
//            var dateParts = $("#txtPossessionDate").val().split('/');
//            pdate = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
//        }

     
        order.PlanId = 1;//  $('.mealplan:checked').attr("planid");        
        order.OrderDate = new Date();
        order.RequestId = 0;
        order.PaymentDone = 0;
        order.NonCustomized = 1;
        order.IsLunch = IsLunch;
        order.IsActive = 0;
        order.pincode=pincode;
        order.YourguyOrderId=0;

        var dates = $('#disable-dates').multiDatesPicker('getDates');
        var dates_in_string = '';
        order.OrderStartDate = dates[0];

        var index = 0;
        $('#tableQuantity tbody tr').remove();
        for (d in dates) 
        {
            index++;
            dates_in_string += dates[d].split('/')[1] + "/" + dates[d].split('/')[0] + "/" + dates[d].split('/')[2];
            dates_in_string = (dates.length == index) ? dates_in_string : dates_in_string + ", ";
            //alert(dates_in_string);

            var price = GetItenPrice(selectedSubProductId)
            SubTotal = SubTotal + parseFloat(price); ;
            // $('#tableQuantity tbody').append("<tr valign='top'>	<td><strong>" + $("#slsubMenu" + index + " option:selected").text() + "<br/>" + $(this).children("td:eq(1)").text() + "</strong></td>	<td>" + $("#slsubMenu" + index).val() + "</td>	<td align='right'>Rs " + price + "</td>	<td> <input type='text' value='1' /> </td>  <td align='right'>Rs" + price + "</td>  </tr>");

            var orderDetails = new OrderDetails();
            orderDetails.Id = 0;
            orderDetails.OrderId = 0;
            orderDetails.SubProductId = selectedSubProductId;
            orderDetails.Quantity = 1;        
            orderDetails.DeliverDate = dates[d];
            orderDetails.IsActive = 0;
            orderDetails.YourguyOrderId=0;
            orderDetailList.push(orderDetails); //Add to list
        }
        

//        $("#tableDays tbody tr").each(function (index) {
//            if (index != 0) {
//                if ($("#slsubMenu" + index).val() != "0") {
//                    var price = GetItenPrice(selectedSubProductId)
//                    SubTotal = SubTotal + price;
//                    // $('#tableQuantity tbody').append("<tr valign='top'>	<td><strong>" + $("#slsubMenu" + index + " option:selected").text() + "<br/>" + $(this).children("td:eq(1)").text() + "</strong></td>	<td>" + $("#slsubMenu" + index).val() + "</td>	<td align='right'>Rs " + price + "</td>	<td> <input type='text' value='1' /> </td>  <td align='right'>Rs" + price + "</td>  </tr>");

//                    var orderDetails = new OrderDetails();
//                    orderDetails.Id = 0;
//                    orderDetails.OrderId = 0;
//                    orderDetails.SubProductId = selectedSubProductId;
//                    orderDetails.Quantity = 1;

//                    var DeliverDate = "";
//                    if ($(this).children("td:eq(1)").text() != '') {
//                        var dateDParts = $(this).children("td:eq(1)").text().split('/');
//                        DeliverDate = dateDParts[1] + "/" + dateDParts[0] + "/" + dateDParts[2];
//                    }

//                    orderDetails.DeliverDate = DeliverDate;
//                    orderDetails.IsActive = 0;
//                    orderDetailList.push(orderDetails); //Add to list
//                }
//            }
//        });
        var discount=0;
        $.ajax
                  ({
                      type: "POST",
                      url: "KompServices.asmx/GetDiscount",
                      contentType: "application/json; charset=utf-8",
                      data: "{DaysCout:" + JSON.stringify(dates.length) + "}",
                      dataType: "json",
                      async:false,
                      success: function (result) {
                          discount=result.d.Discount;
                      }
                  });
        var discountAmount=0;
        if(discount >0)
        {
            discountAmount=SubTotal-(SubTotal*discount/100);
        }
        order.TotalPayment = SubTotal;
        
        payment.Id = 0;
        payment.OrderId = 0;
        payment.TransactionNo ="";
        payment.Amount = SubTotal;
        payment.Mode = 1;
        payment.PaymentDate = new Date();;
        payment.NameOnCard = "";
        payment.CardNumber = "";
        payment.TrnChrg = 0;//  parseInt(TrnChrg * SubTotal / 100);
        payment.DeliveryChrg = DeliveryChrg;
        payment.IsActive = 0;
        payment.Discount=discountAmount;
       // DeliveryChrgTotal = parseInt(DeliveryChrgTotal) + parseInt(DeliveryChrg);

        order.TotalPayment = parseFloat(SubTotal) + parseFloat(DeliveryChrg);
        
        //Assign it to main DTO        
        orderDTO.Order = order;
        orderDTO.payment = payment;
        orderDTO.OrderDetailList = orderDetailList;
        orderlst.push(orderDTO);
        

        orderList.orders = orderlst;

       for(var i=0; i<orderList.orders.length;i++)
       {        
        DeliveryChrgTotal = parseFloat(DeliveryChrgTotal) + parseFloat(orderList.orders[i].payment.DeliveryChrg);        
       }

       

        SubItemTotals = parseFloat(SubItemTotals) + parseFloat(SubTotal) + parseFloat(DeliveryChrg);

        $('#tableQuantity tbody').append("<tr class='divRow dataHeader DR" + orderlst.length + "'><td><b>MEAL DETAILS</b></td><td><b>AMOUNT DETAILS</b></td></tr>");
        $('#tableQuantity tbody').append("<tr class='divRow DR" + orderlst.length +  "'><td style='width:70%;' id='divPNAME'>" + GetSubProductDetails(selectedSubProductId) + "</td><td style='width:30%;' align='right'><strong style='padding-right:25px;' ><i class='fa fa-inr'></i>" + SubTotal + "</strong></td></tr>");
        //$('#tableQuantity tbody').append("<tr class='divRow divRowData'><td>" + dateParts + ".</td><td>" + pdate + "</td><td>" + $("#slmain" + index + " option:selected").text() + "</td><td>" + price + "</td><td>1</td><td>" + price + "</td></tr>");

        //$('#divPNAME').html(GetSubProductDetails(selectedSubProductId));
        //$('#spCharge').html(SubTotal);
        //$('#spChargeTotal').html(SubTotal);


        //$('#tableQuantity tbody').append("<tr class='divRow' align='right'><td><b>Sub Total &nbsp;&nbsp; </b> </td><td align='center'><b>" + SubTotal + "</b></td></tr>");
        //$('#tableQuantity tbody').append("<tr class='divRow' align='right'><td colspan='5'><b>Tax Amount&nbsp;&nbsp; </b> </th><td align='center'><b>" + 100 + "</b></td></tr>");
        //$('#tableQuantity tbody').append("<tr class='divRow' align='right'><td><b>Delivery Charges&nbsp;&nbsp;</b>  </td><td align='center'><b>" + DeliveryChrg + "</b></td></tr>");
        //$('#tableQuantity tbody').append("<tr class='divRow' align='right'  ><td><span style='font-family:RobotoBlack' >Amount&nbsp;&nbsp;</span>  </td><td align='center' ><span style='font-family:RobotoBlack' >" + parseInt(parseInt(SubTotal) + parseInt(DeliveryChrg)) + "</span></td></tr>");
        $('#tableQuantity tbody').append("<tr class='divRow DR" + orderlst.length + "' align='right'  style='font-size:24px'  ><td><span style='font-family:RobotoBlack' >Amount&nbsp;&nbsp;</span>  </td><td align='right' ><span style='font-family:RobotoBlack;padding-right:25px;' ><i class='fa fa-inr'></i>" + SubTotal + "</span></td></tr>");

        $('#tableQuantity tbody').append("<tr class='divRow DR" + orderlst.length + "'><td align='left' colspan='2'><span style='font-family:RobotoBlack' >Delivery Dates: " + dates_in_string + "</span></td></tr>");

        
        //$('#spCharge').html(SubTotal);
       //alert(SubItemTotals);
        $('.priceTotal').html("<i class='fa fa-inr'></i>"+SubItemTotals);     

        
        $('#divCart #spCharge,#divCart #spnShip').html("<i class='fa fa-inr'></i>" + DeliveryChrgTotal);

        
            var shipchrg = parseFloat(DeliveryChrgTotal);
            if (shipchrg.toFixed) {
                shipchrg = shipchrg.toFixed(2);
            }
            $('#divFinal #spCharge, #divFinal #spnShip').html("<i class='fa fa-inr'></i>"+shipchrg);



//        $('#tableQuantity tbody').append("<tr align='left' class='sectiontableheader'><th></th><th></th><th></th><th>Sub Total:</th><th>" + SubTotal + "</th></tr>");
//        $('#tableQuantity tbody').append("<tr align='left' class='sectiontableheader'><th></th><th></th><th></th><th>Tax Amount:</th><th>" + 100 + "</th></tr>");
//        $('#tableQuantity tbody').append("<tr align='left' class='sectiontableheader'><th></th><th></th><th></th><th>Delivery Charges:</th><th>" + 200 + "</th></tr>");
//        $('#tableQuantity tbody').append("<tr align='left' class='sectiontableheader'><th></th><th></th><th></th><th>Grand Total:</th><th>" + parseInt(SubTotal + 100 + 200) + "</th></tr>");

        //SaveOrder(orderDTO);
        //SetCartTotal();
        $('#ContentPlaceHolder1_divItem,#divChkDelieveryArea,#weeklyPlanDiv,#divCart,#divPaymentMethod').hide();


//Disable zipcode as order is added
$("#txtPinCode").attr("readonly","readonly");



        if(orderlst.length>2)
        {
        ScrollPage();
//            $('html,body').animate({
//                scrollTop: $('#footer').offset().top - 2*$('#footer').height() + 170//scrollTop: $('#divQuantity').offset().top //- $('#footer').height() - 35
//            }, 1000);
        }
        else
        {
        ScrollPage();
//            $('html,body').animate({
//                scrollTop: $('#footer').offset().top - 2*$('#footer').height() + 170//scrollTop: $('#divQuantity').offset().top - $('#footer').height() - 35
//            }, 1000);
        }

        CreateOrdersSession();
        OnProductPage = true;
    }


    function ShowMealPlan()
    {
    IsClickable = false;    
    $("#btnWeekly").hide();
    $("#Note3382").hide();
    $("div[mealtype='" + selectedTab + "'].subItemBox,#divSetDate,#divSetDate2").hide(); 
    //$('#divEditable').hide();
    $('#txtPossessionDate').val('');

    $('#divSetDate').hide();
        if (showcount == 0) 
        {
        $('#divChkDelieveryArea').show();}
        else
        {
        $('#divChkDelieveryArea').show();
         
        } 

         if (orderlst.length == 0) {
         $("#txtPinCode").val('');
        }

         showcount = 1;

         ScrollPage();
    }

    function EditMeals()
    {
        
        $('.mealP').show();
        $("#btnWeekly").show();
        $("#Note3382").show();
        $('#divChkDelieveryArea').hide();
        $('#divPlans,#divSetDate').hide();
        $("input.btnRed").removeClass('btnRedClick');
        IsClickable = true;
       // $("div[mealtype='" + selectedTab + "'].subItemBox,#btnWeekly").show();
        $(".subVeg,div[mealtype='" + selectedTab + "'].subItemBox").slideToggle(1000, function () 
        { 
        }).delay( 1000 );
        //$("#ContentPlaceHolder1_divItem").slideToggle(2600, function () { });        

        $('html,body').animate({  
        scrollTop: $('.subVeg').offset().top}, 1000);
        //alert('ss');

        
           if (orderlst.length == 0) {
         $("#txtPinCode").val('');
        }
    }



</script>
    <script src="Scripts/jsOrder.js" type="text/javascript"></script>

    <script type="text/javascript">
        //*******************************tiffin***************End
        $(document).ready(function () {

            subCat('1');
            $(".DownCornerShap2,.DownCornerShap3").hide();
            $('.subVeg').click(function () {
                subCat($(this).attr('cat'));
            });
        });

        function subCat(t) {

            if (IsClickable) {
                $("div.subItemBox[mealtype!='" + t + "']").hide();
                $("div.subItemBox[mealtype='" + t + "']").show();
                selectedTab = t;

                $("div[cat!='" + t + "']").removeClass('Green').removeClass('Red').removeClass('Blue');
                if (t == "1") {
                    $("div[cat='" + t + "']").addClass("Green");
                    $(".DownCornerShap1").show();
                    $(".DownCornerShap2,.DownCornerShap3").hide();
                    
                }
                else if (t == "0") {
                    $("div[cat='" + t + "']").addClass("Red");
                    $(".DownCornerShap2").show();
                    $(".DownCornerShap1,.DownCornerShap3").hide();
                }
                else if (t == "3") {
                    $("div[cat='" + t + "']").addClass("Blue");
                    $(".DownCornerShap3").show();
                    $(".DownCornerShap1,.DownCornerShap2").hide();
                }
            }
        }
    </script>




 </div></div>

</asp:Content>
