
$(document).ready(function () {
    $("#example").DataTable({
        aaSorting: [],
        responsive: true,

        columnDefs: [
            {
                responsivePriority: 1,
                targets: 0
            },
            {
                responsivePriority: 2,
                targets: -1
            }
        ]
    });

    $(".dataTables_filter input")
        .attr("placeholder", "Search here...")
        .css({
            width: "300px",
            display: "inline-block"
        });

    $('[data-toggle="tooltip"]').tooltip();

    $(".collapse").on('show.bs.collapse', function () {
        $(this).prev(".card-header").find(".fa").removeClass("fa-plus").addClass("fa-minus");
    }).on('hide.bs.collapse', function () {
        $(this).prev(".card-header").find(".fa").removeClass("fa-minus").addClass("fa-plus");
    });
});



$("#employee_form").submit(function (e) {
    e.preventDefault();
    

    

    $.ajax({
        url: "/Employee/Insert",
        data: {
            DNI: $("#DNI").val(),
            Employee_Name: $("#Employee_Name").val(),
            First_Surname: $("#First_Surname").val(),
            Second_Surname: $("#Second_Surname").val(),
            Email: $("#Email").val(),
            Password: $("#Email").val(),
            Supervised: $("#Supervised").val()
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
    
    
});