$('body').on('change', '.filter-input', function (e) {
    e.preventDefault();
    if ($('.dataTable').length > 0) {
        $('.dataTable').DataTable().draw();
    }
    if ($('.gridView').length > 0) {
        loadRows();
    }
});

$(".filter-submit-btn").on("click", function (e) {
    e.preventDefault();
    $(".dt-date").each(function () {
        $(this).val('');
    });
    $("select.filter-input").each(function () {
      
        var exists = $(this).children('option').filter(function () { return $(this).val() == '0'; }).length;
        if (exists == 1) {
            $(this).val('0').change();
        }
        else {
            $(this).val('').change();

        }
    
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