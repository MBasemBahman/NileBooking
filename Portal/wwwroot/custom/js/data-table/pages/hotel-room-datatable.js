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
                {
                    data: "roomType",
                    orderable: false,
                    render: function (data, type, row) {
                        if (data.colorCode == "#fff"
                            || data.colorCode == "#ffff"
                            || data.colorCode == ""
                            || data.colorCode == null) {
                            return data.name;
                        }
                        else {
                            var newColor = hexToRgb(data.colorCode);
                            return '<span class="badge bg-label" style="background-color:rgba(' + newColor.r + ', ' + newColor.g + ', ' + newColor.b + ', .1) " text-capitalized="">'
                                + '<span style="color:' + data.colorCode + '">' + data.name + '</span</span> ';
                        }
                    }
                },
                {
                    data: "roomFoodType",
                    orderable: false,
                    render: function (data, type, row) {
                        if (data.colorCode == "#fff"
                            || data.colorCode == "#ffff"
                            || data.colorCode == ""
                            || data.colorCode == null) {
                            return data.name;
                        }
                        else {
                            var newColor = hexToRgb(data.colorCode);
                            return '<span class="badge bg-label" style="background-color:rgba(' + newColor.r + ', ' + newColor.g + ', ' + newColor.b + ', .1) " text-capitalized="">'
                                + '<span style="color:' + data.colorCode + '">' + data.name + '</span</span> ';
                        }
                    }
                },
                { data: "maxCount" },
                { data: "bookingRoomsCount" },
                { data: "createdAt" },
                { data: "id" },
            ]
        });


    }

})

   