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
    let hideTimeout;

    searchInput.addEventListener("focus", function () {
        clearTimeout(hideTimeout);
        searchExtension.style.display = "block";
    });

    searchInput.addEventListener("blur", function () {
      
        hideTimeout = setTimeout(function () {
            searchExtension.style.display = "none";
        }, 500);
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







const navbar = document.querySelector('.nav-bar');
const navbarScrollClass = 'nav-bar-scroll';
let isNavbarVisible = false;


function debounce(func, delay) {
    let timer;
    return function () {
        clearTimeout(timer);
        timer = setTimeout(func, delay);
    };
}

function toggleNavbarScroll() {
    const scrollTop = window.scrollY || window.pageYOffset;
    const windowHeight = window.innerHeight;
    const documentHeight = Math.max(
        document.body.scrollHeight,
        document.body.offsetHeight,
        document.documentElement.clientHeight,
        document.documentElement.scrollHeight,
        document.documentElement.offsetHeight
    );

    const scrollThresholdTop = 500;
    const scrollThresholdBottom = 700; 

    if (scrollTop > scrollThresholdTop && scrollTop + windowHeight < documentHeight - windowHeight - scrollThresholdBottom) {
        if (!isNavbarVisible) {
            navbar.classList.add(navbarScrollClass);
            isNavbarVisible = true;
        }
    } else {
        if (isNavbarVisible) {
            navbar.classList.remove(navbarScrollClass);
            isNavbarVisible = false;
        }
    }
}

const debouncedToggleNavbarScroll = debounce(toggleNavbarScroll, 40);
window.addEventListener('scroll', debouncedToggleNavbarScroll);














let allProducts = [
    "Fresh Green Beans",
    "Crisp Carrot Sticks",
    "Vibrant Bell Peppers",
    "Organic Spinach",
    "Golden Corn Kernels",
    "Flaky Croissants",
    "Artisan Baguette",
    "Creamy Cheesecake",
    "Cinnamon Swirl Danish",
    "Chocolate Chip Muffins",
    "Merlot Reserve",
    "Chardonnay Elegance",
    "Cabernet Sauvignon",
    "Zinfandel Bliss",
    "Pinot Noir Delight",
    "Farm Fresh Eggs",
    "Creamy Greek Yogurt",
    "Cheddar Cheese Block",
    "Smooth Almond Milk",
    "Whipped Cream",
    "Tenderloin Steak",
    "Roasted Chicken Breast",
    "Savory Ground Beef",
    "Grilled Turkey Burgers",
    "Juicy Pork Chops",
    "Sparkling Lemonade",
    "Cola Classic",
    "Ginger Ale Fizz",
    "Orange Cream Soda",
    "Berry Burst Cooler",
    "All-Purpose Cleaner",
    "Microfiber Cleaning Cloths",
    "Scented Dish Soap",
    "Stainless Steel Polish",
    "Dust and Lint Brushes",
    "Cereal & Snacks",
    "Honey Nut Crunch Cereal",
    "Sea Salt Popcorn",
    "Trail Mix Medley",
    "Granola Bar Variety Pack",
    "Cheddar Snack Crackers"
];

var sortedProducts = allProducts.slice().sort();  

var searchBox = document.getElementById("search");



document.addEventListener("DOMContentLoaded", () => {
   
    const listOfTrends = document.querySelector(".listOfTrends");
  

    searchBox.addEventListener("keyup", (e) => {
        listOfTrends.innerHTML = ""; 
        for (let i of sortedProducts) {
            if (i.toLowerCase().startsWith(searchBox.value.toLowerCase()) && searchBox.value != "") {
                let listItem = document.createElement("li");
                listItem.classList.add("list-items");
                listItem.style.cursor = "pointer";
                listItem.setAttribute("onclick", `displayNames('${i}')`);

                let word = "<b>" + i.substr(0, searchBox.value.length) + "</b>";
                word += i.substr(searchBox.value.length);

                listItem.innerHTML = word;
                listOfTrends.appendChild(listItem);
                
            }
        }
    });

   
});
function displayNames(value) {
    searchBox.value = value;
}