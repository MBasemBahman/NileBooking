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
                    data: "areasCount",
                    render: function (data, type, row) {
                        return '<div class="d-flex align-items-center">'
                            + '<p class="mb-0" ><a class="text-primary" target="_blank" href="/LocationEntity/Area/Index?Fk_Country=' + row.id + '">' + data + '</a></p>'
                            + '<div class="ms-3 badge bg-label-warning">' + row.areasPercent + '%</div>'
                            + '</div>'

                    }
                },
                {
                    data: "hotelsCount",
                    render: function (data, type, row) {
                        return '<div class="d-flex align-items-center">'
                            + '<p class="mb-0" ><a class="text-primary" target="_blank" href="/HotelEntity/Hotel/Index?Fk_Country=' + row.id + '">' + data + '</a></p>'
                            + '<div class="ms-3 badge bg-label-warning">' + row.hotelsPercent + '%</div>'
                            + '</div>'

                    }
                },

                { data: "createdAt" },
              
                { data: "id" },
            ]
        });


    }

})

   