$(document).ready(function () {
    $("#Employee_Form").validate();
    $(".Select").selectpicker();

    $('#table-employees').DataTable({
        ajax: {
            url: '/Employee/GetAll',
            dataSrc: '',

        },
        columns: [
            {
                "defaultContent": '<button class="hvr-bounce-in " data-toggle="modal" data-target="#IssueDetailsModal"><i class="fa fa-eye" aria-hidden="true"></i></button>'
            },
            { data: 'employeeId' },
            { data: 'employeeName' },
            { data: 'firstSurname' },
            { data: 'secondSurname' },
            { data: 'email' }
        ]
    });
});


$("#Employee_Form").submit(function (e) {
    e.preventDefault();
    if ($("#Employee_Form").valid()) {
        $.ajax({
            url: "/Employee/Insert",
            data: {
                EmployeeName: $("#EmployeeName").val(),
                FirstSurname: $("#FirstSurname").val(),
                SecondSurname: $("#SecondSurname").val(),
                Email: $("#Email").val(),
                Password: $("#Password").val(),
                Supervised: $("#Supervised").val(),
                Services: $("#Services").val()
            },
            type: "POST",
            dataType: "json",

            success: function (result) {
                alert(JSON.stringify(result));
            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });
    }
})