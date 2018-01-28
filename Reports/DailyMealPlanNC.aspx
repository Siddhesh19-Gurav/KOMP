<%@ Page Title="Daily Meal Plan - Non Customised" Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="DailyMealPlanNC.aspx.cs"   Inherits="MumbaiPropertyMart.DailyMealPlanNC" %>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
    <title>Daily Meal Plan - Non Customised</title>  
<link href="../Styles/StyleSheetReport.css" rel="stylesheet" type="text/css" />
    <link href="../fonts/font-roboto.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>

    <link rel="stylesheet" href="../Styles/themes/base/jquery.ui.all.css" />	
    <script src="../Scripts/ui/jquery-1.8.2.js"></script>
	<script src="../Scripts/ui/jquery.ui.core.js"></script>
	<script src="../Scripts/ui/jquery.ui.widget.js"></script>
	<script src="../Scripts/ui/jquery.ui.datepicker.js"></script>

    <link href="../Styles/menu.css" rel="stylesheet" type="text/css" />
    
</head>
    

     <body>
    <form id="form1" runat="server"  >
    <script type="text/javascript">
        var disabledSpecificDays = "<%=disabledSpecificDays%>";

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
        SetCalender();
    });


    function SetCalender() {



        var maxDate = new Date(); //getDateYymmdd($(this).data("val-rangedate-max"));
        maxDate.setDate(maxDate.getDate() + 68);
        $("#txtPossessionDate").datepicker({
            beforeShowDay: disableSpecificDaysAndWeekends,
            //dateFormat: "dd-mm-yy",
            startDate: '01/08/2015',
            maxDate: maxDate,
            changeMonth: true,
            changeYear: false,
            numberOfMonths: 2,
            dateFormat: "dd/mm/yy"
        });

        $("#txtPossessionDateTo").datepicker({
            beforeShowDay: disableSpecificDaysAndWeekends,
            //dateFormat: "dd-mm-yy",
            startDate: '01/08/2015',
            maxDate: maxDate,
            changeMonth: true,
            changeYear: false,
            numberOfMonths: 2,
            dateFormat: "dd/mm/yy"
        });

    }

    function disableSpecificDaysAndWeekends(date) {
        var m = date.getMonth();
        var d = date.getDate();
        var y = date.getFullYear();

        for (var i = 0; i < disabledSpecificDays.length; i++) {

            if ($.inArray((m + 1) + '-' + d + '-' + y, disabledSpecificDays) != -1 ) {
                //if (disabledSpecificDays.indexOf((m + 1) + '-' + d + '-' + y) != -1 || new Date() > date) {
                return [false];
            }
        }
        var noWeekend = $.datepicker.noWeekends(date);
        return !noWeekend[0] ? noWeekend : [true];
    }

    function ValidateAdd() 
    {
//        if ($("#ctl00_MainContent_drpLocation").val() == 0) {
//            alert('Select Location');
//            $("#ctl00_MainContent_drpLocation").focus();
//            return false;
//        }

        if ($("#ctl00_MainContent_txtAddPrice").val() == "") {
            alert('Please Enter Price');
            $("#ctl00_MainContent_txtAddPrice").focus();
        }
    }

    function Validate() {


        if ($("#txtPossessionDate").val() == "") {
            alert('Please Enter Delivery Date');
            $("#txtPossessionDate").focus();
            return false;
        }
        return true;
    }
   
</script>

    
     <div style="width:auto;height:auto; margin:0 auto; margin-left:30px; margin-top:0px;border:1px solid #4B220C;font-family:'Roboto';">    
        
        <div style="width:100%;height:auto;color:#fff;background-color:#4B220C;" >
<p style="padding:20px 0 20px 20px;height:auto;font-family:'RobotoBlack'; margin-top:0px !important;">
<span style="margin-top:60px;font-size:2em;">KITCHEN ON MY PLATE REPORTS</span>
</p>
</div>

    <div style="clear:both"></div>

    <%--<div style="float:left;  width:100px;text-align:right;margin-top:2px; " >Order</div>
    <div class="dropdown" style="float:left; margin-left:10px" >
    <asp:DropDownList ID="drpLocation" runat="server">
            </asp:DropDownList>
            </div>--%>

            <table width="80%">
            <tr><td>
            Type Of Meal</td>
            <td>
    <div class="dropdown" style="float:left; margin-left:10px" >
    <asp:DropDownList ID="drpVegNonveg" runat="server">
    <asp:ListItem Value="-1" >-All-</asp:ListItem>
    <asp:ListItem Value="1" >Veg</asp:ListItem>
    <asp:ListItem Value="0" >Non-Veg</asp:ListItem>
            </asp:DropDownList>
    </div>
    </td>
    
    <td>    
    Lunch/Dinner</td>
    <td colspan="3"><div class="dropdown" style="float:left; margin-left:10px" >
    <asp:DropDownList ID="drpLunchDinner" runat="server">
    <asp:ListItem Value="-1" >-All-</asp:ListItem>
    <asp:ListItem Value="1" >Lunch</asp:ListItem>
    <asp:ListItem Value="0" >Dinner</asp:ListItem>
            </asp:DropDownList>
    </div>
            </td>

            </tr>
    <tr>

            <td align="left" >Products</td> 
            <td>   <div class="dropdown" style="float:left; margin-left:10px" >
    <asp:DropDownList ID="drpProducts" runat="server">    
            </asp:DropDownList>
    </div>
    </td>
    <td>
    Order From Date</td>
      <td>
    <div style="float:left; margin-left:10px" >
    <input id="txtPossessionDate" style="" runat="server" clientidmode="Static" placeholder="select date" type="text" />    
    </div>
    </td>
      <td>
    Order To Date</td>
     <td>
    <input id="txtPossessionDateTo" style=" margin-left:10px; float:left;width:150px" runat="server" clientidmode="Static" placeholder="Order To" type="text" />    
    </td>
            </tr>
<tr>
            <td align="left" >Order Number</td> 
            <td>
    <asp:TextBox ID="txtOrderNo" class="textbox NumberClass" maxlength="6" placeholder="Order Number" runat="server"></asp:TextBox>
    </td>
    <td colspan="4" ></td>
    </tr>
     
            </table>

    
    
 


    <div style="width:200px; float:left; margin-left:10px" > 
        <asp:LinkButton ID="lnkShow" runat="server" OnClientClick="return Validate();" onclick="lnkShow_Click">Show Report</asp:LinkButton> </div>

            <div style=" width:100px; float:right; text-align:center">
        <asp:ImageButton ID="ImageButton1" runat="server"  Width="30px" Height="30px"
                ImageUrl="~/images/excel_icon.png" onclick="ImageButton1_Click" ></asp:ImageButton> <br />
                 Export
                 <br /><a href="CMS.aspx" >Back</a>
                </div>
      
      
    
    
        

        <br style="clear:both" />
          <br style="clear:both" />

          
    <div class="DescHeader HeaderBG14FontTopRound"  > 
        <div class="LeftSet" style="width:50%" >  <asp:Label ID="lblName" runat="server" Text="Report : Daily Meal Plan - Non Customised"></asp:Label>  </div> 
        <div class="RightSet">  Total Count :<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>  </div> 
    </div>

    <asp:GridView ID="gvPrice" runat="server" CssClass="CommonFont" PageSize="100"  Width="100%"    PagerSettings-Mode="Numeric" AllowPaging="True"
        onrowEditing="EditCustomer" 
        onrowupdating="UpdateLocation" OnRowDeleting="DeleteLocation"  AutoGenerateColumns="true" onrowcancelingedit="CancelEdit"  RowStyle-Wrap="true"
        onrowdatabound="gvPrice_RowDataBound" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <Columns>
            
       
        </Columns>
        <AlternatingRowStyle BackColor="White" />
        
        <Columns>         
        
        </Columns>

        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#F16822" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
        <div style="width:100%;height:50px"> 
        <asp:Label ID="lblPage" runat="server" Text="Page : 1"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click"><<</asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click"><</asp:LinkButton>
    <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">></asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">>></asp:LinkButton>
     </div>
    </div>
    </form>
    </body>


</html>

