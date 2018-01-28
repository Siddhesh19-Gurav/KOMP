<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/SiteMaster.Master" AutoEventWireup="true" CodeBehind="WeeklyMenu.aspx.cs" Inherits="KitchenOnMyPlate.Masters.WeeklyMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<style>
    .weeklyMenuTable input[type="submit"], .weeklyMenuTable input[type="button"]{background:#4b220c !important;padding:10px !important; margin-left:0px !important; font-size:1em !important;}
</style>

<div style="width:100%;font-size:25px;font-weight:bold;padding-top:10px;font-family:RobotoBold;color:#4b220c">OUR VEG-NON-VEG WEEKLY MENU</div>        
      

<input id="hdnValue" type="hidden" value="0" />
<asp:DropDownList ID="drpMenyType"  AutoPostBack="true"  runat="server" 
        onselectedindexchanged="drpMenyType_SelectedIndexChanged">
        <asp:ListItem Value="0">-Select Menu Type-</asp:ListItem>
<asp:ListItem Value="TL">Lunch</asp:ListItem>
<asp:ListItem Value="TD">Dinner</asp:ListItem>
<asp:ListItem Value="NL">Nutrimeal Lunch</asp:ListItem>
<asp:ListItem Value="ND">Nutrimeal Dinner</asp:ListItem>
</asp:DropDownList>
<div id="divItem" runat="server" ></div>

<table class="text weeklyMenuTable" id="tblweekly" border="1" width="100%" cellspacing="0" cellpadding="2" align="center" bordercolor="#c8c6c6">
<tbody class="plan" >
<tr valign="middle" bgcolor="#451F0C" style="color:#fff;" >
<td align="center"><span><strong>Menu</strong></span></td>
<td align="center"><span><strong>MONDAY</strong></span></td>
<td align="center"><span><strong>TUESDAY</strong></span></td>
<td align="center"><span><strong>WEDNESDAY</strong></span></td>
<td align="center"><span><strong>THURSDAY</strong></span></td>
<td align="center"><span><strong>FRIDAY</strong></span></td>
<td align="center"><span><strong>SATURDAY</strong></span></td>
<td align="center" style="display:none"><span><strong>SUNDAY</strong></span></td>
<td align="center"><span><strong>ACTIONS</strong></span></td>
</tr>
<tr valign="middle" bgcolor="#FFE0CE">
<td align="center"><strong></strong></td>
<td align="center"><strong><asp:Label ID="lblDt1" runat="server"></asp:Label> </strong></td>
<td align="center"><strong><asp:Label ID="lblDt2" runat="server"></asp:Label></strong></td>
<td align="center"><strong><asp:Label ID="lblDt3" runat="server"></asp:Label></strong></td>
<td align="center"><strong><asp:Label ID="lblDt4" runat="server"></asp:Label></strong></td>
<td align="center"><strong><asp:Label ID="lblDt5" runat="server"></asp:Label></strong></td>
<td align="center"><strong><asp:Label ID="lblDt6" runat="server"></asp:Label></strong></td>
<td align="center" style="display:none" ><strong><asp:Label ID="lblDt7" runat="server"></asp:Label></strong></td>
<td align="center"><span><strong></strong></span></td>
</tr>
    <asp:Literal ID="ltrlRow" runat="server"></asp:Literal>



</tbody>
</table>

<table class="text" border="1" id="tblenter" runat="server" visible="false" width="100%" cellspacing="0" cellpadding="2" align="center" bordercolor="#c8c6c6">
<tbody class="plan" >
<tr valign="middle">
<td align="left" colspan="3"  >Menu Name <input type="text" id='txtMenu' placeholder="Menu Name.." /> </td>
</tr>
    <tr valign="middle">
<td align="center">Mon <input type="text" id='txt1' placeholder="Monday Menu.." /> </td>
<td align="center">Tue <input type="text" id='txt2'  placeholder="Tuesday Menu.."  /> </td>
<td align="center">Wed <input type="text" id='txt3'  placeholder="Wednesday Menu.."  /> </td>
</tr>
<tr valign="middle">
<td align="center">Thu <input type="text" id='txt4'  placeholder="Thursday Menu.."  /> </td>
<td align="center">Fri <input type="text" id='txt5'  placeholder="Friday Menu.."  /> </td>
<td align="center">Sat <input type="text" id='txt6'  placeholder="Saturday Menu.."  /> </td>
</tr>
<tr valign="middle">
<td align="center"  colspan="2" ><input type="text" style="display:none" id='txt7' /> </td>
<td align="center"><span><strong><input id="btAdTolst" type="button" value="Submit" onclick="AddToList();" style="padding:10px !important;" />

<input type="button" id="Button1" value="Main Menu" style="background:#ed651e !important;padding:10px !important; margin-left:0px !important;"  onclick="window.location.href='cms.aspx'" />
<input id="btnCancel" type="button" value="Cancel" style="padding:10px !important;" onclick="$('.weeklyMenuTable').show();Reset();" />
</strong></span></td>
</tr>
<tr valign="middle">
<td align="center"  colspan="6" ></td>
</tr>
</tbody>
</table>
<div style="width:100%;height:20px">&nbsp;</div>

<%--<input id="btnsubmit" type="button" value="Submit" />--%>

<script type="text/javascript">

    function AddToList() 
    {


        if ($('#txt1').val() == "" && $('#txt2').val() == "" && $('#txt3').val() == "" && $('#txt4').val() == "" && $('#txt5').val() == "" && $('#txt6').val() == "" && $('#txt7').val() == "" && $('#txtMenu').val() == "")
        {
        alert('Please enter atleaset one item!');
        return false;
        }
    
    var weekly = new WeeklyMenu();
    weekly.Id = $('#hdnValue').val();    
        weekly.Monday = $('#txt1').val();
        weekly.Tuesday = $('#txt2').val();
        weekly.Wednesday = $('#txt3').val();
        weekly.Thursday = $('#txt4').val();
        weekly.Friday = $('#txt5').val();
        weekly.Saturday = $('#txt6').val();
        weekly.Sunday = $('#txt7').val();
        weekly.IsActive = 1;
        weekly.ShowIn = $('#ContentPlaceHolder1_drpMenyType').val();
        weekly.MenuItm = $('#txtMenu').val();
      

        $.ajax
                  ({
                      type: "POST",
                      url: "../KompServices.asmx/SaveWeeklyMenu",
                      contentType: "application/json; charset=utf-8",
                      data: "{weeklyMenu:" + JSON.stringify(weekly) + "}",
                      dataType: "json",
                      success: function (result) {

                          if ($('#hdnValue').val() != "0") { //Edit mode

                              $('#tr' + $('#hdnValue').val()).html(""+
                              "<td align='center'><span><strong>" + $('#txtMenu').val() + "</strong></span></td>" +
                              "<td align='center'><span><strong>" + $('#txt1').val() + "</strong></span></td>" +                              
                            "<td align='center'><span><strong>" + $('#txt2').val() + "</strong></span></td>" +
                            "<td align='center'><span><strong>" + $('#txt3').val() + "</strong></span></td>" +
                            "<td align='center'><span><strong>" + $('#txt4').val() + "</strong></span></td>" +
                            "<td align='center'><span><strong>" + $('#txt5').val() + "</strong></span></td>" +
                            "<td align='center'><span><strong>" + $('#txt6').val() + "</strong></span></td>" +
                            "<td align='center' style='display:none'><span><strong>" + $('#txt7').val() + "</strong></span></td>"+
                             "<td align='center'><span><strong><input type='button' onclick=SelectRow('tr" + $('#hdnValue').val() + "')  value='Select' /><input type='button' onclick=Delete('tr" + $('#hdnValue').val() + "')  value='Delete' /></strong></span></td>");
                          }
                          else {
                              if (result.d > 1) { //Add mode

                                  $('.weeklyMenuTable tbody').append("<tr id='tr" + result.d + "' valign='middle'>" +
                                  "<td align='center'><span><strong>" + $('#txtMenu').val() + "</strong></span></td>" +
                              "<td align='center'><span><strong>" + $('#txt1').val() + "</strong></span></td>" +
                             "<td align='center'><span><strong>" + $('#txt2').val() + "</strong></span></td>" +
                             "<td align='center'><span><strong>" + $('#txt3').val() + "</strong></span></td>" +
                             "<td align='center'><span><strong>" + $('#txt4').val() + "</strong></span></td>" +
                             "<td align='center'><span><strong>" + $('#txt5').val() + "</strong></span></td>" +
                             "<td align='center'><span><strong>" + $('#txt6').val() + "</strong></span></td>" +
                             "<td align='center' style='display:none'><span><strong>" + $('#txt7').val() + "</strong></span></td>" +
                             "<td align='center'><span><strong><input type='button' onclick=SelectRow('tr" + result.d + "')  value='Select' /><input type='button' onclick=Delete('tr" + result.d + "')  value='Delete' /></strong></span></td>" +
                             "</tr>");
                              }
                          }
                          alert('Saved Sucessfully!!');

                          $('#hdnValue').val("0");
                          $('#txt1').val('');
                          $('#txt2').val('');
                          $('#txt3').val('');
                          $('#txt4').val('');
                          $('#txt5').val('');
                          $('#txt6').val('');
                          $('#txt7').val('');
                          $('#txtMenu').val('');

                          $('#btAdTolst').val('Submit');
                          //$('#btnsubmit').val('Submit');
                          $('#hdnValue').val("0");
                          $('.weeklyMenuTable').show();
                      },
                      error: function (res) { alert("During Order -" + res.status + ' ' + res.statusText); }
                  });



              }

//              function SelectRow(trid) {

//                  $('#hdnValue').val(trid.replace('tr', ''));
//                  $('#txtMenu').val($('#' + trid + " td:eq(0) strong").html());
//                  $('#txt1').val($('#' + trid + " td:eq(1) strong").html());
//                  $('#txt2').val($('#' + trid + " td:eq(2) strong").html());
//                  $('#txt3').val($('#' + trid + " td:eq(3) strong").html());
//                  $('#txt4').val($('#' + trid + " td:eq(4) strong").html());
//                  $('#txt5').val($('#' + trid + " td:eq(5) strong").html());
//                  $('#txt6').val($('#' + trid + " td:eq(6) strong").html());
//                  $('#txt7').val($('#' + trid + " td:eq(7) strong").html());
//                  

//                  $('#btAdTolst').val('Update');

//                  $('.weeklyMenuTable').hide();
//                  //$('#btnsubmit').val('Update');
//              }

              function Delete(trid) {


                  if ( !confirm('Are you sure you want to delete this item?') ) {                      
                      return false;
                  }

                  $.ajax
                  ({
                      type: "POST",
                      url: "../KompServices.asmx/DeltedWeeklyMenuItem",
                      contentType: "application/json; charset=utf-8",
                      data: "{id:" + parseInt(trid.replace('tr','')) + "}",
                      dataType: "json",
                      success: function (result) {

                          if (result.d > 1) { //Add mode

                              alert('Deleted Sucessfully!!');
                              $("#"+trid).remove();
                              Reset();
                          }

                      },
                      error: function (res) { alert("During deletre -" + res.status + ' ' + res.statusText); }
                  });



              }

              function Reset()
              {
                         $('#hdnValue').val("0");
                          $('#txt1').val('');
                          $('#txt2').val('');
                          $('#txt3').val('');
                          $('#txt4').val('');
                          $('#txt5').val('');
                          $('#txt6').val('');
                          $('#txt7').val('');
                          $('#txtMenu').val('');
                          $('#btAdTolst').val('Submit');
                          //$('#btnsubmit').val('Submit');
                          $('#hdnValue').val("0");
              }

              function SelectRow(trid) {

                  $('#hdnValue').val(trid.replace('tr', ''));
                  $('#txt1').val($('#' + trid + " td:eq(1) strong").html());
                  $('#txt2').val($('#' + trid + " td:eq(2) strong").html());
                  $('#txt3').val($('#' + trid + " td:eq(3) strong").html());
                  $('#txt4').val($('#' + trid + " td:eq(4) strong").html());
                  $('#txt5').val($('#' + trid + " td:eq(5) strong").html());
                  $('#txt6').val($('#' + trid + " td:eq(6) strong").html());
                  $('#txt7').val($('#' + trid + " td:eq(7) strong").html());
                  $('#txtMenu').val($('#' + trid + " td:eq(0) strong").html());
                  $('.weeklyMenuTable').hide();
                  $('#btAdTolst').val('Update');
                  //$('#btnsubmit').val('Update');
              }

    function WeeklyMenu() {
        var Id;      
        var Monday;
        var Tuesday;
        var Wednesday;
        var Thursday;
        var Friday;
        var Saturday;
        var Sunday;
        var IsActive;
        var ShowIn;
        var MenuItm;
    }
</script>
</asp:Content>

