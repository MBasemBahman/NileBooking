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
});

$(document).on('click', '.check-before-send', function (e) {
    e.preventDefault();

    $('.validation-summary-valid').html('');
    
    let form = $(this).closest('form')[0];
    let submitBtn = $(this).closest('form').find('.send-form-btn');
    
    $.ajax({
        url: form.action,
        method: form.method,
        data: $(this).closest('form').serialize(),
        headers: { 'For-Validation': true },
        success: function (data) {
            submitBtn.click();
        },
        error: function (err) {
            let list = '<ul>';

            err.responseJSON.forEach(error => {
                list += `<li>${error.errorMessage}</li>`;
            });

            list += '</ul>';

            $('.validation-summary-valid').html(list);
        }
    });
});
