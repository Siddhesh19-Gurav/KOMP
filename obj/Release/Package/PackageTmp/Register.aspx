<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KotaCoachings.Register" Title="" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript" >
    //*******************************LOGIN***************Start

    function switchUserType(divId) {
        if (divId == "N") {
            $("#loginDiv").show();
            $("#regDiv").hide();
            $("#loginBttn div").html("Login");

        }
        else {
            $("#loginDiv").hide();
            $("#regDiv").show();
            $("#loginBttn div").html("Register");

            // $("#ifUserNotLoggedIn").height($("#regDiv").height());
        }
    }


    $(function () {
        $("#ifUserNotLoggedIn,#loginBttn").hide();
               

        $("#btnRegister").click(function () {

            //var IsExistanceUser = $("#regDiv").is(':hidden');

            // if (!IsExistanceUser) { //Existance user , create session
            SubmitUser();
            // }           
            return false;
        });

        /////
    });





    var picture = '';
    function SubmitUser() {

        
        var txtFirstName = Trim(document.getElementById("txtFirstName").value);
        var txtLastName = Trim(document.getElementById("txtLastName").value);
        var txtEmail = Trim(document.getElementById("txtEmail").value);
        var NewOld = Trim(document.getElementById("ContentPlaceHolder1_hdnIsNew").value);

        var txtPasssword = "";
        var txtRePasssword = "";
        if (NewOld == "1")
        {
        txtPasssword = Trim(document.getElementById("txtPasssword").value);
        txtRePasssword = Trim(document.getElementById("txtRePasssword").value);
        }

        var txtMobile = Trim(document.getElementById("txtMobile").value);

        var location = Trim(document.getElementById("ContentPlaceHolder1_drpLocation").value);
        var txtCompanyName = Trim(document.getElementById("txtCompanyName").value);
        var WorkingSince = 0;
        var address = Trim($("#txtAddress").val());
        
              

        location = (location == "") ? "0" : location;

        if (txtFirstName == '' || txtLastName == '') {
            alert('Please fill First Name and Last Name.');
            $("#txtFirstName").focus();
            return false;
        }


        if (txtMobile == '') {
            alert('Please fill mobile number.');
            $("#txtMobile").focus();
            return false;
        }


        if (address == '') {
            alert('Please fill Address.');
            $("#txtAddress").focus();
            return false;
        }


        if (NewOld=="1" && txtEmail == '') {
            alert('Please Enter Email address.');
            $("#txtEmail").focus();
            return false;
        }

        if (location == '') {
            alert('Please select location.');
            $("#ContentPlaceHolder1_drpLocation").focus(); 
            return false;
        }

        if (NewOld == "1") {
            if (txtPasssword == "") {
                alert('Please enter password.');
                return false;
            }

            if (txtRePasssword != txtPasssword) {
                alert('Please confirm password.');
                return false;
            }

        }

        //       if ($("#fileToUpload").val() != "") {
        //           if (confirm("Do you want to upload your pictue? Click Upload!")) {
        //               return false;
        //           }
        //       }

        if (NewOld == "1" && !$('#chkAgree').is(':checked')) {
            alert("Please accept Terms & Conditions");
            return false;
        }


        //$("#ImgProgress img").css("margin-top", "350px");

        //$("#ImgProgress").height($("#divMain").height() + 160).show();




        $.ajax({
            type: "POST",
            url: "KompServices.asmx/SubmitUser",
            contentType: "application/json; charset=utf-8",
            data: "{firstName:'" + txtFirstName + "',lastName:'" + txtLastName + "',email:'" + txtEmail + "',mobile:'" + txtMobile + "',passsword:'" + txtPasssword + "',NewOld:" + NewOld + ",userType:'0',location:'" + location + "',WorkingSince:'0',picture:'',std:'0',landline:'0',landline1:'',landline2:'',web:'',social:'',address:'" + address + "',aboutu:'',companyName:'" + txtCompanyName + "',companyLogo:''}",
            dataType: "json",
            success: AjaxSubmitUserSucceeded,
            error: function (er) { alert(err.d); }
        });



        return false;
    }

    function AjaxSubmitUserSucceeded(result) {

        $("#ImgProgress").hide();
        if (result.d == 9999999) {
            alert('User with this email is already exist.');
        }
        else if (result.d == 8888888) {
            alert('User with this mobile is already exist.');
        }
        else {
            loggiedIn = result.d;
                                    

            var LoginID = Trim(document.getElementById("txtEmail").value);
            CreateSession(LoginID); //Create Session

            
        }

        $("#ImgProgress").hide();
    }



    function CreateSession(txtuser) {
            
        if (txtuser != '') {

            $.ajax({
                type: "POST",
                url: "KompServices.asmx/CreateSession",
                contentType: "application/json; charset=utf-8",
                data: "{userid:'" + txtuser + "'}",
                dataType: "json",
                success: function (result) {

                    if (Trim(document.getElementById("ContentPlaceHolder1_hdnIsNew").value) == "1") 
                    {
                        alert('Thanks  for registering!!');
                    }
                    else 
                    {
                        alert('Update successfully!!');
                    }

                    window.location.href = '/';
                },
                error: function (errorMessage) { }
            });
        }
        return false;
    }

    
    

    //*******************************LOGIN***************End




</script>

  
  <asp:HiddenField ID="hdnIsNew" Value="1" runat="server" />
  
  <!--container end here-->
      <div class="row faq">
    	<div class="MoreDet" id="regDiv" style="width:100%;height:auto">

    <div class="contact-form_grid" style="float:left; text-align:left; width:100%;height:auto">
		
             <article class="page-art">
                        <h1 class="page-title" runat="server" id="registerH1" >REGISTER NOW!</h1>                        
                        </article>

                        <div style="float:left;width:50%;height:auto;padding-right:15px">

			<h3 class="ContactLabel">FIRST NAME<em style="color:Red">*</em></h3>			
		    <input id="txtFirstName" runat="server" clientidmode="Static" class="textbox AlphaClass" placeholder="Enter your first name here.." maxlength="22" type="text" value=""/>
			
	<h3 class="ContactLabel">LAST NAME<em style="color:Red">*</em></h3>
			<input id="txtLastName" runat="server" clientidmode="Static" class="textbox AlphaClass" maxlength="22" placeholder="Enter your last name here.." type="text" value=""/>
			
		
        	<h3 class="ContactLabel">MOBILE<em style="color:Red">*</em></h3>
			
				<input id="txtMobile" runat="server" clientidmode="Static" placeholder="Enter your mobile number here.." class="textbox NumberClass" type="text" value="" maxlength="10"/>
			
			
		

                
			<h3 class="ContactLabel">COMPANY NAME<em style="color:Red">*</em></h3>		
			<input id="txtCompanyName" runat="server" clientidmode="Static" class="textbox AlphaClass" placeholder="Enter your company name here.." maxlength="22" type="text" value=""/>
			
		    <h3 class="ContactLabel">LOCATION<em style="color:Red">*</em></h3>		
			<asp:DropDownList ID="drpLocation" runat="server"></asp:DropDownList>
		

		
    
            </div>
                        <div style="float:left; width:50%;height:auto;padding-left:15px">
     
     	
		
		
        
			<h3 class="ContactLabel">ADDRESS<em style="color:Red">*</em></h3>
            <textarea id="txtAddress" runat="server" clientidmode="Static" placeholder="Enter your address here.." class="textbox" maxlength="200"  style="height:27px" rows="2"></textarea>

		<h3 class="ContactLabel">EMAIL<em style="color:Red">*</em></h3>
	
				<input id="txtEmail" runat="server" clientidmode="Static" class="textbox EmailClass" placeholder="Enter your email address here.." type="text" value=""/>
			
            <div runat="server" id="divPassword" >
                <h3 class="ContactLabel">Password<em style="color:Red">*</em></h3>
	
				<input id="txtPasssword" runat="server" clientidmode="Static" class="textbox EmailClass" placeholder="Enter password here.." type="password" value=""/>
                <h3 class="ContactLabel">Re-Password<em style="color:Red">*</em></h3>
	
				<input id="txtRePasssword" runat="server" clientidmode="Static" class="textbox EmailClass" placeholder="Re Enter your password here.." type="password" value=""/>
	
    <div style="width:100%;height: auto;" class="SearchTxt"  >
        <input id="chkAgree" type="checkbox" />  I agree to <asp:Label ID="lblSite" runat="server" ></asp:Label>'s <a href="javascript:void()" onclick="OpernTerms()" target="_blank">Terms &amp; Conditions</a>.<br/>	
    </div>			
    </div>
    <input id="btnRegister" runat="server" clientidmode="Static" type="button" class="btnRed" style="margin-left:0px" value="CREATE YOUR ACCOUNT" />        
	</div>

		    <div style="clear:none"></div>
	

    

        </div>

      
	</div>
    </div>
    <div style="clear:none"></div>
</asp:Content>
