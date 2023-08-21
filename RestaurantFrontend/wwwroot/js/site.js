function addToCart(buttonElement) {
    const productId = $(buttonElement).data("product-id");
    const quantityText = $(".counter-container .count-" + productId).text();
    const quantity = parseInt(quantityText);

    $.post("/Cart/AddToCart", { productId: productId, quantity: quantity }, function (response) {
        if (response.success) {
            // Reload the page on success
            location.reload();
        } else {
            alert("Failed to add product to cart.");
        }
    });
}

function addToCart1(buttonElement) {
    const productId = $(buttonElement).data("product-id");
    const quantityText = $(".counter-container .count-" + productId).text();
    const quantity = parseInt(quantityText);

    $.post("/Cart/AddToCart", { productId: productId, quantity: quantity }, function (response) {
        if (response.success) {
            // Reload the page on success
            location.reload();
        } else {
            alert("Failed to add product to cart.");
        }
    });
}