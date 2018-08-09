<%@ Page Title="Contact us – Kitchenonmyplate" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="KitchenOnMyPlate.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="title" content=" Contact us – Kitchenonmyplate" />
<meta name="description" content="Contact KOMP for inquiries related tiffin services, meal, catering etc. To get in touch with us please fill in the form, or find contact information of Kitchen on my plate." />
    <meta name="keywords" content="Contact us, Contact us Kitchen on my plate" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script src="http://maps.google.com/maps/api/js?sensor=false"></script> <!-- Google Map -->
 <script type="text/javascript">
        function PropertiesMap() {

            /* Properties Array */
            var properties = [                
                { title:"Kitchen On My Plate",  lat:19.091409, lng:72.890552,  thumb:"images/logo.jpg",  url:"Default.aspx",  icon:"images/ad.png", }
				
				];

            /* Map Center Location - From Theme Options */
            var location_center = new google.maps.LatLng(properties[0].lat,properties[0].lng);

            var mapOptions = {
                zoom: 12,
                scrollwheel: false
            }

            var map = new google.maps.Map(document.getElementById("gmap"), mapOptions);

            var bounds = new google.maps.LatLngBounds();

            var markers = new Array();
            var info_windows = new Array();

            for (var i=0; i < properties.length; i++) {

                markers[i] = new google.maps.Marker({
                    position: new google.maps.LatLng(properties[i].lat,properties[i].lng),
                    map: map,
                    icon: properties[i].icon,
                    title: properties[i].title,
                    animation: google.maps.Animation.DROP
                });

                bounds.extend(markers[i].getPosition());

                info_windows[i] = new google.maps.InfoWindow({
                    content:    '<div class="map-property">'+
                        '<h4 class="property-title"><a class="title-link" href="'+properties[i].url+'">'+properties[i].title+'</a></h4>'+
                        '<a class="property-featured-image" href="'+properties[i].url+'"><img class="property-thumb" src="'+properties[i].thumb+'" alt="'+properties[i].title+'"/></a>'+                        
                        '</div>'
                });

                attachInfoWindowToMarker(map, markers[i], info_windows[i]);
            }

            map.fitBounds(bounds);

            /* function to attach infowindow with marker */
            function attachInfoWindowToMarker( map, marker, infoWindow ){
                google.maps.event.addListener( marker, 'click', function(){
                    infoWindow.open( map, marker );
                });
            }

        }

        google.maps.event.addDomListener(window, 'load', PropertiesMap);
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
	          <img src="images/banner/contact_us.jpg" alt="komp contatus">
	          
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
      
                  <div class="col-ms-12">
                  	
<!--Contact Start-->
       	<div class="contact" id="contact" >
        
       
       <script type="text/javascript">
           var IsClickable = true;
           $(function () {
               $("#sendBtn").click(function () {

                   if (!IsClickable) {
                       return false;
                   }

                   var name = $("#nameC").val();
               
                   var address = $("#txtAddr").val() + ","+ $("#txtpin").val();
               
                   var email = $("#emailC").val();
                   var mobile = $("#mobileC").val();

                   var messaging = $("#messagingC").val();


                   if (name == '') {
                       swal('Please enter name.');
                       $("#nameC").focus();
                       return false;
                   }

                   if (address == '') {
                       swal('Please enter address.');
                       $("#txtAddr").focus();
                       return false;
                   }

                   if ($("#txtpin").val() == '') {
                       swal('Please enter pincode.');
                       $("#txtpin").focus();
                       return false;
                   }

                   if (mobile == '') {
                       swal('Please enter mobile number.');
                       $("#mobileC").focus();
                       return false;
                   }

                   if (mobile.length < 10) {
                       swal('Mobile number must be 10 digits');
                       $("#mobileC").focus();
                       return false;
                   }

                   if (email == '') {
                       swal('Please enter email address.');
                       $("#emailC").focus();
                       return false;
                   }
                   if (messaging == '') {
                       swal('Please enter message.');
                       $("#messagingC").focus();
                       return false;
                   }


                   IsClickable = false;
                   $.ajax({
                       type: "POST",
                       url: "KompServices.asmx/SendMsgToAgent",
                       contentType: "application/json; charset=utf-8",
                       data: "{name:'" + name + " <br/>Address : "+address +"',mobile:'" + mobile + "',email:'" + email + "',message:'" + messaging + "',agentId:0,propertyId:0}",
                       dataType: "json",
                       success: function (w) {

                           swal("Thank You for sending message, we will contact you as early as possible");
                           $("#nameC,#emailC,#mobileC,#messagingC").val('');
                           IsClickable = false;
                           //$("#bmsgC").fadeIn(2000, function () { $("#bmsgC").fadeOut(2000) })
                       },
                       error: function (w) { alert(w.d) }
                   });
               });
           });
           
</script>
   


       
			     <div class="contact-form_grid" style="float:left; text-align:left">

              
                    <div style="clear:both" ></div> 
                    
                    
                    
                    
                    <div class="divider" style="margin-top:0px; margin-bottom:1px; "></div>
                   
                      		<div style="clear:both" ></div>
<%--
                            <div style="float:left;width:20%">
                       <img alt="contact KOMP" src="images/contKOMP.png" />
                       </div>--%>

                            <div style="float:left;width:100%">
      <article class="page-art">

      <div style="width:45%;float:left"><h1 class="page-titleMain">CONTACT US</h1></div>
      <div style="width:50%;float:left" class="HideOnMobile" ><h1 class="page-titleMain" style="" >ENQUIRY FORM</h1></div>
                        
                                             
                         
                        </article>
                   <div class="ContactInfo">  
                        <%--<span> Thanks for your interest in Kitchen On My Plate(KOMP). Provide details in below form. One of our team members will contact you shortly once you post a message. Or, you may call us. </span><br />--%>
                        <table width="100%">
                        <tr><td valign="top"><img style="width:30px" src="images/ad.png"/></td>
                        <td valign="top"><p> 106, Gomes Industrial Estate,<br/> Behind Lathia Rubber, Sakinaka, <br /> Andheri East , Mumbai, 400 072<br/><div style="width:auto; height:10px" >&nbsp;</div> </p></td>
                        </tr>
                        
                        <tr><td valign="top"><img style="width:30px" src="images/mo.png"/></td>
                        <td valign="top"><p>  +91 84520 04123<br /> 
                        <span style="font-size:12px;"> Business Hours: (Mon - Sat), 09.30 am to 08.30 pm.</span>
                        <div style="width:auto; height:3px" >&nbsp;</div> </p></td>
                        </tr>

                        <tr><td valign="top" ><img style="width:30px" src="images/ml.png"/></td>
                        <td valign="top"><p>  <a href="mailto:info@kitchenonmyplate.com" >info@kitchenonmyplate.com</a></p></td>
                        </tr>
                        </table>
                        
                         <h3 class="ContactLabel">CONNECT WITH US! <a style="margin-left:15px" target="_blank" href="https://www.facebook.com/kitchenonmyplate" ><img style="width:30px" src="images/fbc.png"/></a> <a target="_blank" href="https://twitter.com/kitchenonmyplate" ><img style="width:30px; margin-left:8px" src="images/twc.png"/></a> <a target="_blank" href="https://twitter.com/kitchenonmyplate" ><img style="width:30px; margin-left:8px" src="images/ytc.png"/></a></h3>
                        
                        <div style="padding:5px; border:1px solid #d4d4d4;" >
                        <div style="width:100%;height:370px" id="gmap"></div>
                        
                        </div>

                    </div>			  

				   <div class="ContectMsg" >
                     
                     <div style="width:93%;height:auto;float:right">
                       
                     <h3 class="ContactLabel">FULL NAME<em style="color:Red">*</em></h3>
					    <input type="text" id="nameC" class="textbox" maxlength="50" placeholder="Enter your full name here.." />
                                             <div style="width:100%;height:155; overflow:hidden;" >
                     <h3 class="ContactLabel">ADDRESS<em style="color:Red">*</em></h3>
                        <textarea  class="textbox" style="height:110px" id="txtAddr" placeholder="Enter your address here.."></textarea>

                     <h3 class="ContactLabel" style="padding-top:21px;" >PINCODE<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox NumberClass" id="txtpin" " maxlength="6" placeholder="Enter pincode here.." />
                     

                        <h3 class="ContactLabel">CONTACT NUMBER<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="mobileC" class="NumberClass" maxlength="10" placeholder="Enter your contact number here.." />
                        <h3 class="ContactLabel">EMAIL<em style="color:Red">*</em></h3>
					    <input type="text" class="textbox" id="emailC" class="EmailClass" maxlength="50"  placeholder="Enter your email address here.." />
                        <input type="text" class="textbox" style="display:none" value="Subject" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Subject';}"/>
                     </div>

                     <div style="width:100%;height:155; overflow:hidden;" >
                     <h3 class="ContactLabel">MESSAGE<em style="color:Red">*</em></h3>
                        <textarea  class="textbox" style="height:110px" id="messagingC" placeholder="Enter your message here.."></textarea>

                        <input type="button" class="proceed" style="float:right" id="sendBtn" value="SUBMIT"/>
                     </div>
                      <div style="clear:both" ></div>
					 
				   </div>

                   </div>

			      </div>
   			  
              <div style="clear:both" ></div> 
              <div style="padding:5px; margin-top:20px; border:0px solid #d4d4d4;" >
<%--<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d942.7867841879386!2d72.8469557840621!3d19.057267394160945!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3be7c92196e29025%3A0xa90d1c2336a7a2ac!2sAnanta+Interior%2C+45!5e0!3m2!1sen!2sin!4v1423241058600" width="100%" height="370px" frameborder="0" style="border:0"></iframe>--%>
</div>


       	</div>
        <!--Contact End-->

                   </div>
                      
     </div>           
     <!--container end here-->
</asp:Content>
