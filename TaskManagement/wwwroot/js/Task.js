$(function () {

});

function ValidateInput() {
    if (!$("#taskName").val()) {
        alert("Task Name is required");
        return false;
    }

    if (!$("#taskDescription").val()) {
        alert("Task Description is required");
        return false;
    }

    if ($("#taskStatusId").val() < 1) {
        alert("Please Task status");
        return false;
    }

    return true;
}

function SubmitTask() {
    if (ValidateInput()) {
        $.ajax({
            url: "/Task/AddTask",
            contentType: "application/json",
            type: "POST",
            dataType: "json",
            data: JSON.stringify({
                TaskName: $("#taskName").val(),
                TaskDescription: $("#taskDescription").val(),
                TaskStatusId: $("#taskStatusId").val(),
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

function UpdateTask() {
    if (ValidateInput()) {
        $.ajax({
            url: "/Task/UpdateTask",
            contentType: "application/json",
            type: "POST",
            dataType: "json",
            data: JSON.stringify({
                Id: $("#taskId").val(),
                TaskName: $("#taskName").val(),
                TaskDescription: $("#taskDescription").val(),
                TaskStatusId: $("#taskStatusId").val(),
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

function DeleteTask(id) {
    if (confirm('Are you sure you want to delete this task?')) {
        $.ajax({
            url: "/Task/DeleteTask?id=" + id,
            type: "delete",
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
