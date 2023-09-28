$(document).on('click', '.modal-btn-edit', function () {
    event.preventDefault();
    var href = $(this).attr('href');
    $('.general-modal-form-content').load(href);
    $("#general-modal").modal("show");
});

$(document).on('click', '.modal-btn-delete', function () {
    event.preventDefault();
    var href = $(this).attr('href');
    $('.general-modal-form-content').load(href);
    $("#general-modal").modal("show");
});

$(document).on('click', '.modal-btn-details', function () {
    event.preventDefault();
    var href = $(this).attr('href');
    $('.general-modal-form-content').load(href);
    $("#general-modal").modal("show");
});
$(document).on('submit', "#general-modal", function () {
    event.preventDefault();
    $.ajax({
        type: $('.general-modal-form-content form').attr('method'),
        url: $('.general-modal-form-content form').attr('action'),
        data: $('.general-modal-form-content form').serialize(),
        success: function (response, status, xhr) {
            if ($('.dataTable').length > 0) {
                $('.dataTable').DataTable().draw();
            }
            $("#general-modal").modal("hide");
            $("#success-modal").modal("show");
        },
        error: function (error) {
            alert(error)
            $("#general-modal").modal("hide");
            $("#error-modal").modal("show");

        }
    });
})
