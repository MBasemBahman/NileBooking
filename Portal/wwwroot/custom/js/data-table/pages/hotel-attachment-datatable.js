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
                                + $('#ClickToViewLbl').val()
                                +'</a>';
                        } else {
                            return `<a href="${row.fileUrl}" target="_blank">
                                         ${$('#ClickToViewLbl').val()}
                                    </a>`
                        }
                    }
                },
                {
                    data: "fileUrl",
                    render: function (data, type, row) {
                        if (row.storageUrl != null) {
                            return '<a href="' + data + '" target="_blank" download="' + row.fileName + '">'
                                + '@Localizer.Get("Download")'
                                + $('#DownloadLbl').val()
                                +'</a>'
                        } else {
                            return `<a href="${row.fileUrl}" target="_blank">
                                         ${$('#VisitLinkLbl').val()}
                                    </a>`
                        }
                    }
                },
                { data: "createdAt" },
                { data: "id" },
            ]
        });


    }

})

   