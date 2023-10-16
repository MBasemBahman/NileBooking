let currentPage = 1;
let pageSize = 6;
let searchTimeoutId;


$(document).ready(function () {
    $('.select2').each(function () {
        $(this).select2({ dropdownParent: $(this).parent() });
    });

    $("#Fk_Country_Filter").on('change', function () {
        getAreas($("#Fk_Area_Filter"), $("#Fk_Country_Filter").val(), false, true);
    });

    $("#Fk_HotelFeatureCategory_Filter").on('change', function () {
        getFeatures($("#Fk_HotelFeature_Filter"), $("#Fk_HotelFeatureCategory_Filter").val(), false, false);
    });
});
// Search Filter :: Start
$(document).on('input', '#search-input', function () {
    clearTimeout(searchTimeoutId);
    searchTimeoutId = setTimeout(resetHotels, 1000);
});
// Search Filter :: End

// Other Filter :: Start
$(document).on('click', '.is_active', function () {
    loadRows();
});

$(document).on('click', '.is_recommended', function () {
    loadRows();
});

$(document).on('change', '.order_by_selector', function () {
    loadRows();
});
// Other Filter :: End

///////////////////////////////////////////////////////////////////////////////////////


$(document).on('click', '.pagination-btn', function() {

    // set the current page to the page number clicked
    currentPage = parseInt($(this).text());

    // load the data for the selected page
    loadRows();

    // update the active page button
    $(this).parent().addClass('active').siblings().removeClass('active');
});

$(document).on('click', '.open-create-modal', function () {
    let href = $(this).attr('href');
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
            $('.general-xl-modal-form-content').html(data);
            $("#general-xl-modal").modal("show");
        },
    });
});

// Select2
let select2 = $('.select2');
if (select2.length) {
    select2.each(function () {
        let $this = $(this);
        $this.wrap('<div class="position-relative"></div>').select2({
            dropdownParent: $this.parent(),
            placeholder: $this.data('placeholder'), // for dynamic placeholder
            dropdownCss: {
                minWidth: '150px' // set a minimum width for the dropdown
            }
        });
    });
    $('.select2-selection__rendered').addClass('w-px-150');
}

function loadRows() {
    $.ajax({
        url: "/HotelEntity/Hotel/LoadHotels",
        method: "post",
        data: {
            PageNumber: currentPage,
            PageSize: pageSize,
            OrderBy: $('.order_by_selector').val(),
            IsActive: $(".is_active").is(":checked"),
            IsRecommended: $(".is_recommended").is(":checked"),
            TxtSearch: $('#search-input').val(),
            Fk_Country: $("#Fk_Country_Filter").length > 0 ? $("#Fk_Country_Filter").val() : 0,
            Fk_Area: $("#Fk_Area_Filter").length > 0 ? $("#Fk_Area_Filter").val() : 0,
            Fk_HotelTypes: $("#Fk_HotelType_Filter").length > 0 ? $("#Fk_HotelType_Filter").val() : null,
            Fk_RoomTypes: $("#Fk_RoomType_Filter").length > 0 ? $("#Fk_RoomType_Filter").val() : null,
            Fk_RoomFoodTypes: $("#Fk_RoomFoodType_Filter").length > 0 ? $("#Fk_RoomFoodType_Filter").val() : null,
            Fk_HotelFeatureCategories: $("#Fk_HotelFeatureCategory_Filter").length > 0 ? $("#Fk_HotelFeatureCategory_Filter").val() : null,
            Fk_HotelFeatures: $("#Fk_HotelFeature_Filter").length > 0 ? $("#Fk_HotelFeature_Filter").val() : null,
        },
        beforeSend: function() {
            $('#cover-spin').show();
        },
        complete: function() {
            $('#cover-spin').hide();
        },
        success: function(data) {
            if (data.data.length > 0) {
                $(".results_found_count").html(data.count);
                setHotelTable(data.data);
                setPagination(data);
            } else {
                $(".results_found_count").html(0);
                $("#list-of-hotels").html('');
                $("#not-found-hotels").html(`<div class="misc-inner p-2 p-sm-3">
                     <div class="w-100 text-center">
                         <img src="/custom/img/search.png" />
                         <h1 class="mt-2">${$("#NotExistsDataLbl").val()}</h1>
                         <p class="mb-2"></p>
                     </div>
                 </div>`);
                $("#pagination-controls").html(``);
            }
        }
    });
}

function setHotelTable(hotels) {
    let list = '';

    hotels.forEach(function(hotel)  {
        list += `<div class="col-sm-6 col-lg-4">
          <div class="card p-2 h-100 shadow-none border">
            <div class="rounded-2 text-center mb-3">
              <a href="/HotelEntity/Hotel/Profile/${hotel.id}">
                <img class="img-fluid" src="${hotel.imageUrl}" alt="tutor image 1" />
              </a>
            </div>
            <div class="card-body p-3 pt-2">
              <div class="d-flex justify-content-between align-items-center mb-3">
                <span class="badge bg-label-primary">${hotel.hotelType.name}</span>
                <span class="badge bg-label-${hotel.isActive ? "success" : "danger"}">
                    ${hotel.isActive ? $("#Active").val() : $("#Inactive").val()}
                </span>
                <h6 class="d-flex align-items-center justify-content-center gap-1 mb-0">
                  ${hotel.rate} <span class="text-warning"><i class="ti ti-star-filled me-1 mt-n1"></i></span><span class="text-muted"></span>
                </h6>
              </div>
              <a href="/HotelEntity/Hotel/Profile/${hotel.id}" class="h5">${hotel.name}</a>
              <p class="mt-2">${hotel.description}</p>
              <hr/>
              <div class="d-flex flex-column flex-md-row gap-3 text-nowrap justify-content-center">
                <a class="app-academy-md-50 btn btn-label-primary d-flex align-items-center modal-xl-btn-edit" href="/HotelEntity/Hotel/CreateOrEdit/${hotel.id}">
                  <span class="me-2">${ $("#EditLbl").val() }</span><i class="ti ti-chevron-right scaleX-n1-rtl ti-sm"></i>
                </a>
                <a class="app-academy-md-50 btn btn-label-danger d-flex align-items-center modal-btn-delete" href="/HotelEntity/Hotel/Delete/${hotel.id}">
                  <span class="me-2">${ $("#RemoveLbl").val() }</span><i class="ti ti-trash scaleX-n1-rtl ti-sm"></i>
                </a>
              </div>
            </div>
          </div>
        </div>`;
    });

    $("#not-found-hotels").html('');
    $("#list-of-hotels").html(list);
}

function resetHotels() {
    resetPageVariables();
    loadRows();
}

function resetPageVariables() {
    currentPage = 1;
    pageSize = 6;
}

function setPagination(data) {
    const totalPages = Math.ceil(data.count / pageSize);

    const paginationControls = $('#pagination-controls'); // get the pagination controls container
    paginationControls.empty(); // clear the pagination controls

    // create the pagination controls
    for (let i = 1; i <= totalPages; i++) {
        paginationControls.append(`<li class="page-item"><a class="page-link pagination-btn" href="javascript:void(0);">${i}</a></li>`);
    }

    // update the active page button
    paginationControls.find('li').removeClass('active');
    paginationControls.find('li').eq(currentPage - 1).addClass('active');
}