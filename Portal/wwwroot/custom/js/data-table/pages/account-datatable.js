
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
                    data.Fk_AccountType = $("#Fk_AccountType_Filter").length > 0 ? $("#Fk_AccountType_Filter").val() : 0;
                    data.Fk_AccountState = $("#Fk_AccountState_Filter").length > 0 ? $("#Fk_AccountState_Filter").val() : 0;
                    data.HaveBookings = $("#HaveBookings_Filter").length > 0 ? $("#HaveBookings_Filter").val() : null;
                    data.CreatedAtFrom = $("#CreatedAtFrom").length > 0 ? $("#CreatedAtFrom").val() : null;
                    data.CreatedAtTo = $("#CreatedAtTo").length > 0 ? $("#CreatedAtTo").val() : null;
                    return JSON.stringify(data);
                }
            },
            // Columns Setups
            columns: [
                { data: "id" },
                {
                    data: "user.fullName",
                    render: function (data, type, row) {
                        var avatar = '<img src="' + row.imageUrl + '" alt="Avatar" class="rounded-circle">';
                        if (row.imageUrl == null || row.imageUrl == '') {
                            var Name = row.user.firstName.charAt(0).toUpperCase() + row.user.lastName.charAt(0).toUpperCase();
                            avatar = '<span class="avatar-initial rounded-circle bg-label-primary">' + Name + '</span>'
                        }
                       
                        return '<div class="d-flex justify-content-start align-items-center user-name">'
                            + '<div class="avatar-wrapper"><div class="avatar me-3">' + avatar + ''
                            + '</div></div><div class="d-flex flex-column"><a href="/AccountEntity/Account/Profile/'+row.id+'" class="text-body text-truncate">'
                            + '<span class="fw-medium" > '+data+'</span ></a>'
                            + '<small class="text-muted" > ' + row.user.emailAddress+'</small></div></div>'
                    }
                },
                { data: "user.userName" },

                {
                    data: "accountType",
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
                                + '<span style="color:' + data.colorCode+'">' + data.name + '</span</span> ';
                        }

                    }
                },
                {
                    data: "accountState",
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
                { data: "user.phoneNumber" },

             
                { data: "createdAt" },

                { data: "id" },
            ]
        });


    }

})

