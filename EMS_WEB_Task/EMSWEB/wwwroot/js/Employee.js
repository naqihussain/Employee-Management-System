$(document).ready(function () {
    console.log('readypage');
    EmployeeList();
    GetDepartment();
    //var table = $('#employeetable').DataTable();
});
function EmployeeList() {
    $('.data_table tbody').html('');
    var endpoint = $("#EndPoint").val();
    $.ajax({
        type: "GET",
        url: endpoint + "api/Employee",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            var rows = '';
            $('.data_table tbody').html('');
            $.each(data, function (i, v) {
                var roleName = '';
                if (v.department) {
                    roleName = v.department.name;
                }
                var status = 'Suspend';
                if (v.active) {
                    status = 'Active';
                }
                var date = new Date(v.dob);
                var createdDate = ((date.getMonth() > 8) ? (date.getMonth() + 1) : ('0' + (date.getMonth() + 1))) + '/' + ((date.getDate() > 9) ? date.getDate() : ('0' + date.getDate())) + '/' + date.getFullYear();
                rows += '<tr>  <td> ' + v.fullName + '</td> <td> ' + v.email + '</td><td>' + createdDate + ' </td><td>' + roleName + ' </td><td>' + status + ' </td><td>' + "<a onclick='EditEmployee(this)' data-id='" + v.id + "'><i class='material-icons'>&#xE254;</i></a>  <a onclick='DeleteEmployee(this)' data-id='" + v.id + "'><i class='material-icons'>&#xE872;</i></a>" + ' </td></tr>';
            });
            $('.data_table tbody').append(rows);
            $('#employeetable').DataTable();
        }, error: function () {
        }
    });
  
}
function showAddUserModal() {
    $("#EmpId").val('');
    $("#FName").val('');
    $("#LName").val('');
    $("#Name").val('');
    $("#Email").val('');
    $('#DOB').val('');
    $("#Dept").val('');
    $('#addUserModal').modal('show');
}
function GetDepartment() {
    var endpoint = $("#EndPoint").val();
    $.ajax({
        type: "GET",
        url: endpoint + "api/department",
        success: function (data) {
            var rows = '';
            $('#Dept').html('');
            $.each(data, function (i, v) {
                $("#Dept").append("<option value='"+v.id+"'>" + v.name + "</option>");
            });
        }, error: function () {
        }
    });
}
function AddEmployee() {
    if ($('#Email').val() === null || $('#Email').val() === "") {
        alertify.error("please fill all required fields.");
        return true;
    }
    var loginVM = {
        Id: $('#EmpId').val(),
        FName: $('#FName').val(),
        LName: $('#LName').val(),
        Name: $('#FName').val() + " " + $('#LName').val(),
        Email: $('#Email').val(),
        DOB: $('#DOB').val(),
        DeptID: $('#Dept').val()
    };
    var endpoint = $("#EndPoint").val();
    $.ajax({
            type: "POST",
            url: endpoint + "api/Employee",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            cache: false,
            data: JSON.stringify(loginVM),
            success: function (data) {
                alertify.success('Employee is successfully saved.')
                $('#addUserModal').modal('hide');
                EmployeeList();
            },
            error: function (xhr) {
                alertify.error(xhr.responseText);
            }
        });
}
function DeleteEmployee(elem) {
    var id = $(elem).data('id');
    var endpoint = $("#EndPoint").val();
    $.ajax({
        type: "DELETE",
        url: endpoint + "api/Employee/" + id,
        cache: false,
        success: function (data) {
           alertify.success('Employee is successfully deleted.')
            EmployeeList();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
function EditEmployee(elem) {
    var id = $(elem).data('id');
    var endpoint = $("#EndPoint").val();
    $.ajax({
        type: "GET",
        url: endpoint + "api/Employee/" + id,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        cache: false,
        //data: { id: id },
        success: function (data) {
            $("#EmpId").val(data.id);
            $("#FName").val(data.firstName);
            $("#LName").val(data.lastName);
            $("#Name").val(data.firstName + " " + data.lastName);
            $("#Email").val(data.email);
            var now = new Date(data.dob);
            var day = ("0" + now.getDate()).slice(-2);
            var month = ("0" + (now.getMonth() + 1)).slice(-2);
            var today = now.getFullYear() + "-" + (month) + "-" + (day);
            $('#DOB').val(today);
            $("#Dept").val(data.department.id);
            $('#addUserModal').modal('show');
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
function CloseModal() {

    $("#addUserModal").modal("hide");
}
