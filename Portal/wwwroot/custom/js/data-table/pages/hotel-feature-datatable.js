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
                    data.Fk_HotelFeatureCategory = $("#Fk_HotelFeatureCategory_Filter").length > 0 ? $("#Fk_HotelFeatureCategory_Filter").val() : 0
                    return JSON.stringify(data);
                }
            },
            // Columns Setups
            columns: [
                { data: "id" },
                { data: "name" },
                { data:"hotelFeatureCategory.name"},
                { data: "createdAt" },
                { data: "id" },
            ]
        });


    }

})

   