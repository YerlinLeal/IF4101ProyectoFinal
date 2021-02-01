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
                "render": function (data, type, s, meta) {
                    
                    return '<div class="dropdown"><button class= "btn btn-sm btn-icon" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">' +
                        '<i class="fas fa-ellipsis-h" data-toggle="tooltip" data-placement="top" title="Actions"></i>' +
                        '</button>' +
                        '<div class="dropdown-menu" aria-labelledby="dropdownMenuButton">' +
                        '<a class="dropdown-item" ><i class="fas fa-eye mr-2" onclick=editEmployee(' + s.employeeId + ')></i> Edit Profile</a>' +
                        '<a class="detele dropdown-item text-danger" onclick=deleteEmployee(' + s.employeeId + ') ><i class="fas fa-trash mr-2 "></i> Remove</a>' +
                        '</div>' +
                        '</div>'
                }
            },
            { data: 'employeeId' },
            { data: 'employeeName' },
            { data: 'firstSurname' },
            { data: 'secondSurname' },
            { data: 'email' }
        ]
    });
    
});


$('#table-employees tbody').on('click', 'tr', function () {
    var table = $('#table-employees').DataTable(); 
    table.$('tr.selected').removeClass('selected');
    $(this).addClass('selected');
    
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
});


function editEmployee (id){
    $.ajax({
        url: "/Employee/GetById",
        data: {
            id: id
        },
        type: "GET",
        success: function (result) {
            $("#UEmployeeName").val(result.employeeName);
            $("#UEmail").val(result.email);
            $("#UFirstSurname").val(result.firstSurname);
            $("#USecondSurname").val(result.secondSurname);
            $("#UPassword").val(result.password);
            $("#USupervised").val(result.supervised);
            $("#UServices").val(result.services);
            $('.selectpicker').selectpicker('refresh');
            $("#DetailEmployeeModal").modal("show");
            
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function deleteEmployee(id) {
    var table = $('#table-employees').DataTable();
    $.ajax({
        url: "/Employee/Delete",
        data: {
            EmployeeId: id 
        },
        type: "DELETE",
        dataType: "json",
        success: function (result) {
            alert(JSON.stringify(result));
            table.row(".selected").remove().draw();
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}