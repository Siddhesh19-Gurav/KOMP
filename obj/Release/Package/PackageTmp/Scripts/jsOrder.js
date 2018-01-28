

//Set Property Type
var pincode = 0; //Variable during area verification
var Products = null;
var SubProducts = null;
var IsClickable = true; //only for service page
var selectedTab = '1'; //only for service page
//End To set PropertyType

var multiDateReset = true;


var order = new Order();
var payment = new Payment();

var orderDetailList = new Array();
var orderDTO = new OrderDTO();
var orderList = new OrderList();
var Page = '';
var SubItemTotals = 0; //it is forl all sub order of all orders

var HolidayBetweenRange = 0;

function GetProducts() {
    $.ajax({
        type: "POST",
        url: "KompServices.asmx/GetProducts",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        dataType: "json",
        success: function (result) {
            Products = result.d;
        },
        error: AjaxFailed
    });
}

function GetSubProducts() {
    $.ajax({
        type: "POST",
        url: "KompServices.asmx/GetSubProducts",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        dataType: "json",
        success: function (result) {
            SubProducts = result.d;
        },
        error: AjaxFailed
    });
}


function AjaxFailed(result) {
    swal("err1" + result.status + ' ' + result.statusText);
} 


//function SetProductData() {
//    
//    for (var k = 0; k < Products.length; k++) {
//            $(".slmainMenu").append("<option value='" + Products[k].Id + "'>" + Products[k].Header + "</option>");
//    }

//    }


function SetProductData() {

    $(".slmainMenu").each(function (index) {

    
        var dow = $(this).attr('dow');

        var OptionID = 0;
        for (var i = 0; i < SubProducts.length; i++) {

            if (SubProducts[i].Varity == '' && (SubProducts[i].NonCustomized == 0 || SubProducts[i].NonCustomized == 2) && SubProducts[i].AvailableDay.indexOf(dow) > -1)//set for customized
            {

                if (OptionID == 0 || OptionID != SubProducts[i].MenuId) {

                    var ProductName = '';

                    for (var k = 0; k < Products.length; k++) {
                        if (SubProducts[i].MenuId == Products[k].Id) {
                            ProductName = Products[k].Header;
                        }
                    }

                    $("<optgroup label='" + ProductName + "' ></optgroup>").appendTo(this);
                }

                $("<option  value='" + SubProducts[i].Id + "'>" + SubProducts[i].Header + "</option>").appendTo(this);
                OptionID = SubProducts[i].MenuId;
            }
        }

    });
          }

function SetSubProductData(mainMenuId, subMenuComboId) {

    $("#" + subMenuComboId).html('');
    $("#" + subMenuComboId).append("<option value='0'>-Select-</option>");
        for (var k = 0; k < SubProducts.length; k++) {
            if (mainMenuId == SubProducts[k].MenuId) {
            $("#" + subMenuComboId).append("<option value='" + SubProducts[k].Id + "'>" + SubProducts[k].Header + "</option>");
            }
        }
}

function GetSubProductDetails(subMenuComboId) {
    var subProduct = '';
    for (var k = 0; k < SubProducts.length; k++) {
        if (subMenuComboId == SubProducts[k].Id) {
            var veg = SubProducts[k].Veg = "1" ? "(VEG)" : (SubProducts[k].Veg = "2" ? "(NON-VEG)" : "V-NV");
            subProduct = "<span class='price'>" + SubProducts[k].Header + "</span>" + "<span class='pricedt' >" + SubProducts[k].Detail + "</span>";
        }
    }
    return subProduct;
}

function GetSubProductName(subMenuComboId) {
    var subProduct = '';
    for (var k = 0; k < SubProducts.length; k++) {
        if (subMenuComboId == SubProducts[k].Id) {
            //var veg = SubProducts[k].Veg = "1" ? "(VEG)" : (SubProducts[k].Veg = "2" ? "(NON-VEG)" : "V-NV");
            return SubProducts[k].Header;
        }
    }
    return subProduct;
}

//**********Validate Means Plan***********************

//Customnized
function ValidateOrder() {
    var SelectedAllSubMenu = true;
    $(".slmainMenu option:selected[value!='0']").each(function (index) {
        if ($("#" + $(this).parent().attr('submenu')).val() == "0") {
            swal('Please select menu items');
            $("#" + $(this).parent().attr('submenu')).focus();
            SelectedAllSubMenu = false;
        }
    });

    if (SelectedAllSubMenu) {
        if ($(".slmainMenu option:selected[value!='0']").length != maxSelection) {
            //swal("Here's a message!")
            swal('Please choose ' + maxSelection + ' meals as per your selected meal plan');
            return false;
        }
        else {
            return true;
        }
    }
}

function ValidateOrderTiffin() 
{
    //alert($('#disable-dates').multiDatesPicker('getDates').length);
    if ($('#disable-dates').multiDatesPicker('getDates').length != DaysInPlan) 
    {
        //swal('Please select ' + DaysInPlan + ' days as per selected plan');
        swal('Please choose ' + DaysInPlan + ' meals as per your selected meal plan');
        
        return false;
    }
    else 
    {
        return true;
    }

//        if ($(".checkDate:checked").length != maxSelection) 
//        {
//            swal('Please select ' + maxSelection + ' days only as per selected plan');
//            return false;
//        }
//        else 
//        {
//            return true;
//        }
}


function countHoliday(start, end) {
    //alert(disabledSpecificDays + "pp" + start +"ll"+ end);
    if (end < start) return; //avoid infinite loop;
    //for (var count = { sun: 0, sat: 0 }; start < end; start.setDate(start.getDate() + 1)) {
    for (var count = { sun: 0 }; start < end; start.setDate(start.getDate() + 1)) {
        if (start.getDay() == 0) count.sun++;
        //else if (start.getDay() == 7) count.sat++;
        
        //for (var i = 0; i < disabledSpecificDays.length; i++) {

            //if ($.inArray((m + 1) + '-' + d + '-' + y, disabledSpecificDays) != -1 || new Date() > date) {

        //}
        var yr1 = start.getYear() + 1900;
        //alert("start:"+start + "end "+ end+" disable "+disabledSpecificDays + " pp " + start.getMonth()+1 + "-" + start.getDate() + "-" + yr1 + " cnt" + HolidayBetweenRange);
        if (disabledSpecificDays.indexOf(start.getMonth()+1 + "-" + start.getDate() + "-" + yr1) != -1) 
        {
            HolidayBetweenRange = HolidayBetweenRange + 1;
        }
    }

    return count;
}

function countSatSun(start, end) {
    //alert(disabledSpecificDays + "pp" + start +"ll"+ end);
    if (end < start) return; //avoid infinite loop;
    //for (var count = { sun: 0, sat: 0 }; start < end; start.setDate(start.getDate() + 1)) {
    for (var count = { sun: 0 }; start < end; start.setDate(start.getDate() + 1)) {
        if (start.getDay() == 0) count.sun++;
        //else if (start.getDay() == 7) count.sat++;
        
        //for (var i = 0; i < disabledSpecificDays.length; i++) {

            //if ($.inArray((m + 1) + '-' + d + '-' + y, disabledSpecificDays) != -1 || new Date() > date) {

        //}
        var yr1 = start.getYear() + 1900;
        //alert("start:"+start + "end "+ end+" disable "+disabledSpecificDays + " pp " + start.getMonth()+1 + "-" + start.getDate() + "-" + yr1 + " cnt" + HolidayBetweenRange);
        if (disabledSpecificDays.indexOf(start.getMonth()+1 + "-" + start.getDate() + "-" + yr1) != -1) 
        {
            HolidayBetweenRange = HolidayBetweenRange + 1;
        }
    }


//    for (var count = { sun: 0 }; start < end; start.setDate(start.getDate() + 1)) {
//        if (start.getDay() == 0) count.sun++;
//        //else if (start.getDay() == 7) count.sat++;

//        //for (var i = 0; i < disabledSpecificDays.length; i++) {

//        //if ($.inArray((m + 1) + '-' + d + '-' + y, disabledSpecificDays) != -1 || new Date() > date) {

//        //}
//        var yr1 = start.getYear() + 1900;
//        alert(disabledSpecificDays + " pp " + start.getMonth() + "-" + start.getDate() + "-" + yr1 + " cnt" + HolidayBetweenRange);
//        if (disabledSpecificDays.indexOf(start.getMonth() + "-" + start.getDate() + "-" + yr1) != -1) {
//            HolidayBetweenRange = HolidayBetweenRange + 1;
//        }
//    }
    
    return count;
}

/** Datepicker start */
/** Days to be disabled as an array */
//var disabledSpecificDays = ["3-20-2015", "9-24-2015", "9-25-2015", "10-01-2015"];
//var disabledSpecificDays = ["3-20-2015"];

function disableSpecificDaysAndWeekends(date) {
    var m = date.getMonth();
    var d = date.getDate();
    var y = date.getFullYear();
    
    for (var i = 0; i < disabledSpecificDays.length; i++) {
        
        //if ($.inArray((m + 1) + '-' + d + '-' + y, disabledSpecificDays) != -1 || new Date() > date) {
        if (disabledSpecificDays.indexOf((m + 1) + '-' + d + '-' + y) != -1 || new Date() > date) {
           // HolidayBetweenRange = HolidayBetweenRange + 1;
            return [false];
        }
    }
    var noWeekend = $.datepicker.noWeekends(date);
    return !noWeekend[0] ? noWeekend : [true];
   }

   $(document).ready(function () {

//       $(window).scroll(function () {
//           alert($(document).scrollBottom());
//           if ($(document).scrollTop() > 100)
//               $('#footer').fadeIn();
//           else
//               $('#footer').fadeOut();
//       });

       SetCalender();

       $('.mealplan').click(function () {
           ResetSingleCalender();
           //alter($('.mealplan:checked').attr("planid"));
           //SetCalender();
       });

     


   });

   function ResetSingleCalender() {
       countRows = parseInt($('.mealplan:checked').attr("validaty"));
       var maxDate = new Date(); //getDateYymmdd($(this).data("val-rangedate-max"));
       maxDate.setDate(maxDate.getDate() + 33);
       $("#txtPossessionDate").datepicker("option", "maxDate", maxDate);
       $("#divSetDate2,#divDays").hide();
       
   }

   $("#txtPossessionDate").click(function () {
       $("#divSetDate2,#divDays").hide();
       multiDateReset = false;
   });

   function SetCalender() {

       

       var maxDate = new Date(); //getDateYymmdd($(this).data("val-rangedate-max"));
       maxDate.setDate(maxDate.getDate() + 33 - minDateAdmin);
       $("#txtPossessionDate").datepicker({
           beforeShowDay: disableSpecificDaysAndWeekends,
           //dateFormat: "dd-mm-yy",
           minDate: 4 - minDateAdmin,
           maxDate: maxDate,
           changeMonth: false,
           changeYear: false,
           numberOfMonths: 2,
           dateFormat: "dd/mm/yy"
       });

//       $("#txtPossessionDate").change(function () {
//           var dateParts = $("#txtPossessionDate").val().split('/');
//           $("#txtPossessionDate").val(dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2]);
//       });

       //Multi date picker
//       $('#disable-dates').multiDatesPicker({        
//           addDisabledDates: [today.setDate(1), today.setDate(3)], numberOfMonths: 3
//       });

   }
   /** Datepicker end */


   /** Get Item price start */
   function GetItenPrice(subProductId) {
      
       for (var k = 0; k < SubProducts.length; k++) {
           if (SubProducts[k].Id == subProductId) {
               return SubProducts[k].Price;
           }
       }

       return 0;
   }
   /** Get Item price end */

   $(document).ready(function () {
       GetProducts();
       GetSubProducts();


       
   });


   /*****Classes********************/

    function OrderList()
    {
        var orders;
    }

   function Order() {
       var Id;
       var CustomerId;
       var PlanId;
       var RequestId;
       var OrderDate;
       var OrderStartDate;
       var PaymentDone;
       var TotalPayment;
       var IsLunch;
       var NonCustomized;
       var IsActive;
       var pincode;
       var YourguyOrderId;
   }

   function OrderDetails() {
       var Id;
       var OrderId;
       var SubProductId;
       var Quantity;
       var DeliverDate;
       var IsActive;
       var YourguyOrderId;
   }

   function Payment() {
       var Id;
       var OrderId;
       var TransactionNo;
       var Amount;
       var Mode;
       var PaymentDate;
       var NameOnCard;
       var CardNumber;
       var TrnChrg;
       var DeliveryChrg;
       var IsActive;
   }

   function OrderDTO() {
    var Order;
    var OrderDetailList;
    var payment;
   }
   //-----Common functions start


   function ShowDays() { //Back button on Quantity
       $('#tableQuantity tbody').html('');
       $('#divDays').show();
       $('#divQuantity').hide();
   }

   function ShowItems() { //On continue shoping

       $('.ChkDelieveryArea,#ContentPlaceHolder1_divItem').show();
      // $('#divPlans,.ChkDelieveryArea,#divSetDate,#divPaymentMethod,#divFinal,.DivWithButtonOnly').show();
       $('.FistArt').show();

       $('#divCart,#divPaymentMethod,#divQuantity').hide();
       if (orderlst.length == 0) {
           $('#divCart').hide();
       }
       if (Page == 'YourOrder') {
//           $('html,body').animate({
//           //scrollTop: $('#ContentPlaceHolder1_divItem').offset().top - $('#footer').height() - 35               
//               scrollTop: $('.CustHeader').offset().top
           //           }, 1000);
           $('#divPlans,#divSetDate').show();
           $('#divSetDate2,#divPaymentMethod,#divFinal,.DivWithButtonOnly').hide();
           ScrollPage(0);
       }
       else {
           $('html,body').animate({               
               scrollTop: $('.subVeg').offset().top
                      }, 1000);
           IsClickable = true;
           $("input.btnRed").removeClass('btnRedClick');
           $("div[mealtype='" + selectedTab + "'].subItemBox").show();
           $(".FistArt").show();
           $('#divPlans,#divSetDate,#btnWeekly').show();
           $('#divSetDate').hide();
           $('.ChkDelieveryArea,#divSetDate2,#divPaymentMethod,#divFinal,.DivWithButtonOnly').hide();
           $("#btnWeekly").show();
           $("#Note3382").show();
           $('.mealP').show();
           $(".subVeg,div[mealtype='" + selectedTab + "'].subItemBox").show();
           $("#divEditable").hide();
           
           ScrollPage();
       }

       


       $('#txtPossessionDate').val('');

       //$('#divSetDate2').show();
     
       //$('#ContentPlaceHolder1_divItem').hide();
       //$('#divPlans').show();
   }

   //From home top cart calling this function if it is on product page elase calling DeleteOrderHome
   function DeleteOrder(indx) 
   {

//       var DoDelete = true;
//       var rowID = orderList.orders[indx].Order.Id;
//       if (orderList.orders.length == 1) {
//           DoDelete = confirm('At least one order need to be placed, Do you want to delete it?');
//       }

//       if (DoDelete) {

//           if (confirm('Are you confirmed want to delete selected item?')) {               
//               $('#Ord' + indx).remove();
//               orderlst.splice(indx,1);
//               orderList.orders = orderlst;
//           }
//       }


       var msgConfirm = (orderList.orders.length == 1) ? "Are you sure, you want to delete this Order from the Cart?" : "Are you sure, you want to delete this Order from the Cart?";
       //var msgConfirm = (orderList.orders.length == 1) ? "At least one order need to be placed, Do you want to delete it?" : "Are you sure, you want to delete this order?";

       swal({ title: msgConfirm, text: "", type: "warning", showCancelButton: true, confirmButtonColor: "#4b220c", confirmButtonText: "YES", cancelButtonText: "NO", closeOnConfirm: false, closeOnCancel: false },
    function (isConfirm) {
        if (isConfirm) {
            swal("", "Your order has been deleted.", "success");
            $('.Ord' + indx).remove();


            //Delte set sub del start

            // debugger;


            var sub = parseFloat($('.GRTOTAL').html().replace("<i class='fa fa-inr'></i>", "")) - parseFloat(orderList.orders[indx].payment.Amount) - parseFloat(orderList.orders[indx].payment.DeliveryChrg);

            var chrge1 = $('#divCart tfoot #spCharge').html().split('</i>')[1];
            var chrge2 = $('#divFinal tfoot #spnShip').html().split('</i>')[1];

            var charge3 = (parseFloat(chrge2) - parseFloat(orderList.orders[indx].payment.DeliveryChrg));
            if (charge3.toFixed) {
                charge3= charge3.toFixed(2);
            }
            

            $('#divCart tfoot #spCharge').html("<i class='fa fa-inr'></i>" + (parseFloat(chrge1) - parseFloat(orderList.orders[indx].payment.DeliveryChrg)));
            $('#divFinal tfoot #spnShip').html("<i class='fa fa-inr'></i>" + charge3);
            //$('tfoot #spnCharge').html(parseInt($('tfoot #spnCharge').html()) - parseInt(orderList.orders[indx].payment.DeliveryChrg));

            $('.GRTOTAL').html("<i class='fa fa-inr'></i>" + sub);

            //Grand Total for final start
            var FNSM = 0.0;
            $("#divFinal tbody .priceTotal").each(function (index) {
                FNSM = FNSM + parseFloat($(this).html().split('</i>')[1]);
            });

            SubItemTotals = FNSM + parseFloat($('#divFinal tfoot #spnShip').html().split('</i>')[1]);


            var onlchrg = Math.round(parseFloat((SubItemTotals * TrnChrg) / 100));
            if (onlchrg.toFixed) {
                onlchrg = onlchrg.toFixed(2);
            }

            var GSTPercent = 5;

            //alert(onlchrg)
            $(".onChrges").html(onlchrg);

            var gtotal = parseFloat(onlchrg) + parseFloat(SubItemTotals);
            //$('.onlineCls').html('ONLINE PROCESSING CHARGE');        

            var GstCharge = gtotal * (GSTPercent / 100);

            gtotal = parseFloat(GstCharge) + parseFloat(gtotal);

            if (gtotal.toFixed) {
                gtotal = gtotal.toFixed(2);
            }
            
            $('#spnGST').html("<i class='fa fa-inr'></i>" + GstCharge.toFixed(2));
            //$("#Strong1").html('GST('+GSTPercent+'%)');
            $('#divFinal #spnOnlineGrandTotal').html(gtotal);
            //Grand Total for final end

            //Delte set sub del end

            orderlst.splice(indx, 1);
            orderList.orders = orderlst;

            SetCartTotal(0);

            if (orderlst.length == 0) {
                $("#PlacedOrders").hide();

                //enable zipcode as order is added
                $("#txtPinCode").attr("readonly", "");

                $('#tableQuantity tbody tr.DR' + indx + 1).remove();
                ShowItems();
            }

            //alert('13');
            CreateOrdersSession();


        } else {
            swal("", "Your Order is safe !!", "error");
        }
    });


              
       

   }


   function EnableDisablePin() 
   {
       if (orderlst.length == 0) 
       {
           //enable zipcode as order is added
           $("#txtPinCode").attr("readonly", "");
       }
       else 
       {
           $("#txtPinCode").attr("readonly", "readonly");
       }
   }

   

   function SetCartTotal(scroll) {

       
       $(".tableCart tbody tr.cstItem").remove();

       

       //swal(orderList.orders[0].OrderDetailList[0].SubProductId);
       var grandtotal = 0;
       for (var i = 0; i < orderList.orders.length; i++) {
           var ProductSelected = orderList.orders[i].Order.NonCustomized==0?"CUSTOMIZED MEALS": GetSubProductName(orderList.orders[i].OrderDetailList[0].SubProductId);
           var LunchDinner = orderList.orders[i].Order.IsLunch == 1 ? "LUNCH" : "DINNER";
           var dt = new Date(orderList.orders[i].OrderDetailList[0].DeliverDate);
           var dd = dt.getDate();
           var mm = dt.getMonth() + 1; //January is 0!
           var yyyy = dt.getFullYear();
           if (dd < 10) {dd = '0' + dd}
           if (mm < 10) {mm = '0' + mm}
           var dt = dd + '/' + mm + '/' + yyyy;

           //alert(orderList.orders[i].OrderDetailList.length);
           $("#divCart .tableCart tbody").append("<tr class='divRow cstItem Ord" + i + "' align='center'><td  style='width:10%;'><span class='deleteProduct' onclick='DeleteOrder(" + i + "); ScrollPage();' title='Delete Order' >x</span></td><td  style='width:10%;'>" + parseInt(i + 1) + ".</td><td  style='width:60%;'  align='left'> <span>" + ProductSelected + "</span><br/><span class='startDate'>MEAL START DATE : " + dt + "<br/>MEAL TYPE : " + LunchDinner + "</span></td><td><span> " + orderList.orders[i].OrderDetailList.length + "</span></td><td style='width:30%;' align='right'><span id='spCharge' class='priceTotal'><i class='fa fa-inr'></i>" + orderList.orders[i].payment.Amount + "</span></td></tr>");


           var amountFin = orderList.orders[i].payment.Amount;
           if (amountFin.toFixed) {
               amountFin = amountFin.toFixed(2);
           }

           $("#divFinal .tableCart tbody").append("<tr class='divRow cstItem Ord" + i + "' align='center'><td  style='width:10%;'><span class='deleteProduct' onclick='DeleteOrder(" + i + "); ScrollPage();' title='Delete Order' >x</span></td><td  style='width:10%;'>" + parseInt(i + 1) + ".</td><td  style='width:60%;'  align='left'> <span>" + ProductSelected + "</span><br/><span class='startDate'>MEAL START DATE : " + dt + "<br/>MEAL TYPE : " + LunchDinner + "</span></td><td><span> " + orderList.orders[i].OrderDetailList.length + "</span></td><td style='width:30%;' align='right'><span id='spCharge' class='priceTotal'><i class='fa fa-inr'></i>" + amountFin + "</span></td></tr>");

           //grandtotal = grandtotal + parseFloat(orderList.orders[i].payment.Amount) + parseFloat(orderList.orders[i].payment.DeliveryChrg) + parseFloat(orderList.orders[i].payment.TrnChrg);
           grandtotal = grandtotal + parseFloat(orderList.orders[i].payment.Amount) + parseFloat(orderList.orders[i].payment.DeliveryChrg);

       }

       $(".GRTOTAL").html("<i class='fa fa-inr'></i>" + grandtotal);

       var amountFin = grandtotal;
       amountFin = grandtotal + amountFin * 4 / 100;
       if (amountFin.toFixed) 
       {
           amountFin = amountFin.toFixed(2);
       }

       var GstCharge = amountFin * (5 / 100);
       var gtotal = parseFloat(GstCharge) + parseFloat(amountFin);

       if (gtotal.toFixed) {
           gtotal = gtotal.toFixed(2);
       }



       $("#spnOnlineGrandTotal").html("<i class='fa fa-inr'></i>" + gtotal);

       

       

       //SetCartTotal()
       if (scroll != '0') {
           $("#divQuantity").hide();
           $("#divCart").show();
           ScrollPage();
       }

   }

   function ShowPaymentMethod() {
       $('#divCart').hide(); $('#divPaymentMethod').show();
//       $('html,body').animate({
//           scrollTop: $('#divPaymentMethod').offset().top - $('#footer').height() + 35
//       }, 1000);
       ScrollPage();

   }
   function ShowFinal() {

       if ($('.PAYMENTMTH:checked').length == 0) 
       {
                   swal('Please select payment method!');
                   return false;
       }

               if ($('#rdPM1').is(':checked')) 
               {
                   if ($('.PAYMENTMTHOFF:checked').length == 0) 
                   {
                       swal('Please select offline payment method!');
                       return false;
                   }
               }

             


        
        



        if ($('#rdPM2').is(':checked') || $('#chkCashPickUp').is(':checked')) //Online selected
        {

            var grandtotal = 0;
            var TotaldiscooutAmount = 0;
            for (var i = 0; i < orderList.orders.length; i++) 
            {
                $.ajax
                  ({
                      type: "POST",
                      url: "KompServices.asmx/GetDiscount",
                      contentType: "application/json; charset=utf-8",
                      data: "{DaysCout:" + JSON.stringify(orderList.orders[i].OrderDetailList.length) + "}",
                      dataType: "json",
                      async:false,
                      success: function (result) {                          
                          var amountFin = orderList.orders[i].payment.Amount;
                          var discooutAmount = parseFloat(amountFin) * parseFloat(result.d.Discount) / 100;
                          if (amountFin.toFixed) {
                              amountFin = amountFin.toFixed(2);
                          }
                          grandtotal = grandtotal + (parseFloat(orderList.orders[i].payment.Amount) - discooutAmount) + parseFloat(orderList.orders[i].payment.DeliveryChrg);
                          TotaldiscooutAmount = TotaldiscooutAmount + discooutAmount;
                      }
                  });
            }

            var onlchrgPer;
            var GstChargePer;
            $.ajax
                  ({
                      type: "POST",
                      url: "KompServices.asmx/GetConfigValues",
                      contentType: "application/json; charset=utf-8",
                      data: "{}",
                      dataType: "json",
                      async:false,
                      success: function (result) {
                          onlchrgPer = result.d.TrnChrg;
                          GstChargePer = result.d.Tax;
                      }
                  });

            var onlchrg = parseFloat(onlchrgPer * grandtotal / 100);
            if (onlchrg.toFixed) {
                onlchrg = onlchrg.toFixed(2);
            }
                        
            $('#spnTrns').html("<i class='fa fa-inr'></i>"+onlchrg);
                        

            var gtotal = 0.00;
            
            if($('#chkCashPickUp').is(':checked')) // Check Cash PickUp
            {
                //alert("chkCashPickUp:" + chkCashPickUp + " orderList.orders.length:" + orderList.orders.length + " chkCashPickUpPers:" + chkCashPickUpPers);
                //alert(chkCashPickUpPers * grandtotal / 100);
                onlchrg = Math.round((chkCashPickUp) * 1 + chkCashPickUpPers * grandtotal/100);
                //onlchrg = 50.00 * orderList.orders.length;
                $('.onChrges').html("<i class='fa fa-inr'></i>" + onlchrg);
                gtotal = onlchrg + parseFloat(grandtotal);

                $('.onlineCls').html('CASH PICK UP CHARGE');
            }
            else
            {
                //Online
                gtotal = parseFloat(onlchrg) + parseFloat(grandtotal);
                $('.onlineCls').html('ONLINE PROCESSING CHARGE');
            }

            var GstCharge = gtotal * (GstChargePer / 100);
            gtotal = parseFloat(GstCharge) + parseFloat(gtotal);
            
            if (gtotal.toFixed) {
                gtotal = gtotal.toFixed(2);
            }

            
            if (TotaldiscooutAmount == 0) {
                $("#trdiscount").css("display", "none");
                
            }
            else {
                $("#trdiscount").removeAttr("style");
                $("#spnDiscount").html("<i class='fa fa-inr'></i>" + TotaldiscooutAmount.toFixed(2));
            }
            $('#divPaymentMethod').hide();
            $('#spnGST').html("<i class='fa fa-inr'></i>" + GstCharge.toFixed(2));
            $('#spnOnlineGrandTotal').html("<i class='fa fa-inr'></i>"+gtotal);
            $('#divFinal').show();
            ScrollPage();
            if (orderList.orders.length > 2) {
//                $('html,body').animate({
//                    scrollTop: $('#divFinal').offset().top
                //                }, 1000);
                //ScrollPage();
            }
            else {
               // ScrollPage();
//                $('html,body').animate({
//                    scrollTop: $('#divFinal').offset().top - $('#footer').height() - 35
//                }, 1000);
            }

           
        }
        else 
        {//Offline mode
            
            return SetPayment();
        }
        //$('#divPaymentMethod').hide();
        ScrollPage();
   }

   function SetPayment() 
   {

//       var lognmsg = "Please login first to place your order";
//       if (loggiedIn > 0) {
//           lognmsg ="We are proceeding your order!"
//       }

//       swal({ title: lognmsg, text: "If you want to make change still you can, Click cancel if you want to make change!", type: "warning", showCancelButton: true, confirmButtonColor: "#4b220c", confirmButtonText: "PROCEED", closeOnConfirm: false },
//       function () {
//           
          // swal({ title: "Login Please!", text: "Sign Up! If you are a new user.", timer: 0, showConfirmButton: false });
          //         
           if (loggiedIn > 0) {
               SaveOrder(orderList);
           }
           else 
           {
               $('#hdnIsHome').val("5");
               $('#aRegister').click();
           }
         //  $('#divFinal').show();   
       //});
      
     }




              function CreateOrdersSession() {

                  //alert(orderList.orders.length);
                                
                  for (var i = 0; i < orderList.orders.length; i++) {

                      orderList.orders[i].payment.PaymentDate = new Date();

                      orderList.orders[i].Order.OrderDate = new Date(); ;
                      orderList.orders[i].Order.OrderStartDate = new Date(); ;

                     // swal(orderList.orders[i].Payment.PaymentDate);
                      for (var k = 0; k < orderList.orders[i].OrderDetailList.length; k++) {                          

                          var date = orderList.orders[i].OrderDetailList[k].DeliverDate.toString().indexOf('Date')!="-1"?new Date(parseInt(orderList.orders[i].OrderDetailList[k].DeliverDate.substring(6))):orderList.orders[i].OrderDetailList[k].DeliverDate;                          
                          orderList.orders[i].OrderDetailList[k].DeliverDate = date;
                          
                      }
                        
                  }

                 // alert(JSON.stringify(orderList));

                  $.ajax
                  ({
                      type: "POST",
                      url: "KompServices.asmx/CreateOrdersSession",
                      contentType: "application/json; charset=utf-8",
                      data: "{orders:" + JSON.stringify(orderList) + "}",
                      dataType: "json",
                      success: function (result) {


                          $(".tableCart1 tbody").html(result.d.split('$')[0]);
                          $(".custom-ltr:first label").html(orderList.orders.length + " Item(s) -");
                          $(".custom-ltr:last").html($(".tableCart1 .priceTotal:last").html());

                          //alert(orderList.orders.length);
                          if (orderList.orders.length > 3) {
                              $("#PlacedOrders").css('height', '550px');
                              $("#PlacedOrders").css('overflow-y', 'auto');
                          }
                          else {
                              $("#PlacedOrders").css('height', 'auto');
                              $("#PlacedOrders").css('overflow-y', 'auto');
                          }

                      },
                      error: function (res) { swal("During session -" + res.status + ' ' + res.statusText); }
                  });


              }

   //-----Common functions end


              var myInput = document.getElementById("txtExistingUserName");
              if (myInput.addEventListener) {
                  myInput.addEventListener('keydown', this.keyHandler, false);
              } else if (myInput.attachEvent) {
                  myInput.attachEvent('onkeydown', this.keyHandler); /* damn IE hack */
              }

              var myInput1 = document.getElementById("txtFirstName");
              if (myInput1.addEventListener) {
                  myInput1.addEventListener('keydown', this.keyHandler, false);
              } else if (myInput1.attachEvent) {
                  myInput1.attachEvent('onkeydown', this.keyHandler); /* damn IE hack */
              }

              var myInput2 = document.getElementById("txtEmail");
              if (myInput2.addEventListener) {
                  myInput2.addEventListener('keydown', this.keyHandler, false);
              } else if (myInput2.attachEvent) {
                  myInput2.attachEvent('onkeydown', this.keyHandler); /* damn IE hack */
              }

              var myInput3 = document.getElementById("txtPasssword");
              if (myInput3.addEventListener) {
                  myInput3.addEventListener('keydown', this.keyHandler, false);
              } else if (myInput3.attachEvent) {
                  myInput3.attachEvent('onkeydown', this.keyHandler); /* damn IE hack */
              }

              function keyHandler(e) {                  
                  var TABKEY = 9;
                  if (e.keyCode == TABKEY) {
                      //this.value += "    ";
                      $(this).next().focus();
                      if (e.preventDefault) {
                          e.preventDefault();
                      }
                      return false;
                  }
              }



              function ScrollPage(time) {
                  var time1 = time == 0 ? 0 : 1000;

//                  var ua = window.navigator.userAgent;
//                  var msie = ua.indexOf("MSIE ");
//                  alert(ua);
//                  if (msie > 0)      // If Internet Explorer, return version number
//                      alert(parseInt(ua.substring(msie + 5, ua.indexOf(".", msie))));
//                  else                 // If another browser, return 0
//                      alert('otherbrowser');



                  $('html,body').animate({
                      scrollTop: $('#footer').offset().top - 2 * $('#footer').height() + 175
                  }, time1);
              }


              function CheckArea() {
                  $("#divSetDate").hide();
                  if ($("#txtPinCode").val().length == 0) {
                      swal("Please enter your PIN code for delivery availability")
                      $("#txtPinCode").focus();
                      return false;
                  }

                  if ($("#txtPinCode").val().length < 6) 
                  {
                      swal("Please enter valid PIN code for delivery availability")
                      $("#txtPinCode").focus();
                      return false;
                  }

                  $.ajax({
                      type: "POST",
                      url: "KompServices.asmx/CheckDeliveryArea",
                      contentType: "application/json; charset=utf-8",
                      data: "{pin:" + $("#txtPinCode").val() + "}",
                      dataType: "json",
                      success: function (result) {
                          if (result.d.pincode == 0) {
                              //swal("We are sorry! Unfortunately, Kitchen On My Plate is unavailable in your area.")
                              //window.location.href = "Contactus.aspx";
                              SorryAvailibility();
                              return false;
                          }
                          else {
                              swal("Welcome, Kitchen On My Plate meal delivery service is available in your area. Please select your meal start date.");
                              pincode = result.d.pincode;
                              AftercheckValid();
                              return true;
                          }

                      },
                      error: function (res) { swal("During check area  -" + res.status + ' ' + res.statusText); return false; }
                  });
              }


              function HideDateBoxes() 
              {
                  //$('.mealP').show();
                  //$("#btnWeekly").show();
                  //$('#divChkDelieveryArea').hide();
                  $('#divSetDate,#divSetDate2').hide();
                  //$("input.btnRed").removeClass('btnRedClick');
               //   IsClickable = true;
                  // $("div[mealtype='" + selectedTab + "'].subItemBox,#btnWeekly").show();
//                  $(".subVeg,div[mealtype='" + selectedTab + "'].subItemBox").slideToggle(1000, function () {
//                  }).delay(1000);
//                  //$("#ContentPlaceHolder1_divItem").slideToggle(2600, function () { });        

//                  $('html,body').animate({
//                      scrollTop: $('.subVeg').offset().top
//                  }, 1000);
              }

              function SorryAvailibility() {

                  var msgConfirm = "We are sorry! \n Unfortunately, Kitchen On My Plate delivery service is unavailable in your area. \n But we are continuously adding new areas; \n please enter your area details in our enquiry form.";
                  swal({ title: msgConfirm, text: "", type: "warning", showCancelButton: false, confirmButtonColor: "#4b220c", confirmButtonText: "OK", cancelButtonText: "NO", closeOnConfirm: true, closeOnCancel: true },
                    function (isConfirm) {
                        if (isConfirm) 
                        {
                            window.location.href = "Contactus.aspx";
                        }                        
                });

              }