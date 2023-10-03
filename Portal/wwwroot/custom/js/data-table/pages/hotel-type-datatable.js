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
                    data: "hotelsCount",
                    render: function (data, type, row) {
                        return '<div class="d-flex align-items-center my-2">'
                            + '<span class="badge badge-center rounded-pill bg-label-success w-px-30 h-px-30 me-2">'
                            + '<i class="ti ti-star ti-sm" ></i></span></span>'
                            + '<h4 class="mb-0 me-2"><a class="text-dark" target="_blank" href="/HotelEntity/Hotel/Index?Fk_HotelType=' + row.id + '">' + data + '</a></h4>'
                            + '<p class="text-success mb-0">(' + row.hotelsPercent + '%)</p></div>';
                    }
                },
                { data: "createdAt" },
              
                { data: "id" },
            ]
        });


    }

})

   