var OnProductPage = false;

function OpernTerms() {
    window.open('TermsNConditions.aspx', 'winname', "directories=0,titlebar=0,toolbar=0,location=0,status=0,menubar=0,scrollbars=yes,resizable=no,width=1050,height=570");
}


function ForgotPwd() {
    window.open('ForgetPassword.htm', 'winname', "directories=0,titlebar=0,toolbar=0,location=0,status=0,menubar=0,scrollbars=yes,resizable=no,width=510,height=180");
}


function Trim(str) {
    while (str.substring(0, 1) == ' ') // check for white spaces from beginning
    {
        str = str.substring(1, str.length);
    }
    while (str.substring(str.length - 1, str.length) == ' ') // check white space from end
    {
        str = str.substring(0, str.length - 1);
    }

    return str;
}



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
    $("#ifUserNotLoggedIn").hide();



    $('#txtFirstName').keypress(function (e) {
        if (e.which == 13) {
            jQuery(this).blur();
            jQuery('#txtEmail').focus();
        }
    });


    $('#txtEmail').keypress(function (e) {
        if (e.which == 13) {
            jQuery(this).blur();
            jQuery('#txtPasssword').focus();
            return false;
        }
    });

    $('#txtPasssword').keypress(function (e) {
        if (e.which == 13) {
            jQuery(this).blur();
            jQuery('#txtRePasssword').focus();
            return false;
        }
    });
    $('#txtRePasssword').keypress(function (e) {
        if (e.which == 13) {
            jQuery(this).blur();
            jQuery('#btnRegister').click();
            return false;

        }
    });


    $('#txtExistingUserName').keypress(function (e) {

        if (e.which == 13) {
            jQuery(this).blur();
            jQuery('#txtPasswordExistingUser').focus();
            return false;
        }
    });
    $('#txtPasswordExistingUser').keypress(function (e) {
        if (e.which == 13) {
            jQuery(this).blur();
            jQuery('#loginBttn').click();
            return false;
        }
    });

    $("#btnForgotPassword").click(function () {

        if (ValidateEmail(document.getElementById("txtForgotPassword").value)) {
            $.ajax
                  ({
                      type: "POST",
                      url: "KompServices.asmx/ForgetPassword",
                      contentType: "application/json; charset=utf-8",
                      data: "{email:" + JSON.stringify(document.getElementById("txtForgotPassword").value) + "}",
                      dataType: "json",
                      async: false,
                      success: function (result) {
                          if (result.d == "1") {
                              swal('Password has been sent to your registered email address. Please check spam/ junk folder as well.');
                              //window.close();
                              $("#Forgotmodal").hide();
                              $("#lean_overlay").hide();
                              document.getElementById("txtForgotPassword").value = '';
                          }
                          else if (result.d == "9999") {
                              swal('Your EmailId does not match our records. Please try again');
                          }
                      },
                      failure: function (response) {
                          alert(response.d);
                      }
                  });
        }
        else {
            swal('Please enter valid user id');
            $("#txtExistingUserName").focus();
            return false;
        }

    });

    function ValidateEmail(mail) {
        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
            return (true)
        }
        else {
            return false;
        }
    }

    $("#loginBttn").click(function () {

        //var IsExistanceUser = $("#regDiv").is(':hidden');


        var txtuser = document.getElementById("txtExistingUserName").value;
        var txtpwd = document.getElementById("txtPasswordExistingUser").value;

        if (txtuser == "") {
            swal('Please enter user name');
            return false;
        }
        else if (txtpwd == "") {
            swal('Please enter password');
            return false;
        }



        DoLoginNewExistance(txtuser, txtpwd);


        return false;
    });

    $("#btnRegister").click(function () {

        //var IsExistanceUser = $("#regDiv").is(':hidden');

        // if (!IsExistanceUser) { //Existance user , create session
        return SubmitUser();
        // }           

    });


    $("#login,#aRegister").attr("href", "#loginmodal");

    $("#lnkForgotPassword").attr("href", "#Forgotmodal")


    $('.SOSC a').mouseover(function () {
        $(this).find(".MAM").hide();
        $(this).find(".MAMH").show();
    });
    
    $('.SOSC a').mouseout(function () {
        $(this).find(".MAM").show();
        $(this).find(".MAMH").hide();
    });


    $('option').hover(function () {
        $(this).css("background-color", "#F16822");
    });

    /////
    $('.nav li.scroll').removeClass('active');

    if (subpageId != "") {
        $("#" + subpageId).addClass('active');
    }

    $('.nav li.scroll:nth(' + pageId + ')').addClass('active');



});





var picture = '';
function SubmitUser() {


    var txtFirstName = Trim(document.getElementById("txtFirstName").value);
    var txtLastName = '';// Trim(document.getElementById("txtLastName").value);
    var txtEmail = Trim(document.getElementById("txtEmail").value);
    var txtPasssword = Trim(document.getElementById("txtPasssword").value);
    var txtRePasssword = Trim(document.getElementById("txtRePasssword").value);
    var txtMobile = Trim(document.getElementById("txtMobile").value);

    var location = ''; //Trim(document.getElementById("ContentPlaceHolder1_drpAgentLocation").value);
    var txtCompanyName = ''; //Trim(document.getElementById("txtCompanyName").value);
    var WorkingSince = 0; //Trim(document.getElementById("<%=drpWorkingSince.ClientID%>").value);  
    var address = ''; //Trim($("#txtAddress").val());

    //picture = (picture == '') ? $("#loading").attr("src") : picture;

    //picture = (picture.split('/').length == 3) ? picture.split('/')[2] : (picture.split('/').length == 2) ? picture.split('/')[1] : picture;

    //       var userType = 'A';
    //       if ($('#rdUType1').is(':checked')) {
    //           var IsPostingProperty = "<%=IsPostingProperty%>"; //True if Property is getting posted/Updated                                        
    //           userType = (IsPostingProperty == "True") ? "O" : "C";
    //       }
    //       else if ($('#rdUType3').is(':checked')) {
    //           userType = "B";
    //       }

    location = (location == "") ? "0" : location;

    if (txtFirstName == '' ) {
        swal('Please fill First Name.');
        $("#txtFirstName").focus();
        return false;
    }

        

//    if (address == '') {
//        swal('Please fill Address.');
//        $("#txtAddress").focus();
//        return false;
//    }


    if (txtEmail == '') {
        swal('Please Enter Email address.');
        $("#txtEmail").focus();
        return false;
    }

        if (txtMobile == '') {
            swal('Please fill mobile number.');
            $("#txtMobile").focus();
            return false;
        }



////           if (txtPasssword == "") {
////               swal('Please enter password.');
////               jQuery('#txtPasssword').focus();
////               return false;
////           }

        if (txtMobile.length < 10) {
            swal('Mobile number must be 10 digits');
            jQuery('#txtMobile').focus();
               return false;
           }


           if (txtRePasssword != txtPasssword) {
               swal('Password and confirm password not match!');
               jQuery('#txtRePasssword').focus();
               return false;
           }



    //       if ($("#fileToUpload").val() != "") {
    //           if (confirm("Do you want to upload your pictue? Click Upload!")) {
    //               return false;
    //           }
    //       }

    if (!$('#chkAgree').is(':checked')) {
        swal("Please accept Terms & Conditions");
        return false;
    }


    //$("#ImgProgress img").css("margin-top", "350px");

    //$("#ImgProgress").height($("#divMain").height() + 160).show();




    $.ajax({
        type: "POST",
        url: "KompServices.asmx/SubmitUser",
        contentType: "application/json; charset=utf-8",
        data: "{firstName:'" + txtFirstName + "',lastName:'" + txtLastName + "',email:'" + txtEmail + "',mobile:'" + txtMobile + "',passsword:'" + txtPasssword + "',NewOld:1,userType:'0',location:'" + location + "',WorkingSince:'0',picture:'',std:'0',landline:'0',landline1:'',landline2:'',web:'',social:'',address:'" + address + "',aboutu:'',companyName:'" + txtCompanyName + "',companyLogo:''}",
        dataType: "json",
        success: AjaxSubmitUserSucceeded,
        error: function (er) { swal(err.d); }
    });



    return false;
}

function AjaxSubmitUserSucceeded(result) {

   // $("#ImgProgress").hide();

    if (result.d == 111111) {
        swal('This email address is already registered with us. \n Please enter another email address.');
        return false;
    }
    else if (result.d == 9999999) {
        swal('This email address is already registered with us. \n Please enter another email address.');
        return false;
    }
    else {
        //loggiedIn = result.d;

        $("#btnRegister").hide();
        $("#txtEmail").attr('readonly', 'readonly');
        swal('Thank you for registering at Kitchen On My Plate!'); //\n Please login with the password sent to your email.

        document.getElementById("txtFirstName").value = "";
        document.getElementById("txtEmail").value = "";
        document.getElementById("txtPasssword").value = "";
        document.getElementById("txtRePasssword").value = "";
        document.getElementById("txtMobile").value = "";

        if ($('#hdnIsHome').val() != "5") {
            //swal('Thanks  for registration at Kitchen At My Plate! \n Please check your email, we have sent a password!!');
            //CreateSession(LoginID); //Create Session
            return false;
        }
        else {

            //$("#txtExistingUserName").val(Trim(document.getElementById("txtEmail").value));
            //$("#loginDiv").show();
            

            //$("#ifUserNotLoggedIn,#loginBttn").hide();


            var LoginID = document.getElementById("txtEmail").value;

            //CreateSession(LoginID); //Create Session
            return false;
        }
    }

    $("#ImgProgress").hide();
    return false;
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

                $('#loggendUser').text("Hi " + result.d.FirstName);
                $("#aMyOrders,#logOut,#loggendUser").show();
                $("#login,#aRegister,#loginmodal,#Forgotmodal,#lnkForgotPassword,#lblhindResh").hide();

                loggiedIn = result.d.UserId;

                //orderDTO.orderDTO.CustomerId = loggiedIn;
                //                   $(".slmainMenu").each(function (index) {
                //                   $.each(orderList)
                //                   {
                //                       $(this).Order.CustomerId = loggiedIn;
                //                   }

                $("#lean_overlay").hide();
                if ($('#hdnIsHome').val() == "5") {
                    SaveOrder(orderList);
                }
                else if ($('#hdnIsHome').val() == "7") //7 indicate calls from ItemBox then go direct on paymetprocess page once click on register/logon(logged in case)
                {
                    window.location.href = "PaymentProcess.aspx?LT=LS%%";
                }

            },
            error: function (errorMessage) { }
        });
    }
    return false;
}

function DoLoginNewExistance(txtuser, txtpwd) {
    var rememberme = $('#chkrem').is(':checked') ? 1 : 0;
    if (txtuser != '') {
        if ($('#chkrem').is(':checked')) {
            // save username and password
            localStorage.usrname = txtuser;//$('#username').val();
            localStorage.pass = txtpwd;//$('#pass').val();
            localStorage.chkbx = $('#chkrem').val();
        } else {
            localStorage.usrname = '';
            localStorage.pass = '';
            localStorage.chkbx = '';
        }
        $.ajax({
            type: "POST",
            url: "KompServices.asmx/IsValidUser",
            contentType: "application/json; charset=utf-8",
            data: "{userid:'" + txtuser + "',password:'" + txtpwd + "',rememberme:" + rememberme + "}",
            dataType: "json",
            success: AjaxSucceeded2,
            error: function (errorMessage) { }
        });
    }
    return false;
}


function AjaxSucceeded2(result) {
    
    if (result.d) {
        $("#ifUserNotLoggedIn").hide();
        $("#saveAndProceed").show();
        CreateSession(document.getElementById("txtExistingUserName").value); //Create Session
    }
    else {
        swal('Invalid login id or password!');
        $("#txtExistingUserName").focus();
    }
}


//*******************************LOGIN***************End

function GOTOPAYMENT() {

        
    if (loggiedIn > 0) {
    
        //SaveOrder(orderList);
        window.location.href = "PaymentProcess.aspx?LT=LS%%";
        return false;
    }
    else {
        $('#hdnIsHome').val("7");//7 indicate calls from ItemBox then go direct on paymetprocess page once click on register/logon(logged in case)
        $('#aRegister').click();
        return false;
        //$("#ifUserNotLoggedIn,#loginBttn").show();
        //$("#divQuantity,#saveAndProceed").hide();
    }   
}

function DeleteOrderOnHome(indx) {

    
    if (!OnProductPage) { //Delete only in cart
        //var msgConfirm = ($("#PlacedOrders .cstItem").length == 1) ? "At least one order need to be placed, Do you want to delete it?" : "Are you confirmed want to delete selected item?";
        var msgConfirm = ($("#PlacedOrders .cstItem").length == 1) ? "Are you sure, you want to delete this Order from the Cart?" : "Are you sure, you want to delete this Order from the Cart?";
        swal({ title: msgConfirm, text: "", type: "warning", showCancelButton: true, confirmButtonColor: "#4b220c", confirmButtonText: "YES", cancelButtonText: "NO", closeOnConfirm: false, closeOnCancel: false },
    function (isConfirm) {
        if (isConfirm) {
            swal("", "Your order has been deleted.", "success");

            if ($('#hdnIsHome').val() == "5") //5 means if it is on order page
            {
                $('#OrdHome' + indx).remove();
                orderlst.splice(indx, 1);
                orderList.orders = orderlst;
                $("#PlacedOrders").hide();
            }

            CreateOrdersSessionOnHome(indx);
            GetPlacedOrderFinalHTML();

        } else {
            swal("", "Your Order is safe !!", "error");
        }
    });



        if ($("#PlacedOrders .cstItem").length == 0) {
            $('#OrdHome' + indx).remove();
            
            ShowItems();
        }
    }
    else {//Delete in both cart and on product page, inside product page called createproduct session it will refresh to cart.
        
        DeleteOrder(indx);
    }
    
}

function GetPlacedOrderFinalHTML() {

    $.ajax
                  ({
                      type: "POST",
                      url: "KompServices.asmx/GetPlacedOrderFinalHTML",
                      contentType: "application/json; charset=utf-8",
                      data: "{}",
                      dataType: "json",
                      success: function (result) {


                          $("#divFinal .tableCart tbody").html(result.d);
                          //if (result.d.split('$')[0].length > 0) {
                          //$(".tableCart1 tbody").html(result.d);
                          //}

                          //window.location.href = 'default1.aspx';
                      },
                      error: function (res) { swal("During session home -" + res.status + ' ' + res.statusText); }
                  });
}


function CreateOrdersSessionOnHome(indx) {

    $.ajax
                  ({
                      type: "POST",
                      url: "KompServices.asmx/CreateOrdersSessionOnHome",
                      contentType: "application/json; charset=utf-8",
                      data: "{index:" + indx + "}",
                      dataType: "json",
                      success: function (result) {

                         
                          //if (result.d.split('$')[0].length > 0) {
                          $(".tableCart1 tbody").html(result.d.split('$')[0]);
                          //}

                          if ($('#hdnIsHome').val() == "5") //5 means if it is on order page
                          {
                              $(".custom-ltr:first").html(orderList.orders.length + " Item(s) -");
                              $(".custom-ltr:last").html($(".tableCart1 .priceTotal:last").html());
                          }
                          else {// It is not from oder page
                              var itemdetails = result.d.split('$')[1];
                              $(".custom-ltr:first").html(itemdetails.split('^')[0] + " Item(s) -");
                              //$(".custom-ltr:last").html("<i class='fa fa-inr'></i>" + itemdetails.split('^')[1]);
                              $(".custom-ltr:last").html($(".tableCart1 .priceTotal:last").html());
                          }

                          if (result.d.split('$')[1].split('^')[0] == "0") {
                              $(".hidemodal").click();
                          }




                          //window.location.href = 'default1.aspx';
                      },
                      error: function (res) { swal("During session home -" + res.status + ' ' + res.statusText); }
                  });
              }


function SearchResult() {
var txt = $("#txtSearch").val();
window.location.href = "search.aspx?q=" + txt;
return false;
}

function NewsLetter() {

    var email = $("#txtNewsLetter").val();    
    if (email == '') {
        swal('Please enter email address.');
        $("#txtNewsLetter").focus();
        return false;
    }   



    $.ajax({
        type: "POST",
        url: "KompServices.asmx/SendMsgToAgent",
        contentType: "application/json; charset=utf-8",
        data: "{name:'',mobile:'',email:'" + email + "',message:'News Letter Request',agentId:0,propertyId:0}",
        dataType: "json",
        success: function (w) {

            swal("Thank you for your subscription.");
            $("#txtNewsLetter").val('');
            //$("#bmsgC").fadeIn(2000, function () { $("#bmsgC").fadeOut(2000) })
        },
        error: function (w) { alert(w.d) }
    });

    return false;
}




function MyAccount() {

    var msgConfirm = "Please login to view your KOMP Account.";
    swal({ title: msgConfirm, text: "", type: "warning", showCancelButton: false, confirmButtonColor: "#4b220c", confirmButtonText: "OK", cancelButtonText: "NO", closeOnConfirm: true, closeOnCancel: true },
    function (isConfirm) 
    {
        if (isConfirm) 
        {
            $('#aRegister').click();
        }
        //        else 
        //        {
        //            swal("", "text !!", "error");
        //        }
    });

    
    
}