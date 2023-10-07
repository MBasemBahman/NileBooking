$(document).ready(function ()
{
    var dt_ajax_table = $('.dataTable');
    if (dt_ajax_table.length) {
        var dt_ajax = dt_ajax_table.dataTable({
            // Ajax Filter
            ajax: {
                url: '/HotelEntity/HotelAttachment/LoadTable',
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
                    data: "fileName",
                    render: function (data, type, row) {
                        if (row.storageUrl != null) {
                            return data;
                        } else {
                            return row.fileUrl;
                        }
                    }
                },
                {
                    data: "fileUrl",
                    render: function (data, type, row) {
                        if (row.storageUrl != null) {
                            return '<a href="' + data + '" target="_blank">'
                                + '@Localizer.Get("Click to View")'
                                +'</a>';
                        } else {
                            return `<a href="${row.fileUrl}" target="_blank">
                                         @Localizer.Get("Click to View")
                                    </a>`
                        }
                    }
                },
                { data: "createdAt" },
                {
                    data: "fileUrl",
                    render: function (data, type, row) {
                        if (row.storageUrl != null) {
                            return '<a href="' + data + '" target="_blank" download="' + row.fileName + '">'
                                + '@Localizer.Get("Download")'
                                +'</a>'
                        } else {
                            return `<a href="${row.fileUrl}" target="_blank">
                                         @Localizer.Get("Visit Link")
                                    </a>`
                        }
                    }
                },
                { data: "id" },
            ]
        });


    }

})

   