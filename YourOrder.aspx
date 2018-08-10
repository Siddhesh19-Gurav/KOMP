<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="YourOrder.aspx.cs" Inherits="KitchenOnMyPlate.YourOrder" %>
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
	          <img src="images/banner/Customized_Tiffin_Service.jpg" alt="customised tiffin serrvice">
	          
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

                 <%--   <div class="Tiffin" style="margin-top:-43px;float:right; width:auto;">
                        <img style="margin-left:-5px;" src="images/banner/sl1.png" alt=""/>                        
                      </div>--%>

                      
                      </div>
                <!--SLIDERNEWEND-->

      <div class="row faq">
      <div style="clear:both" ></div>
      <article class="page-art FistArt">
                        <h1 class="page-titleMain">CUSTOMISED TIFFIN SERVICE</h1>                        
                        </article>
                  <div class="col-ms-12">

                  <%--<p class="FistArt">Yes, you can virtually design your own meals. The idea is to tickle your palate, every day. Just choose more than one plan of your choice from.</p>--%>


    <div id="divItem" class="customized" runat="server" ></div>
 

        <div style="clear:both;height:40px" class="FistArt" ></div>
<div id="divPlans" style="width:100%; display:none;" >

    <div id="divChkDelieveryArea" class="ChkDelieveryArea ProcessBox CUSTBOX" >
        <div style="clear:both" ></div>
      
        <article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >01</span>CHECK YOUR DELIVERY AREA</h1>       
        </article>
         <div class="ProcesBoxInner" >
        <div>Please enter your pin code for delivery availability</div>
        <%--<input type="button" value="Back" onclick="ShowItems();" />--%>
        <br />
        <input id="txtPinCode" runat="server" onclick="HideDateBoxes();" clientidmode="Static" class="textbox NumberClass" maxlength="6" autocomplete="off" placeholder="Pincode" type="text" /> <br />
        
        <input type="button" class="proceed" value="PROCEED" onclick="return CheckArea();" />

        <div style="clear:both" ></div>
        </div>
      </div>

      <div id="divSetDate"  class="ProcessBox CUSTBOX" style="display:none;height:auto;margin-top:0px;border-top:0px;">
        <div style="clear:both" ></div>
        <article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >02</span>SELECT START DATE</h1>        
        </article>
         <div class="ProcesBoxInner" >
         <span>We have 3 types of plans</span><br />
        <input type="radio" id="rd1" class="mealplan" planid="1" checked="checked" daysPlan="10" deliveryChrg="300" validaty="15" name="plan" /><label for="rd1"></label> <span style="margin-left:0px" >10 Days Meal Plan (to be consumed in 15 working days)</span> <br />
        <input type="radio" id="rd2" class="mealplan" planid="2" daysPlan="22" validaty="35" deliveryChrg="660" name="plan" /><label for="rd2"></label><span style="margin-left:6px">22 Days Meal Plan (to be consumed in 35 working days)</span><br />
        <input type="radio" id="rd3" class="mealplan" planid="3" daysPlan="44" validaty="75" deliveryChrg="1320" name="plan" /><label for="rd3"></label><span style="margin-left:6px">44 Days Meal Plan (to be consumed in 75 working days)</span><br />

        <div style="width:90%; text-align:left;margin-left:0px; margin-top:10px; float:left; ">
        
   <%--     <script type="text/javascript">
                        var today = new Date();            
                        $('#disable-dates').multiDatesPicker({                
                            addDisabledDates: [today.setDate(1), today.setDate(3)], numberOfMonths: 3
                        });
        </script>--%>
         </div>

        <input id="txtPossessionDate" onkeypress="return false;" placeholder="select start date" type="text" autocomplete="off" /> <br />
         <br />
          <div style="clear:both" ></div>
      
         <input type="button" value="PROCEED" class="proceed"  onclick="DaysSelection()" />
         <%--<input type="button" value="BACK" class="proceedBack" onclick="$('#divSetDate').hide();$('.ChkDelieveryArea,#ContentPlaceHolder1_divItem').show();" />--%>
         <div style="clear:both" ></div>      
        </div>
         <div style="clear:both" ></div>
    </div>

      <div id="divSetDate2"  class="ProcessBox CUSTBOX" style="display:none;height:auto;margin-top:0px;border-top:0px;">
        <div style="clear:both" ></div>
        <article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >03</span>CHOOSE YOUR DATES</h1>        
        </article>
           <div class="ProcesBoxInner" >
           <%--<span style="padding:0 0 10px 25px" ><em style="color:#F26724">*</em>&nbsp;Select <span class="sds" ></span> Meal Delivery Dates (to be consumed in <span class="sdsCon" ></span> working days)</span>--%>
           <span style="padding:0 0 10px 25px" ><em style="color:#F26724; display:none">*</em><span class="sds" ></span> Meals to be consumed within <span class="sdsCon" ></span> working days.</span> <br /> 
           <span style="padding:0 0 0 25px" >If you wish to change the meal delivery dates, click on any pre-selected date in the calendar to choose new date(s). </span>
        <div style="width:90%; text-align:left;margin-left:0px; margin-top:10px; float:left; ">
          
        <div id="disable-dates" class="box" style="float:left;margin-left:0px;"></div>        
        
         </div>
         
                 
         <br />
          <div style="clear:both" ></div>
         <br />
         <span style="padding:10px 0 0 20px; font-style:italic" ><em style="color:#F26724">*</em>&nbsp;Working days exclude Sundays and public holidays.</span>
         <input type="button" value="PROCEED"  class="proceed" onclick="SetDays();" />            
         <%--<input type="button" value="BACK" class="proceedBack" onclick="$('#divSetDate').show(); $('#divSetDate2').hide();" />--%>
         <div style="clear:both" ></div>
         
        </div>
    </div>
</div>
<script  type="text/javascript">
    var loggiedIn = "<%=loggiedIn%>"; // value 1 if user session
    var minDateAdmin = "<%=minDateAdmin%>"; 
    var chkCashPickUp = "<%=chkCashPickUp%>"; //
    var chkCashPickUpPers = "<%=chkCashPickUpPers%>"; //in percent
    var countRows = 15;
    var maxSelection = 0;
    var DaysInPlan = 0;
    var ValidUpTo = 0;
    var disabledSpecificDays = "<%=disabledSpecificDays%>";
    var dayOfWeek = "<%=dayOfWeek%>";
    var days = [
    'Sunday', //Sunday starts at 0
    'Monday',
    'Tuesday',
    'Wednesday',
    'Thursday',
    'Friday',
    'Saturday'
];

   var dayOfWeek = "<%=dayOfWeek%>";
   var DeliveryChrg = 0;
   var TrnChrg = "<%=TrnChrg%>"; //in percent
   var selectedItem = "<%=selectedItem%>";

   var orderlst = <%= this.javaSerial.Serialize(orderlst) %>;
   var scPostion = "<%=scPostion %>"; 

   $(window).load(function () {
    //$(document).on("pageload", function () 
    
    
        if(scPostion!="")
        {
         $('html,body').animate({
                        scrollTop: $('.page-titleMain').offset().top
                    }, 0);        

        }
        else
        {

           $('html,body').animate({
               scrollTop: $('#selectedItem' + selectedItem).offset().top
           }, 0);
       }
//ScrollPage();
       Page = 'YourOrder';
              
   });


//   $(document).on("pageload", function () {
//       $('html,body').animate({
//           scrollTop: $('#selectedItem' + selectedItem).offset().top
//       }, 0);
//   });


function AftercheckValid()
   {
    swal("Welcome, Kitchen On My Plate meal delivery service is available in your area. Please select your meal start date.");
    $('#ContentPlaceHolder1_divItem,.pt').show();$('#divSetDate').show(); $('#divSetDate2').hide();        ScrollPage();        
}

    function SetDays() {

        //ValidateOrderTiffin

//        if ($('#txtPossessionDate').val() == "") {
//            alert('Please select starting date!');
//            $('#txtPossessionDate').focus();
//            return false;
        //        }

        if (!ValidateOrderTiffin()) {
            return false;
        }

//        if ($('.mealplan:checked').length == 0) {
//            alert('Please select meal plan!');
//            return false;
//        }

//        var pdate = "";
//        if ($("#txtPossessionDate").val() != '') {
//            var dateParts = $("#txtPossessionDate").val().split('/');
//            pdate = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];            
//        }

        //var today = pdate;
        var htmlDays = '';



         countRows = parseInt($('.mealplan:checked').attr("validaty"));
         maxSelection = parseInt($('.mealplan:checked').attr("daysPlan"));

         if (countRows > 0) {
             $('#tableDays tbody tr').remove();
             //$('#divPlans').hide();
            $('#divDays').show();
            $('#tableDays tbody').append("<tr class='divRow'><td width='10%'><b>NO.</b></td><td><b>DAY</b></td><td><b>DATE</b></td><td><b>MEAL NAME</b></td></tr>");
            
            //ScrollPage();
           
           }

        var dates = $('#disable-dates').multiDatesPicker('getDates');
        var dates_in_string = '';
        //order.OrderStartDate = dates[0];

        var i = 0;
        for (d in dates) {
            i++;

            
            var pdate = days[new Date(dates[d]).getDay()];
                    var dateParts = dates[d].split('/');
                    dateParts = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
                    $('#tableDays tbody').append("<tr class='divRow'><td>" + i + ".</td><td>" + pdate + "</td><td>" + dateParts + "</td><td><select id = 'slmain" + i.toString() + "' name='slmainMenu' dow='" + new Date(dates[d]).getDay() + "' submenu='slsubMenu" + i.toString() + "' class='slmainMenu'><option value='0'>select</option></select></td></tr>");
                                        
                    //$('#tableDays tbody').append("<tr class='divRow'><td>" + i + ".</td><td>" + pdate + "</td><td><select name='slmainMenu' submenu='slsubMenu" + i.toString() + "' class='slmainMenu'><option value='0'>select</option></select></td><td><select id='slsubMenu" + i.toString() + "' name='slmainMenu' class='slsubMenu'><option value='0'>select</option></select></td><td>" + dateParts + "</td></tr>");
        }

        SetCalender();
        SetProductData();
//        $(".slmainMenu").change(function () {

//            var subMenuComboId = $(this).attr("submenu");
//            SetSubProductData($(this).val(), subMenuComboId);
//            $("#" + subMenuComboId).focus();
//        });
        //SetSubProductData();

        loggiedIn = "<%=loggiedIn%>"; // value 1 if user session
        

               // $('#divDays').hide();
            $('#divPlans').hide();
           // $('#divQuantity').show();
$('.FistArt').hide();
$('#ContentPlaceHolder1_divItem,#divChkDelieveryArea,#divCart,#divPaymentMethod').hide();



 $('html,body').animate({
                scrollTop: $('#divDays').offset().top
            }, 1000);        
//            

     
    }

    function SetDaysBack() {
        $('#ContentPlaceHolder1_divItem,#divPlans,#divChkDelieveryArea').show();
        $('#divSetDate2').show();
        $('#divDays').hide();        
        $('.FistArt').show();
        $('#tableDays tbody').html("");




        ScrollPage();
    }


    var showcount = 0;
    function ShowPlans() {

        $('#divSetDate2,.DivWithButtonOnly').hide();
        
        
        
        if (showcount==0) 
        {
            $('#divPlans,.ChkDelieveryArea').show();
//            $('html,body').animate({
//                scrollTop: $('#divPlans').offset().top-$('#footer').height()-35
//            }, 1000);
ScrollPage();
        }
        else {
            $('#divPlans').show(); 
            $('#divChkDelieveryArea input').click();
//            $('#ContentPlaceHolder1_divItem,.pt').show(); $('#divSetDate').show(); $('html,body').animate({
//                scrollTop: $('#divSetDate').offset().top
//            }, 1000);        
        }

        showcount = 1;

        if (orderlst.length == 0) {
         $("#txtPinCode").val('');
        }
    }




    function DaysSelection() {
            if ($('#txtPossessionDate').val() == "") {
                    swal('Please Select The Start Date!');
                    $('#txtPossessionDate').focus();
                    return false;
                }

                
        ValidUpTo = parseInt($('.mealplan:checked').attr("validaty"));
        daysInPlan = parseInt($('.mealplan:checked').attr("daysPlan"));
        DaysInPlan = daysInPlan;
        DeliveryChrg = parseFloat($('.mealplan:checked').attr("deliveryChrg"));

       // ValidUpTo = parseInt(ValidUpTo) + 4;
        $(".sds").html(daysInPlan);
        $(".sdsCon").html(ValidUpTo);
        

        var pdate = "";
        if ($("#txtPossessionDate").val() != '') {
         var dateParts = $("#txtPossessionDate").val().split('/');
         pdate = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
        }

     
     var ShowCalender = 3;
     if (ValidUpTo < 29) {
         ShowCalender = 2; 
     }


     //var MaxDt = parseInt (((new Date(pdate)) - (new Date()))/(1000*60*60*24)) + ValidUpTo-2;
     var MaxDt = parseInt(((new Date(pdate)) - (new Date())) / (1000 * 60 * 60 * 24)) + ValidUpTo;

      var addExtra = 0;//(new Date(pdate)).getDay()==5?1:1;

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
               
                       //Mahesh old start
//                 $('#disable-dates').multiDatesPicker('resetDates','picked');           
//                 $('#disable-dates').multiDatesPicker('resetKOMP');
//     $('#disable-dates').multiDatesPicker('destroy');
//        $('#disable-dates').multiDatesPicker({
//            beforeShowDay: disableSpecificDaysAndWeekends, numberOfMonths: ShowCalender, minDate: pdate, maxDate: MaxDt, maxPicks: daysInPlan, adjustRangeToDisabled: true,
//              onSelect: function(dateText, inst) { }
//        });

//        $('#disable-dates').multiDatesPicker('destroy');
//        $('#disable-dates').multiDatesPicker({
//            beforeShowDay: disableSpecificDaysAndWeekends, numberOfMonths: ShowCalender, minDate: pdate, maxDate: MaxDt, maxPicks: daysInPlan, adjustRangeToDisabled: true,
//              onSelect: function(dateText, inst) { }
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


        //$('td').removeClass('ui-state-highlight');
        
       // $('#ContentPlaceHolder1_divItem,#divChkDelieveryArea').hide();
        //$('.ChkDelieveryArea,#ContentPlaceHolder1_divItem').show();
        $('#divPlans').show();
        //$('#divSetDate').hide();
        $('#divSetDate2').show();
        ScrollPage();
//        $('html,body').animate({
//          scrollTop: $('#footer').offset().top - 2*$('#footer').height() + 170 //scrollTop: $('#divSetDate2').offset().top - $('#footer').height()*53/100 
//        }, 1000);
    }

    function ShowQuantity() {//Back button on login
        $("#ifUserNotLoggedIn").hide();
        $('#divQuantity').show();
        $('.FistArt').hide();
    }


    function SetPriceQuantity() {
            
        if (!ValidateOrder()) {
            return false;
        }

         
        order = new Order();
        payment = new Payment();
        orderDTO = new OrderDTO();
        orderDetailList = new Array();

        var today = new Date();
        var htmlDays = '';
        var countRows = 4;
        var DeliveryChrgTotal = 0;

        $('#tableQuantity tbody tr').remove();
        if (countRows > 0) {
            $('#divDays').hide();
            $('#divPlans').hide();
            $('#divQuantity').show();
            $('.FistArt').hide();

            // $('#tableQuantity tbody').append("<tr align='left' class='sectiontableheader'><th>Name</th><th>SKU</th><th>Price</th><th>Quantity</th><th>Subtotal</th></tr>");
            $('#tableQuantity tbody').append("<tr class='divRow dataHeader DR" + orderlst.length + 1 + "' style='background:#fff;height:12px' ></tr>");
            $('#tableQuantity tbody').append("<tr class='divRow dataHeader DR" + orderlst.length + 1 + "' style='background:#F16822;color:#fff;font-family:RobotoBold;font-size:1.2em;' ><td colspan='5' >ORDER - " + (orderlst.length + 1) + "</td></tr>");
            $('#tableQuantity tbody').append("<tr class='divRow dataHeader DR" + orderlst.length + 1 + "'><td align='center'><b>DATE</b></td><td align='center'><b>DAY</b></td><td><b>MEAL NAME</b></td><td align='center'><b>QUANTITY</b></td><td align='center'><b>PRICE</b></td></tr>");
        }

         

        var SubTotal = 0;

        //Create Object Order and OrderDetails
             
        
        order.Id = 0;
        order.CustomerId = loggiedIn;
               
//        var pdate = "";
//        if ($("#txtPossessionDate").val() != '') {
//            var dateParts = $("#txtPossessionDate").val().split('/');
//            pdate = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
//        }

        order.PlanId = 1;//  $('.mealplan:checked').attr("planid");        
        order.OrderDate = new Date();
        //order.OrderStartDate = pdate;
        order.RequestId = 0;
        order.PaymentDone = 0;
        order.NonCustomized = 0; //Customized
        order.IsLunch = 1;
        order.IsActive = 0;
        order.pincode=pincode;
        order.YourguyOrderId=0;
         
        var dates = $('#disable-dates').multiDatesPicker('getDates');
        var dates_in_string = '';
        order.OrderStartDate = dates[0];

        var index = 0;
        for (d in dates) {
            index++;
           // if ($("#slsubMenu" + index).val() != "0") {
            var price = GetItenPrice($("#slmain" + index).val())
                SubTotal = SubTotal + parseFloat(price);

                   var pdate = days[new Date(dates[d]).getDay()];
                    var dateParts = dates[d].split('/');
                    dateParts = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];

                //$('#tableQuantity tbody').append("<tr valign='top'>	<td><strong>" + $("#slsubMenu" + index + " option:selected").text() + "<br/>" + $(this).children("td:eq(1)").text() + "</strong></td>	<td>" + $("#slsubMenu" + index).val() + "</td>	<td align='right'>Rs " + price + "</td>	<td> <input type='text' value='1' /> </td>  <td align='right'>Rs" + price + "</td>  </tr>");
                    $('#tableQuantity tbody').append("<tr class='divRow divRowData DR" + orderlst.length + 1 + "'><td align='center'>" + dateParts + "</td><td align='center'>" + pdate + "</td><td class='RobotoBold'>" + $("#slmain" + index + " option:selected").text() + "</td><td align='center'>1</td><td align='right'><span style='padding-right:45px;' ><i class='fa fa-inr'></i>" + price + "</span></td></tr>");

                var orderDetails = new OrderDetails();
                orderDetails.Id = 0;
                orderDetails.OrderId = 0;
                orderDetails.SubProductId = parseInt($("#slmain" + index).val());
                orderDetails.Quantity = 1;                
                orderDetails.DeliverDate = dates[d];
                orderDetails.IsActive = 0;
                orderDetails.YourguyOrderId=0;
                orderDetailList.push(orderDetails); //Add to list
          //  }
        }

         
            
Payment = SubTotal;
      
       
        payment.Id = 0;
        payment.OrderId = 0;
        payment.TransactionNo = "";
        payment.Amount = SubTotal;
        payment.Mode = 1;
       
        payment.PaymentDate = new Date();
       
        payment.NameOnCard = "";
        payment.CardNumber = "";
        payment.TrnChrg = 0;// parseInt(TrnChrg * SubTotal / 100);

        payment.DeliveryChrg = DeliveryChrg;
        payment.IsActive = 0;
       
       //DeliveryChrgTotal = parseInt(DeliveryChrgTotal) + parseInt(DeliveryChrg);

        //Set Total payment with delivery charges
        order.TotalPayment = parseFloat(SubTotal) + parseFloat(DeliveryChrg);
       
        //Assign it to main DTO
        orderDTO.Order = order;
        orderDTO.payment = payment;
        orderDTO.OrderDetailList = orderDetailList;
        orderlst.push(orderDTO);
        //orderlst.slice();
        orderList.orders = orderlst;
        
       for(var i=0; i<orderList.orders.length;i++)
       {        
        DeliveryChrgTotal = parseInt(DeliveryChrgTotal) + parseInt(orderList.orders[i].payment.DeliveryChrg);        
       }


        SubItemTotals = parseFloat(SubItemTotals) + parseFloat(SubTotal) + parseFloat(DeliveryChrg);

        //$('#tableQuantity tbody').append("<tr class='divRow' align='right'><td colspan='5'><b>Sub Total &nbsp;&nbsp; </b> </td><td align='center'><b>" + SubTotal + "</b></td></tr>");
        //$('#tableQuantity tbody').append("<tr class='divRow' align='right'><td colspan='5'><b>Tax Amount&nbsp;&nbsp; </b> </th><td align='center'><b>" + 100 + "</b></td></tr>");
        //$('#tableQuantity tbody').append("<tr class='divRow' align='right'><td colspan='5'><b>Delivery Charges&nbsp;&nbsp;</b>  </td><td align='center'><b>" + DeliveryChrg + "</b></td></tr>");
        //$('#tableQuantity tbody').append("<tr class='divRow' align='right'  ><td colspan='5'><span style='font-family:RobotoBlack' >Amount&nbsp;&nbsp;</span>  </td><td align='center' ><span style='font-family:RobotoBlack' >" + parseInt(parseInt(SubTotal) + parseInt(DeliveryChrg)) + "</span></td></tr>");
        $('#tableQuantity tbody').append("<tr class='divRow DR" + orderlst.length + 1 + "' align='right' style='font-size:24px' ><td colspan='4'><span style='font-family:RobotoBlack' >Amount&nbsp;&nbsp;</span>  </td><td align='right' ><span style='font-family:RobotoBlack;padding-right:45px;' ><i class='fa fa-inr'></i>" + SubTotal + "</span></td></tr>");

        
        
        $('.priceTotal').html("<i class='fa fa-inr'></i>"+SubItemTotals);

        
        //$('#spCharge,#spnShip').html("<i class='fa fa-inr'></i>"+DeliveryChrg * orderlst.length);
        $('#divCart #spCharge,#divCart #spnShip').html("<i class='fa fa-inr'></i>"+DeliveryChrgTotal);

        
            var shipchrg = parseFloat(DeliveryChrgTotal);
            if (shipchrg.toFixed) {
                shipchrg = shipchrg.toFixed(2);
            }
            $('#divFinal #spCharge, #divFinal #spnShip').html("<i class='fa fa-inr'></i>"+shipchrg);
        //$('#divFinal #spCharge, #divFinal #spnShip').html("<i class='fa fa-inr'>"+DeliveryChrg * orderlst.length);

        $('#ContentPlaceHolder1_divItem,#divChkDelieveryArea,#divCart,#divPaymentMethod').hide();

        //Disable zipcode as order is added
$("#txtPinCode").attr("readonly","readonly");

        //ScrollPage();
        $('html,body').animate({
            scrollTop: $('#divQuantity').offset().top
        }, 1000);

        
        CreateOrdersSession();
        OnProductPage = true;
        //SaveOrder(orderDTO);
    }



    function dayOfWeek(s) {
        var d = Globalize.parseDate(s, 'yyyy/M/d');
        if (d == null) {
            return null;
        } else {
            return Globalize.format(d, 'dddd');
        }
    }


    
</script>
    <script src="Scripts/jsOrder.js?v=100820181010" type="text/javascript"></script>
    <!--container start here-->
   
<div  id="divDays"  class="ProcessBox CUSTBOX" style="display:none;height:auto;margin-top:0px;border-top:0px;">
 <div style="clear:both" ></div>
        <article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >04</span>SELECT YOUR MEALS</h1>        
        </article>
           <div class="ProcesBoxInner" >

   <div style="width:100%">

                    <table id="tableDays" class="tbl" cellspacing="1" width="100%" align="center" cellpadding="2" >
				    <tbody>															                    
				</tbody></table>

                <input type="button" value="PROCEED" class="proceed"  onclick="SetPriceQuantity();" />
                <input type="button" value="Back" class="proceedBack" onclick="SetDaysBack();" />
</div>
</div>
<div style="clear:both" ></div>
</div>

<!--Shikha work Start -->
<div id="divQuantity" class="ProcessBox CUSTBOX" style="display:none;height:auto;margin-top:15px;">
<article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >05</span>CART</h1>        
        </article>
        <div class ="ProcesBoxInner">
        <div style="width:100%;" >
                    <table id="tableQuantity" class="tbl" cellspacing="1" width="100%" align="center" cellpadding="5" >
				    <tbody>															                    
				</tbody></table>
                
                <input type="button" value="CONTINUE SHOPPING" class="proceedBack" style="float:left" onclick="ShowItems();" />

                <input type="button" class="proceed" value="ADD TO CART" onclick="SetCartTotal();" />
                <input type="button" value="BACK" class="proceedBack" style="float:right" onclick="$('#divSetDate2').hide();$('#divQuantity').hide(); $('#divPlans').hide();$('#divDays').show(); $('.FistArt').hide();$('#ContentPlaceHolder1_divItem').hide(); orderlst.pop(); orderList.orders = orderlst;EnableDisablePin(); $('html,body').animate({scrollTop: $('#divDays').offset().top}, 1000);      " />
</div>
        </div>
   <div style="clear:both" ></div>
</div>
<!--Shikha work end -->

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




 
 </div></div>
</asp:Content>
