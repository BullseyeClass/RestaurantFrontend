





function removeFromCart(buttonElement) {
    const productId = $(buttonElement).data("product-id");
    const quantityText = $(".counter-container .count-" + productId).text();
    const firstDigit = parseInt(quantityText.match(/\d/)[0]);

    $.post("/Cart/RemoveFromCart", { productId: productId, quantity: firstDigit }, function (response) {
        if (response.success) {
            location.reload();

        } else {
            alert("Failed to remove product from cart.");
        }
    });
}