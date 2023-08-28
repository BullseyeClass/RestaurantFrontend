var currentLocation = window.location.href;



function addToCart(buttonElement) {
    const productId = $(buttonElement).data("product-id");
    const quantityText = $(".counter-container .count-" + productId).text();
    const quantity = parseInt(quantityText);

    $.post("/Cart/AddToCart", { productId: productId, quantity: quantity }, function (response) {
        if (response.success) {
            location.reload();
        } else {
            alert("Failed to add product to cart.");
        }
    });
}

function addToCart1(buttonElement) {
    const productId = $(buttonElement).data("product-id");
    const quantityText = $(".counter-container .count-" + productId).text();
    const firstDigit = parseInt(quantityText.match(/\d/)[0]);

    $.post("/Cart/AddToCart", { productId: productId, quantity: firstDigit }, function (response) {
        if (response.success) {
            location.reload();
           
            updateCartSection(response.cartInfo);
        } else {
            alert("Failed to add product to cart.");
        }
    });
}
function addToCart2(buttonElement) {
    const productId = $(buttonElement).data("product-id");
    const quantityText = $("#cardDetails").val(); // Use .val() to get input element value
    const quantity = parseInt(quantityText);

    if (!isNaN(quantity)) { // Check if quantity is a valid number
        $.post("/Cart/AddToCart", { productId: productId, quantity: quantity }, function (response) {
            if (response.success) {
                location.reload();
                updateCartSection(response.cartInfo);
            } else {
                alert("Failed to add product to cart.");
            }
        });
    } else {
        alert("Invalid quantity entered.");
    }
}


function removeFromCart(buttonElement) {
    try {
        const productId = $(buttonElement).data("product-id");
        const quantityText = $(".count").text();
        const firstDigit = parseInt(quantityText.match(/\d/)[0]);

        $.post("/Cart/RemoveFromCart", { productId: productId, quantity: firstDigit }, function (response) {
            if (response.success) {
                location.reload();
            } else {
                alert("Failed to remove product from cart.");
            }
        });
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

