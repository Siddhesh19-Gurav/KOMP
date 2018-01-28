<%@ Page Language="C#" MasterPageFile="SiteSamarth.Master" AutoEventWireup="true" CodeBehind="Events1.aspx.cs" Inherits="SwamiSamarthSeva.Events" Title="Image Gallery" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentPage" >
    <div class="CenterContainerMostOut" >
        <div class="CenterContainerOut" >
          <div class="CenterContainer" style="height:500px;"  >

<style>
                p {
        padding: 0 0 1em;
        }
        .msg_list 
        {
        	width:610px;
        margin: 0px;
        padding: 0px;       
        }
        .msg_head {
        padding: 5px 10px;
        cursor: pointer;
        font-family:Arial;
        font-size:12px;
        font-weight:bold;
        position: relative;        
        margin:1px;
        background-image:url(images/3.png);background-repeat:repeat;      
        }
        .msg_body 
        {
        width:auto;
        height:270px;
        padding: 5px 10px 15px;
        background-color:#FAE8ED;
        font-family:lucida grande, tahoma, verdana, arial, sans-serif;font-size:13px;
        }
        
        .smallbutton
        {
         font-size:11px;	
         cursor:pointer;
        }
    </style>


   <script type="text/javascript">
       var evetnName = "<%=evetnName%>";
    function LeftMove(innerId) {
        if (!$("#"+innerId+" div").is(":animated")) {        
            if (parseInt($("#"+innerId+" div").css("left").replace("px", "")) < -10) {

                $("#"+innerId+" div").animate({ left: "+=225px" }, 1000, function () { });
            }
        }
         
     }

     function RightMove(innerId) {
     
         if (!$("#"+innerId+" div").is(":animated")) {
             var right = $("#"+innerId+" div").width() + (parseInt($("#"+innerId+" div").css("left").replace("px", "")));             
             
             if (right > 890) {             
                 $("#"+innerId+" div").animate({ left: "+=-225px" }, 1000, function () { });
             }
         }       
     
     }


     //$(document).ready(function () {  //hide the all of the element with class msg_body            
     $(window).load(function () {
         //Generate events        
         //Show all event name if event name is blank
         if (evetnName != "") {
             SetImages("", evetnName, evetnName);
         }
         else {
             SetImages("", evetnName, evetnName);
             //GenerateEvents();
         }

         $("#tdNews,#tdNews1").hide();
         $("#tdNews3").width("1020px");
     });
         
         function SetAnimation()
         {
            var firstfolder = $("div.msg_body:first div").attr("id").replace("div","");

            if (evetnName != "") {
                SetImages("div" + evetnName, evetnName, evetnName);               
            }
            else {
                SetImages("div" + firstfolder, firstfolder, firstfolder);
                $("div.msg_body").hide();
                $(".msg_body:first").show();
              
            }



            //toggle the componenet with class msg_body  
            $(".msg_head").click(function ()
             {

                if (!$(this).next(".msg_body").is(':visible')) 
                {
                    $("div.msg_body").hide();                    
                    $(this).next(".msg_body").slideToggle(600, function(){   });           
                    $("#divHotels,#ctl00_MainContent_literalDives").fadeIn(1000);                  
                }
                else 
                {
                    $("div.msg_body:visible").animate({ height: "toggle" }, 600, function () { });                    
                   $("#divHotels,#ctl00_MainContent_literalDives").fadeOut();
                   
                }
                
            });
         }

         function clickFirst() {
             $('.EventDiv a.fancy').first().click();
         }

         function SetImages(literalId,imageFolder,group)
         {
         if(evetnName != "" || $("#"+literalId+" img").length==0)
         {//Start If
             $.ajax({
                 type: "POST",
                 url: "PerafinServices.asmx/SetImagesOnEventPage",
                 contentType: "application/json; charset=utf-8",
                 data: "{imageFolder:'" + imageFolder + "',group:'" + group + "'}",
                 dataType: "json",
                 success: function (result) {


                     if (evetnName != "") {
                         //                         var htmlStr = "<img onclick=LeftMove('div" + evetnName + "') style='width:35px;z-index:10;position:absolute;margin-left:-26px;margin-top:73px' src='../images/Previous.png'/>";
                         //                         htmlStr = htmlStr + "<div id='div" + evetnName + "'  style='margin-left:6px;position:absolute;overflow:hidden;width:910px;height:280px' ><div id='outerDiv' style='position:absolute;left:-10px;width:auto;height:280px' >" + result.d + "</div></div>";
                         //                         htmlStr = htmlStr + "<img onclick=RightMove('div" + evetnName + "') style='width:35px;position:absolute;margin-left:905px;margin-top:73px' src='../images/Next.png'/>";
                         //                         alert(htmlStr);
                         $("div.EventDiv").append(result.d.split("^")[0]);
                         //$("#" + literalId).html("<div id='outerDiv' style='position:absolute;left:-10px;width:auto;height:280px' >" + result.d + "</div>");
                         //$("div.EventDiv div").css("margin","13px");
                         $('.title01').html(result.d.split("^")[1]);
                         $('.spanFooterCity').html(result.d.split("^")[1]);


                         $("a.fancy").fancybox();
                         //$('.CenterImg').html($('.EventDiv img').first());
                         $('.CenterImg').html(result.d.split("^")[2] + "<img onclick='clickFirst();' style='position:absolute; margin-left:430px;margin-top:350px; ;  cursor:pointer' src='images/search-glass.png' />");
                         //$('.CenterImg').append("<img style='position:absolute; margin-bottom:20px; margin-right:30px;  cursor:pointer' src='images/search-glass.png' />");
                     }
                     else {
                         //                         var htmlStr = "<img onclick=LeftMove('div" + evetnName + "') style='width:35px;z-index:10;position:absolute;margin-left:-26px;margin-top:73px' src='../images/Previous.png'/>";
                         //                         htmlStr = htmlStr + "<div id='div" + evetnName + "'  style='margin-left:6px;position:absolute;overflow:hidden;width:910px;height:280px' ><div id='outerDiv' style='position:absolute;left:-10px;width:auto;height:280px' >" + result.d + "</div></div>";
                         //                         htmlStr = htmlStr + "<img onclick=RightMove('div" + evetnName + "') style='width:35px;position:absolute;margin-left:905px;margin-top:73px' src='../images/Next.png'/>";
                         //                         alert(htmlStr);
                         $("div.EventDiv").append(result.d.split("^")[0]);
                         //$("#" + literalId).html("<div id='outerDiv' style='position:absolute;left:-10px;width:auto;height:280px' >" + result.d + "</div>");
                         //$("div.EventDiv div").css("margin","13px");
                         $('.title01').html(result.d.split("^")[1]);
                         $("a.fancy").fancybox();
                         //$('.CenterImg').html($('.EventDiv img').first());
                         $('.CenterImg').html(result.d.split("^")[2] + "<img onclick='$('.EventDiv a.fancy').first().click()' style='position:absolute; margin-left:430px;margin-top:300px; ;  cursor:pointer' src='images/search-glass.png' />");
                         //$('.CenterImg').append("<img style='position:absolute; margin-bottom:20px; margin-right:30px;  cursor:pointer' src='images/search-glass.png' />");
                     }


                     var height = $("div.EventDiv").height()< 470 ? 420 : $("div.EventDiv").height() + 20;


                     //$(".divVLine").css("height", height - 40);
                     $(".main").css("height", height - 40);
                     $(".main").css("min-height", height-20);
                     $(".CenterContainer").css("height", height+70);
                     //$(".CenterContainer").css("height", height);

//                     $(".CenterContainer").height() - 100;
//                     $(".main").css("min-height", height);



                 },
                 error: AjaxFailed
             }); 
          }//End If
         }   
             
      function GenerateEvents()
         {
             $.ajax({
                 type: "POST",
                 url: "PerafinServices.asmx/GenerateEvents",
                 contentType: "application/json; charset=utf-8",
                 data: "",
                 dataType: "json",
                 success: function (result) {
                     $("div.EventDiv").append(result.d);

                     SetAnimation();                    

                 },
                 error: AjaxFailed
             });    
         }
function AjaxFailed(result) {
           alert(result.status + ' ' + result.statusText);
      }

      function ShowMoreCities() {
          $('.MoreZones1').show();
      }

      function HideMoreCities() {

          $('.MoreZones1').hide();
      }
      
   </script>
       

       <!--Fancy Start-->    
    <link href="Scripts/jsFancy/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jsFancy/jquery.fancybox-1.2.1.js" type="text/javascript"></script>         
    <script type="text/javascript" >
    $(function(){
    
    });
    </script>

     <div style="height:100%;width:700px;text-align:left; float:left;" >

             <!--Logo Start-->
            <div style="float:left;width:300px;height:50px; margin-left:15px; margin-right:25px;  margin-top:0px">
            <div  class="ShowCity1" onclick="$('#divCities').show()"   onmouseover='ShowMoreCities()' onmouseout='HideMoreCities()'  >
                <div style='width:auto;margin-left:15px;margin-right:15px'>
                 <span class="spanFooterCity" runat="server" id="SpnLatestEvent"  ></span> <span style='font-size:15px;color:#B12C00' >▽</span>
                 </div>
            </div> 
            <div id='divCities' runat="server"  onmouseover='ShowMoreCities()' onmouseout='HideMoreCities()' class='MoreZones1'></div>
            </div>	

    <%--          <div class="labelClNoBG" > 
              <div style='height:10px' ></div>
                <span class="title01" >Events</span>
            </div>--%>
                <%--<div style="width:300px;height:34px" class="HeaderBoxCommon" > </div>--%>
            <div style="clear:both"></div>
            <!--Logo End-->        

         <div class="EventDiv"  style="height:auto;width:220px;text-align:left; margin-left:15px; float:left;" ></div>
         <div class='CenterImg' style=" position:relative; height:390px;width:460px; overflow:hidden; text-align:left; float:left; margin-top:8px" ></div>
           <div style="clear:both"></div>
          <div style='clear:both; width:690px; margin:0 auto' >   <div class="labelClNoBG" > 
              <div style='height:0px' ></div>
                 &nbsp;&nbsp;&nbsp;  <asp:Label ID="lblDon1" runat="server"></asp:Label> <a href="Trustees.aspx" > <asp:Label ID="lblDon2" runat="server"> </asp:Label> </a>  <a style="float:right" href="MakeDonation.aspx" > <asp:Label ID="lblDon3" runat="server"> </asp:Label> </a>     
            </div>
       </div>

         </div>

         <div style="height:100%;width:220px;text-align:left; float:left; margin-left:25px " >
         
         <!--Left div start-->
         <div id="divVLine" style="width:1px;height:91%; margin-top:20px; margin-left:10px;float:left;border-left-style:dotted ; border-left-width:thin;" ></div>  
            <div style="width:180px;height:auto; margin-top:20px; margin-left:25px;text-align:left;float:left;" >


            <div class="labelCl" style="width:180px;margin-left:6px"  >  <asp:Label ID="lblH6" runat="server"></asp:Label> </div>
            <div style="float:left;width:180px;height:90px;overflow:hidden; margin-top:10px;margin-bottom:50px; margin-left:6px"  >
                 <a rel="map" href="Images/map.jpg" class='fancy'><img alt="pleas smarth"  style="width:180px;height:auto;overflow:hidden"  src="Images/map.jpg" /></a>
                 </div>
      
      
      <div style="clear:both" ></div>

            <div class="labelCl" style="width:180px;margin-top:15px;margin-left:6px" >  <asp:Label ID="lblH7" runat="server"></asp:Label> </div>
           <div style="float:left;width:180px;height:200px;overflow:hidden; margin-top:10px;margin-bottom:50px; margin-left:6px"  >
         <a rel="vachan" href="Images/vachan.jpg" class='fancy'><img alt="Vachan"  style="width:180px;height:200px;overflow:hidden"  src="Images/vachan.jpg" /></a>
         </div>

         </div>
         <!--Left div end-->

         </div>
         <br /><br /><br />
      
</div>
 </div>
 </div>
    </div>

 
</asp:Content>
