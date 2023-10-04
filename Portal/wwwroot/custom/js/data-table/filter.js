$('body').on('change', '.filter-input', function () {
    event.preventDefault();
    if ($('.dataTable').length > 0) {
        $('.dataTable').DataTable().draw();
    }
});

$(".filter-submit-btn").on("click", function () {
    event.preventDefault();
    $(".dt-date").each(function () {
        $(this).val('');
    });
    $("select.filter-input").each(function () {
        $(this).val($(this).find("option:not([disabled]):first").val());
    });

    if ($('.dataTable').length > 0) {
        $('.dataTable').DataTable().draw();
    }
});
$(".flatpickr-input").on('change', function () {
    var value = $(this).val();
    if (value.includes('to')) {
        if ($("#ToText").length > 0) {
            value = value.replace("to", $("#ToText").val());
            $(this).val(value);
        }
    }
});