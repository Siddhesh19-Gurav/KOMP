function GetOrderDetails(orderId) {
    $.ajax({
        type: "POST",
        url: "KompServices.asmx/GetOrderDetails",
        contentType: "application/json; charset=utf-8",
        data: "{orderId:" + orderId + "}",
        dataType: "json",
        success: function (result) {
            $('#divQuantity').show();
            $('#divOrdersDetails').html(result.d);
            $('html,body').animate({
                scrollTop: $('#divQuantity').offset().top
            }, 1000);
        },
        error: function (result) { alert('error:' + result.d); }
    });
}


function GetOrderDetailsMaster(orderId) {
    $.ajax({
        type: "POST",
        url: "../KompServices.asmx/GetOrderDetails",
        contentType: "application/json; charset=utf-8",
        data: "{orderId:" + orderId + "}",
        dataType: "json",
        success: function (result) {
            $('#divOrdersDetails').html(result.d);
        },
        error: function (result) { alert('error:' + result.d); }
    });
}