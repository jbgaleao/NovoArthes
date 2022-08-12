$(document).ready(function () {
    debugger;
    var RevistaReceita = $('#RevistaReceita').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pt-BR.json"
        }
    });

    $('#RevistaReceita tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            RevistaReceita.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });


});

function passIdRevista(idRevista) {
    debugger;
    document.getElementById('hdRevista').value = idRevista;

}