function getAreas(elem, fk_Country, removeFirstElem = true,resetData = true) {
    var serviceUrl = "/Services/GetAreas?Fk_Country=" + fk_Country;
    $.ajax({
        type: "Get",
        url: serviceUrl,
        success: function (result) {
            if (resetData == true) {
                if (removeFirstElem) {
                    $(elem).empty();
                }
                else {
                    $(elem).find('option').not(':first').remove();
                }
            }
            let options = '';
            if (result.length > 0) {
                for (let i = 0; i < result.length; i++) {
                    options += '<option value="' + result[i].id + '">' + result[i].name + '</option>'
                }
            }
            $(elem).append(options);
        }
    });
}

function getFeatures(elem, fk_FeatureCategory, removeFirstElem = true, resetData = true) {
    var serviceUrl = "/Services/GetFeatures?Fk_FeatureCategory=" + fk_FeatureCategory;
    $.ajax({
        type: "Get",
        url: serviceUrl,
        success: function (result) {
            if (resetData == true) {
                if (removeFirstElem) {
                    $(elem).empty();
                }
                else {
                    $(elem).find('option').not(':first').remove();
                }
            }
            else {
                $(elem).find('option').not(':selected').remove();

            }
            let options = '';
            if (result.length > 0) {
                for (let i = 0; i < result.length; i++) {
                    if ($(elem).find("option[value='" + result[i].id + "']").val() === undefined) {
                        options += '<option value="' + result[i].id + '">' + result[i].name + '</option>'
                    }
                }
            }
            $(elem).append(options);
        }
    });
}