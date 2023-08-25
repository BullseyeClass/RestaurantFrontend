const slideUpElement1 = document.getElementById('slide-up-element1');
const slideUpElement2 = document.getElementById('slide-up-element2');
const food = document.getElementById('footer-food-hover-link');
const flist = document.getElementById('footer-food-hover-list');
const bevs = document.getElementById('footer-bevs-hover-link');
const blist = document.getElementById('footer-bevs-hover-list');
const house = document.getElementById('footer-house-hover-link');
const hlist = document.getElementById('footer-house-hover-list');
const care = document.getElementById('footer-care-hover-link');
const clist = document.getElementById('footer-care-hover-list');


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






food.addEventListener('mouseover', () => {
    flist.style.display = 'grid';
});


food.addEventListener('mouseout', () => {
    flist.style.display = 'none'; 
});

bevs.addEventListener('mouseover', () => {
    blist.style.display = 'grid';
});


bevs.addEventListener('mouseout', () => {
    blist.style.display = 'none';
});


house.addEventListener('mouseover', () => {
    hlist.style.display = 'grid';
});


house.addEventListener('mouseout', () => {
    hlist.style.display = 'none';
});

care.addEventListener('mouseover', () => {
    clist.style.display = 'grid';
});


care.addEventListener('mouseout', () => {
    clist.style.display = 'none';
});



function fetchUserInformation() {
    $.ajax({
        url: '/CartDisplay',
        method: 'GET',
        success: function (data) {
            var navbarUsernameElement = document.getElementById('navbarCartCount');
            navbarUsernameElement.textContent = data;
        },
        error: function () {
            console.log('Failed to fetch user information.');
        }
    });
}



$(document).ready(function () {
    fetchUserInformation();
});





