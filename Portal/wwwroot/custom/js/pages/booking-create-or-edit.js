$('select[name=Fk_Account]').each(function () {
    $(this).select2({
        ajax: {
            url: "/Services/getAccountBySearch",
            dataType: "json",
            type: 'get',
            quietMillis: 50,
            data: function (params) {
                let query = {
                    searchTerm: params.term,
                }

                return query;
            },
            processResults: function (data) {
                return {
                    results: $.map(data, function (item, index) {
                        return {
                            id: index,
                            text: item
                        }
                    })
                };
            }
        },
        dropdownParent: $(this).parent()
    });
});

$('select[name=Fk_Hotel]').each(function () {
    $(this).select2({
        ajax: {
            url: "/Services/getHotelBySearch",
            dataType: "json",
            type: 'get',
            quietMillis: 50,
            data: function (params) {
                let query = {
                    searchTerm: params.term,
                }

                return query;
            },
            processResults: function (data) {
                return {
                    results: $.map(data, function (item, index) {
                        return {
                            id: index,
                            text: item
                        }
                    })
                };
            }
        },
        dropdownParent: $(this).parent()
    });
});

$(document).ready(function () {
    
    $(document).on('click', '#add-new-btn', function () {
        setTimeout(function () {
            $(".idElem").last().val('0');
            $(".roomTypeElem").last().val('1');
            $(".adultCountElem").last().val('0');
            $(".childCountElem").last().val('0');
        }, 500);

        $(".fromDate").last().flatpickr({
            enableTime: false,
            noCalendar: false,
            enableDate: true
        });

        $(".toDate").last().flatpickr({
            enableTime: false,
            noCalendar: false,
            enableDate: true
        });
    });

    $('.repeater').repeater({
        show: function () {
            $(this).slideDown();
        },
        hide: function (deleteElement) {
            $(this).slideUp(deleteElement);
        },
    });

    $('button[data-repeater-delete][newRepeater]').click();
});
