<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"  EnableViewStateMac="false" CodeBehind="PaymentProcess.aspx.cs" Inherits="KitchenOnMyPlate.PaymentProcess" %>
<%@ Register src="Controls/PaymentMethod.ascx" tagname="PaymentMethod" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .backonprocess{display:none !important;}
</style>
  <script type="text/javascript" language="javascript" >
      var loggiedIn = "<%=loggiedIn%>"; // value 1 if user session
      var requestId = "<%=requestId%>";
      var method = "<%=method%>";
      var FromTopCart = "<%=FromTopCart%>";
      var IsPaymentEnabled = "<%=IsPaymentEnabled%>"; // 1 means paymend enabled
      var txtFirstName, txtLastName, delivery_tel, delivery_address, delivery_city, delivery_state, txtLandMark, delivery_zip;
      var billing_name, txtLastNameB, billing_tel, billing_address, billing_city, billing_state, txtLandMarkB, billing_zip;
      var FinalOrder = "<%=FinalOrder%>";
      var CountProducts = "<%=CountProducts%>";
      var pincode = "<%=pincode%>";
      var txtFlat, txtBuilding, txtStreet,txtLocation, txtFlatB, txtBuildingB, txtStreetB,txtLocationB;

      $(function () {

          if (method == "11" || method == "12" || method == "13") { //Not onlie and cash pickup
              $("#divShipping .OrderBox").html("08");
          }

          if (CountProducts == 0) {
              swal("No product(s) found!");
              window.location.href = "/";
          }

          $("#divFinal .tableCart tbody").append(FinalOrder);
          $("#divFinal .tableCart tfoot").html('');
      });

      $(document).ready(function () {
          
          txtFirstNameR = Trim(document.getElementById("delivery_name").value);
          txtLastNameR = Trim(document.getElementById("txtLastName").value);
          delivery_telR = Trim(document.getElementById("delivery_tel").value);
          txtCompanyNameR = Trim(document.getElementById("txtCompanyName").value);
          delivery_addressR = Trim(document.getElementById("delivery_address").value);
          delivery_cityR = Trim(document.getElementById("delivery_city").value);
          delivery_stateR = Trim(document.getElementById("delivery_state").value);
          txtLandMarkR = Trim(document.getElementById("txtLandMark").value);
          delivery_zipR = Trim(document.getElementById("delivery_zip").value);

          txtFlat = Trim(document.getElementById("txtFlat").value);
          txtBuilding = Trim(document.getElementById("txtBuilding").value);
          txtStreet = Trim(document.getElementById("txtStreet").value);

          txtFlatB = Trim(document.getElementById("txtFlatB").value);
          txtBuildingB = Trim(document.getElementById("txtBuildingB").value);
          txtStreetB = Trim(document.getElementById("txtStreetB").value);

          
          txtFirstNameBR = Trim(document.getElementById("billing_name").value);
          txtLastNameBR = Trim(document.getElementById("txtLastNameB").value);
          delivery_telBR = Trim(document.getElementById("billing_tel").value);
          txtCompanyNameBR = Trim(document.getElementById("txtCompanyNameB").value);
          delivery_addressBR = Trim(document.getElementById("billing_address").value);
          delivery_cityBR = Trim(document.getElementById("billing_city").value);
          delivery_stateBR = Trim(document.getElementById("billing_state").value);
          txtLandMarkBR = Trim(document.getElementById("txtLandMark").value);
          delivery_zipBR = Trim(document.getElementById("billing_zip").value);


          if (FromTopCart == 1) {// From top cart
              $("#divPaymentMethod").show();
              $("#divShipping,#divBilling,#divQuantity1").hide();
          }

      });


      function ResetAddress() {
          document.getElementById("delivery_name").value = txtFirstNameR;
          document.getElementById("txtLastName").value = txtLastNameR;
          document.getElementById("delivery_tel").value = delivery_telR;
          document.getElementById("txtCompanyName").value=txtCompanyNameR;
          document.getElementById("delivery_address").value = delivery_addressR;
          document.getElementById("delivery_city").value = delivery_cityR;
          document.getElementById("delivery_state").value = delivery_stateR
          document.getElementById("txtLandMark").value = txtLandMarkR;
          document.getElementById("delivery_zip").value = delivery_zipR;

          document.getElementById("txtFlat").value = txtFlat;
          document.getElementById("txtBuilding").value = txtBuilding;
          document.getElementById("txtStreet").value = txtStreet;
      }

      function ResetAddressB() {
          document.getElementById("billing_name").value = txtFirstNameBR;
          document.getElementById("txtLastNameB").value = txtLastNameBR;
          document.getElementById("billing_tel").value = delivery_telBR;
          document.getElementById("txtCompanyNameB").value = txtCompanyNameBR;
          document.getElementById("billing_address").value = delivery_addressBR;
          document.getElementById("billing_city").value = delivery_cityBR;
          document.getElementById("billing_state").value = delivery_stateBR
          document.getElementById("txtLandMarkB").value = txtLandMarkBR;
          document.getElementById("billing_zip").value = delivery_zipBR;

          document.getElementById("txtFlatB").value = txtFlatB;
          document.getElementById("txtBuildingB").value = txtBuildingB;
          document.getElementById("txtStreetB").value = txtStreetB;
      }

      function SetShipping() {
          


            delivery_name = Trim(document.getElementById("delivery_name").value);            
            delivery_tel = Trim(document.getElementById("delivery_tel").value);
            txtCompanyName = Trim(document.getElementById("txtCompanyName").value);

            document.getElementById("delivery_address").value = Trim($("#txtFlat").val()) + ", " + Trim($("#txtBuilding").val()) + ", " + Trim($("#txtStreet").val());
            delivery_address = Trim(document.getElementById("delivery_address").value);
            delivery_city = Trim(document.getElementById("delivery_city").value);
            delivery_state = Trim(document.getElementById("delivery_state").value);
            txtLandMark = Trim(document.getElementById("txtLandMark").value);
            delivery_zip = Trim(document.getElementById("delivery_zip").value);

            txtFlat = Trim($("#txtFlat").val());
            txtBuilding = Trim($("#txtBuilding").val());
            txtStreet = Trim($("#txtStreet").val());
            txtLocation = Trim($("#txtLocation").val());

//            billing_name = Trim(document.getElementById("billing_name").value);
//            txtLastNameB = Trim(document.getElementById("txtLastNameB").value);
//            billing_tel = Trim(document.getElementById("billing_tel").value);
//            txtCompanyNameB = Trim(document.getElementById("txtCompanyNameB").value);
//            billing_address = Trim(document.getElementById("billing_address").value);
//            billing_city = Trim(document.getElementById("billing_city").value);
//            billing_state = Trim(document.getElementById("billing_state").value);
//            txtLandMarkB = Trim(document.getElementById("txtLandMarkB").value);
//            billing_zip = Trim(document.getElementById("billing_zip").value);

            if ($("#chkSamAsShipping").is(':checked')) {
                if (delivery_name == '') {
                    swal('Please fill full Name.');
                    $("#delivery_name").focus();
                    return false;
                }

                if (Trim(document.getElementById("txtLastName").value) == '') {
                    swal('Please fill Email Address.');
                    $("#txtLastName").focus();
                    return false;
                }



                if (delivery_tel == '') {
                    swal('Please fill mobile number.');
                    $("#delivery_tel").focus();
                    return false;
                }

                if (delivery_tel.length < 10) {
                    swal('Mobile number must be 10 digits');
                    $("#delivery_tel").focus();
                    return false;
                }


                if (txtFlat == '') {
                    swal('Please fill flat no.');
                    $("#txtFlat").focus();
                    return false;
                }

                if (txtBuilding == '') {
                    swal('Please fill the building name.');
                    $("#txtBuilding").focus();
                    return false;
                }
                if (txtStreet == '') {
                    swal('Please fill street.');
                    $("#txtStreet").focus();
                    return false;
                }
                if (txtLocation == '0') {
                    swal('Please select location.');
                    $("#txtLocation").focus();
                    return false;
                }
                

//                if (delivery_address == '') {
//                    swal('Please fill Address.');
//                    $("#delivery_address").focus();
//                    return false;
//                }


                if (delivery_city == '') {
                    swal('Please fill City.');
                    $("#delivery_city").focus();
                    return false;
                }



                if (delivery_state == '') {
                    swal('Please fill State.');
                    $("#delivery_zip").focus();
                    return false;
                }

                if (delivery_zip == '') {
                    swal('Please enter pin code.');
                    $("#delivery_zip").focus();
                    return false;
                }

                if (delivery_zip.length < 6) {
                    swal('Please enter 6 digits pin code.');
                    $("#delivery_zip").focus();
                    return false;
                }
            }


//          if ($("#chkSamAsShipping").is(':checked')) {
//              CopyShippingToBilling();
//            
//          }
         // else {
              //$("#divShipping").hide();
//              $("#divBilling").show();
//              $('html,body').animate({
//                  scrollTop: $('#divBilling').offset().top
//              }, 1000);

             // return true;
         // }
          
          return true;

        
      }

      function SetBilling() {

          txtFirstName = Trim(document.getElementById("billing_name").value);

          delivery_tel = Trim(document.getElementById("billing_tel").value);
          document.getElementById("billing_address").value = Trim($("#txtFlatB").val()) + ", " + Trim($("#txtBuildingB").val()) + ", " + Trim($("#txtStreetB").val() +", "+ $("#txtLocation").val());

          delivery_address = Trim(document.getElementById("billing_address").value);
          delivery_city = Trim(document.getElementById("billing_city").value);
          delivery_state = Trim(document.getElementById("billing_state").value);
          delivery_zip = Trim(document.getElementById("billing_zip").value);

          txtFlatB = Trim($("#txtFlatB").val());
          txtBuildingB = Trim($("#txtBuildingB").val());
          txtStreetB = Trim($("#txtStreetB").val());
            

          if (!$("#chkSamAsShipping").is(':checked')) 
          { //Not same as above
          
              if (txtFirstName == '') {
                  swal('Please fill Full Name.');
                  $("#billing_name").focus();
                  return false;
              }


              if (delivery_tel == '') {
                  swal('Please fill mobile number.');
                  $("#billing_tel").focus();
                  return false;
              }

              if (delivery_tel.length < 10) {
                  swal('Mobile number must be 10 digits');
                  $("#billing_tel").focus();
                  return false;
              }

              if (txtFlatB == '') {
                  swal('Please fill flat no.');
                  $("#txtFlatB").focus();
                  return false;
              }
              if (txtBuildingB == '') {
                  swal('Please fill the building name.');
                  $("#txtBuildingB").focus();
                  return false;
              }
              if (txtStreetB == '') {
                  swal('Please fill street.');
                  $("#txtStreetB").focus();
                  return false;
              }

//              if (delivery_address == '') {
//                  swal('Please fill Address.');
//                  $("#billing_address").focus();
//                  return false;
//              }
        

              if (delivery_city == '') {
                  swal('Please fill City.');
                  $("#billing_city").focus();
                  return false;
              }

              if (delivery_state == '') {
                  swal('Please fill State.');
                  $("#billing_state").focus();
                  return false;
              }

              if (delivery_zip == '') {
                  swal('Please enter pin code.');
                  $("#billing_zip").focus();
                  return false;
              }

              if (delivery_zip.length < 6) {
                  swal('Please enter 6 digits pin code.');
                  $("#delivery_zip").focus();
                  return false;
              }
      }
          
          $('#divQuantity1').show();
          $('#divShipping').hide(); $('#divBilling').hide();
          $('html,body').animate({
              scrollTop: $('#divQuantity1').offset().top
          }, 1000);
          $('#divQuantity1').focus();
          
          return true;
          //return SaveShipping();
          
      }

      function HideIFVisibile() {

          //$("#divShipping").hide();

          if ($("#chkSamAsShipping").is(':checked')) {

              if (!$("#divBilling").is(':hidden')) {
                  $("#divBilling").hide();
                  $('html,body').animate({
                      scrollTop: $('#divShipping').offset().top
                  }, 1000);
              }
          }
      }

      function CopyShippingToBilling() 
      {

          
      if($("#chkSamAsShipping").is(':checked'))
      {

          document.getElementById("billing_name").value = Trim(document.getElementById("delivery_name").value);
          document.getElementById("txtLastNameB").value = Trim(document.getElementById("txtLastName").value);
          document.getElementById("billing_tel").value = Trim(document.getElementById("delivery_tel").value);
          document.getElementById("txtCompanyNameB").value = Trim(document.getElementById("txtCompanyName").value);

          $("#billing_address").val($("#delivery_address").val());

//          $("#txtFlat").val($("#txtFlatB").val());
//          $("#txtBuilding").val($("#txtBuildingB").val());
          //          $("#txtStreet").val($("#txtStreetB").val());

                    $("#txtFlatB").val($("#txtFlat").val());
                    $("#txtBuildingB").val($("#txtBuilding").val());
                    $("#txtStreetB").val($("#txtStreet").val());


          document.getElementById("billing_city").value = Trim(document.getElementById("delivery_city").value);
          document.getElementById("billing_state").value = Trim(document.getElementById("delivery_state").value);
          document.getElementById("txtLandMarkB").value = Trim(document.getElementById("txtLandMark").value);
          document.getElementById("billing_zip").value= Trim(document.getElementById("delivery_zip").value);
          if ($("#divBilling").is(':visible')) {
              $('#divBilling').slideToggle(1000, function () { });
          }
       }       
      else 
      {

          if (!$("#divBilling").is(':visible')) {
              $('#divBilling').slideToggle(1000, function () { $('html,body').animate({ scrollTop: $('#divBilling').offset().top }, 1000); $('#billing_name').focus(); });
          }

          document.getElementById("billing_name").value = '';
          document.getElementById("txtLastNameB").value = '';
          document.getElementById("billing_tel").value = '';
          document.getElementById("txtCompanyNameB").value = '';

          $("#billing_address").val('');
          $("#txtFlatB").val('');          
          $("#txtBuildingB").val('');
          $("#txtStreetB").val('');

          
          document.getElementById("billing_city").value = '';
          document.getElementById("billing_state").value = '';
          document.getElementById("txtLandMarkB").value = '';
          document.getElementById("billing_zip").value = '';
       }
    }

    window.onload = function () {
        var d = new Date().getTime();
        document.getElementById("tid").value = d;
    };

    function ShowFinal() 
    {

        
        if ($('.PAYMENTMTH:checked').length == 0) 
        {
            swal('Please select payment method!');
            return false;
        }
        
        if ($('#rdPM1').is(':checked')) 
        {
            //if ($('.PAYMENTMTHOFF:checked').length == 0) 
            //{
            //    swal('Please select offline payment method!');
            //    return false;
            //}
        }

        
        if ($('#rdPM2').is(':checked')) //Online selected
        {
            
            $('#divPaymentMethod').hide();            
            $('#divFinal').show();
            
        }
        else {//Offline mode

            $('#divPaymentMethod').hide();
            $('#divFinal').show();
            //return SetPayment();
        }

        $('#divPaymentMethod').hide();
    }


    function SetPayment() {

        $('#divFinal').hide();

        
            SaveOrder();
        
        

        //});

    }



    

        </script>
    <!--SLIDERNEWSTRT-->
             <%--   <div id="divSlider" runat="server" >
<!---/End-Animation---->
                <link rel="stylesheet" type="text/css" href="Styles/slider.css" />
                <link rel="stylesheet" type="text/css" href="Styles/animate.css" />         
                <div class="slider">
	    <div class="callbacks_container">
	      <ul class="rslides" id="slider">
	        <li>
	          <img src="images/banner/5.png" alt="">
	          
               <div class="caption wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>EAT HEALTHY.</span></h3>
	          </div>

              <div class="caption1 wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>SKIP THE DIET.</span></h3>
	          </div>

	        </li>	       

	      </ul>
	  </div>
  </div>

                    <div class="Tiffin" style="margin-top:-43px;float:right; width:auto;">
                        <img style="margin-left:-5px;" src="images/banner/sl1.png" alt=""/>                        
                      </div>

                    
                      </div>--%>
                <!--SLIDERNEWEND-->

<form method="post" id="customerData" action="ccavRequestHandler.aspx">
<div class="row faq">
<div style="clear:both;height:20px" >
    <h3 class="ContactLabel" style="margin: 20px 0px 10px; padding: 0px; box-sizing: border-box; font-family: Roboto; font-weight: bold; line-height: 1.1; color: rgb(66, 66, 66); font-size: 0.85em; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;">PINCODE<em style="margin: 0px 0px 0px 3px; padding: 0px; box-sizing: border-box; font-size: 16px; font-family: normal; color: red;">*</em></h3>
    </div>
    <asp:HiddenField ID="hdnEmail" runat="server" />
    
<asp:TextBox ID="tid" name="tid" ClientIDMode="Static" runat="server" CssClass="hidden"></asp:TextBox>
<asp:TextBox  name="merchant_id" ID="merchant_id" ClientIDMode="Static" Value="61667" runat="server" CssClass="hidden"></asp:TextBox>
<asp:TextBox ID="order_id" name="order_id" ClientIDMode="Static" runat="server" CssClass="hidden"></asp:TextBox>
<asp:TextBox ID="amount" name="amount" ClientIDMode="Static" runat="server" value="0" CssClass="hidden"></asp:TextBox>
<asp:TextBox ID="currency" name="currency" ClientIDMode="Static" Value="INR" runat="server" CssClass="hidden"></asp:TextBox>
<asp:TextBox ID="redirect_url" name="redirect_url" ClientIDMode="Static" value="http://www.kitchenonmyplate.com/ccavResponseHandler.aspx" runat="server" CssClass="hidden"></asp:TextBox>
<asp:TextBox ID="cancel_url" name="cancel_url" ClientIDMode="Static" value="http://192.168.0.96/mcpg_new/iframe/ccavResponseHandler.php" runat="server" CssClass="hidden"></asp:TextBox>

<uc1:PaymentMethod ID="PaymentMethod1" runat="server" />    
<!--SHIPPING  Start -->
    
<div id="divShipping" class="ProcessBox CUSTBOX" style="height:auto;margin-top:15px;">
<article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >09</span>DELIVERY (SHIPPING) DETAILS</h1>        
        </article>
        <div class ="ProcesBoxInner">
        <div style="width:96%;" >
                 <h5 style="color:#F37624; font-family:RobotoBlack;" >FILL THE DELIVERY ADDRESS AS PER PIN CODE DELIVERY AVAILABILITY CHECKED EARLIER</h5>
           <div class="contact-form_grid" style="float:left; text-align:left; width:50%;height:auto;padding-right:20px;">
		
			<h3 class="ContactLabel">FULL NAME<em style="color:Red">*</em></h3>			
		    <input id="delivery_name" name="delivery_name" runat="server" clientidmode="Static" class="textbox AlphaClass"  maxlength="22" type="text" value=""/>
		
			<h3 class="ContactLabel">MOBILE NO.<em style="color:Red">*</em></h3>
			
				<input id="delivery_tel" name="delivery_tel" runat="server" clientidmode="Static" class="textbox NumberClass" type="text" value="" maxlength="10"/>
			
            <h3 class="ContactLabel">ADDRESS<em style="color:Red">*</em></h3>
            
            <input id="txtFlat" name="txtFlat" runat="server" placeholder="Flat/Office No." title="Flat/Office No." clientidmode="Static" maxlength="15"  class="textbox" type="text" value="" style="width:35%;float:left" />
            <input id="txtBuilding" name="txtBuilding" runat="server" placeholder="Building Name" title="Building Name" clientidmode="Static" maxlength="50"  class="textbox" type="text" value="" style="width:60%;float:right"/>
            <div style="clear:both"></div>
            <input id="txtStreet" name="txtStreet" runat="server" placeholder="Street" title="Street" clientidmode="Static" maxlength="100"  class="textbox" type="text" value="" style="width:48%;float:left"/>
            <input id="txtLocation" name="txtLocation" runat="server" clientidmode="Static" placeholder="Area" maxlength="100"  class="textbox" type="text" style="width:48%;float:right;" />
            <%--<select id="txtLocation" name="txtLocation" runat="server" clientidmode="Static" maxlength="100"  class="textbox" type="text" value="" style=" display:none; width:48%;float:right;padding:0.45em;border:1px solid #E4E4E4"></select>--%>
            <div style="clear:both"></div>
            <textarea id="delivery_address" name="delivery_address" runat="server" clientidmode="Static"  class="textbox" maxlength="200"  rows="4" style="height:116px;display:none" ></textarea>

		
		
			<h3 class="ContactLabel">PINCODE<em style="color:Red">*</em></h3>
	
				<input id="delivery_zip" readonly="readonly" name="delivery_zip" runat="server" clientidmode="Static" maxlength="6"  class="textbox NumberClass" type="text" value=""/>
				
        </div>

          <div class="contact-form_grid" style="float:left; text-align:left; width:50%;height:auto; padding-left:20px;">
          
			<h3 class="ContactLabel">Email Address<em style="color:Red">*</em></h3>
			<input id="txtLastName" name="txtLastName" runat="server" clientidmode="Static"  class="textbox EmailClass" maxlength="60" type="text" value=""/>
			
		
		

                
			<h3 class="ContactLabel">COMPANY NAME</h3>		
			<input id="txtCompanyName" runat="server" clientidmode="Static"  class="textbox AlphaClass" maxlength="22" type="text" value=""/>
			
            <h3 class="ContactLabel">LANDMARK</h3>		
			<input id="txtLandMark" runat="server" clientidmode="Static"  class="textbox AlphaClass" maxlength="30" type="text" value=""/>

            <h3 class="ContactLabel">CITY<em style="color:Red">*</em></h3>		
			    <input id="delivery_city" name="delivery_city" runat="server" clientidmode="Static"  class="textbox AlphaClass"  maxlength="22" type="text" readonly value="Mumbai"/>

            <h3 class="ContactLabel">STATE<em style="color:Red">*</em></h3>		
			<input id="delivery_state" name="delivery_state" runat="server" clientidmode="Static"  class="textbox AlphaClass"  maxlength="22" type="text" readonly value="Maharashtra"/>
		
        
			
          </div>
             <div style="clear:both" ></div>
          <div style="width:auto; height: 20px;font-size:12px" class="SearchTxt"  >
        <%--<input id="chkPrInfo" type="checkbox" /><string>AUTO COMPLETE WITH YOUR PROFILE INFO</string><br/>	--%>
        
        <strong>YOUR BILLING ADDRESS IS :&nbsp;&nbsp;&nbsp; <input id="chkSamAsShipping" checked="checked" type="radio" onclick="CopyShippingToBilling();" name="bll" /><label for="chkSamAsShipping"></label>&nbsp;&nbsp;SAME AS ABOVE &nbsp;&nbsp;&nbsp<input id="Radio1" type="radio" onclick="CopyShippingToBilling();" name="bll" /> <label for="Radio1"></label>&nbsp;&nbsp;DIFFERENT BILLING ADDRESS<asp:Label ID="Label1" runat="server" ></asp:Label></strong><br/>	
    </div>
            <%--<input type="button" class="proceed" value="PROCEED" onclick="SetShipping();" />--%>
    <%--<input type="submit" class="proceed" value="PROCEED" onclick="SetShipping();" />--%>
        <%--<input type="button" value="RESET" class="proceedBack" style="float:right" onclick="ResetAddress();" />--%>
                
                
                
</div>
        </div>
   <div style="clear:both" ></div>
</div>
<!--SHIPPING end -->

<!--BILLING ADDDRESS Start -->
<div id="divBilling" class="ProcessBox CUSTBOX" style="height:auto;margin-top:0px;border-top-width:0px;display:none;">
<article class="page-art">
        <h1 class="page-titleSmallCust"><span class="" >&nbsp;&nbsp;</span>BILLING DETAILS</h1>        
        </article>
        <div class ="ProcesBoxInner">
        <div style="width:96%;" >
                 
           <div class="contact-form_grid" style="float:left; text-align:left; width:50%;height:auto;padding-right:20px;">
		
			<h3 class="ContactLabel">FIRST NAME<em style="color:Red">*</em></h3>			
		    <input id="billing_name" name="billing_name" runat="server" clientidmode="Static" class="textbox AlphaClass"  maxlength="22" type="text" value=""/>
		
			<h3 class="ContactLabel">MOBILE NO.<em style="color:Red">*</em></h3>
			
				<input id="billing_tel" name="billing_tel" runat="server" clientidmode="Static" class="textbox NumberClass" type="text" value="" maxlength="10"/>
			
            <h3 class="ContactLabel">ADDRESS<em style="color:Red">*</em></h3>

            <input id="txtFlatB" name="txtFlatB" runat="server" placeholder="Flat No." title="Flat No." clientidmode="Static" maxlength="8"  class="textbox" type="text" value="" style="width:35%;float:left" />
            <input id="txtBuildingB" name="txtBuildingB" runat="server" placeholder="Building Name" title="Building Name" clientidmode="Static" maxlength="50"  class="textbox" type="text" value="" style="width:60%;float:right"/>
            <div style="clear:both"></div>
            <input id="txtStreetB" name="txtStreetB" runat="server" placeholder="Street" title="Street" clientidmode="Static" maxlength="100"  class="textbox" type="text" value="" style="width:100%;float:left"/>
            <input id="txtLocationB" name="txtLocationB" runat="server" placeholder="Location" clientidmode="Static" maxlength="100"  class="textbox" type="text" value="" style="display:none;width:48%;float:right"/>

            
            <textarea id="billing_address" name="billing_address" runat="server" clientidmode="Static" class="textbox" maxlength="200"  rows="4" style="height:116px;;display:none" ></textarea>

		
		
			<h3 class="ContactLabel">PINCODE<em style="color:Red">*</em></h3>
	
				<input id="billing_zip" name="billing_zip" runat="server" clientidmode="Static" maxlength="6"  class="textbox NumberClass" type="text" value=""/>
				
        </div>

          <div class="contact-form_grid" style="float:left; text-align:left; width:50%;height:auto; padding-left:20px;">
          
			<h3 class="ContactLabel">Email Address</h3>
			<input id="txtLastNameB" name="txtLastNameB" runat="server" clientidmode="Static" class="textbox" maxlength="60" type="text" readonly value=""/>
			
		
		

                
			<h3 class="ContactLabel">COMPANY NAME</h3>		
			<input id="txtCompanyNameB" class="textbox AlphaClass" runat="server" clientidmode="Static" maxlength="22" type="text" value=""/>
			
            <h3 class="ContactLabel">LANDMARK</h3>		
			<input id="txtLandMarkB" class="textbox AlphaClass" runat="server" clientidmode="Static" maxlength="22" type="text" value=""/>

            <h3 class="ContactLabel">CITY<em style="color:Red">*</em></h3>		
			    <input id="billing_city" name="billing_city" runat="server" clientidmode="Static" class="textbox AlphaClass"  maxlength="22" type="text" value="Mumbai"/>

            <h3 class="ContactLabel">STATE<em style="color:Red">*</em></h3>		
			<input id="billing_state" name="billing_state" runat="server" clientidmode="Static" class="textbox AlphaClass"  maxlength="22" type="text" value="Maharashtra"/>
		
        
			
          </div>
             <div style="clear:both" ></div>
          <div style="width:auto; height: 20px;font-size:12px" class="SearchTxt"  >
    </div>

    <input type="button" value="RESET" class="proceedBack" style="float:right" onclick="ResetAddressB();" />
    <%--<asp:Button ID="btnBill" class="proceed" runat="server" Text="PROCEED" onclick="btnSub_Click" OnClientClick="return SetShipping();"  />--%>
                <%--<input type="submit" class="proceed" value="PROCEED" onclick="return SetBilling();" />--%>
                <%--<input type="button" value="BACK" class="proceedBack" onclick="  $('#divShipping').show();$('#divBilling').back(); " />--%>
                
</div>
        </div>
   <div style="clear:both" ></div>
</div>
<!--BILLING ADDDRESS end -->

      <div style="clear:both" ></div>

      
      <!--Shikha work Start -->
<div id="divQuantity1" class="ProcessBox CUSTBOX" style="height:auto;margin-top:0px;border-top-width:0px">
<article class="page-art">
        <h1 class="page-titleSmallCust"><span class="" >&nbsp;&nbsp;</span>ORDER DETAILS</h1>        
        </article>
        <div class ="ProcesBoxInner">
        <div style="width:100%;" >
            
            <table id="table1" class="tableCart tbl" cellspacing="1" width="100%" align="center" cellpadding="5" >
                 <thead>
                 <tr class='divRow dataHeader' style='background:#F16822;color:#fff;font-family:RobotoBold;font-size:1.2em;' ><td>ORDER</td><td>PRODUCT</td><td>Total No. Of Meals</td><td align="center">AMOUNT</td></tr>
                 </thead>
				    <tbody>		        
                    <%--<tr class="divRow"><td style="width:10%;"></td><td style="width:60%;" id="divPNAME"></td><td style="width:30%;"><span id='spCharge' class='price'></span></td></tr>--%>                                        
                    <asp:Literal ID="tbOrders" runat="server"></asp:Literal>
                        <tr id="trdiscount" runat="server"  class="divRow"><td colspan="3" style="width:70%;" align="right"><span class='priceTotaltxt'>DISCOUNT(5%)<span class='sppp'>&nbsp;&nbsp;&nbsp;</span></span></td><td style="width:30%;" align="right" ><span id='spnDiscount' runat="server" class='priceTotal'></span></td></tr>
                    <tr class="divRow"><td colspan="3" style="width:70%;" align="right"><span class='priceTotaltxt'>DELIVERY CHARGE&nbsp;&nbsp;&nbsp;</span></td><td style="width:30%;" align="right" ><span class="RSBig"></span><span id='spnShip'  runat="server" class='priceTotal'></span></td></tr>
                    <tr class="divRow" id="trTran" runat="server"  ><td colspan="3" style="width:70%;" align="right"><span class='priceTotaltxt' runat="server" id="spOT" >ONLINE PROCESSING CHARGE&nbsp;&nbsp;&nbsp;</span></td><td style="width:30%;" align="right" ><span id='spnTrns' runat="server"  class='priceTotal'></span></td></tr>
                    <tr class="divRow"><td colspan="3" style="width:70%;" align="right"><span class='priceTotaltxt onlineGST'><span id="Strong1" runat="server" class='sppp'>SGST:2.5%&nbsp;&nbsp;&nbsp;</span></span></td><td style="width:30%;" align="right" ><span id='spnSGST' runat="server" class='priceTotal onGST'></span></td></tr>
                        <tr class="divRow"><td colspan="3" style="width:70%;" align="right"><span class='priceTotaltxt onlineGST'><span id="Span1" runat="server" class='sppp'>CGST:2.5%&nbsp;&nbsp;&nbsp;</span></span></td><td style="width:30%;" align="right" ><span id='spnCGST' runat="server" class='priceTotal onGST'></span></td></tr>
                    <tr class="divRow"><td colspan="3" style="width:70%;" align="right"><span class='priceTotaltxt'>TOTAL AMOUNT&nbsp;&nbsp;&nbsp;</span></td><td style="width:30%;" align="right" class='priceTotal' ><span id='spnOnlineGrandTotal' runat="server"></span></td></tr>
				</tbody>                
                
                </table>


                    <%--<table id="tableQuantity" class="tbl" cellspacing="1" width="100%" align="center" cellpadding="5" >
				    <tbody>															                    
                    <asp:Literal ID="tbOrders" runat="server"></asp:Literal>
				</tbody></table>--%>

                <asp:Button ID="btnSub" class="proceed" runat="server" Text="PLACE ORDER" onclick="btnSub_Click" OnClientClick="return GOTOPAYMENTOnProcess();"  />
                <asp:Button ID="btnProcC" class="proceed" Visible="false" runat="server" Text="PLACE ORDER FOR CUSTOMER" onclick="btnProcC_Click" OnClientClick="return GOTOPAYMENTOnProcess();"/>
                
                
</div>
        </div>
   <div style="clear:both" ></div>
</div>
<!--Shikha work end -->


      </div>




    <script type="text/javascript">


        function SaveShipping() {

            //Note use last name as emaiid
            var shippingBilling = new ShippingBilling();
            
            shippingBilling.Id = 0;
        
            shippingBilling.UserId = loggiedIn;
       
            shippingBilling.RequestId = requestId;

            shippingBilling.FirstName = Trim(document.getElementById("delivery_name").value);
          
            shippingBilling.LastName = Trim(document.getElementById("txtLastName").value);
            shippingBilling.mobile = Trim(document.getElementById("delivery_tel").value);
            shippingBilling.CompanyName = Trim(document.getElementById("txtCompanyName").value);

            //Create address              
            document.getElementById("delivery_address").value = Trim($("#txtFlat").val()) +", "+ Trim($("#txtBuilding").val()) +", "+ Trim($("#txtStreet").val()+", "+$("#txtLocation").val());




            shippingBilling.Address = Trim($("#txtFlat").val()) + "$" + Trim($("#txtBuilding").val()) + "$" + Trim($("#txtStreet").val() + "$" + $("#txtLocation").val()); // Trim(document.getElementById("delivery_address").value);
            shippingBilling.City = Trim(document.getElementById("delivery_city").value);
            shippingBilling.State = Trim(document.getElementById("delivery_state").value);
            shippingBilling.LandMark = Trim(document.getElementById("txtLandMark").value);
            shippingBilling.Pincode = Trim(document.getElementById("delivery_zip").value);

            if ($("#chkSamAsShipping").is(':checked')) {
                            

                            //Need to set control value too for ccavenu posting -start
                    document.getElementById("billing_name").value = Trim(document.getElementById("delivery_name").value);
                    document.getElementById("txtLastNameB").value = Trim(document.getElementById("txtLastName").value);
                    document.getElementById("billing_tel").value = Trim(document.getElementById("delivery_tel").value);
                    document.getElementById("txtCompanyNameB").value = Trim(document.getElementById("txtCompanyName").value);
                    $("#billing_address").val($("#delivery_address").val());
//                    $("#txtFlat").val($("#txtFlatB").val());
//                    $("#txtBuilding").val($("#txtBuildingB").val());
                    //                    $("#txtStreet").val($("#txtStreetB").val());

                    $("#txtFlatB").val($("#txtFlat").val());
                    $("#txtBuildingB").val($("#txtBuilding").val());
                    $("#txtStreetB").val($("#txtStreet").val());

                    document.getElementById("billing_city").value = Trim(document.getElementById("delivery_city").value);
                    document.getElementById("billing_state").value = Trim(document.getElementById("delivery_state").value);
                    document.getElementById("txtLandMarkB").value = Trim(document.getElementById("txtLandMark").value);
                    document.getElementById("billing_zip").value = Trim(document.getElementById("delivery_zip").value);
                    //Need to set control value too for ccavenu posting -end
                  

                shippingBilling.FirstNameB = Trim(document.getElementById("delivery_name").value);
                shippingBilling.LastNameB = Trim(document.getElementById("txtLastName").value);
                shippingBilling.mobileB = Trim(document.getElementById("delivery_tel").value);
                shippingBilling.CompanyNameB = Trim(document.getElementById("txtCompanyName").value);
                shippingBilling.AddressB = Trim($("#txtFlat").val()) + "$" + Trim($("#txtBuilding").val()) + "$" + $("#txtLocation").val(); // Trim(document.getElementById("delivery_address").value);
                shippingBilling.CityB = Trim(document.getElementById("delivery_city").value);
                shippingBilling.StateB = Trim(document.getElementById("delivery_state").value);
                shippingBilling.LandMarkB = Trim(document.getElementById("txtLandMark").value);
                shippingBilling.PincodeB = Trim(document.getElementById("delivery_zip").value);

                shippingBilling.CreatedDate = '';
            }
            else {
                shippingBilling.FirstNameB = Trim(document.getElementById("billing_name").value);
                shippingBilling.LastNameB = Trim(document.getElementById("txtLastNameB").value);
                shippingBilling.mobileB = Trim(document.getElementById("billing_tel").value);
                shippingBilling.CompanyNameB = Trim(document.getElementById("txtCompanyNameB").value);

                document.getElementById("billing_address").value = Trim($("#txtFlatB").val()) + ", " + Trim($("#txtBuildingB").val()) + ", " + Trim($("#txtStreetB").val());

                shippingBilling.AddressB = Trim($("#txtFlatB").val()) + "$" + Trim($("#txtBuildingB").val()) + "$" + Trim($("#txtStreetB").val()+"$"+$("#txtLocationB").val()); // Trim(document.getElementById("billing_address").value);
                shippingBilling.CityB = Trim(document.getElementById("billing_city").value);
                shippingBilling.StateB = Trim(document.getElementById("billing_state").value);
                shippingBilling.LandMarkB = Trim(document.getElementById("txtLandMarkB").value);
                shippingBilling.PincodeB = Trim(document.getElementById("billing_zip").value);
                shippingBilling.CreatedDate = '';
            }

            
          
//location = (location == "") ? "0" : location;




            //$("#ImgProgress img").css("margin-top", "350px");

            //$("#ImgProgress").height($("#divMain").height() + 160).show();

            //Note use last name as emaiid

            $.ajax({
                type: "POST",
                url: "KompServices.asmx/SubmitShippingBilling",
                contentType: "application/json; charset=utf-8",
                data: "{shippingBilling:" + JSON.stringify(shippingBilling) + "}",  
                dataType: "json",
                success: AjaxSubmitUserSucceededPP,
                error: function (er) { swal(err.d); }
            });



            return true;
        }


        function AjaxSubmitUserSucceededPP(r) {
            
            if (r.d > 0) 
            {

                swal({ title: "Please wait...", text: "", timer: 15000, showConfirmButton: false });
            //alert('124');
            
            if (IsPaymentEnabled == 0) 
                {


                    if (method == "11" || method == "12" || method == "13" || method == "14") {
                    
                       // window.location.href = "ConfirmationPage.aspx?method=" + method + "&referanceNo=123&PaymentDone=0&requestId=" + requestId;
                        //return false;
                        swal({ title: "Thanks for placing offline order!", text: "", timer: 25000, showConfirmButton: false });
                        //swal("Thanks for placing offline order!", "", "success");
                        return false;
                    }
                    else {
                       // window.location.href = "Stub.aspx?requestId=" + requestId;
                      return true;
                    }
                }
                else 
                {
                    //Payment enabled

                    if (method == '11' || method == '12' || method == '13' || method == '14') 
                    {//Offlne     
                        //                        alert('now');
                        swal("Thanks for placing offline order!", "", "success");                 
//                        window.location = "ConfirmationPage.aspx?method=" + method + "&referanceNo=123&PaymentDone=0&requestId=" + requestId;
                        return false;
                    }
                    else {
                        //Online ccAvenue
                        //swal('posting to thrid');                        
                       
                       //$.post( "ccavRequestHandler.aspx", $("form").serialize() );                       
//                        $.ajax({
//                            type: 'post',
//                            url: 'ccavRequestHandler.aspx',
//                            data: $('#customerData').serialize()),
//                            success: function (msg) {
//                                swal("Success");
//                            }
//                        });

                        //document.customerData.submit();
                        //document.forms[0].submit();
                        //$.post("PaymentProcess.aspx");                        
                        return true;
                       
                    }
                }
//            }            
//            else {
//                loggiedIn = r.d;

//                swal('Seems some problem . Contat to admin!!');
//            
//                return false;
            }

//            $("#ImgProgress").hide();
        }


        function GOTOPAYMENTOnProcess() {
            
            if (SetShipping() == false) {
                //swal();
            //    swal('APPP');
                return false;
            }

            //CopyShippingToBilling();
            
            if (SetBilling() == false) {
                //swal();
            
                return false;
            }

            
            return SaveShipping();


           // swal('P');
                
              
            
        }

        function ShippingBilling() 
        {
            var Id;
            var UserId;
            var RequestId;
            var FirstName;
            var LastName;
            var mobile;
            var CompanyName;
            var Address;
            var City;
            var State;
            var LandMark;
            var Pincode;
            var FirstNameB;
            var LastNameB;
            var mobileB;
            var CompanyNameB;
            var AddressB;
            var CityB;
            var StateB;
            var LandMarkB;
            var PincodeB;
            var CreatedDate;
        }

        

    </script>
    </form>
</asp:Content>
