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
                            var newColor = hexToRgb(row.colorCode);
                            return '<span class="badge bg-label" style="background-color:rgba(' + newColor.r + ', ' + newColor.g + ', ' + newColor.b + ', .1) " text-capitalized="">'
                                + '<span style="color:' + row.colorCode + '">' + data + '</span</span> ';
                        }
                    }
                },
             
                { data: "createdAt" },
             
                { data: "id" },
            ]
        });


    }

})

   