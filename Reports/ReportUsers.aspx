<%@ Page Title="Users" Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ReportUsers.aspx.cs"   Inherits="MumbaiPropertyMart.ReportUsers" %>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server"></head>
    <title>User List</title>  
<link href="../Styles/StyleSheetReport.css" rel="stylesheet" type="text/css" />
</head>

     <body>
    <form id="form1" runat="server"  >
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

    function ValidateAdd() 
    {
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

    
    <div style="width:auto;height:auto; margin:0 auto; margin-left:30px ; border:2px solid #D1E4FF" class="CommonFont" >    
        <div style="float:left;width:408px;height:124px; position:relative; margin-left:15px;  margin-top:3px"><a style="text-decoration:none" href="http://www.mumbaipropertymart.com"> <img alt="" src="../images/Layer112.png"/></a></div>
    <div style="clear:both"></div>


    <div style="float:left; width:100px;text-align:right;margin-top:8px; " >User Type </div>
    <div class="dropdown" style="float:left; margin-left:10px" >
    <asp:DropDownList ID="drpRegion" runat="server"  AutoPostBack="true"
            onselectedindexchanged="drpRegion_SelectedIndexChanged">   
    <asp:ListItem Value="" Selected="True" >All</asp:ListItem>
    <asp:ListItem Value="A" >Agents</asp:ListItem>
    <asp:ListItem Value="B" >Builders</asp:ListItem>
    <asp:ListItem Value="C" >Buyers</asp:ListItem>
    <asp:ListItem Value="O" >Owners</asp:ListItem>
    <asp:ListItem Value="R" >Architecture</asp:ListItem>
    </asp:DropDownList> </div> 

    <div style=" width:200px; float:left; margin-left:10px" > 
        <asp:LinkButton ID="lnkShow" runat="server" onclick="lnkShow_Click">Show Report</asp:LinkButton> </div>

            <div style=" width:100px; float:right; text-align:center">
        <asp:ImageButton ID="ImageButton1" runat="server"  Width="30px" Height="30px"
                ImageUrl="~/images/excel_icon.png" onclick="ImageButton1_Click" ></asp:ImageButton> <br />
                 Export to excel
                </div>
      
      
    
    
        

<br style="clear:both" />
          <br style="clear:both" />
    <div class="DescHeader HeaderBG14FontTopRound"  > 
        <div class="LeftSet">  <asp:Label ID="lblName" runat="server" Text="Report : User List"></asp:Label>  </div> 
        <div class="RightSet">  Total Count :<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>  </div> 
    </div>

    <asp:GridView ID="gvPrice" runat="server" CssClass="CommonFont" PageSize="20"  Width="100%"  
        onrowEditing="EditCustomer" 
        onrowupdating="UpdateLocation" OnRowDeleting="DeleteLocation"  AutoGenerateColumns="true" onrowcancelingedit="CancelEdit" 
        onrowdatabound="gvPrice_RowDataBound" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <Columns>
            
       
        </Columns>
        <AlternatingRowStyle BackColor="White" />
        
        <Columns>         
        <asp:CommandField  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="Select"  ShowSelectButton="True" /> 
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
    </form>
    </body>


</html>

