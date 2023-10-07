$(document).ready(function ()
{
    var dt_ajax_table = $('.dataTable');
    if (dt_ajax_table.length) {
        var dt_ajax = dt_ajax_table.dataTable({
            // Ajax Filter
            ajax: {
                url: '/HotelEntity/HotelRoom/LoadTable',
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: function (data) {
                    data.Fk_Hotel = $('#Fk_Hotel').val();
                    
                    return JSON.stringify(data);
                }
            },
            // Columns Setups
            columns: [
                { data: "id" },
                { data: "roomFoodType.name" },
                { data: "roomType.name" },
                { data: "maxCount" },
                { data: "bookingRoomsCount" },
                { data: "createdAt" },
                { data: "id" },
            ]
        });


    }

})

   