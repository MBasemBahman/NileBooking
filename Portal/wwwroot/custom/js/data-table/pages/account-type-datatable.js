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
                    data: "accountsCount",
                    render: function (data, type, row) {
                        return '<div class="d-flex align-items-center my-2">'
                            + '<span class="badge badge-center rounded-pill bg-label-success w-px-30 h-px-30 me-2">'
                            + '<i class="ti ti-user ti-sm" ></i></span></span>'
                            + '<h4 class="mb-0 me-2"><a class="text-dark" target="_blank" href="/AccountEntity/Account/Index?Fk_AccountType=' + row.id + '">' + row.accountsCount + '</a></h4>'
                            + '<p class="text-success mb-0">(' + row.accountsPercent + '%)</p></div>';
                    }
                },
                { data: "createdAt" },
             
                { data: "id" },
            ]
        });


    }

})

   