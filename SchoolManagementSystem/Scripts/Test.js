$(document).ready(function () {
    var table = $('#students_table').DataTable({
        "scrollY": '50vh',
        scrollCollapse: true,
        paging: false

    });
    $('#students_table tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected')
        }
    });
    $('#btnDelete').click(function () {
        var studentId = table.row('.selected')[0];
        alert(studentId);
        if (studentId) {
            var href = "/students/delete/" + encodeURIComponent(studentId);
            //alert(href);
            alert(("#DeleteButton").attr("href", href).click());
        }
        table.row('.selected').remove().draw(false);

    });

});
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>