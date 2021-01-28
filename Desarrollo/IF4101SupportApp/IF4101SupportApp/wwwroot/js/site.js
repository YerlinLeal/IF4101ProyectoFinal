var $th = $('.scroll-vertical').find('thead th')
$('.scroll-vertical').on('scroll', function () {
    $th.css('transform', 'translateY(' + this.scrollTop + 'px)');
});

$(function () {
    // Handler for .ready() called.
    LoadTable();
    $('#table-recorded-issues').DataTable();
});

function LoadTable() {

    var html = '';
    for (var i = 0; i < 30; i++) {
        html += '<tr>';
        html += '<td>Report number' + i + '</td>';
        html += '<td>Employee assigned' + i + '</td>';
        html += '<td>Classification' + i + '</td>';
        html += '<td>Status' + i + '</td>';
        html += '<td>Creation date' + i + '</td>';
        html += '<td>Report Timestamp' + i + '</td>';
        html += '</tr>';
    }

    $('.tbody').html(html);
}
