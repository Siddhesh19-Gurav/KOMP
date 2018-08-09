<%@ Page Title="" Language="C#" MasterPageFile="Masters/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="KitchenOnMyPlate.Masters.ManageOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="Styles/themes/base/jquery.ui.all.css" />	
    <%--<script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>--%>
	<script type="text/javascript" src="Scripts/ui/jquery.ui.core.js"></script>
	<script type="text/javascript" src="Scripts/ui/jquery.ui.widget.js"></script>
	<script type="text/javascript" src="Scripts/ui/jquery.ui.datepicker.js"></script>
	<%--<link rel="stylesheet" href="../demos.css">--%>

<link href="Styles/StyleSheetReport.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jsPlacedOrders.js" type="text/javascript"></script>
    <script type="text/javascript">
        function MyPopUpWin(url, width, height) {

            var leftPosition, topPosition;
            //Allow for borders.
            leftPosition = (window.screen.width / 2) - ((width / 2) + 10);
            //Allow for title and status bars.
            topPosition = (window.screen.height / 2) - ((height / 2) + 50);
            //Open the window.
            window.open(url, "Window2",
    "status=no,height=" + height + ",width=" + width + ",resizable=yes,left="
    + leftPosition + ",top=" + topPosition + ",screenX=" + leftPosition + ",screenY="
    + topPosition + ",toolbar=no,menubar=no,scrollbars=no,location=no,directories=no");
        }
    </script>
<script type="text/javascript">

    $(function () {
        //   GetLocationsOnLoad();
    });

    function ValidateAdd() {
        if ($("#ctl00_MainContent_drpLocation").val() == 0) {
            alert('Select Location');
            $("#ctl00_MainContent_drpLocation").focus();
            return false;
        }

        if ($("#ctl00_MainContent_txtAddPrice").val() == "") {
            alert('Please Enter Price');
            $("#ctl00_MainContent_txtAddPrice").focus();
        }
    }

    var RowId = 0;
    function SetMakePayementDetails(rowId, invoice, totalPayment, DuePayment) {

        RowId = rowId;
        $(".spInv").html(invoice);
        $(".spanTotal").html(totalPayment);
        $("#txtAmount").val(totalPayment);

        $(".spanDueTotal").html($('#divRow' + RowId).children(".due").html());

    }

    $(window).load(function () {
        // $('#printFullModal').leanModalCenter({ top: 52, overlay: 0.45, closeButton: ".hidemodal" });                
        $('.viewInvoice,#btnSendInvoice,.addAmountInvoice,.ReporActionBtn').leanModalCenter({ top: 25, overlay: 0.45, closeButton: ".hidemodal" });
    });

    function Payment()
    {
    var Id;
    var OrderId;
    var TransactionNo;
    var Amount;
    var Mode;
    var PaymentDate;
    var NameOnCard;
    var CardNumber;
    var IsActive;
    var Bank;
    var Branch;
    var Comments;
    }

    function SavePayementDetails() {

        if (!ValidationPMade()) {
            return false;
        }

        //Common action
        var objPaymentHistory = new Payment();
        objPaymentHistory.Id = 0;
        objPaymentHistory.OrderId = $(".spInv").html();
        //objPaymentHistory.TransactionNo = $('#txtDetails').val();
        objPaymentHistory.Amount = $("#txtAmount").val();
        objPaymentHistory.Mode = $('#cmdMethod').val();
        objPaymentHistory.PaymentDate = currentSelected;// $('#ContentPlaceHolder1_hdnInvoiceDate').val();
        objPaymentHistory.NameOnCard = 'NAME';
        objPaymentHistory.CardNumber = 'CARD';

        objPaymentHistory.Bank = $('#txtBank').val(); ;
        objPaymentHistory.Branch = $('#txtBranch').val(); ;
        objPaymentHistory.TransactionNo = $('#txtRef').val();

        //objPaymentHistory.ChequeNo = 'CARD'; 
        objPaymentHistory.Comments = $('#txtDetails').val();

        objPaymentHistory.IsActive = 1;
        

        $('.alert').hide();
        $('#ContentPlaceHolder1_lblError').text('');

        
        //
        $.ajax({
            type: "POST",
            url: "KompServices.asmx/SavePayementDetails",
            contentType: "application/json",
            data: "{objPaymentHistory: " + JSON.stringify(objPaymentHistory) + "}",
            dataType: "json",
            success: function (result) {

                if (result.d == 1) {
                    alert('Updated Successfully!!');
                    $('.hidemodal').click();
                    var dueAmt = parseInt($('#divRow' + RowId).children(".due").html()) - parseInt($("#txtAmount").val());
                    $('#divRow' + RowId).children(".due").html(dueAmt);
                    var statusStr = (dueAmt == 0 ? "<span class='label label-success'>Paid</span>" : "");
                    if (statusStr != "") {
                        //$('#divRow' + RowId).children("td:eq(5)").html(statusStr);

                    }
                    window.location.href = "ManageOrders.aspx";

                    $("#txtAmount").val('');
                    $('#fromDate').val('');
                    $('#cmdMethod').val("0");
                    $('#txtDetails').val('');

                }
                else {
                    alert('Seems some problem!!');
                }

                return false;
            },
            error: function (result) { alert(result.d); return false; }
        });
        return false;

    }

    function DeleteOrder(indx,orderNo) {

        var msgConfirm = "Are you sure, you want to delete this Order?"
     
              if( confirm(msgConfirm))
              {
                $.ajax({
                    type: "POST",
                    url: "KompServices.asmx/DeleteOrder",
                    contentType: "application/json",
                    data: "{orderId: " + orderNo + "}",
                    dataType: "json",
                    success: function (result) {

                        if (result.d == 1) {
                            alert("Order #"+orderNo+" is deleted  Successfully!!");
                            $("#divRow" + indx).remove();

                        }
                        else {
                            alert('Seems some problem, relogin and try again!!');
                        }

                        return false;
                    },
                    error: function (result) { alert(result.d); return false; }
                });
                }
            return false;
}

    function ValidationPMade() {

        if ($("#txtAmount").val() == "") {
            alert("Please enter amount");

            $('.alert').show();
            $('#ContentPlaceHolder1_lblErrorP').text('*Please enter amount');

            $('#txtAmount').focus();
            return false;
        }

//        if (parseInt($("#txtAmount").val()) > parseInt($(".spanDueTotal").html())) {
//            alert("Amount cannot be greater than due payment");
//                       

//            $('#txtAmount').focus();
//            return false;
//        }

        if (parseInt($("#txtAmount").val()) != parseInt($(".spanTotal").html())) {
            alert("Amount should be equal to " + parseInt($(".spanTotal").html()));

            //$('.alert').show();
            //$('#ContentPlaceHolder1_lblErrorP').text('*Amount cannot be greater than due payment');

            $('#txtAmount').focus();
            return false;
        }


        if ($('#fromDate').val() == "") {
            alert("Please enter payment date");

            $('.alert').show();
            $('#ContentPlaceHolder1_lblErrorP').text('*Please enter payment date');

            $('#fromDate').focus();
            return false;
        }

        if ($("#txtPossessionDate").val() == "") {
            alert("Please enter payment date");

            //$('.alert').show();
            //$('#ContentPlaceHolder1_lblErrorP').text('*Please enter payment date');

            $("#txtPossessionDate").focus();
            return false;
        }





        if ($('#cmdMethod').val() == "0") {
            alert("Please select payment method");

            $('.alert').show();
            $('#ContentPlaceHolder1_lblErrorP').text('*Please select payment method');

            $('#cmdMethod').focus();
            return false;
        }


        if ($("#txtRef").val() == "") {
            alert("Please enter referance/cheque/recept no");
            $("#txtRef").focus();
            return false;
        }

        if ($('#cmdMethod').val() != "14") {

            if($("#txtBank").val() == "") {
                alert("Please enter bank name");
                $("#txtBank").focus();
                return false;
            }


            if ($("#txtBranch").val() == "") {
                alert("Please enter branch");
                $("#txtBranch").focus();
                return false;
            }
        }
        


        //alert($('#txtDetails').html());
        //alert($('#txtDetails').val());
        if ($('#txtDetails').val() == "") {
            alert("Please enter payment details");

            $('.alert').show();
            $('#ContentPlaceHolder1_lblErrorP').text('*Please enter payment details');

            $('#txtDetails').focus();
            return false;
        }

        return true;

    }

</script>


<script type="text/javascript"\>
    var list = new Array();
    var currentSelected = '';
    
    /** Datepicker start */
    /** Days to be disabled as an array */
    //var disabledSpecificDays = ["3-20-2015", "9-24-2015", "9-25-2015", "10-01-2015"];
    var disabledSpecificDays = '';

    function disableSpecificDaysAndWeekends(date) {
        var m = date.getMonth();
        var d = date.getDate();
        var y = date.getFullYear();
        for (var i = 0; i < disabledSpecificDays.length; i++) {
            if ($.inArray((m + 1) + '-' + d + '-' + y, disabledSpecificDays) != -1 || new Date() > date) {
                return [false];
            }
        }
        var noWeekend = $.datepicker.noWeekends(date);
        return !noWeekend[0] ? noWeekend : [true];
    }

    $(document).ready(function () {

        //GetHolidayes();
        SetCalender();

        $('#btnAddDate').click(function () {

            var IsalreadyListed = false;

            $(".spndt").each(function (index) {
                if ($(this).html() == $("#txtPossessionDate").val()) {
                    IsalreadyListed = true;
                }
            });

            if ($("#txtPossessionDate").val() != "") {

                if (!IsalreadyListed) {
                    $("#divHolidayList").append("<div id='divDt" + cnt + "' > <span class='spndt'>" + $("#txtPossessionDate").val() + "</span> <span  style='cursor:pointer' onclick=DeleteItem('divDt" + cnt + "') ><b>X</b></span>  </div>");
                    $("#txtPossessionDate").val('');
                    cnt++;
                }
                else {
                    alert('Date cannot be added as it already listed for holiday!!')
                }

            }
            else {
                alert('Please enter date');
                $("#txtPossessionDate").focus();
            }
        });


        $("#cmdMethod").change(function () {
            $(".hideonCashPickup").show();

            if ($("#cmdMethod").val() == "12") {
                $("#lblrefType").html("Cheque No.:");
            }
            else if ($("#cmdMethod").val() == "13") {
                $("#lblrefType").html("NEFT Ref. No.:");
            }
            else if ($("#cmdMethod").val() == "14") {
                $("#lblrefType").html("Cash Pick up Receipt No.:");
                $(".hideonCashPickup").hide();
            }


        });



        $("#txtPossessionDate").change(function () {
            currentSelected = $("#txtPossessionDate").val();
            var dateParts = $("#txtPossessionDate").val().split('/');
            $("#txtPossessionDate").val(dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2]);
        });

    });

    function SetCalender() {        
        var maxDate = new Date(); //getDateYymmdd($(this).data("val-rangedate-max"));
        maxDate.setDate(maxDate.getDate()+365);
        $("#txtPossessionDate").datepicker({
            beforeShowDay: disableSpecificDaysAndWeekends,
            //dateFormat: "dd-mm-yy",
            minDate: -5,
            maxDate: maxDate,
            changeMonth: true,
            changeYear: true,
            numberOfMonths: 3
        });
        $("#ContentPlaceHolder1_txtFromDate").datepicker({
            beforeShowDay: disableSpecificDaysAndWeekends,
            dateFormat: "dd/mm/yy",
            maxDate: maxDate,
            changeMonth: true,
            changeYear: true
        });
        $("#ContentPlaceHolder1_txtToDate").datepicker({
            beforeShowDay: disableSpecificDaysAndWeekends,
            dateFormat: "dd/mm/yy",
            maxDate: maxDate,
            changeMonth: true,
            changeYear: true
        });
    }
    /** Datepicker end */

</script>

   <script src="Scripts/jquery.leanModal.min.js" type="text/javascript"></script>       
    
    <div class="contact-form_grid" style="float:left; text-align:left">
    <div style="width:auto;height:auto; margin:0 auto;margin-top:10px" class="CommonFont" >            
    
    <div style="width:100%;font-size:16px;font-weight:bold;padding-top:10px;font-family:RobotoBold;color:#4b220c">
    <table width="100%">
    <tr>
    <td>
    <asp:TextBox ID="txtOrderNo" class="textbox NumberClass" maxlength="6" placeholder="Order Number" runat="server"></asp:TextBox>
    </td>    
    <td>
    <asp:Button ID="btnReport1" OnClick="btnReport1_Click"  runat="server"  style="margin-left:10px; margin-top:-8px;" Text="Show" />        
    </td>
        <td>
            <asp:TextBox id="txtFromDate" style="" runat="server" name="txtFromDate" onkeypress="return false;" placeholder="From Date" type="text" autocomplete="off" />

        </td>
        <td>
            <asp:TextBox id="txtToDate" style="" runat="server" name="txtToDate" onkeypress="return false;" placeholder="To Date" type="text" autocomplete="off"/>
        </td>
    <td>   <div style=" width:100px; float:right; text-align:center">
        <asp:ImageButton ID="ImageButton1" runat="server"  Width="30px" Height="30px"
                ImageUrl="~/images/excel_icon.png" onclick="ImageButton1_Click" ></asp:ImageButton> <br />
                 <span style="font-size:12px">Export to excel</span>
                </div></td>
    </tr>
    </table>
    
    

    </div>        
        
    
  
    

    

    <%--<div style="float:left; width:auto;text-align:right;margin-top:2px; " >Select from your saved Orders</div>--%>
    <div id="divOrders" runat="server" style="width:100%;height:auto" ></div>
   
    <div id="divSumm" class="form-horizontal" style="width:80%;height:auto; background-color:#fff !important;display:none" >
    <div style="width:100%;height:30px; margin:0 auto; font-weight:bold;background-color:#4B220C;color:#fff;vertical-align:middle;font-size:18px;" >&nbsp;&nbsp; Order Summary<span class="hidemodal" >X</span></div>
    <div id="divOrdersDetails" class="form-horizontal" style="width:100%;height:auto; margin:0 auto;background-color:#fff !important" ></div>
    
    

    </div>
   
    <div style="width:100%;height:50px"> 
        <asp:Label ID="lblPage" runat="server" Text="Page : 1"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click"><<</asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click"><</asp:LinkButton>
    <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">></asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">>></asp:LinkButton>
     </div>

    <%--<div class="dropdown" style="float:left; margin-left:10px" >
    <asp:DropDownList ID="drpLocation" runat="server">
            </asp:DropDownList>
            </div>--%>

    <%--<div style=" width:200px; float:left; margin-left:10px" > 
        <asp:LinkButton ID="lnkShow" runat="server" onclick="lnkShow_Click">View</asp:LinkButton> </div>--%>

         
      
      
    

        

        <br style="clear:both" />
          <br style="clear:both" />

          
    

  <!-- Add Payment -->                       
                   <div class="form-horizontal" id="divAddAmount" style='display:none'>
					<fieldset>                          
                      <!-- Form components -->
	                    <div class="row-fluid">

                    <!-- Column -->
	                        <div class="    ">
						<!-- General form elements -->
						<div class="manageOrder">
						  
						    <div class="well1">

						    	<div class="alert margin" style='display:none' id="Div1" runat="server" >
						    		<button type="button" class="close" data-dismiss="alert">×</button>
						    		<asp:Label ID="lblErrorP" runat="server"></asp:Label>  
						    	</div>
						    
                  <%--          <div class="control-group">
						            <label class="control-label">From:</label>
						            <div class="controls">
						                Aware Info System
						            </div>
						        </div>  --%>  

                                <div class="control-group">
						            <label class="control-label">Amout Details:</label>
						            <div class="controls">
						                 
                                         <div class="span6">
						                    	
                                                Order  : <span class="spInv" style="font-weight:bold" ></span>
						                    </div>
						                	<div class="span6">						                    	
                                                Total Amount : <span class="spanTotal" style="font-weight:bold" ></span>
						                    </div>
						              <%--  	<div class="span6" style="width:100%;"  id="availableQtyDiv">
						                    	
                                                Due Amount : <span class="spanDueTotal" style="font-weight:bold" ></span>
						                    </div>	  --%>                                          
						            	
						            </div>
						        </div>    

                            <div class="control-group">
						            <label class="control-label">Amount:</label>
						            <div class="controls">
						                <input class="span12 NumberClass" maxlength="12" type="text" id="txtAmount" name="txtAmount" readonly="readonly" />
						            </div>
						        </div>    

                                <div class="control-group">
						            <label class="control-label">Transaction Payment Date:</label>
						            <div class="controls">
                                          <!-- Dates range -->
                                        <ul class="dates-range">
                                            <li><input type="text" id="txtPossessionDate" name="txtPossessionDate" placeholder="Payment Date" /></li>                                                                                        
                                        </ul>
                                        <!-- /dates range -->

            <asp:HiddenField ID="hdnInvoiceDate" runat="server" />
            <asp:HiddenField ID="hdnDueDate" runat="server" />
                                    </div>
						        </div>

                                <div class="control-group">
						            <label class="control-label">Payment Method:</label>
						            <div class="controls">    
                                   <select id="cmdMethod" name="cmdMethod" class="styled" >
	                                                <option value="0">--Select Method--</option>
                                                    <option value="11">Cash Deposit</option>
                                                    <option value="12">Cheque</option>
                                                    <option value="13">NEFT</option>
                                                    <option value="14">Cash Pick up</option>
                                                    </select>
                                                    </div>
						        </div>						    
                                <div class="control-group">
						            <label class="control-label" id="lblrefType" >Details:</label>
						            <div class="controls">						                
						                <input class="span12" maxlength="12" type="text" id="txtRef" name="txtRef" />

						            </div>
						        </div>

                                <div class="control-group hideonCashPickup"  >
						            <label class="control-label" id="Label1" >Bank:</label>
						            <div class="controls">						                
						                <input class="span12" maxlength="12" type="text" id="txtBank" name="txtBank"/>
						            </div>
						        </div>

                                <div class="control-group hideonCashPickup">
						            <label class="control-label" id="Label2" >Branch:</label>
						            <div class="controls">						                
						                <input class="span12" maxlength="12" type="text" id="txtBranch" name="txtBranch"/>
						            </div>
						        </div>

                                <div class="control-group">
						            <label class="control-label">Comments:</label>
						            <div class="controls">
						                <textarea rows="2" class="limited" style=" height:30px; width:100%" id="txtDetails" name="txtDetails" ></textarea>
						                
						            </div>
						        </div>
						        
						     
                                                    <input type="button"  id="sendBtn" onclick="SavePayementDetails()" style="background:#4b220c;padding:10px !important; margin-left:0px !important;" value="Save Payment"/>
                                                        <span class="hidemodal" >X</span>

                             <div style="clear:both" ></div>                            
	                                
	                                
                                    					      

						    </div>
						</div>
						<!-- /general form elements -->

                        </div>
                           <!-- Column -->



                            </div>
	                    <!-- /form comp-->
                        </fieldset>
                    </div>     
                <!-- Add Payment-->                  

    </div>
    </div>
        </asp:Content>


