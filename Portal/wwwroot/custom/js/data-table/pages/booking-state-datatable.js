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
                {
                    data: "name",
                    orderable: false,
                    render: function (data, type, row) {
                        if (row.colorCode == "#fff"
                            || row.colorCode == "#ffff"
                            || row.colorCode == ""
                            || row.colorCode == null) {
                            return data;
                        }
                        else {
                            return '<span class="badge  px-2 text-center" style="background-color:' + row.colorCode + ';color:white">' + data + '</span>';
                        }
                    }
                },
                {
                    data: "bookingsCount",
                    render: function (data, type, row) {
                        return '<a href="/BookingEntity/Booking/Index?Fk_BookingState=' + row.id + '">' + data + '</a>'
                    }
                },
                { data: "createdAt" },
              
                { data: "id" },
            ]
        });


    }

})

   