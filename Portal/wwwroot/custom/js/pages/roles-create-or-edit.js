function setViewsInSelect(elem) {
    var selectedItems = $(elem).val();
    $('.views-select').not(elem).each(function () {
        $(this).children('option').each(function () {
            selectedItems.includes(this.value.toString())
                ?
                this.remove() : ''
        });
    });
}

$(document).ready(function () {
    $(".select2").each(function () {
        $(this).select2();
    });

    $(".views-select").each(function () {
        setViewsInSelect($(this))
    });

    $(".views-select").each(function () {
        $(this).on('change', function () {
            setViewsInSelect($(this))
        });
    });

    $(".views-select").each(function () {
        $(this).on('select2:unselecting', function (e) {
            let optTxt = e.params.args.data.text;
            let optVal = e.params.args.data.id;

            $('.views-select').not($(this)).each(function () {
                $(this).prepend(`<option value="${optVal}">${optTxt}</option>`);

            });
        });
    });

    $(".choose_all").each(function () {
        $(this).on('click', function () {
            event.preventDefault();
            var indx = $(".choose_all").index($(this));
            $(".views-select").eq(indx).select2('destroy').find('option').prop('selected', 'selected').end().select2();
            setViewsInSelect($(".views-select").eq(indx));

        });
    });

    $(".remove_all").each(function () {
        $(this).on('click', function () {
            event.preventDefault();
            var indx = $(".remove_all").index($(this));
            $(".views-select").eq(indx).select2('destroy').val("").select2();

            $('.views-select').not($(this)).each(function () {
                var currentSelect = $(this);
                $(".views-select").eq(indx).find("option").each(function () {
                    currentSelect.append(`<option value="${this.value}">${this.text}</option>`);

                });

            });
        });
    });
});