$(document).ready(function () {
    GetDepartment();
});
function showAddDepartModal() {
    $('#adddepartModal').modal('show');
}
function GetDepartment() {
    var endpoint = $("#EndPoint").val();
    $('.data_table tbody').html('');
    $.ajax({
        type: "GET",
        url: endpoint + "api/department",
        success: function (data) {
            var rows = '';
            $('.data_table tbody').html('');
            $.each(data, function (i, v) {
                rows += '<tr><td> ' + v.name + '</td> </tr>';
            });
            $('.data_table tbody').append(rows);
            $('#departtable').DataTable();
        }, error: function () {
        }
    });
}
function AddDepartment() {
    if ($('#Email').val() === null || $('#Email').val() === "") {
        alertify.error("please fill all required fields.");
        return true;
    }
    var loginVM = {
        Name: $('#Name').val()
    };
    var endpoint = $("#EndPoint").val();
    $.ajax({
            type: "POST",
            url: endpoint + "api/Department",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            cache: false,
            data: JSON.stringify(loginVM),
            success: function (data) {
                alertify.success('Department is successfully added.')
                $('#adddepartModal').modal('hide');
                GetDepartment();
            },
            error: function (xhr) {
                alertify.error(xhr.responseText);
            }
        });
}
function CloseModal() {
    $("#adddepartModal").modal("hide");
}
