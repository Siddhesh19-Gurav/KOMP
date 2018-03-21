<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaymentMethod.ascx.cs" Inherits="KitchenOnMyPlate.Controls.PaymentMethod" %>
<script type="text/javascript">
//    function ShowFinal() {

//        if ($('.PAYMENTMTH:checked').length == 0) {
//            swal('Please select payment method!');
//            return false;
//        }

//        if ($('#rdPM1').is(':checked')) 
//        {
//            if ($('.PAYMENTMTHOFF:checked').length == 0) 
//            {
//                swal('Please select offline payment method!');
//                return false;
//            }
//        }



//        if ($('#rdPM2').is(':checked')) //Online selected
//        {
////            alert('1');
////            alert(TrnChrg);
////            alert(SubItemTotals);
//            $('#spnTrns').html(TrnChrg * SubItemTotals / 100);
//            $('#spnOnlineGrandTotal').html(parseInt(TrnChrg * SubItemTotals / 100 + SubItemTotals));
//            $('#divFinal').show();
//        }
//        else {//Offline mode

//            SaveOrder();
//        }
//        $('#divPaymentMethod').hide();
    //    }

    $(function () {
        $('.PAYMENTMTH').click(function () {
            $('.PAYMENTMTHOFF:checked').attr('checked', '');
            //ResetSingleCalender();
            //alter($('.mealplan:checked').attr("planid"));
            //SetCalender();
        });

        $('.PAYMENTMTHOFF').click(function () {
            $('.PAYMENTMTHOFF:checked').attr('checked', '');
            $(this).attr('checked', 'checked');
            $('#rdPM1').attr('checked', 'checked');
            //ResetSingleCalender();
            //alter($('.mealplan:checked').attr("planid"));
            //SetCalender();
        });
    });

    function SaveOrder() {

        var method = "1";
        if ($('#rdPM1').is(':checked')) {//Offline

            //if ($('#chkCash').is(':checked')) {//Offline
            //    method = "11";
            //}
            //else if ($('#chkCheque').is(':checked')) {//Offline
            //    method = "12";
            //}
            //else if ($('#chkNeft').is(':checked')) {//Offline
                method = "13";
            //}
            //else if ($('#chkCashPickUp').is(':checked')) {//Offline
            //    method = "14";
            //}
            //else if ($('#chkIMPS').is(':checked')) {//Offline
            //    method = "15";
            //}

            
        }

        swal({ title: "Please wait...", text: "", timer: 9000, showConfirmButton: false });
        $.ajax
                  ({
                      type: "POST",
                      url: "KompServices.asmx/SaveOrder",
                      contentType: "application/json; charset=utf-8",
                      //data: "{orders:" + JSON.stringify(orderList) + "}",
                      data: "{method:'" + method + "'}",
                      dataType: "json",
                      success: function (result) {
                          //$(".msg_body:first").hide();
                          //$("#ImgProgress,#imgFree,#imgPostHeader").hide();

                          //swal('Proccedding for payment....');
                          // swal({ title: "Proccedding for payment!", text: "Please Wait....", timer: 4000, showConfirmButton: false });

                          if (result.d == -1) {
                              swal('"Sorry!! Request Timeout! Order Again!');
                              ShowItems();
                          }
                          else 
                          {
                              window.location.href = "PaymentProcess.aspx?method=" + method + "&requestId=" + result.d;
                          }

                      },
                      error: function (res) { swal("During Order -" + res.status + ' ' + res.statusText); }
                  });
              }


              
           
</script>
<div id="divPaymentMethod" class="ProcessBox CUSTBOX" style="display:none;height:auto;margin-top:15px;">
<article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" style="color:#fff !important;font-size:22px !important;margin-left:0px !important" >07</span>PAYMENT METHOD</h1>
        </article>
        <div class ="ProcesBoxInner">
        <div style="margin: 0px auto; width: 80%;" >

        <input type="radio" id="rdPM1" name="grpPM" class="PAYMENTMTH" /><label for="rdPM1"></label> <span>Offline - &nbsp; 
        <%--<input id="chkCash" class="PAYMENTMTHOFF" type="checkbox" /><label class="smallForMobile" for="chkCash">Cash Deposit</label><span class='sppp' >&nbsp;&nbsp;&nbsp;</span>
        <input id="chkCheque" type="checkbox" class="PAYMENTMTHOFF" /><label class="smallForMobile" for="chkCheque">Cheque Deposit</label><span class='sppp'>&nbsp;&nbsp;&nbsp;</span> --%>
        <span style="display:none"><input id="chkNeft" type="checkbox" checked="checked" visible="false" class="PAYMENTMTHOFF" /></span><label class="smallForMobile" for="chkNeft">NEFT/IMPS</label><span class='sppp' >&nbsp;&nbsp;&nbsp; </span>
         <%--<input id="chkIMPS" type="checkbox" class="PAYMENTMTHOFF" /><label class="smallForMobile" for="chkIMPS">IMPS</label><span class='sppp' >&nbsp;&nbsp;&nbsp; </span> --%>
        <input id="chkCashPickUp" type="checkbox" class="PAYMENTMTHOFF hide" /><label class="smallForMobile hide" for="chkCashPickUp">Cash Pick up</label></span> <br class='sppp' />
       
        <input type="radio" id="rdPM2" name="grpPM" class="PAYMENTMTH" /><label for="rdPM2"></label> <span>Online &nbsp;- </span><span class="smallForMobileNoBreak">Credit Card / Debit Card / Net Banking</span><br class='sppp' /><br class='sppp' />
        
        <h5>PAY SECURELY BY CREDIT OR DEBIT CARD OR INTERNET BANKING THROUGH <img alt="ccavenue" style="margin-top:-7px" src="images/cca.png" /> SECURED PAYMENT GATEWAY</h5>
        <p class="spnNote"><label>Please Note:</label> All Credit Card / Debit Card / Net Banking transactions through our online payment gateway- CC Avenue <br/>will attract an extra charge on the total billed amount. 
        <%--Cash Pick up is a chargeable service, a fee will be added on the total billed amount.--%></p>
                    <table id="table2" class="tbl" cellspacing="1" width="100%" align="center" cellpadding="5" >
				    <tbody>															                    
				</tbody></table>
                
                <input type="button" value="CONTINUE SHOPPING" class="proceedBack backonprocess" style="float:left;margin-left:0px" onclick="ShowItems();" />

                <input type="button" class="proceed " value="PROCEED" onclick="ShowFinal();" />
                <input type="button" value="BACK" class="proceedBack backonprocess" style="float:right" onclick="$('#divPaymentMethod').hide(); $('#divCart').show(); ScrollPage();" />
                
</div>
        </div>
   <div style="clear:both" ></div>
</div>

<!--FINAL TOTAL Start -->
<div id="divFinal" class="ProcessBox CUSTBOX" style="display:none;height:auto;margin-top:15px;">
<article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >08</span>FINAL AMOUNT TO BE PAID</h1>        
        </article>
        <div class ="ProcesBoxInner">
        <div style="width:100%;" >
                 <table id="table1" class="tableCart tbl" cellspacing="1" width="100%" align="center" cellpadding="5" >
                 <thead>
                 <tr class='divRow dataHeader' style='background:#F16822;color:#fff;font-family:RobotoBold;font-size:1.2em;' ><td></td><td>ORDER</td><td>PRODUCT</td><td>Total No. Of Meals</td><td align="center">AMOUNT</td></tr>
                 </thead>
				    <tbody>		                            
				</tbody>                
                <tfoot> 
                <%--<tr class="divRow"><td style="width:10%;"></td><td style="width:60%;" id="divPNAME"></td><td style="width:30%;"><span id='spCharge' class='price'></span></td></tr>--%>                                        
                    <tr id="trdiscount"  class="divRow"><td colspan="4" style="width:70%;" align="right"><span class='priceTotaltxt'>AMOUNT (AFTER  5% DISCOUNT)<span class='sppp'>&nbsp;&nbsp;&nbsp;</span></span></td><td style="width:30%;" align="right" ><span id='spnDiscount' class='priceTotal'></span></td></tr>
                    <tr class="divRow"><td colspan="4" style="width:70%;" align="right"><span class='priceTotaltxt'>DELIVERY CHARGE <span class='sppp'>&nbsp;&nbsp;&nbsp;</span></span></td><td style="width:30%;" align="right" ><span id='spnShip' class='priceTotal'></span></td></tr>
                    <tr class="divRow"><td colspan="4" style="width:70%;" align="right"><span class='priceTotaltxt onlineCls'>ONLINE PROCESSING CHARGE<span class='sppp'>&nbsp;&nbsp;&nbsp;</span></span></td><td style="width:30%;" align="right" ><span id='spnTrns' class='priceTotal onChrges'></span></td></tr>
                    <tr class="divRow" id="tr1" runat="server" ><td colspan="4" style="width:70%;" align="right"><span class='priceTotaltxt'>SGST:2.5%&nbsp;&nbsp;&nbsp;</span></td><td style="width:30%;" align="right" ><span id='spnSGST' class='priceTotal onChrges'></span></td></tr>
                        <tr class="divRow" id="tr2" runat="server" ><td colspan="4" style="width:70%;" align="right"><span class='priceTotaltxt'>CGST:2.5%&nbsp;&nbsp;&nbsp;</span></td><td style="width:30%;" align="right" ><span id='spnCGST' class='priceTotal onChrges'></span></td></tr>
                    <tr class="divRow"><td colspan="4" style="width:70%;" align="right"><span class='priceTotaltxt'>TOTAL AMOUNT<span class='sppp'>&nbsp;&nbsp;&nbsp;</span></span></td><td style="width:30%;" align="right" ><span id='spnOnlineGrandTotal' class='priceTotal GRTOTAL'></span></td></tr>
                </tfoot>
                </table>

                <%--<table class="tbl" cellspacing="1" >
        <tr class="divRow"><td colspan="2">        
        <span class="page-titleSmallBlackNOLEFT">ORDER REVIEW</span>                
        </td></tr>

        <tr class="divRowHeader"><td style="width:70%;">PRODUCT DETAILS</td><td style="width:30%;">ORDER TOTAL</td></tr>
        
        </table>--%>

                
                <input type="button" value="CONTINUE SHOPPING" class="proceedBack backonprocess" style="float:left" onclick="ShowItems();" />

                <input type="button" class="proceed" value="PROCEED" onclick="SetPayment();" />
                <input type="button" value="BACK" class="proceedBack" style="float:right" onclick="$('#divFinal').hide();$('#divPaymentMethod').show();" />
                
</div>
        </div>
   <div style="clear:both" ></div>
</div>
<!--FINAL TOTAL end -->