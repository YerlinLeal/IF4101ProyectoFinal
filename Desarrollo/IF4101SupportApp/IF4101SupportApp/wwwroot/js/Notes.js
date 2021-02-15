

$('.ui.shape')
    .shape();

$('.write').on('click', function () {
    $(this).closest('.shape').shape('flip over');
});

$('.undo').on('click', function () {
    $(this).closest('.shape').shape('flip over');

});

$('.save').on('click', function () {
    alert("HILA");
    var shape = $(this).closest('.shape');
    var id = shape.attr("id");
    var comment = $("#txa_" + id).val();
    $("#ptx_" + id).html(comment);
    shape.shape('flip over');
});


function AddNote() {
    $("#content-note").append(
        '<div class="col-sm-3 col-md-4">' +
        '<div class="ui shape" id="-1">' +
        '<div class="sides">' +
        '<div class="side">' +
        '<div class="ui note card">' +
        '<div class="content">' +
        '<p id="ptx_-1"></p>' +
        '<button class="ui right floated transparent icon button">' +
        '<i class="red trash icon"></i>' +
        '</button>' +
        '<button class="ui right floated transparent icon button">' +
        '<i class="yellow write square icon flip-left"></i>' +
        '</button>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '<div class="side active">' +
        '<div class="ui note card edit">' +
        '<div class="content">' +
        '<div class="row">' +
        '<div class="col-sm-12" style="height: 60px;">' +
        '<textarea class="col-sm-12 form-control form-control-sm h-100" id="txt_-1" rows="6"></textarea>' +
        '</div>' +
        '</div>' +
        '<button class="ui right floated transparent icon button">' +
        '<i class="yellow save square icon flip-right"></i>' +
        '</button>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '</div>'
    )
}