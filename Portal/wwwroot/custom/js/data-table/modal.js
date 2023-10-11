$(document).on('click', '.modal-btn-edit', function (e) {
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

$(document).on('click', '.modal-xl-btn-edit', function (e) {
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
            $('.general-xl-modal-form-content').html(data);
            $("#general-xl-modal").modal("show");
        },
    });
});

$(document).on('click', '.modal-btn-delete', function (e) {
    e.preventDefault();

    let href = $(this).attr('href');
    $('.form-delete').attr('action', href);
    $('#delete-modal').modal('show');
});

$(document).on('click', '.modal-btn-details', function (e) {
    e.preventDefault();

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

$(document).on('click', '.modal-btn-edit-side', function (e) {
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
            $('#offcanvasAddItem').html(data);
            var bsOffcanvas = new bootstrap.Offcanvas($("#offcanvasAddItem"))
            bsOffcanvas.show()
        },
    });
});

$(document).on('submit', "#general-modal", function (e) {
    e.preventDefault();
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

            if ($('.gridView').length > 0) {
                loadRows();
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

$(document).on('submit', "#general-xl-modal", function (e) {
    e.preventDefault();
    
    let form = $('.general-xl-modal-form-content form');
    
    $.ajax({
        type: form.attr('method'),
        url: form.attr('action'),
        data: form.serialize(),
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

            if ($('.gridView').length > 0) {
                loadRows();
            }
            $("#general-xl-modal").modal("hide");
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

            if ($('.gridView').length > 0) {
                loadRows();
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

$(document).on('submit', "#offcanvasAddItem", function (e) {
    e.preventDefault();
    var form = $('#offcanvasAddItem form');
    var formData = new FormData(form[0]);
    $.ajax({
        type: $('#offcanvasAddItem form').attr('method'),
        url: $('#offcanvasAddItem form').attr('action'),
        data: formData,
        contentType: false,
        processData: false,
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

            if ($('.gridView').length > 0) {
                loadRows();
            }
            
            let openedCanvas = bootstrap.Offcanvas.getInstance($("#offcanvasAddItem"));
            openedCanvas.hide();
            $("#offcanvasAddItem").empty();
            $("#success-modal").modal("show");
        },
        error: function (error) {
            let list = assignUlErrors(error.responseJSON);

            $('.validation-summary-valid').html(list);
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

