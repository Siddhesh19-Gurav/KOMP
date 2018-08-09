<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConfirmationPage.aspx.cs" Inherits="KitchenOnMyPlate.ConfirmationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
#tableQuantity strong{font-size:16px;}
</style>
<div>
<br />
<h1 class="page-titleMain">YOUR ORDER DETAILS</h1>
<div style="width:50%;float:left;display:none" >ORDER CODE</div><div style="width:50%;float:left;display:none" ><asp:Label ID="lblOrderCode" runat="server" ></asp:Label></div>

<div style="width:50%;float:left;display:none" >PAYMENT METHOD</div><div style="width:50%;float:left;display:none" ><asp:Label ID="lblPMethod" runat="server" ></asp:Label></div>



<!--Shikha work Start -->
<div id="divOff" runat="server" visible="false"  class="ProcessBox CUSTBOX" style="height:auto;margin-top:15px;">
<article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >01</span>ORDER SUMMARY</h1>        
        </article>
        <div class ="ProcesBoxInner">
        <div style="width:100%;" >
        <div style="width:100%;float:left" ><h5 class="emailH5" style="color:#F37624; font-family:RobotoBlack;" ><asp:Label ID="lblPaymentMessage" runat="server" ></asp:Label>:</h5></div>

                 <table id="table3" class="tableCartOS tbl" cellspacing="1" width="100%" align="center" cellpadding="5" >
				    <tbody>		                            
                    <tr class="divRow"><td colspan="2" style="width:30%;" align="left"><strong>Name&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnName' runat="server"></span></td></tr>
                    <tr class="divRow" style="display:none;hideonemail" ><td colspan="2" style="width:30%;" align="left"><strong>Order No.&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnRqst' runat="server"></span></td></tr>
                    <tr class="divRow"><td colspan="2" style="width:30%;" align="left"><strong>Delivery Address&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnSA' runat="server"></span></td></tr>
                    <tr class="divRow"><td colspan="2" style="width:30%;" align="left"><strong>Billing Address&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnBA' runat="server"></span></td></tr>

                    <tr class="divRow" id="trlist" runat="server"  visible="false" ><td colspan="3" style="width:100%;" align="left">

                    <div class ="ProcesBoxInner1">
        <div style="width:100%;" >
            
            <table id="table4" class="tableCart tbl" cellspacing="1" width='100%' align="center" cellpadding="5" >
                 <thead>
                 <tr class='divRow dataHeader' style='background:#F16822;color:#fff;font-family:RobotoBold;font-size:1em; ' ><td>ORDER#</td><td>PRODUCT</td><td>Total No. Of Meals</td><td>START DATE</td><td>MEAL TYPE</td></tr>
                 </thead>
				    <tbody>		                            
                    <asp:Literal ID="tbOrders1" runat="server"></asp:Literal>                    
				</tbody>
                
                </table>
                
</div>
        </div>

                    </td></tr>



                    <tr class="divRow"><td colspan="2" style="width:30%;" align="left"><strong>Order Date&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnRQSTDATE' runat="server"></span></td></tr>
                    <tr class="divRow" style="display:none;hideonemail"><td colspan="2" style="width:30%;" align="left"><strong>Product Name&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnPName' runat="server"></span></td></tr>
                    <tr class="divRow" style="display:none;hideonemail" ><td colspan="2" style="width:30%;" align="left"><strong>Quantity&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnQuantity' runat="server"></span></td></tr>                    
                    <tr class="divRow" style=""><td colspan="2" style="width:30%;" align="left"><strong>Payment Mode Opted&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnPaymentMode' runat="server"></span></td></tr>
                    <tr class="divRow" style="display:none"><td colspan="2" style="width:30%;" align="left"><strong>Payment Amount&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnPaymentAmount' runat="server"></span></td></tr>
                    <tr class="divRow"><td colspan="2" style="width:30%;" align="left"><strong>Payment Status&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnPaymentStatus' runat="server"></span></td></tr>
                    <tr class="divRow" style="display:none;hideonemail"><td colspan="2" style="width:30%;" align="left"><strong>Meal Plan Period&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnMealPP' runat="server"></span></td></tr>
                    <tr class="divRow" style="display:none;hideonemail"><td colspan="2" style="width:30%;" align="left"><strong>Meal Start Date&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnaMealSDate' runat="server"></span></td></tr>
                    <tr class="divRow" style="display:none;hideonemail"><td colspan="2" style="width:30%;" align="left"><strong>Meal Type&nbsp;&nbsp;&nbsp;</strong></td><td style="width:70%;" align="left" ><span id='spnaMealType' runat="server"></span></td></tr>
				</tbody>                
                
                </table>
                <div class="hidden">$ALLORDERS$</div>
                   <div style="width:100%;" >
                   <br />
                   <div id="offlineBankDtl" runat="server" visible="false" style="width:auto;height:auto;color:#333" >
                  <p><i>Please note:</i> Payment for your order to be received by Kitchen On My Plate atleast before 4 pm a day prior to your meal start date. The meal delivery for any payment received after 4 pm will start a day later.</p>
                  <p> In case of online transfer of funds you are requested to mail us transaction reference. Also, mention your name in the transaction description for online transfer of funds.</p>
                  <p><b> Bank Details For Payment:</b></p>        
                  <p>Bank: KOTAK MAHINDRA BANK<br />Branch Address: Goregaon Branch<br />City: MUMBAI<br />Account Number: 7911547099<br />IFSC Code: KKBK0000646<br />Beneficiary A/c Type: CURRENT<br />Full name of beneficiary (Pay to Name): KITCHEN ON MY PLATE</p>
                  <p> If you have any questions about your order please call us at 84520 04123 or send us an email at info@kitchenonmyplate.com. </p>
                  </div>
                   </div>

                
                
</div>
        </div>
   <div style="clear:both" ></div>
</div>
<!--Shikha work end -->

<!--Shikha work Start -->
<div id="divQuantity" class="ProcessBox CUSTBOX" style="height:auto;margin-top:15px;">
<article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >02</span>ORDER DETAILS</h1>        
        </article>
        <div class ="ProcesBoxInner">
        <div style="width:100%;" >
                    <table id="tableQuantity" class="tbl" cellspacing="1" width="100%" align="center" cellpadding="5" >
				    <tbody>															                    
                    <asp:Literal ID="tbOrders" runat="server"></asp:Literal>
				</tbody></table>
                
                
</div>
        </div>
   <div style="clear:both" ></div>
</div>
<!--Shikha work end -->

<!--FINAL TOTAL Start -->
<div id="divFinal" runat="server" clientidmode="Static" class="ProcessBox CUSTBOX" style="height:auto;margin-top:15px;">
<article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >03</span>PAYMENT DETAILS</h1>        
        </article>
        <div class ="ProcesBoxInner">
        <div style="width:100%;" >
                 <table id="table1" class="tableCart tbl" cellspacing="1" width="100%" align="center" cellpadding="5" >
				    <tbody>		                                            
                    <tr id="trdiscount" runat="server" class="divRow"><td colspan="2" style="width:70%;" align="right"><strong>AMOUNT (AFTER  <span id="spnDiscountCount" runat="server"></span> %  DISCOUNT)&nbsp;&nbsp;&nbsp;</strong></td><td style="width:30%;" align="center" ><span id='spnDiscount' runat="server" class='price'></span></td></tr>
                    <tr class="divRow"><td colspan="2" style="width:70%;" align="right"><strong>Sub Total&nbsp;&nbsp;&nbsp;</strong></td><td style="width:30%;" align="center" ><span id='spnSubTotal' runat="server" class='price'></span></td></tr>
                    <tr class="divRow"><td colspan="2" style="width:70%;" align="right"><strong>Delivery Charges&nbsp;&nbsp;&nbsp;</strong></td><td style="width:30%;" align="center" >&nbsp;<span id='spnDelivery' runat="server" class='price'></span></td></tr>
                    <%--<tr class="divRow" id="trTran" runat="server" ><td colspan="2" style="width:70%;" align="right"><strong runat="server" id="strOnln" >Online Processing Charges&nbsp;&nbsp;&nbsp;</strong></td><td style="width:30%;" align="center" ><span id='spnTrns' runat="server" class='price'></span></td></tr>--%>
                    <tr class="divRow" id="tr1" runat="server" ><td colspan="2" style="width:70%;" align="right"><strong runat="server" id="Strong1" >SGST:2.5%&nbsp;&nbsp;&nbsp;</strong></td><td style="width:30%;" align="center" ><span id='spnSGST' runat="server" class='price'></span></td></tr>
                    <tr class="divRow" id="tr2" runat="server" ><td colspan="2" style="width:70%;" align="right"><strong runat="server" id="Strong2" >CGST:2.5%&nbsp;&nbsp;&nbsp;</strong></td><td style="width:30%;" align="center" ><span id='spnCGST' runat="server" class='price'></span></td></tr>
                    <tr class="divRow" style="font-size:16px !important" ><td colspan="2" style="width:70%;" align="right"><span class=''>TOTAL AMOUNT&nbsp;&nbsp;&nbsp;</span></td><td style="width:30%;" align="center" ><span id='spnOnlineGrandTotal' runat="server"  style="font-size:1.2em" class=''></span></td></tr>
				</tbody>                
                
                </table>

</div>
        </div>
   <div style="clear:both" ></div>
</div>
<!--FINAL TOTAL end -->

<!--Shipping details Start -->
<div id="div1" class="ProcessBox CUSTBOX" style="height:auto;margin-top:15px;display:none;">
<article class="page-art">
        <h1 class="page-titleSmallCust">SHIPPING DETAILS</h1>        
        </article>
        <div class ="ProcesBoxInner">
        <div style="width:100%;" >
                 <table id="table2" class="tableCart tbl" cellspacing="1" width="100%" align="center" cellpadding="5" >
				    <tbody>		
                    <tr class='divRow dataHeader'><td><b>BILLING ADDRESS</b></td><td><b>DELIVERY ADDRESS</b></td></tr>                            
                    <tr class="divRow"><td style="width:50%;" align="center"><span id="strongBilling" runat="server" ></span></td><td style="width:50%;" align="center" ><span id="strongDelivery" runat="server" ></span></td></tr>                 
				</tbody>                
                
                </table>

</div>
        </div>
   <div style="clear:both" ></div>
</div>
<!--Shipping details end -->

   

<hr />


</div>

</asp:Content>
