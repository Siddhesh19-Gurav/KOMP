<%@ Page Title="About us – Kitchenonmyplate" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="KitchenOnMyPlate.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="title" content="About us – Kitchenonmyplate" />
    <meta name="description" content="To evolve as the most admired brand in healthy meal services that caters to the individual food preferences of all our customers." />
    <meta name="keywords" content="About Us, Our Vision, Kitchen on My Plate" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    var selectedItem = "<%=selectedItem%>";
    $(window).load(function () {


        //window.scrollTo($("#" + selectedItem).offset().top, 0);
        $('html,body').animate({
            scrollTop: $('#' + selectedItem).offset().top
        }, 0);        
    });

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
	          <img src="images/banner/about_us.jpg" alt="">
	          
             <%--  <div class="caption wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>EAT HEALTHY.</span></h3>
	          </div>

              <div class="caption1 wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>SKIP THE DIET.</span></h3>
	          </div>--%>

	        </li>	       

	      </ul>
	  </div>
  </div>

                  <%--  <div class="Tiffin">
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
                        <h1 class="page-titleMain">ABOUT US</h1>                        

                          <div style="width:100%">
                          <p>
                          
                          <div style="float:right;position:relative;" class="leftimgFrame"  >
                          
                          <img src="images/abbg.png" style="position:absolute; right:-1px;top:-3px;" />
                          <img alt="komp logo" title="komp logo" style="float:right" class="AboutImg" src="images/about_us_inside.jpg"></img>

                          </div>
                          
                          
                          
                          <h2 style="color:#ee1d24;font-size:22px;">
                        	<%--<h2 style="color:#ee1d24;font-family:ZapfElliptical711BT; font-size:22px;">--%>
                        	We all enjoy healthy delicious food,<br />
It energizes us and lifts up our mood.<br />
It's all about the rich juicy taste,<br />
When it comes to Kitchen on My Plate.

                        </h2>
                        
                      <strong>Kitchen on My Plate (KOMP)</strong> is a Mumbai-based meal delivery service focusing not only on taste, but on the health of their customers, too.<br /><br />
KOMP takes immense pride in providing balanced, nutritious and delicious meals, cooked home-style at our ultra-modern kitchen that is always kept spic and span. Our menu plans are based on mouth-watering recipes and we have a variety of them to rustle up a scrumptious sumptuous meal for you, every day.  <br /><br />
We handpick premium quality ingredients to prepare your meals. The taste goes beyond the ingredients, into the friendly and healthy tradition that we maintain in our kitchen. Indeed, we don’t have staff, but a big happy family working at KOMP that is ever ready to cater to your taste buds. <br /><br />
<strong>Bon appétit!</strong>
</p>
</div>
<%--<div style="float:right; width:40%"  >

</div>--%>

 
    <h1 class="page-title" id="ourmission" >OUR MISSION</h1>
    To contribute to the healthy living of all our customers by providing them nutritious and delicious meals every day, where each meal is not just food, but an experience in itself!
                        <br />
                        <h1 class="page-title" id="ourvision">OUR VISION</h1>
    To evolve as the most admired brand in healthy meal services that caters to the individual food preferences of all our customers.

    <br />
                        <h1 class="page-title" id="ourvalues">OUR VALUES</h1>
    <span class="valuesKeys">KOMP services promise you:</span><br /><br />
	<span class="valuesKeys"><img class="buttleted" src="images/tick.png">&nbsp;Health & Safety –</span> The food we provide not only appeals to your taste buds, it also agrees with your tummy. By using fresh, premium quality ingredients and adhering to laid-down, strict hygiene practices, we deliver quality meals that you can enjoy till the last bite. Our staff is completely in sync with our health and safety standards, which they very well maintain while handling as well as packing the KOMP meals.<br /><br />
<span class="valuesKeys"><img class="buttleted" src="images/tick.png">&nbsp;Quality & Consistency –</span> We always try to exceed customer expectations when it comes to quality. Our kitchen is equipped with state-of-the-art facilities that help us deliver the quality we promise. Besides, we also promise consistency in quality, taste and nutritional value in the meals that we prepare.<br /><br />
<span class="valuesKeys"><img class="buttleted" src="images/tick.png">&nbsp;Variety –</span> Believing that variety is the spice of life, KOMP offers a huge variety of mouth-watering meals under different menu plans for all 30 days of a month! In addition, you can also customize your plans according to your individual preferences.<br /><br />
<span class="valuesKeys"><img class="buttleted" src="images/tick.png">&nbsp;Passion –</span> We are all foodies who love to rustle up a delicious meal with passion and inventiveness. <br /><br />
<span class="valuesKeys"><img class="buttleted" src="images/tick.png">&nbsp;Feedback –</span> Tell us how to fine-tune a dish to make it better and we will always welcome your feedback. KOMP wants to keep on improving its service on this exciting gastronomical journey with you!  <br />

<br/>
 <h1 class="page-title" id="ourlogo" >OUR LOGO</h1>  
  <div style="float:left;position:relative;"  >
                          <%--<img src="images/abbg.png" style="position:absolute; left:-2px;top:9px; width:279px;height:147px" />--%>
                          <img alt="komp logo" title="komp logo" class="AboutImg1" src="images/logo.jpg" />
                          </div>

 <%--<img alt="komp logo" title="komp logo" class="AboutImg1" src="images/logo.png" />--%>
 <p class="aboutlogoP">
 Every logo tells a story. It gives an identity and is aligned to the character of a brand. The KOMP identity is derived from a bowl holding leaves, symbolic of life itself. KOMP does the same. <br />
KOMP corporate identity is a combination logo that depicts a stack of plates or a bowl of food. The three parts of the bowl represent the huge variety of food that we offer. The leaves denote fresh veggies.
<div style=''></div>
The text in the logo uses orange and brown color.  <div style='clear:both'></div>
Orange combines the energy of red and the happiness of yellow. It is associated with joy, sunshine, and the tropics. Orange also represents enthusiasm, fascination, happiness, creativity, determination, attraction, success, encouragement, and stimulation. Solid, reliable brown is the color of earth and is abundant in nature. <br /><br />
We pick the healthiest of ingredients from nature's bowl and cook a delicious meal that will satiate you. KOMP brings all the abundance of mother earth to your dining table.   
 </p>
      </article>
              
     </div>           
     <!--container end here-->
</asp:Content>
