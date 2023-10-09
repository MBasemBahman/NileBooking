$(document).on('click', '.modal-btn-profile-edit', function (e) {
    e.preventDefault();

    // Make an AJAX request to fetch content from the URL
    $.ajax({
        url: $(this).attr('href'),
        method: 'GET',
        beforeSend: function () {
            $('#cover-spin').show();
        },
        complete: function () {
            $('#cover-spin').hide();
        },
        success: function (data) {
            $('.general-modal-form-content').html(data);
            $("#general-modal").modal("show");
        },
    });
});