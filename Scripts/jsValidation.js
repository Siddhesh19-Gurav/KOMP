$(document).ready(function () {

$(".NumberClass").keypress(function (e) {
    return onlyNumbers(e);
});


$(".DecimalClass").blur(function (e) {
    return onlyDecimal(e);
});




$(".AlphaClass").keypress(function (e) {
    return onlyAlpha(e);
});

$(".AlphaNumericClass").keypress(function (e) {
    return onlyAlphaNumric(e); // if (String.fromCharCode(e.keyCode).match(/[^a-zA-Z0-9]/g)) return false;
});

$(".EmailClass").blur(function (e) {
    return EmailValidate(this);
});

$(".PhoneClass").keypress(function (e) {
    e = (e) ? e : (window.event) ? event : null;

    var cCode = (e.charCode) ? e.charCode :
                    ((e.keyCode) ? e.keyCode :
                    ((e.which) ? e.which : 0));

    if (String.fromCharCode(cCode).match(/[^0-9-.+]/g)) return false;
});

});


function EmailValidate(ctrl) {
    if (ctrl.value != '' && !/^[+a-z0-9._-]+@[a-z0-9.-]+\.[a-z]{2,4}$/i.test(ctrl.value)) {
        $(ctrl).css('border', 'solid 1px red');
        swal('Please enter correct email id');
        $(ctrl).focus();
        return false;
    }
    else {
        $(ctrl).css('border', 'solid 1px #75BDC7');
    }
}

function onlyNumbers(evt) {
    var e = window.event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}


function onlyDecimal(evt) {
    if (event.charCode != 0) {
        var regex = new RegExp("^[0-9]{0,6}(\.[0-9]{1,2})?$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            $(".DecimalClass").val("0.00");
            return false;
        }
    }
}

function onlyAlpha(evt) {
    if (event.charCode != 0) {
        var regex = new RegExp("^[a-zA-Z ]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }
}

function onlyAlphaNumric(evt) {
    if (event.charCode != 0) {
        var regex = new RegExp("^[a-zA-Z0-9 ]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }
}