let link = $(".nav-link.active").eq(0).attr("id");

$(".page_content").load(link);


$(document).on('click', '.nav-link', function(e) {
    e.preventDefault();
   
    let link = $(this).attr('id');

    $(".page_content").load(link);

    $(".active").each(function() {
        $(this).removeClass('active');
    });
    $(this).addClass('active');

    var menuItem = $("#currentActiveLink").val();
    var elem = $('#' + menuItem + '');
    $(elem).addClass("active open");
});


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


$(document).on('submit', "#general-modal", function (e) {
    e.preventDefault();
    let form = $('.general-modal-form-content form');
    let formData = new FormData(form[0]);
    $.ajax({
        type: form.attr('method'),
        url: form.attr('action'),
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
            link = $(".nav-link.active").eq(0).attr("id");
            $(".page_content").load(link);
            $("#general-modal").modal("hide");
            $("#success-modal").modal("show");
        },
        error: function (error) {
            let list = assignUlErrors(error.responseJSON);

            $('.validation-summary-valid').html(list);
        }
    });
});
