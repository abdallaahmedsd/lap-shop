

var ClsItems = {
    currentPage: 1, // Initialize the variable
    isAvailableToLoadMode: true,
    totalElementsPerPage:24,
    GetAll: function () {
        $.ajax({
            method: 'GET',
            url: 'https://localhost:7094/api/Items',
            data: {},

            success: function (data, status) {
                let containerElement = $(".row .margin-res");


                // Clear old data
                containerElement.html('');

                // Generate new HTML
                let dataHTMLFormat = "";
                let itemCount = 1;
                data.data.forEach(function (item) {
                    dataHTMLFormat += ClsItems.draw(item, itemCount); // Generate HTML for each item
                    itemCount++;
                });

                // Append new data
                containerElement.html(dataHTMLFormat);

                $(".search-count").html("")
            },
            error: function (data, status, xhr) {
                console.log("Error data:", data);
                console.log("Status:", status);
                console.log("XHR:", xhr);
            }
        });
    }
    ,
    GetPagingDTO: function (_page = 1, _pageSize = 4, callback) {
        $.ajax({
            method: 'GET',
            url: 'https://localhost:7094/api/items/DTO/paging',
            data: { page: _page, pageSize: _pageSize },

            success: function (data, status) {
                // Execute the callback function with the data
                if (typeof callback === 'function') {
                    callback(data.data);
                }
            },
            error: function (data, status, xhr) {
                console.log("Error data:", data);
                console.log("Status:", status);
                console.log("XHR:", xhr);
            }
        });
    },
    ConstructContainer: function (fromScratch, data) {


        let containerElement = $(".row .margin-res");

        if (fromScratch) {

            // Clear old data
            containerElement.html('');
        }

        // Generate new HTML
        let dataHTMLFormat = "";
        data.forEach(function (item) {
            dataHTMLFormat += ClsItems.draw(item); // Generate HTML for each item
        });

        if (fromScratch) {

            // Append new data
            containerElement.html(dataHTMLFormat);
        }

        else {
            containerElement.append(dataHTMLFormat);
        }
        //if you exceed my target number of pages I want to load I dupracte your normall function 


    }
    ,
    InitiateDataFromScratch: function () {

        let firstPageSize = 8;
        let firstPage = 1;


        this.GetPagingDTO(firstPage, firstPageSize, function (data) {
            console.log("Data:\t", data);
            ClsItems.ConstructContainer(true, data);
        })

        //this.ConstructContainer(true, this.data);

    }
    ,
    Next: function () {

        let pageSize = 4;
        this.currentPage += 1;
        this.GetPagingDTO(this.currentPage, this.pageSize, function (data) {
            ClsItems.ConstructContainer(false, data);
        });

    }
    , resetMoreButton() {
        var element = document.querySelector('.loadMore');
        element.innerHTML="Load More";
    },
    IsValidToLoadMorePages: function () {


        if (this.currentPage * 4 >= this.totalElementsPerPage) {
            
             this.isAvailableToLoadMode=false;
        }
        else {
            this.isAvailableToLoadMode =  true;
            this.resetMoreButton();
        }

    },
    changeTotalElementsPerPage: function (count) {

        this.totalElementsPerPage = count;
        this.IsValidToLoadMorePages();
    },
   
    draw: function (item) {

        let itemCount = 1;
        const displayStyle = itemCount <= 4 ? 'style="display: block;"' : '';

        return `  <div class="col-xl-3 col-6 col-grid-box" ${displayStyle}>
        <div class="product-box">
            <div class="img-wrapper">
                <div class="front">
                    <a href="/home/Details/${item.itemId}">
                        <img src="/Uploads/Items/${item.imageName}" class="img-fluid blur-up lazyload bg-img" alt="">
                    </a>
                </div>
                <div class="back">
                    <a href="/home/Details/${item.itemId}">
                        <img src="/Uploads/Items/${item.imageName}" class="img-fluid blur-up lazyload bg-img" alt="">
                    </a>
                </div>
                <div class="cart-info cart-wrap">
                    <button data-toggle="modal" data-target="#addtocart" title="Add to cart">
                        <i class="ti-shopping-cart"></i>
                    </button>
                    <a href="javascript:void(0)" title="Add to Wishlist">
                        <i class="ti-heart" aria-hidden="true"></i>
                    </a>
                    <a href="/home/Details/${item.itemId}" data-toggle="modal" data-target="#quick-view" title="Quick View">
                        <i class="ti-search" aria-hidden="true"></i>
                    </a>
                    <a href="compare.html" title="Compare">
                        <i class="ti-reload" aria-hidden="true"></i>
                    </a>
                </div>
            </div>
            <div class="product-detail">
                <div>
                    <div class="rating">
                        <i class="fa fa-star"></i>
                        <i class="fa fa-star"></i>
                        <i class="fa fa-star"></i>
                        <i class="fa fa-star"></i>
                        <i class="fa fa-star"></i>
                    </div>
                    <a href="product-page(no-sidebar).html">
                        <h6>${item.itemName}</h6>
                    </a>
                    <p>${item.description}</p>
                    <h4>$${item.purchasePrice}</h4>
                    <ul class="color-variant">
                        <li class="bg-light0"></li>
                        <li class="bg-light1"></li>
                        <li class="bg-light2"></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>`;    }

}



// Wait until the document is fully loaded
document.addEventListener('DOMContentLoaded', function () {
    // Select the element and ensure it's not null
    var element = document.querySelector('.loadMore');
    if (!element) return; // Exit if the element is not found

    // Remove any existing event handlers using jQuery
    $(element).off('click');

    // Add custom click event listener
    element.addEventListener('click', function () {
        console.log("Current Page:", ClsItems.isAvailableToLoadMode); // Log the current page
        console.log("totalelementsPerPage:\t", ClsItems.totalElementsPerPage);

        if (!ClsItems.isAvailableToLoadMode) {
            element.innerHTML = "No More Products"; // Update button text if the condition is met
            return; // Exit the function if no more products
        }

        ClsItems.Next(); // Execute the next action
        if (!ClsItems.isAvailableToLoadMode) {
            element.innerHTML = "No More Products"; // Update button text after the next action
        }
        ClsItems.IsValidToLoadMorePages();
    });
});

$(document).ready(function () {
    // Remove all click handlers for .loadMore
    $('.loadMore').off('click');


    $(".product-page-per-view select").on("change", function () {

        // Get the selected option element
        var selectedOption = $(this).find('option:selected');

        // Get the id and value of the selected option
        var selectedId = selectedOption.attr('id');


        // Perform actions based on the selected id
        switch (selectedId) {
            case "productPerPage_24":
                ClsItems.changeTotalElementsPerPage(24); 
                console.log("Selected ID is 24 Products Per Page.");
                // Implement logic for 24 Products Per Page
                break;
            case "productPerPage_50":
                ClsItems.changeTotalElementsPerPage(50); 

                console.log("Selected ID is 50 Products Per Page.");
                // Implement logic for 50 Products Per Page
                break;
            case "productPerPage_100":
                ClsItems.changeTotalElementsPerPage(100); 
                console.log("Selected ID is 100 Products Per Page.");
                // Implement logic for 100 Products Per Page
                break;
            default:
                console.log("Default or unknown selection.");
                break;
        }


    })
});
 
