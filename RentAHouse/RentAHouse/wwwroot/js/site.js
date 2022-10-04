// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#region-drop-down-list').change(function () {
    var selectedRegionId = $("#region-drop-down-list").val();
    var municipalities = $('#municipality-drop-down-list');
    var settlements = $('#settlement-drop-down-list');
    ClearDropdown(settlements);
    if (selectedRegionId != null && selectedRegionId != '') {
        $.getJSON('GetMunicipalities', { regionId: selectedRegionId }, function (municipalitiesCollection) {
            if (municipalitiesCollection != null && !jQuery.isEmptyObject(municipalitiesCollection)) {
                municipalities.prop("disabled", false)
                ClearDropdown(municipalities);
                $.each(municipalitiesCollection, function (index, municipality) {
                    municipalities.append($('<option/>', {
                        value: municipality.id,
                        text: municipality.name
                    }));
                });
            };
        });
    }
});

$('#municipality-drop-down-list').change(function () {
    var selectedMunicipalityId = $("#municipality-drop-down-list").val();
    var settlements = $('#settlement-drop-down-list');
    settlements.empty();
    if (selectedMunicipalityId != null && selectedMunicipalityId != '') {
        $.getJSON('GetSettlements', { municipalityId: selectedMunicipalityId }, function (settlementsCollection) {
            if (settlementsCollection != null && !jQuery.isEmptyObject(settlementsCollection)) {
                settlements.prop("disabled", false)
                ClearDropdown(settlements);
                $.each(settlementsCollection, function (index, settlement) {
                    settlements.append($('<option/>', {
                        value: settlement.id,
                        text: settlement.name
                    }));
                });
            };
        });
    }
});

function ClearDropdown(dropdown) {
    dropdown.empty();
    dropdown.append($('<option/>', {
        value: null,
        text: "--Избери--"
    }));
}