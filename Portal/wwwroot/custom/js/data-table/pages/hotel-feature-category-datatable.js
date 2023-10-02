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
                {
                    data: "hotelFeaturesCount",
                    render: function (data, type, row) {
                        return '<a target="_blank" href="/HotelEntity/HotelFeature/Index?Fk_HotelFeatureCategory=' + row.id + '">' + data + '</a>'
                    }
                },
                { data: "createdAt" },
              
                { data: "id" },
            ]
        });


    }

})

   