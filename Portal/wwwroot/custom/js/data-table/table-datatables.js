'use strict';
// Datatable (jquery)
$(function () {
    let borderColor, bodyBg, headingColor;

    if (isDarkStyle) {
        borderColor = config.colors_dark.borderColor;
        bodyBg = config.colors_dark.bodyBg;
        headingColor = config.colors_dark.headingColor;
    } else {
        borderColor = config.colors.borderColor;
        bodyBg = config.colors.bodyBg;
        headingColor = config.colors.headingColor;
    }

    // Variable declaration for table
    var dt_user_table = $('.dataTable');
    // datatable
    if (dt_user_table.length) {
        $.extend(true, $.fn.dataTable.defaults, {
            "scrollX": true,
            stateSave: true,
            autoWidth: true,
            processing: true,
            serverSide: true,
            paging: true,
            searching: { regex: true },
            columnDefs: [

                {
                    // Actions
                    targets: -1,
                    title: $("#ActionsLbl").val(),
                    searchable: false,
                    orderable: false,
                    render: function (data, type, full, meta) {
                        let action = '<div class="d-flex align-items-center">';
                        if ($('#edit').attr('href') != undefined) {
                            let modalClass = '';
                            if ($("#edit").hasClass('open-modal')) {
                                modalClass = 'modal-btn-edit';
                            }
                            else if ($("#edit").hasClass('open-modal-side')) {
                                modalClass = 'modal-btn-edit-side';
                            }
                            action += `<a href="${$('#edit').attr('href')}/${full.id}" class="text-body ${modalClass}"><i class="ti ti-edit ti-sm me-2"></i></a>`;
                        }
                        if ($('#delete').attr('href') != undefined) {
                            let modalClass = '';

                            if ($("#delete").hasClass('open-modal')) {
                                modalClass = 'modal-btn-delete';
                            }
                            action += `<a href="${$('#delete').attr('href')}/${full.id}" class="text-body ${modalClass}"><i class="ti ti-trash ti-sm me-2"></i></a>`;
                        }
                        if ($('#details').attr('href') != undefined) {
                            let modalClass = '';

                            if ($("#details").hasClass('open-modal')) {
                                modalClass = 'modal-btn-details';
                            }
                            action += `<a href="${$('#details').attr('href')}/${full.id}" class="text-body ${modalClass}"><i class="ti ti-eye ti-sm me-2"></i></a>`;
                        }

                        action += '</div>';
                        return (action);
                    }
                }
            ],
            order: [[0, 'desc']],
            dom:
                '<"row me-2"' +
                '<"col-md-2"<"me-3"l>>' +
                '<"col-md-10"<"dt-action-buttons text-xl-end text-lg-start text-md-end text-start d-flex align-items-center justify-content-end flex-md-row flex-column mb-3 mb-md-0"fB>>' +
                '>t' +
                '<"row mx-2"' +
                '<"col-sm-12 col-md-6"i>' +
                '<"col-sm-12 col-md-6"p>' +
                '>',
            language: {
                sLengthMenu: '_MENU_',
                searchPlaceholder: $("#SearchLbl").val() + " ....",
                search: $("#SearchLbl").val(),
                paginate: {
                    previous: $("#PrevLbl").val(),
                    next: $("#NextLbl").val()
                },
            },
            // Buttons with Dropdown
            buttons: [
                {
                    extend: 'collection',
                    className: 'btn btn-label-secondary dropdown-toggle mx-3',
                    text: '<i class="ti ti-screen-share me-1 ti-xs"></i>' + $("#ExportLbl").val(),
                    buttons: [
                        {
                            extend: 'print',
                            text: '<i class="ti ti-printer me-2" ></i>' + $("#PrintLbl").val(),
                            className: 'dropdown-item',
                            customize: function (win) {
                                //customize print view for dark
                                $(win.document.body)
                                    .css('color', headingColor)
                                    .css('border-color', borderColor)
                                    .css('background-color', bodyBg);
                                $(win.document.body)
                                    .find('table')
                                    .addClass('compact')
                                    .css('color', 'inherit')
                                    .css('border-color', 'inherit')
                                    .css('background-color', 'inherit');
                            }
                        },
                        {
                            extend: 'csv',
                            text: '<i class="ti ti-file-text me-2" ></i>' + $("#ExcelLbl").val(),
                            className: 'dropdown-item',
                        },
                        {
                            extend: 'excel',
                            text: '<i class="ti ti-file-spreadsheet me-2"></i> $("#ExcelLbl").val()',
                            className: 'dropdown-item',
                        },
                        
                        {
                            extend: 'pdf',
                            text: '<i class="ti ti-file-code-2 me-2"></i>' + $("#PdfLbl").val(),
                            className: 'dropdown-item',
                        },
                        {
                            extend: 'copy',
                            text: '<i class="ti ti-copy me-2" ></i>' + $("#CopyLbl").val(),
                            className: 'dropdown-item',
                        }
                    ]
                },
                {
                    text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">' + $("#AddNewLbl").val() + '</span>',
                    className: 'add-new btn btn-primary',
                    attr: {
                        'data-bs-toggle': 'offcanvas',
                        'data-bs-target': '#offcanvasAddUser'
                    },
                    init: function (api, node, config) {
                        if ($('#create').attr('href') == undefined) {
                            $(node).hide();
                        } else {
                            $(node).removeClass('btn-secondary');
                        }
                    },
                    action: function (e, dt, button, config) {
                        if ($("#create").hasClass('open-modal')) {
                            var href = $("#create").attr('href');
                            $.ajax({
                                url: href,
                                method: 'GET',
                                beforeSend: function () {
                                    $('#cover-spin').show();
                                },
                                complete: function () {
                                    $('#cover-spin').hide();
                                },
                                success: function (data) {
                                    $('.general-modal-form-content').html(data);
                                    $("#general-modal").modal("show");
                                },
                            });

                        }
                        else if ($("#create").hasClass('open-modal-side')) {
                            var href = $("#create").attr('href');
                            $.ajax({
                                url: href,
                                method: 'GET',
                                beforeSend: function () {
                                    $('#cover-spin').show();
                                },
                                complete: function () {
                                    $('#cover-spin').hide();
                                },
                                success: function (data) {
                                    $('#offcanvasAddItem').html(data);
                                    var bsOffcanvas = new bootstrap.Offcanvas($("#offcanvasAddItem"))
                                    bsOffcanvas.show()
                                },
                            });

                          
                        }
                        else {
                            window.location = $('#create').attr('href');
                        }
                    }
                }
            ],

        });
    }

 

});


