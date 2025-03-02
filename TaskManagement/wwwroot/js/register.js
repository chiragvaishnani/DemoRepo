$(function () {

});

function ValidateInput() {
    if (!$("#Email").val()) {
        alert("Email is required");
        return false;
    }

    if (!$("#Password").val()) {
        alert("Password is required");
        return false;
    }

    if (!$("#UserName").val()) {
        alert("UserName is required");
        return false;
    }

    if (!$("#MobileNumber").val()) {
        alert("MobileNumber is required");
        return false;
    }

    return true;
}

function RegisterBtnClick() {
    if (ValidateInput()) {
        $.ajax({
            url: "/Register/RegisterUser",
            contentType: "application/json",
            type: "POST",
            dataType: "json",
            data: JSON.stringify({
                Email: $("#Email").val(),
                Password: $("#Password").val(),
                UserName: $("#UserName").val(),
                MobileNumber: $("#MobileNumber").val(),
            }),
            success: function (result) {
                if (result != "Sucess") {
                    alert(result);
                }
                else {
                    window.location.href = "/Login/Login";
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }

        });
    }
};