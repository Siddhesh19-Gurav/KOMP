<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="KitchenOnMyPlate.MyOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<link href="../Styles/StyleSheetReport.css" rel="stylesheet" type="text/css" />--%>
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
	          
             <%--<div class="caption wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>EAT HEALTHY.</span></h3>
	          </div>

              <div class="caption1 wow bounceIn animated" data-wow-delay="0.4s" style="visibility: visible; -webkit-animation-delay: 0.4s;">	          	
	          	<h3><span>SKIP THE DIET.</span></h3>
	          </div>
--%>
	        </li>	       

	      </ul>
	  </div>
  </div>

                    <div class="Tiffin" style="margin-top:-43px;float:right; width:auto;">
                        <img style="margin-left:-5px;" src="images/banner/sl1.png" alt=""/>                        
                      </div>

                      
                      </div>
                <!--SLIDERNEWEND-->

          <div class="row faq">
           <div class="col-ms-12">
      <div style="clear:both" ></div>
      <article class="page-art FistArt">
                        <h1 class="page-titleMain">YOUR ORDER(S)</h1>                        
                        </article>

        
    <div style="clear:both"></div>

    <%--<div style="float:left; width:100px;text-align:right;margin-top:2px; " >Select from your saved Orders</div>--%>
    <div id="divCart" class="ProcessBox CUSTBOX" style="height:auto;margin-top:15px;">
<article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >01</span>PLACED ORDERS</h1>        
        </article>
        <div class ="ProcesBoxInner">

         <table class="tbl" cellspacing="1" width="100%" align="center" cellpadding="5" >
                 <thead>
                 <tr class='divRow dataHeader DR' style='' ><td>ORDER ID</td><td>PRODUCT</td><td>QUANTITY</td><td>ORDER PLACED DATE</td><td>PAYMENT STATUS</td><td></td></tr>
                 </thead>                 
				<tbody>                
                    <div id="divOrders" runat="server" style="width:100%;height:auto" ></div>
                </tbody>
                </table>
                
    </div></div>
    <div style="clear:both" ></div>
    <%--<div style="width:30%;height:auto; margin:0 auto; font-weight:bold" >Order Summary</div>--%>
    <div id="divQuantity" class="ProcessBox CUSTBOX" style="display:none;height:auto;margin-top:15px;">
  <article class="page-art">
        <h1 class="page-titleSmallCust"><span class="OrderBox" >02</span>ORDER DETAILS</h1>        
        </article>
        <div class ="ProcesBoxInner">
               
<div style="width:100%;" >
        
        <div id="divOrdersDetails" style="width:100%;height:auto; margin:0 auto;" ></div>
        

        <%--<input type="button" value="CONTINUE SHOPPING" class="proceedBack" style="float:left" onclick="ShowItems();" />

                <input type="button" class="proceed" value="PROCEED" onclick="SetCartTotal();" />--%>

        </div>
        </div>        

<div style="clear:both" ></div>
</div>

    

    <%--<div class="dropdown" style="float:left; margin-left:10px" >
    <asp:DropDownList ID="drpLocation" runat="server">
            </asp:DropDownList>
            </div>--%>

    <%--<div style=" width:200px; float:left; margin-left:10px" > 
        <asp:LinkButton ID="lnkShow" runat="server" onclick="lnkShow_Click">View</asp:LinkButton> </div>--%>
<%--
            <div style=" width:100px; float:right; text-align:center">
        <asp:ImageButton ID="ImageButton1" runat="server"  Width="30px" Height="30px"
                ImageUrl="~/images/excel_icon.png" onclick="ImageButton1_Click" ></asp:ImageButton> <br />
                 Export to excel
                </div>--%>
      
      
    
    
        

        <br style="clear:both" />
          <br style="clear:both" />

          
    

    <asp:GridView ID="gvPrice" runat="server" CssClass="CommonFont" PageSize="20"  Width="100%"  
        onrowEditing="EditCustomer" 
        onrowupdating="UpdateLocation" OnRowDeleting="DeleteLocation"  AutoGenerateColumns="true" onrowcancelingedit="CancelEdit" 
        onrowdatabound="gvPrice_RowDataBound" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <Columns>
            
       
        </Columns>
        <AlternatingRowStyle BackColor="White" />
        
        <Columns>         
        
        </Columns>

        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

    </div>
    </div>
</asp:Content>
