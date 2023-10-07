
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
            "drawCallback": function (settings) {
                getRoles();
            },
            // Columns Setups
            columns: [
                { data: "id" },
                {
                    data: "user.fullName",
                    render: function (data, type, row) {
                        var Name = row.user.firstName.charAt(0).toUpperCase() + row.user.lastName.charAt(0).toUpperCase();
                        var avatar = '<span class="avatar-initial rounded-circle bg-label-primary">' + Name + '</span>'

                        return '<div class="d-flex justify-content-start align-items-center user-name">'
                            + '<div class="avatar-wrapper"><div class="avatar me-3">' + avatar + ''
                            + '</div></div><div class="d-flex flex-column"><a href="#" class="text-body text-truncate">'
                            + '<span class="fw-medium" > ' + data + '</span ></a>'
                            + '<small class="text-muted" > ' + row.user.emailAddress + '</small></div></div>'
                    }
                },
                { data: "user.userName" },
                { data: "user.phoneNumber" },
                {
                    data: "dashboardAdministrationRole",
                    orderable: false,
                    render: function (data, type, row) {
                        return    '<span class="text-truncate d-flex align-items-center"><span class="badge badge-center rounded-pill bg-label-secondary w-px-30 h-px-30 me-2">'
                            + '<i class="ti ti-device-laptop ti-sm" ></i ></span > ' + data.name + '</span >'
                    }
                },
                { data: "jobTitle" },
                {
                    data: "isActive",
                    render: function (data) {
                        if (data == true) {
                            return '<span class="badge bg-label-success" text-capitalized="">' + $("#Active").val()+'</span>'
                        }
                        else {
                            return '<span class="badge bg-label-secondary" text-capitalized="">' + $("#Inactive").val() + '</span>'
                        }
                    }
                },

                { data: "createdAt" },
                { data: "id" },
            ]
        });


    }

})

