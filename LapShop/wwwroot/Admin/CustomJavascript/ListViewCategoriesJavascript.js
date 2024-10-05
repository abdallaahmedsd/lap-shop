

$(document).ready(function () {
    loadCategories();
    loadItemTypes();
    bindCategoryAndItemTypeChange();
});
function loadCategories() {

    $.ajax({

        url: '/Admin/Items/GetAllCategoriesInList',
        type: 'GET',
        datatype: 'json',
        success: function (data) {

            console.log("data:", data);

            let select = $('#selectCategoryName');

            select.empty();// Clear any existing options
            select.append($('<option/>', {
                value: 0,
                text: "nothing"
            }));
            $.each(data, function (index, category) {
                select.append($('<option/>', {
                    value: category.categoryId,
                    text: category.categoryName
                }));
            });
            select.selectedValue = 0;
        },
        error: function () {
            alert('Error loading categories.');
        }
    });
}
function loadItemTypes() {

    $.ajax({

        url: '/Admin/Items/GetAllItemTypesInList',
        type: 'GET',
        datatype: 'json',
        success: function (data) {

            console.log("data:", data);

            let select = $('#selectItemTypeId');

            select.empty();// Clear any existing options

            select.append($('<option/>', {
                value: 0,
                text: "nothing"
            }));

            $.each(data, function (index, itemType) {
                select.append($('<option/>', {
                    value: itemType.itemTypeId,
                    text: itemType.itemTypeName
                }));
             
            });
        },
        error: function () {
            alert('Error loading itemtpyes.');
        }
    });
}
function bindCategoryAndItemTypeChange() {

    // Bind change event to both #selectCategoryName and #selectItemType
      $("#selectCategoryName, #selectItemTypeId").change(function () {
        let selectedValue = $("#selectCategoryName").val();
        let selectedValue2 = $("#selectItemTypeId").val();

        console.log("Selected value 1:", selectedValue);
        console.log("Selected value 2:", selectedValue2);

        $.ajax({
            url: '/Admin/Items/Search',
            type: 'GET', // or 'POST' if you prefer
            data: { elementId1: selectedValue, elementId2: selectedValue2 }, // Fixed the syntax error here
            success: function (response) {

                document.open();
                document.write(response);
                // Re-set the previously selected values
                $("#selectCategoryName").val(selectedValue);
                $("#selectItemTypeId").val(selectedValue2);
                document.close();
            
            },
            error: function (xhr, status, error) {
                console.error("Error occurred:", status, error);
            }
        });

    });
    
}