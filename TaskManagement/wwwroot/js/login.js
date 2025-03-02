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

    return true;
}

function LoginBtnClick() {
    if (ValidateInput()) {
        $.ajax({
            url: "/Login/ValidateUser",
            contentType: "application/json",
            type: "POST",
            dataType: "json",
            data: JSON.stringify({
                Email: $("#Email").val(),
                Password: $("#Password").val() 
            }),
            success: function (result) {
                if (result != "Sucess") {
                    alert(result);
                }
                else {
                    window.location.href = "/Task/Index";
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }

        });
    }
};