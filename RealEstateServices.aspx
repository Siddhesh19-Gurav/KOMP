<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RealEstateServices.aspx.cs" Inherits="KotaCoachings.RealEstateServices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css" >


   </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
   
   
    <!--Sart Scripts for autotext-->
    
	<script  type="text/javascript" src="Scripts/ui/jquery.ui.core.js"></script>
	<script   type="text/javascript" src="Scripts/ui/jquery.ui.widget.js"></script>
	<script  type="text/javascript" src="Scripts/ui/jquery.ui.mouse.js"></script>
	
	
<script src="Scripts/jquery.rating.js" type="text/javascript"></script> 

  <script src="Scripts/jsRealEstateServices.js" type="text/javascript"></script> 
        <script src="Scripts/ui/jquery.ui.button.js" type="text/javascript"></script>	
    <script src="Scripts/ui/jquery.ui.position.js" type="text/javascript"></script>
    <script src="Scripts/ui/jquery.ui.autocomplete.js" type="text/javascript"></script>    
<%--    <script src="Scripts/jsAutoComplete.js" type="text/javascript"></script>--%>
    <!--End Scripts for autotext-->
 <%--   <script src="Scripts/jsWaterMark.js" type="text/javascript"></script>--%>
    <!--tool tip window-->
    


    
    <script type="text/javascript" >
    var totalCount= "<%=totalCount%>";
    </script>
<%--    <script src="Scripts/jsWaterMark.js" type="text/javascript"></script>--%>

<!--Start Get IP Info-->
    <script src="Scripts/jqIpLocation.js" type="text/javascript"></script>
            
            <!--Start Get IP Info-->
    <script  type="text/javascript" language="JavaScript" src="http://j.maxmind.com/app/geoip.js"></script> 

 <script type="text/javascript" >
     function getLocationIP(ipAddress, hits) {
         SendMail(ipAddress + "- Country -City ", hits);
         //SendMail(ipAddress + "- Country " + geoip_country_name() + "-City " + geoip_city(), hits);
   
//    $.jqIpLocation({
//    ip : ipAddress,
//    locationType : 'city',
//    success: function (location) {
//        SendMail(location.ipAddress + "- Country " + geoip_country_name() + "-City " + geoip_city(), hits);			
//			//SendMail(location.ipAddress+"- Country"+location.countryName+"-City"+location.cityName,hits);
//     }
//   });

     

}

function SendMail(ipAddDetails,hits)
{
  $.ajax({
                  type: "POST",
                  url: "kotaEstateServices.asmx/SendIPDetailsMail",                      
                  contentType: "application/json; charset=utf-8",
                  data: "{ipDetails:'"+ipAddDetails+"',hits:'"+hits+"'}",
                  dataType: "json",
                  success:  function(w){
                          
                  },
                  error: function(w){}
   }); 
   
}

var firstIntid = null;
$(function () {
   // $('#combobox,#txtDropDown,#btnDrp').attr('disabled', '');
  //  $('#combobox1,#txtDropDown1,#btnDrp1').attr('disabled', 'disabled');
    //$('#txtDropDown1').css('background-color', '#C9D3D6');
    $('#txtDropDown').removeClass("watermark").val("");
    $('#txtDropDown').focus();
    //firstIntid = setInterval(AnimationNew, 9000); Stop Popup AD.
    
});

</script>
<script type="text/javascript">





var fistShow = false;
var fistShow1 = false;

function AnimationNew() {
  


    if (fistShow && !fistShow1) {
        fistShow1 = true;
        $("#divAddDown1").show();
        $("#mainDiv").height("1260px");


    }

    if (!fistShow) {
        fistShow = true;
        $("#divAddDown").show();
        $("#mainDiv").height("1260px");
        clearInterval(firstIntid);

    }

}

</script>
<!--End Get IP Info-->



    
   <div style="background-color:#eef5ff; color:#447ed0;  float:left; margin-left:13px;width:769px;height:103px;"  >
                  
        
        
        <div style=" float:left; font-size:12px; font-weight:bold;width:210px;height:60px; margin-left:14px;margin-top:6px">          
          <div><asp:RadioButton ID="rdCourse"  GroupName="SearchType" runat="server" Checked="true" Visible="false"  />Services</div>
          <div> <div class="dropdown" > <select  id="combobox" >          
          </select></div>
          </div>          
          </div>
        
        <div style="float:left; margin-left:5px; font-size:12px; font-weight:bold;width:210px;height:60px;margin-top:6px">          
          <div><asp:RadioButton ID="rdCoaching" runat="server" GroupName="SearchType" Visible="false"  /> Deals in</div>
          <div> <div class='dropdown'> <select id="combobox1" >          
          </select> </div>
          </div>           
          </div><br />
         <div  style="clear:both; font-size:12px; font-weight:bold;width:580px; margin:0 auto; margin-left:15px; height:21px;">
         <h3 id="h3Select" style="font-size:10px; font-weight:bold;" >Select Real Estate services!</h3>
     
        </div>
        
   </div>

 


   <div style="clear:both" ></div> 

<div id="mainDiv"   >

<div style='width:auto;height:20px' >&nbsp;</div>

<div style="clear:both" ></div>  

   

   <!--Display image while searching/navigation-->
   <div id="imgSrch" style=" cursor:default; position:absolute; margin-left:30px;margin-top:10px; display:none" />
    <img id="img1" src="images/Search-icon.png" alt=""  />
    </div>    
    <div style="clear:both; width:auto;">

       <!--Display Title Start-->
            <div class="MarkHideOnSearch" style="position:absolute;margin-left:20px;margin-top:-7px;width:auto; height:41px;" >            
            <div class="LeftHClip" ></div>
            <div class="MiddleHClip" >
            <div class="HeaderTitleC" id = "Div1"><h4 style="margin-top:1px;float:left;vertical-align:top" id="hHeader" >Real Estate Service Providers</h4></div>            
            </div>
            <div class="RightHClip" ></div>
            </div>
            <!--Display Title End -->

    <table border="0"  id="ctl00_MainContent_JQGrid1" cellpadding="0" cellspacing="0" class="BlueBorder" style="clear:both; margin-left:15px;   width: 769px;height: auto;" >    
    <tbody>
    <tr><td>

    <div id="divOuter" style="width:auto;height:382px" >
    </div>

    </td></tr>
    </tbody>
    </table>


    


    </div>
    
        <div id="divNavigation" style=" display:none; height:30px;width:auto; margin-left:20px; margin-top:25px"></div>

        <br /><br />


        

    <asp:HiddenField ID="hdnCourse" runat="server" />
    <asp:HiddenField ID="hdnCoaching" runat="server" />
      
<div style="float:left; height:20px" ><div style="height:auto; margin-left:5px;margin-top:-1px" ><g:plusone></g:plusone></div> </div>
        <div style="float:left;height:auto" >
               
        
        </div><br/>
       </div>

</asp:Content>
