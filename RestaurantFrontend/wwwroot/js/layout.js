const slideUpElement1 = document.getElementById('slide-up-element1');
const slideUpElement2 = document.getElementById('slide-up-element2');


setInterval(() => {
    slideUpElement1.classList.toggle('hiddens');
    slideUpElement2.classList.toggle('hiddens');

}, 5000);




document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("search");
    const searchExtension = document.getElementById("trending-content");

    searchInput.addEventListener("focus", function () {
        searchExtension.style.display = "block";
    });

    searchInput.addEventListener("blur", function () {
        searchExtension.style.display = "none";
    });
});


function navigateToFAQSection(event) {
    event.preventDefault();

    var targetSection = document.querySelector("#" + event.target.getAttribute("data-section"));
    if (targetSection) {
        targetSection.scrollIntoView({ behavior: "smooth" });
    }
}
