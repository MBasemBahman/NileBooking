$('body').on('change', '.filter-input', function () {
    event.preventDefault();
    if ($('.dataTable').length > 0) {
        $('.dataTable').DataTable().draw();
    }
});