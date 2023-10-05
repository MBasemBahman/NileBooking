$(document).ready(function () {
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
                {
                    data: "accountsCount",
                    render: function (data, type, row) {
                        return '<div class="d-flex align-items-center">'
                            + '<p class="mb-0" ><a class="text-dark" target="_blank" href="/AccountEntity/Account/Index?Fk_AccountState=' + row.id + '">' + row.accountsCount + '</a></p>'
                            + '<div class="ms-3 badge bg-label-warning">' + row.accountsPercent+'%</div>'
                            + '</div>'
                      
                    }
                },
                { data: "createdAt" },

                { data: "id" },
            ]
        });


    }

})

