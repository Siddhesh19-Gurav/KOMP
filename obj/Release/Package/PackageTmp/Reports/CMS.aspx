<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="CMS.aspx.cs" Inherits="KitchenOnMyPlate.Reports.CMS" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="~/Scripts/jsValidation.js" type="text/javascript"></script>
    <script src="~/Scripts/jsMaster.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.leanModal.min.js" type="text/javascript"></script>
    <link href="~/Styles/modelstyle.css" rel="stylesheet" type="text/css" />
    <link href="../fonts/font-roboto.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">

 <script src="~/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/Scripts/jquery.leanModal.min.js" ></script>    
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/menu.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/modelstyle.css" rel="stylesheet" type="text/css" />
    
            <script type="text/javascript">
                var pageId = 0;

                $(function () {
                    $('form').submit(function (e) {
                        return false;
                    });


                    $('#modaltrigger').leanModalCenter({ top: 140, overlay: 0.45, closeButton: ".hidemodal" });
                });

                function ToolTipFocus(id, url) {
                    if ($("#" + id).val() == url) {
                        $("#" + id).val('');
                        $("#" + id).removeClass('ToolTipColor');
                    }
                }

                function ToolTipBlur(id, url) {
                    if ($("#" + id).val() == '') {
                        $("#" + id).val(url);
                        $("#" + id).addClass('ToolTipColor');
                    }
                }


                //login start
                function DoLogin() {

                    var txtuser = document.getElementById("userName").value;
                    var txtpwd = document.getElementById("passWord").value;

                    if (txtuser == '') {
                        alert("Please enter email Id.");
                        $("#userName").focus();
                        return false;
                    }

                    if (txtpwd == '') {
                        alert("Please enter Password .");
                        $("#passWord").focus();
                        return false;
                    }

                    if (txtuser != '') {

                        $.ajax({
                            type: "POST",
                            url: "../KompServices.asmx/IsValidUser",
                            contentType: "application/json; charset=utf-8",
                            data: "{userid:'" + txtuser + "',password:'" + txtpwd + "',rememberme:0}",
                            dataType: "json",
                            success: AjaxUserSucceeded2,
                            error: AjaxFailed
                        });
                    }
                    return false;
                }


                function AjaxUserSucceeded2(result) {

                    if (result.d) {

                        // $("#btnHide1").show(); 
                        //$("#ctl00$btnHide1").trigger('click');
                        //$("#btnHide1").triggerHandler('click');
                        //$("#btnHide1").click();
                        //var el = document.getElementById('btnHide1');
                        //el.click(); // 
                        //__doPostBack('ctl00$btnHide1', '');



                        CreateSessionOnMaster(document.getElementById("userName").value); //Create Session

                        //window.location.href="Default.aspx";

                    }
                    else {
                        alert('Invalid User Id or Password');
                        //$('#spanInvalis').css("visibility", "");
                    }

                }

                function AjaxFailed(result) {
                    alert("err1" + result.status + ' ' + result.statusText);
                }
                //login end


                function CreateSessionOnMaster(txtuser) {
                    if (txtuser != '') {                        
                        $.ajax({
                            type: "POST",
                            url: "../KompServices.asmx/CreateSession",
                            contentType: "application/json; charset=utf-8",
                            data: "{userid:'" + txtuser + "'}",
                            dataType: "json",
                            success: function (result) {
                               // if (result.d) {
                                    window.location.href = "CMS.aspx?c=234d3";
                                //}
                            },
                            error: function (errorMessage) { }
                        });
                    }
                    return false;
                }


</script>

<style type="text/css">
 .labelClNoBG
{ 
    width:auto; height:20px; color:#E3000C; font-weight:bold;text-align:left; font-size:16px;
    text-align:center;
 }
 
 .ContentPage
{
    background-color:#F4E7BD; width:974px;height:auto;
    margin:0 auto; margin-top:200px;
    border-radius: 8px; 
-moz-border-radius: 8px; 
-webkit-border-radius: 8px; 
border: 1px solid #FEEE50;
    }

.CenterContainerMostOut
{
width:976px;height:auto;background-color:#FFFDE4;margin: 0 auto;z-index:2;
border-radius: 8px; 
-moz-border-radius: 8px; 
-webkit-border-radius: 8px; 
border: 1px solid #FEEE50;
}

.CenterContainerOut
{
width:971px;height:auto;background-color:#FFFDE4; margin: 0 auto;
border-radius: 8px; 
-moz-border-radius: 8px; 
-webkit-border-radius: 8px; 
border: 5px solid #448368;
}

.CenterContainer
{
      height:auto;
width:970px;background-color:#FFFDE4;
border-radius: 8px; 
-moz-border-radius: 8px; 
-webkit-border-radius: 8px; 
border: 1px solid #FEEE50;
}

.proceed{background:#4b220c !important; float:right;  margin:0 auto; }
.proceedBack{background:#F16822 !important; float:left; }
.title01{margin-top:10px;color:#4b220c !important;font-size:23px; font-family:robotoBlack; margin:0 auto; }
</style>

<div class="contact-form_grid" style="padding-top:13em" >
    <div class="CenterContainerMostOut" >
        <div class="CenterContainerOut" >
          <div class="CenterContainer" style="margin:0 auto;"  >

   <div class="labelClNoBG" style=" width:500px; margin:0 auto" > 
              <div style='height:10px' ></div>
                <span class="title01" >KOMP Reporting System</span>
            </div>

 <div id="divNoLogin" runat="server" style="width:100px;height:200px;margin:0 auto;margin:" >
 <a href="#loginmodal" id="modaltrigger" style="text-decoration: none; font-weight:bold; outline:none; float:left; font-size:13px; color:#21942D;" >
 <input id="Button1" type="button" class="proceed" value="Login" />
 </a>
<div id="loginmodal" style="display:none" class="RoundCorner" >      
					<!-- put HTML-Content here / BEGIN -->
<span class='hidemodal'  style="padding:10px !important;" >X</span>
              
      <div id="spanInvalis" style="color: Red; float:left; margin-left:28px; background-color:#E1E4E6;  font-family:Verdana; font-size:11px;  margin-top:2px;  visibility:hidden">Invalid User!</div>
      
	  <div style="clear:both; text-align:center" >
      <img src="../images/logo.png" />
      
      </div>

      

      <div style="width: 230px;	 height: 220px;  font-family:Verdana;	 overflow: hidden;	 z-index:0;margin:0 auto" >      
      
       <input class=""   title="Enter User Id" placeholder="User Id" type="text" runat="server" maxlength="50" name="textfield" id="userName" />
     
     

     
     
     <input class="homeUsername ToolTipColor" style="float:left;margin-top:12px;" type="password" title="Password" placeholder="Password"  runat="server" maxlength ="12" name="textfield2" id="passWord" />
     

     <div style="clear:both" ></div>     
     

<%--     <div style="clear:both" ></div>     

     <div style="height:auto; margin:10px; width:316px;  color:#999999; font-family:Verdana;font-size:11px;margin:0 auto; text-align:center; margin-top:10px" >     
     <div style=" width:136px;float:left"><div style=" float:left; width:25px; height:31px; text-align:left "><input type="checkbox" name="checkbox" style=" background-color:transparent;margin-top:10px; border-width:0px;" id="Checkbox1" /></div>   <div style=" width:100px;float:left; font-size:13px; color:#333333;margin-top: 8px; margin-left:1px; text-align:left ">Remember me</div></div>
     <div style=" width:20px;float:left;margin-top:12px"><img alt="" src="img/sept.png"/> </div> 
     <div style=" width:112px;float:left;margin-top:9px"><a href="javascript:void(0)" onclick="ForgotPwd()" style=" margin-left:1px; color:#0099cc; font-family:Verdana;font-size:13px ; text-decoration:none;" title="" class="password">Forgot password</a></div>                  
      </div>--%>

        <div style="clear:both" ></div> 
     
              
              <input id="loginBttn" type="button" class="proceed"   onclick="return DoLogin();"  value="Login" />
      <%--<div id='imgLogin11' class="findPropertyOuter" style="margin:0 auto; margin-top:4px"  onclick="return DoLogin();"  >               
      <div style="height:30px;color:White; margin:0 auto; font-weight:bold; margin:0 auto; text-align:center; margin-top:0px;  font-family:Myriad Pro;font-size:22px;font-weight:bold;">Login</div>
     </div>   
     --%>

            


        </div>
					<!-- put HTML-Content here / END -->
				</div>
</div>          
 <div id="divLoggedLogin" runat="server" style="width:500px;height:300px; margin:0 auto;" visible="false" >
 <asp:LinkButton ID="logOut" runat="server" clientidmode="Static" CssClass="LogOutCss" style="float:right;color:#4b220c"  onclick="logOut_Click"> &nbsp; Logout</asp:LinkButton>
 <input id="Button6" type="button" onclick="window.location.href='DailyMealPlan.aspx'" class="proceedBack" value="Daily Meal Plan - Customised" />  
 <input id="Button7" type="button" onclick="window.location.href='DailyMealPlanNC.aspx'" class="proceedBack" value="Daily Meal Plan - Non Customised" />  
 <input id="Button11" type="button" onclick="window.location.href='DailyDeliveryTracking.aspx'" class="proceedBack" value="Daily Delivery Tracking" />  
 <input id="Button8" type="button" onclick="window.location.href='DailyPackagingName.aspx'" class="proceedBack" value="Daily Packaging Name" />  
 <input id="Button9" type="button" onclick="window.location.href='DailyPaymentStatus.aspx'" class="proceedBack" value="Daily Payment Status" />  
 <input id="Button10" type="button" onclick="window.location.href='DeliveryDatesSummary.aspx'" class="proceedBack" value="Delivery Dates Summary" />  
 


 <%--<input id="Button5" type="button" onclick="window.location.href='ReportMealDetails.aspx'" class="proceedBack" value="Ordered Meal Details" />  
 <input id="Button2" type="button" onclick="window.location.href='ReportStatusPayment.aspx'" class="proceedBack" value="Payment Status" />  
 <input id="Button4" type="button" onclick="window.location.href='ReportDelivery.aspx'" class="proceedBack" value="Delivery" />  
 <input id="Button3" type="button" onclick="window.location.href='ReportOrder.aspx'" style="display:none" class="proceedBack" value="Orders" /> --%> 

 <%--<input id="Button4" type="button" onclick="window.location.href='ReportLocationView.aspx'" class="proceedBack" value="Location View" />  --%> 
 <%--<input id="Button6" type="button" onclick="window.location.href='ReportTomorrowOrders.aspx'" class="proceedBack" value="Tomorrow's Orders" />  --%>
 </div>


</div>
        </div>
    </div>

 </div>
</form>
</body>
</html>
