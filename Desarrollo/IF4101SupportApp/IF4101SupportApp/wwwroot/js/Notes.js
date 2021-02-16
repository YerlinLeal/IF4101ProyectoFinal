



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
            //Falta validar errores
        }
    });
}

function editNote(id) {
    sessionStorage.setItem("note", $("#note-" + id).find(".card-body").find('p').html());
    $("#note-" + id).find(".card-header").find(".btn-div").html(
        '<a href="javascript: void(0)" onclick="saveNote( ' + id +' );"><span><i class="fa fa-floppy-o"></i></span></a>' +
        '<a href="javascript: void(0)" onclick="backNote( ' + id +' );"><span><i class="fa fa-undo"></i></span></a>'
    );
    
    $("#note-" + id).find(".card-body").html(
        '<textarea id="note-description" class="form-control" rows="3">' +
            sessionStorage.note+
        '</textarea>');
}

function saveNote(id) {
    var newDescription = $("#note-" + id).find(".card-body").find("#note-description").val();
   
    $.ajax({
        url: "/Note/Update",
        cache: false,
        type: "PUT",
        dataType: "json",
        data: {
            NoteId: id,
            Description: newDescription
        },
        success: function (data) {
            $("#note-" + id).find(".card-header").find(".btn-div").html(
                '<a href="javascript: void(0)" onclick="editNote( ' + id + ' );"><span><i class="fa fa-pencil"></i></span></a>' +
                '<a href="javascript: void(0)" onclick="deleteNote( ' + id + ' );"><span><i class="fa fa-trash"></i></span></a>'
            );
            $("#note-" + id).find(".card-body").html('<p class="card-text">' + newDescription + '</p>');            
        },
        error: function (error) {
            alert(error);
        }
    });
}

function backNote(id) {
    $("#note-" + id).find(".card-header").find(".btn-div").html(
        '<a href="javascript: void(0)" onclick="editNote( '+id+' );"><span><i class="fa fa-pencil"></i></span></a>' +
        '<a href="javascript: void(0)" onclick="deleteNote( ' + id +' );"><span><i class="fa fa-trash"></i></span></a>'
    );
    $("#note-" + id).find(".card-body").html('<p class="card-text">'+sessionStorage.note+'</p>');
}