$('.select2').each(function () {
    $(this).select2({ dropdownParent: $(this).parent() });
});

$("#Fk_Country").on('change', function () {
    getAreas($("#Fk_Area"), $("#Fk_Country").val(), false, true);
});

$("#Fk_FeatureCategory").on('change', function () {
    getFeatures($("#Fk_HotelSelectedFeatures"), $("#Fk_FeatureCategory").val(), false, false);
});