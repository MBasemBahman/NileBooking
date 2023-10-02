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
                    data.Fk_Country = $("#Fk_Country_Filter").length > 0 ? $("#Fk_Country_Filter").val()  : 0
                    return JSON.stringify(data);
                }
            },
            // Columns Setups
            columns: [
                { data: "id" },
                { data: "name" },
                { data:"country.name"},
                {
                    data: "hotelsCount",
                    render: function (data, type, row) {
                        return '<a href="/HotelEntity/Hotel/Index?Fk_Area=' + row.id + '">' + data + '</a>'
                    }
                },
                { data: "createdAt" },
              
                { data: "id" },
            ]
        });


    }

})

   