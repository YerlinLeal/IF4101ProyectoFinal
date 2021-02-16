



$("#note-form").submit(function (e) {
    e.preventDefault();
    $.ajax({
        url: "/Note/Insert",
        cache: false,
        type: "Post",
        data: {
            ReportNumber: sessionStorage.ReportNumber,
            Description: $(this).find("#note-description").val()
        },
        beforeSend: function () {
            //$("#content-note").empty();
            //agregarSpinnerCargando($("#gastos-contenedor"))
        },
        success: function (data) {

            $('#content-note').append(data);
            
        },
        error: function (error) {


        }
    });
});

function deleteNote(id) {
    $.ajax({
        url: "/Note/Delete",
        cache: false,
        type: "Delete",
        data: {
            NoteId: id
        },
        success: function (data) {
            $("#note-" + id).parent().remove();

        },
        error: function (error) {


        }
    });
}

$("#notes-tab").on("click", function () {
    $.ajax({
        url: "/Note/NotesByIssue",
        cache: false,
        type: "GET",
        data: {
            id: sessionStorage.ReportNumber
        },
        beforeSend: function () {
            $("#content-note").empty();
            //agregarSpinnerCargando($("#gastos-contenedor"))
        },
        success: function (data) {
            
            $('#content-note').html(data);
            //desactivarAcciones();
        },
        error: function (error) {
            
            //$("#mensaje-body").html(error.responseText);
            //$("#modalMensajeError").modal("show");
        }
    });

});
