<%@ Page Title="" Language="C#" MasterPageFile="SiteMaster.Master" AutoEventWireup="true" CodeBehind="HolidayMaster.aspx.cs" Inherits="KitchenOnMyPlate.Masters.HolidayMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="../Styles/themes/base/jquery.ui.all.css" />	
    
	<script type="text/javascript" src="../Scripts/ui/jquery.ui.core.js"></script>
	<script type="text/javascript" src="../Scripts/ui/jquery.ui.widget.js"></script>
	<script type="text/javascript" src="../Scripts/ui/jquery.ui.datepicker.js"></script>

    <style>
        #divHolidayList b{margin-left:10px;color:#4b220c;}
        #divHolidayList b:hover{color:#ed651e;}
    </style>

<script type="text/javascript"\>
    var list = new Array();
    var currentSelected = '';
    var cnt = <%=cnt%>;
    /** Datepicker start */
    /** Days to be disabled as an array */
    //var disabledSpecificDays = ["3-20-2015", "9-24-2015", "9-25-2015", "10-01-2015"];
    var disabledSpecificDays = ["3-20-2015"];

    function disableSpecificDaysAndWeekends(date) {
        var m = date.getMonth();
        var d = date.getDate();
        var y = date.getFullYear();
        for (var i = 0; i < disabledSpecificDays.length; i++) {
            if ($.inArray((m + 1) + '-' + d + '-' + y, disabledSpecificDays) != -1 || new Date() > date) {
                return [false];
            }
        }
        var noWeekend = $.datepicker.noWeekends(date);
        return !noWeekend[0] ? noWeekend : [true];
    }

    $(document).ready(function () {

        //GetHolidayes();
        SetCalender();

        $('#btnAddDate').click(function () {

        var IsalreadyListed = false;
        
                $(".spndt").each(function (index) {
                    if ($(this).html() == $("#txtPossessionDate").val())
                    {
                    IsalreadyListed = true;                
                    }
                });

            if ($("#txtPossessionDate").val() != "") {

                if(!IsalreadyListed)
                {
                $("#divHolidayList").append("<div id='divDt" + cnt + "' > <span class='spndt'>" + $("#txtPossessionDate").val() + "</span> <span  style='cursor:pointer' onclick=DeleteItem('divDt" + cnt + "') ><b>X</b></span>  </div>");
                $("#txtPossessionDate").val('');
                cnt++;
                }
                else
                {
                    alert('Date cannot be added as it already listed for holiday!!')                    
                }

            }
            else {
                alert('Please enter date');
                $("#txtPossessionDate").focus();
            }
        });

        $("#txtPossessionDate").change(function () {
            currentSelected = $("#txtPossessionDate").val();
            var dateParts = $("#txtPossessionDate").val().split('/');
            $("#txtPossessionDate").val(dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2]);
        });

    });

    function SetCalender() {        
        var maxDate = new Date(); //getDateYymmdd($(this).data("val-rangedate-max"));
        maxDate.setDate(maxDate.getDate()+365);
        $("#txtPossessionDate").datepicker({
            beforeShowDay: disableSpecificDaysAndWeekends,
            //dateFormat: "dd-mm-yy",
            minDate: 1,
            maxDate: maxDate,
            changeMonth: true,
            changeYear: true,
            numberOfMonths: 3
        });
    }
    /** Datepicker end */

    function DeleteItem(id) {        
        $("#" + id).remove();
        cnt--;
    }

    function SaveHoliday() {


        $(".spndt").each(function (index) {
            var dateParts = $(this).html().split('/');
            var objHoliDay = new HoliDay();
            objHoliDay.Id = 0;
            objHoliDay.DeliverDate = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
            objHoliDay.IsActive = 1;
            list.push(objHoliDay);
        });

        $.ajax
                  ({
                      type: "POST",
                      url: "../KompServices.asmx/SubmitHoliday",
                      contentType: "application/json; charset=utf-8",
                      data: "{list:" + JSON.stringify(list) + "}",
                      dataType: "json",
                      success: function (result) {           
                          alert('Updated Holidayes sucessfully!! ');
                          window.location.href = "CMS.aspx";

                      },
                      error: function (res) { alert("During post -" + res.status + ' ' + res.statusText); }
                  });
              }

              

              /*****Classes********************/
              function HoliDay() {
                  var Id;
                  var DeliverDate;                  
                  var IsActive;
              }


</script>
<div style="width:100%;font-size:25px;font-weight:bold;padding-top:10px;font-family:RobotoBold;color:#4b220c">Holiday Master</div>        

<input id="txtPossessionDate" style="" placeholder="select date" type="text" /> 
<input type="button" id="btnAddDate" style="background:#4b220c;padding:10px !important; margin-left:0px !important;" value="Add To List"  />
<div id="divHolidayList" runat="server" clientidmode="Static" style="width:30%;height:auto"></div>
<input type="button" id="btnSubmit" value="Submit" style="background:#4b220c;padding:10px !important; margin-left:0px !important;" onclick="SaveHoliday();" />
<input type="button" id="Button1" value="Main Menu" style="background:#ed651e;padding:10px !important; margin-left:0px !important;" onclick="window.location.href='cms.aspx'" />
</asp:Content>
