$(document).on('click', '.modal-btn-edit', function () {
    event.preventDefault();
    
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

$(document).on('click', '.modal-btn-delete', function (e) {
    e.preventDefault();

    let href = $(this).attr('href');
    $('.form-delete').attr('action', href);
    $('#delete-modal').modal('show');
});

$(document).on('click', '.modal-btn-details', function () {
    event.preventDefault();
    
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

$(document).on('submit', "#general-modal", function () {
    event.preventDefault();
    $.ajax({
        type: $('.general-modal-form-content form').attr('method'),
        url: $('.general-modal-form-content form').attr('action'),
        data: $('.general-modal-form-content form').serialize(),
        beforeSend: function () {
            $('#cover-spin').show();
        },
        complete: function () {
            $('#cover-spin').hide();
        },
        success: function (response, status, xhr) {
            if ($('.dataTable').length > 0) {
                $('.dataTable').DataTable().draw();
            }
            $("#general-modal").modal("hide");
            $("#success-modal").modal("show");
        },
        error: function (error) {
            let list = assignUlErrors(error.responseJSON);

            $('.validation-summary-valid').html(list);
        }
    });
});

$(document).on('submit', '.form-delete', function (e) {
    e.preventDefault();

    $.ajax({
        url: $(this).attr('action'),
        method: $(this).attr('method'),
        beforeSend: function () {
            $('#cover-spin').show();
        },
        complete: function () {
            $('#cover-spin').hide();
        },
        success: function (data) {
            if ($('.dataTable').length > 0) {
                $('.dataTable').DataTable().draw();
            }
            
            $("#delete-modal").modal("hide");
            $("#success-modal").modal("show");
        },
        error: function (error) {
            let list = assignUlErrors(error.responseJSON);
            console.log(list);
            $('.delete-validation-summary-valid').html(list);
        }
    });
});

function assignUlErrors(errors) {
    let list = '<ul>';

    errors.forEach(err => {
        if (err.errorMessage !== '') {
            list += `<li>${err.errorMessage}</li>`;
        }
    });

    list += '</ul>';
    
    return list;
}