<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="KitchenOnMyPlate.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<input id="hdnCoachingId" type="hidden" value="0"  />

                <!--SLIDERNEWSTRT-->
                <div id="divSlider" runat="server" >
<!---/End-Animation---->
                <link rel="stylesheet" type="text/css" href="Styles/slider.css" />
                <link rel="stylesheet" type="text/css" href="Styles/animate.css" />         
                <div class="slider">
	    <div class="callbacks_container">
	      <ul class="rslides" id="slider">
	        <li>
	          <img src="images/banner/feedback.jpg" alt="">
	          
            <%-- <div class="caption wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>EAT HEALTHY.</span></h3>
	          </div>

              <div class="caption1 wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>SKIP THE DIET.</span></h3>
	          </div>--%>

	        </li>	       

	      </ul>
	  </div>
  </div>

               <%--     <div class="Tiffin">
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
                        <h1 class="page-titleMain">FEEDBACK</h1>
                        </article>
                  <div class="col-ms-12">

                  <div style="width:100%; height:auto;float:left;" >
                 

                  	<p> At KOMP, we make every effort to constantly improve our line of meal packages and level of service. Your feedback is important to us. Please share your thoughts with us in order to offer you a better service by filling out the “Feedback Form” below. We look forward to hearing from you!</p>
                   

<!--Contact Start-->
   
        
       
       <script type="text/javascript">

           var IsClickable = true;

           $(function () {

               $("#sendBtn").click(function () {

                   if (!IsClickable) {
                       return false;
                   }

                   var name = $("#txtCname").val();
                   var compName = $("#txtCompName").val();
                   // var location = $("#txtLocation").val();
                   var email = $("#txtCemail").val();
                   var mobile = $("#txtCphone").val();
                   var messaging = $("#messagingC").val();

                   // var voOfPPL = $("#txtNoOfPPL").val();
                   var bSTTimeToCallU = ""; //$("#messagingC").val(); //$("#txtBSTTimeToCallU").val();

                   if ($(".feedbacktable input:checked").length < 10) {
                       alert('Please Complete The Feedback Form.');
                       return false;
                   }

                   if (name == '') {
                       alert('Please enter name.');
                       $("#txtCname").focus();
                       return false;

                   }

                   //                   if (compName == '') {
                   //                       alert('Please enter company number.');
                   //                       $("#txtCompName").focus();
                   //                       return false;
                   //                   }


                   if (compName == '') {
                       alert('Please enter company name.');
                       $("#txtCompName").focus();
                       return false;
                   }

                   //                   if (voOfPPL == '') {
                   //                       alert('Please enter no of people.');
                   //                       $("#txtNoOfPPL").focus();
                   //                       return false;
                   //                   }

                   if (email == '') {
                       alert('Please enter email address.');
                       $("#txtCemail").focus();
                       return false;
                   }

                   if (mobile == '') {
                       alert('Please enter mobile number.');
                       $("#txtCphone").focus();
                       return false;
                   }

                   if (mobile.length < 10) {
                       alert('Please enter 10 digits contact number.');
                       $("#txtCphone").focus();
                       return false;
                   }







                   if (messaging == '') {
                       alert('Please enter message.');
                       $("#messagingC").focus();
                       return false;
                   }

                   bSTTimeToCallU = bSTTimeToCallU + "<br/><br/><b>FEEDBACK</b><br/><br/>";
                   bSTTimeToCallU = bSTTimeToCallU + "<table>";
                   bSTTimeToCallU = bSTTimeToCallU + "<tr> <td>Taste of food : </td><td>" + $("input[name='testoffood']:checked").attr("fdbk") + "</td> </tr>";
                   bSTTimeToCallU = bSTTimeToCallU + "<tr> <td>Freshness of food : </td><td>" + $("input[name='testoffood1']:checked").attr("fdbk") + "</td> </tr>";
                   bSTTimeToCallU = bSTTimeToCallU + "<tr> <td>Taste of food Presentation : </td><td>" + $("input[name='testoffood2']:checked").attr("fdbk") + "</td> </tr>";
                   bSTTimeToCallU = bSTTimeToCallU + "<tr> <td>Variety of Dishes / Meal Packages : </td><td>" + $("input[name='testoffood3']:checked").attr("fdbk") + "</td> </tr>";
                   bSTTimeToCallU = bSTTimeToCallU + "<tr><td>Packaging of Food : </td><td>" + $("input[name='testoffood4']:checked").attr("fdbk") + "</td></tr>";
                   bSTTimeToCallU = bSTTimeToCallU + "<tr><td>Schedule (Delivered on time and to the correct location) : </td><td>" + $("input[name='testoffood5']:checked").attr("fdbk") + "</td></tr>";
                   bSTTimeToCallU = bSTTimeToCallU + "<tr><td>Ordering system-Online : </td><td>" + $("input[name='testoffood6']:checked").attr("fdbk") + "</td></tr>";
                   bSTTimeToCallU = bSTTimeToCallU + "<tr><td>Customer Support (On call) : </td><td>" + $("input[name='testoffood7']:checked").attr("fdbk") + "</td></tr>";
                   bSTTimeToCallU = bSTTimeToCallU + "<tr><td>Staff Behavior : </td><td>" + $("input[name='testoffood8']:checked").attr("fdbk") + "</td></tr>";
                   bSTTimeToCallU = bSTTimeToCallU + "<tr><td>Overall Experience and Satisfaction : </td><td>" + $("input[name='testoffood9']:checked").attr("fdbk") + "</td></tr>";
                   bSTTimeToCallU = bSTTimeToCallU + "</table>";


                   //IsClickable = false;

                   $.ajax({
                       type: "POST",
                       url: "KompServices.asmx/CorporateMessage",
                       contentType: "application/json; charset=utf-8",
                       data: "{name:'" + name + "',mobile:'" + mobile + "',email:'" + email + "',message:'" + messaging + "',compName:'" + compName + "',location:'',noofpeople:'',besttimetocall:'" + bSTTimeToCallU + "'}",
                       dataType: "json",
                       success: function (w) {

                           alert("Thank You for sending message, we will contact you as early as possible");
                           $("#txtCname,#txtCompName,#txtLocation,#txtNoOfPPL,#txtCemail,#txtCompName,#txtCphone,#messagingC").val('');
                           IsClickable = false;
                           //$("#bmsgC").fadeIn(2000, function () { $("#bmsgC").fadeOut(2000) })
                       },
                       error: function (w) { alert(w.d) }
                   });
               });
           });
           function txtCname_onclick() {

           }

       </script>
   

      <table class="tbl feedbacktable" width="100%" cellspacing="0" cellpadding="2" align="center">

<tr  class="divRowHeader feedbackheader" valign="middle">
<td align="center" style="width:10%"><span><strong>Sr. No.</strong></span></td>
<td align="center" style="width:30%"><span><strong>Service </strong></span></td>
<td align="center" style="width:12%"><span><strong>Delighted</strong></span></td>
<td align="center" style="width:12%"><span><strong>Happy</strong></span></td>
<td align="center" style="width:12%"><span><strong>Ok</strong></span></td>
<td align="center" style="width:12%"><span><strong>Needs Improvement</strong></span></td>
<td align="center" style="width:12%" ><span><strong>Needs Immediate Attention</strong></span></td>
</tr>
<tr class="divRow" valign="middle" >
<td align="center">1.</td>
<td align="left">Taste of food</td>
<td align="center"><input id="rd1" fdbk="Delighted" type="radio" name="testoffood" /><label for="rd1" ></label> </td>
<td align="center"><input id="rd2" fdbk="Happy" type="radio" name="testoffood" /><label for="rd2" ></label> </td>
<td align="center"><input id="rd3" fdbk="Ok" type="radio" name="testoffood" /><label for="rd3" ></label> </td>
<td align="center"><input id="rd4" fdbk="Needs Improvement" type="radio" name="testoffood" /><label for="rd4" ></label> </td>
<td align="center"><input id="rd5" fdbk="Needs Immediate Attention" type="radio" name="testoffood" /><label for="rd5" ></label> </td>
</tr>
<tr class="divRow" valign="middle">
<td align="center">2.</td>
<td align="left">Freshness of food</td>
<td align="center"><input id="rd6" fdbk="Delighted" type="radio" name="testoffood1"  /><label for="rd6" ></label> </td>
<td align="center"><input id="rd7" fdbk="Happy" type="radio" name="testoffood1"  /><label for="rd7" ></label> </td>
<td align="center"><input id="rd8" fdbk="Ok" type="radio" name="testoffood1" /><label for="rd8" ></label> </td>
<td align="center"><input id="rd9" fdbk="Needs Improvement" type="radio" name="testoffood1" /><label for="rd9" ></label> </td>
<td align="center"><input id="rd10" fdbk="Needs Immediate Attention" type="radio" name="testoffood1" /><label for="rd10" ></label> </td>
</tr>
<tr class="divRow" valign="middle">
<td align="center">3.</td>
<td align="left">Taste of food Presentation</td>
<td align="center"><input id="rd11" fdbk="Delighted" type="radio" name="testoffood2"  /><label for="rd11" ></label> </td>
<td align="center"><input id="rd12" fdbk="Happy" type="radio" name="testoffood2"  /><label for="rd12" ></label> </td>
<td align="center"><input id="rd13" fdbk="Ok" type="radio" name="testoffood2" /><label for="rd13" ></label> </td>
<td align="center"><input id="rd14" fdbk="Needs Improvement" type="radio" name="testoffood2" /><label for="rd14" ></label> </td>
<td align="center"><input id="rd15" fdbk="Needs Immediate Attention" type="radio" name="testoffood2" /><label for="rd15" ></label> </td>
</tr>
<tr class="divRow" valign="middle">
<td align="center">4.</td>
<td align="left">Variety of Dishes / Meal Packages</td>
<td align="center"><input id="rd16" fdbk="Delighted" type="radio" name="testoffood3" /><label for="rd16" ></label> </td>
<td align="center"><input id="rd17" fdbk="Happy" type="radio" name="testoffood3" /><label for="rd17" ></label> </td>
<td align="center"><input id="rd18" fdbk="Ok" type="radio" name="testoffood3"  /><label for="rd18" ></label> </td>
<td align="center"><input id="rd19" fdbk="Needs Improvement" type="radio" name="testoffood3"  /><label for="rd19" ></label> </td>
<td align="center"><input id="rd20" fdbk="Needs Immediate Attention" type="radio" name="testoffood3"  /><label for="rd20" ></label> </td>
</tr>
<tr class="divRow" valign="middle">
<td align="center">5.</td>
<td align="left">Packaging of Food</td>
<td align="center"><input id="rd21" fdbk="Delighted" fdbk="Delighted" type="radio" name="testoffood4"  /><label for="rd21" ></label> </td>
<td align="center"><input id="rd22" fdbk="Happy" type="radio" name="testoffood4"  /><label for="rd22" ></label> </td>
<td align="center"><input id="rd23" fdbk="Ok" type="radio" name="testoffood4"  /><label for="rd23" ></label> </td>
<td align="center"><input id="rd24" fdbk="Needs Improvement" type="radio" name="testoffood4"  /><label for="rd24" ></label> </td>
<td align="center"><input id="rd25" fdbk="Needs Immediate Attention" type="radio" name="testoffood4"  /><label for="rd25" ></label> </td>
</tr>
<tr class="divRow" valign="middle">
<td align="center">6.</td>
<td align="left">Schedule (Delivered on time and to the correct location)</td>
<td align="center"><input id="rd26" fdbk="Delighted" type="radio" name="testoffood5" /> <label for="rd26" ></label></td>
<td align="center"><input id="rd27" fdbk="Happy" type="radio" name="testoffood5" /> <label for="rd27" ></label></td>
<td align="center"><input id="rd28" fdbk="Ok" type="radio" name="testoffood5" /> <label for="rd28" ></label></td>
<td align="center"><input id="rd29" fdbk="Needs Improvement" type="radio" name="testoffood5" /> <label for="rd29" ></label></td>
<td align="center"><input id="rd30" fdbk="Needs Immediate Attention" type="radio" name="testoffood5" /> <label for="rd30" ></label></td>
</tr>
<tr class="divRow"  valign="middle">
<td align="center" class="style1">7.</td>
<td align="left" class="style1">Ordering system-Online</td>
<td align="center" class="style1"><input fdbk="Delighted" id="rd31" name="testoffood6" type="radio" /><label for="rd31" ></label> </td>
<td align="center" class="style1"><input fdbk="Happy" id="rd32" name="testoffood6" type="radio" /><label for="rd32" ></label> </td>
<td align="center" class="style1"><input fdbk="Ok" id="rd33" name="testoffood6" type="radio" /><label for="rd33" ></label> </td>
<td align="center" class="style1"><input fdbk="Needs Improvement" id="rd34" name="testoffood6" type="radio" /><label for="rd34" ></label> </td>
<td align="center" class="style1"><input fdbk="Needs Immediate Attention" id="rd35" name="testoffood6" type="radio" /><label for="rd35" ></label> </td>
</tr>
<tr class="divRow" valign="middle">
<td align="center">8.</td>
<td align="left">Customer Support (On call)</td>
<td align="center"><input id="rd36" fdbk="Delighted" type="radio" name="testoffood7" /><label for="rd36" ></label> </td>
<td align="center"><input id="rd37" fdbk="Happy" type="radio"  name="testoffood7" /><label for="rd37" ></label> </td>
<td align="center"><input id="rd38" fdbk="Ok" type="radio" name="testoffood7" /><label for="rd38" ></label> </td>
<td align="center"><input id="rd39" fdbk="Needs Improvement" type="radio" name="testoffood7" /><label for="rd39" ></label> </td>
<td align="center"><input id="rd40" fdbk="Needs Immediate Attention" type="radio" name="testoffood7" /><label for="rd40" ></label> </td>
</tr>
<tr class="divRow" valign="middle">
<td align="center">9.</td>
<td align="left">Staff Behavior</td>
<td align="center"><input id="rd41" fdbk="Delighted" type="radio" name="testoffood8" /><label for="rd41" ></label> </td>
<td align="center"><input id="rd42" fdbk="Happy" type="radio" name="testoffood8" /><label for="rd42" ></label> </td>
<td align="center"><input id="rd43" fdbk="Ok" type="radio" name="testoffood8" /><label for="rd43" ></label> </td>
<td align="center"><input id="rd44" fdbk="Needs Improvement" type="radio" name="testoffood8" /><label for="rd44" ></label> </td>
<td align="center"><input id="rd45" fdbk="Needs Immediate Attention" type="radio" name="testoffood8" /><label for="rd45" ></label> </td>
</tr>
<tr class="divRow" valign="middle">
<td align="center">10.</td>
<td align="left">Overall Experience and Satisfaction</td>
<td align="center"><input id="rd46" fdbk="Delighted" type="radio" name="testoffood9" /><label for="rd46" ></label> </td>
<td align="center"><input id="rd47" fdbk="Happy"  type="radio" name="testoffood9" /><label for="rd47" ></label> </td>
<td align="center"><input id="rd48" fdbk="Ok" type="radio" name="testoffood9" /><label for="rd48" ></label> </td>
<td align="center"><input id="rd49" fdbk="Needs Improvement" type="radio" name="testoffood9" /><label for="rd49" ></label> </td>
<td align="center"><input id="rd50" fdbk="Needs Immediate Attention" type="radio" name="testoffood9" /><label for="rd50" ></label> </td>
</tr>
    

</table>
       
			     <div class="contact-form_grid" style="float:left; text-align:left">

              
                    <div style="clear:both" ></div> 
                    
                     <asp:HiddenField ID="hdnCV" runat="server" />
                    
                    
                    <div class="divider" style="margin-top:0px; margin-bottom:1px; "></div>
                   
                      		<div style="clear:both" ></div>


                         
       <div style="clear:both" ></div>
            
				   <div style="width:100%">
                     
                     <div style="width:35%;height:auto; float:left; padding-right:15px;" >
                     <h3 class="ContactLabel">YOUR NAME:<em style="color:Red">*</em></h3>
					    <input type="text" id="txtCname" runat="server" clientidmode="Static" maxlength="50" class="textbox" placeholder="Enter your full name here.." onclick="return txtCname_onclick()" />

                        <h3 class="ContactLabel">EMAIL ID<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox EmailClass" id="txtCemail" runat="server" clientidmode="Static" maxlength="60"  placeholder="Enter your email address here.." />

                        <h3 class="ContactLabel">COMMENTS<em style="color:Red">*</em></h3>
                        <textarea  class="textbox" id="messagingC" placeholder="Enter your comments here.."></textarea>&nbsp;

                     </div>
                       
                     <div style="width:35%;height:auto; float:left; padding-left:15px;" >
                        
                        <h3 class="ContactLabel">COMPANY NAME:<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="txtCompName" runat="server" clientidmode="Static" maxlength="50"  placeholder="Enter your company name here.." />
                        
                        <h3 class="ContactLabel">CONTACT NUMBER<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="txtCphone" runat="server" clientidmode="Static" maxlength="10" placeholder="Enter contact number here.." />

                     </div>
                        <div style="clear:both" ></div>
                        <%--<div>You can also email your feedback directly to support@kitchenonmyplate.com</div>--%>
                        <input type="button" class="proceed" style="float:left;margin-left:0px;margin-top:-15px !important;" id="sendBtn" value="SUBMIT"/>
                        <div style="clear:both;margin-top:6px;" ></div><br />
                        <div style="color:Black" >You can also email your feedback directly to support@kitchenonmyplate.com</div>

                                       
                      <div style="clear:both" ></div>
					 
				   </div>


			      </div>
   			  
              <div style="clear:both" ></div> 

        <!--Contact End-->

         </div>
                  <div style="width:25%; height:auto;float:left;" >

                  <%--<div class='fb-like-box' data-href='https://www.facebook.com/kotacoaching' data-width='90%' data-height='280' data-colorscheme='light' data-show-faces='true' data-header='true' data-stream='false' data-show-border='true'></div>--%>
                  <div style="clear:both;height:10px" ></div>



                  </div>

                   </div>
                      
     </div>           
     <!--container end here-->
</asp:Content>
