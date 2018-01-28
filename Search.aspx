<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="KitchenOnMyPlate.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<style>
    .contact-form_grid p{margin-bottom:0px !important;}
</style>
<script type="text/javascript">
    var searchtext = "<%=searchtext%>";
    $("#txtSearch").val(searchtext);
</script>
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
	          <img src="images/banner/School Catering.jpg" alt="Search komp">
	          
        <%--      <div class="caption wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>EAT HEALTHY.</span></h3>
	          </div>

              <div class="caption1 wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>SKIP THE DIET.</span></h3>
	          </div>--%>

	        </li>	       

	      </ul>
	  </div>
  </div>

             <%--       <div class="Tiffin">
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
                        <h1 class="page-titleMain">SEARCH RESULT</h1>
                        
                  <div class="col-ms-12">

                  <div style="width:100%; height:auto;" >
                 

                   

<!--Contact Start-->
   
        
   


       
			     <div class="contact-form_grid" style="float:left; text-align:left">

              
                    <div style="clear:both;width:100%;height:auto" id="custDivInner" clientidmode="Static"  runat="server" ></div> 

				 
                   </div>

		
   			  
              <div style="clear:both" ></div> 

        <!--Contact End-->

         </div>
              <%--    <div style="width:30%; height:auto;float:left;" >

                  <div class='fb-like-box' data-href='https://www.facebook.com/kitchenonmyplate' data-width='90%' data-height='280' data-colorscheme='light' data-show-faces='true' data-header='true' data-stream='false' data-show-border='true'></div>
                  <div style="clear:both;height:10px" ></div>



                  </div>
--%>
                   </div>
                      
     </div>           
     <!--container end here-->
</asp:Content>
