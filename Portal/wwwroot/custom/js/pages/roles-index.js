function getRoles() {
    $.ajax({
        url: "/DashboardAdministrationEntity/DashboardAdministrationRole/GetRoles",
        method: "get",
        beforeSend: function () {
            $('#cover-spin').show();
        },
        complete: function () {
            $('#cover-spin').hide();
        },
        success: function (data)
        {
            $(".role-item").remove();

            for (var i = 0; i < data.length; i++) {
                var elem = $("#role-item-container").clone();
                elem.addClass("role-item");
                elem.attr("id", "");
                elem.find(".total-users-count").text(data[i].administratorsCount);
                elem.find(".total-users-count").attr('id', data[i].id);

                elem.find(".role-name").text(data[i].name);

                if (elem.find('.edit-role').length > 0) {
                    elem.find(".edit-role").attr('href', '/DashboardAdministrationEntity/DashboardAdministrationRole/CreateOrEdit/' + data[i].id);
                    elem.find(".edit-role").on('click', function () {
                        event.preventDefault();
                        $.ajax({
                            url: $(this).attr('href'),
                            method: 'GET',
                            beforeSend: function () {
                                $('#cover-spin').show();
                            },
                            complete: function () {
                                $('#cover-spin').hide();
                            },
                            success: function (data) {
                                $('.role-modal-form-content').html(data);
                                $("#role-create-edit-modal").modal("show");
                            },
                        });


                    });

                }
                if (elem.find('.remove-role').length > 0) {
                    elem.find(".remove-role").attr('href', '/DashboardAdministrationEntity/DashboardAdministrationRole/Delete/' + data[i].id);
                    elem.find(".remove-role").on('click', function () {
                        event.preventDefault();
                        let href = $(this).attr('href');
                        $('.role-form-delete').attr('action', href);
                        $('#role-delete-modal').modal('show');

                    });
                }


                $(elem.show()).insertBefore(".add-new-role-container");

            }
        }
    });
}


function assignErrors(errors) {
    let list = '<ul>';

    errors.forEach(err => {
        if (err.errorMessage !== '') {
            list += `<li>${err.errorMessage}</li>`;
        }
    });

    list += '</ul>';

    return list;
}


$(document).on('click', '.modal-add-role-btn', function (e) {
    e.preventDefault();

    // Make an AJAX request to fetch content from the URL
    $.ajax({
        url: '/DashboardAdministrationEntity/DashboardAdministrationRole/CreateOrEdit',
        method: 'GET',
        beforeSend: function () {
            $('#cover-spin').show();
        },
        complete: function () {
            $('#cover-spin').hide();
        },
        success: function (data) {
            $('.role-modal-form-content').html(data);
            $("#role-create-edit-modal").modal("show");
        },
    });
});

$(document).on('submit', "#role-create-edit-modal", function (e) {
    e.preventDefault();
    $.ajax({
        type: $('.role-modal-form-content form').attr('method'),
        url: $('.role-modal-form-content form').attr('action'),
        data: $('.role-modal-form-content form').serialize(),
        beforeSend: function () {
            $('#cover-spin').show();
        },
        complete: function () {
            $('#cover-spin').hide();
        },
        success: function (response, status, xhr) {
            getRoles();
            $("#role-create-edit-modal").modal("hide");
            $("#success-modal").modal("show");
        },
        error: function (error) {
            let list = assignErrors(error.responseJSON);
            $('.validation-summary-valid').html(list);
        }
    });
});

$(document).on('submit', '.role-form-delete', function (e) {
    e.preventDefault();

    $.ajax({
        url: $(this).attr('action'),
        method: $(this).attr('method'),
        beforeSend: function () {
            $('#cover-spin').show();
        },
        complete: function () {
            $('#cover-spin').hide();
        },
        success: function (data) {
            getRoles();
            $("#role-delete-modal").modal("hide");
            $("#success-modal").modal("show");
        },
        error: function (error) {
            let list = assignUlErrors(error.responseJSON);
            console.log(list);
            $('.delete-validation-summary-valid').html(list);
        }
    });
});

$(document).ready(function () {
    getRoles();
});


