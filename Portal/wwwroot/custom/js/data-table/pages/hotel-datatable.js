$(document).ready(function ()
{
    var dt_ajax_table = $('.dataTable');
    if (dt_ajax_table.length) {
        var dt_ajax = dt_ajax_table.dataTable({
            // Ajax Filter
            ajax: {
                url: 'LoadTable',
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: function (data) {
                    return JSON.stringify(data);
                }
            },
            // Columns Setups
            columns: [
                { data: "id" },
                { data: "name" },
                { data: "hotelType.name" },
                { data: "area.name" },
                { data: "price" },
                { data: "rate" },
                { data: "isRecommended" },
                { data: "isActive" },
                { data: "createdAt" },
                { data: "id" },
            ]
        });


    }

})

   