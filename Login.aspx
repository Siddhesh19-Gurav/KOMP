<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KotaCoachings.Login" Title="" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript" >
    //*******************************LOGIN***************Start
       

    $(function () {
        

        $("#loginBttn").click(function () {

            

            
                var txtuser = document.getElementById("txtExistingUserName").value;
                var txtpwd = document.getElementById("txtPasswordExistingUser").value;

                if (txtuser == "") {
                    alert('Please enter user name');
                    return false;
                }
                else if (txtpwd == "") {
                    alert('Please enter password');
                    return false;
                }

                DoLoginNewExistance(txtuser, txtpwd);
            

            return false;
        });

       

        /////
    });





    var picture = '';
  


        //$("#ImgProgress img").css("margin-top", "350px");

        //$("#ImgProgress").height($("#divMain").height() + 160).show();







    function CreateSession(txtuser) {

        if (txtuser != '') {
            $.ajax({
                type: "POST",
                url: "KompServices.asmx/CreateSession",
                contentType: "application/json; charset=utf-8",
                data: "{userid:'" + txtuser + "'}",
                dataType: "json",
                success: function (result) {

                    window.location.href = 'default1.aspx';

                },
                error: function (errorMessage) { }
            });
        }
        return false;
    }

    function DoLoginNewExistance(txtuser, txtpwd) {
        if (txtuser != '') {

            $.ajax({
                type: "POST",
                url: "KompServices.asmx/IsValidUser",
                contentType: "application/json; charset=utf-8",
                data: "{userid:'" + txtuser + "',password:'" + txtpwd + "'}",
                dataType: "json",
                success: AjaxSucceeded2,
                error: function (errorMessage) { }
            });
        }
        return false;
    }


    function AjaxSucceeded2(result) {
        if (result.d) {
            var LoginID = Trim(document.getElementById("txtExistingUserName").value);
            CreateSession(LoginID); //Create Session
           
        }
        else {
            alert('Invalid User!');
        }
     
    }


    //*******************************LOGIN***************End




</script>

  
  <asp:HiddenField ID="HiddenField1" Value="1" runat="server" />
  
  <!--container end here-->
      <div class="row">
   	<div  id="loginDiv" class="contact-form_grid" style="float:left; text-align:left; width:50%;height:auto">
        
      <div class="col-ms-12">
		     <article class="page-art">
                        <h1 class="page-title">LOGIN TO YOUR ACCOUNT</h1>                        
                        </article>

		
        
        

			
			
            <h3 class="ContactLabel">EMAIL ADDRESS<em style="color:Red">*</em></h3>
			<input id="txtExistingUserName" class="textbox"  type="text" placeholder="Enter your email address here.." value=""/>
			
		

			
			         
		<h3 class="ContactLabel">PASSWORD<em style="color:Red">*</em></h3>
        <input id="txtPasswordExistingUser" class="textbox" type="password"  placeholder="Enter your password here.." />
	    <span><a href="javascript:void(0)" style="color:#FE0000" onclick="ForgotPwd()" >FORGOT YOUR PASSWORD? CLICK HERE!</a> </span>
        <br style="padding-top:10px;" />
        <%--<input type="button" value="Back" onclick="ShowQuantity();" />         --%>
        <input id="loginBttn" type="button" class="btnRed" style="margin-left:0em" value="SIGN IN NOW!" />        
        <div class='SuccessDiv' style="display:none" ></div>   
		

      </div>
	</div>
    </div>
    <div style="height:50px;clear:none"></div>
</asp:Content>
