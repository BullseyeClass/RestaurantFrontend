
﻿
//const dropdownItem = document.querySelector('.dropdown');
//const dropdownMenu = document.querySelector('.dropdown-menu');

//dropdownItem.addEventListener('mouseenter', () => {
//    dropdownMenu.style.display = 'block';
//});

//dropdownItem.addEventListener('mouseleave', () => {
//    dropdownMenu.style.display = 'none';
//});



//document.addEventListener("DOMContentLoaded", function () {
//    const showListBtn = document.getElementById("search");
//    const hiddenList = document.querySelector(".trending-content");
//    const trendingContainer = document.querySelector('#trend')

//    showListBtn.addEventListener("click", function () {
//        if (hiddenList.style.display === "none") {
//            hiddenList.style.display = "block";
//            trendingContainer.classList.add('addborder');
//            slideDown(hiddenList);
//        } else {
//            hiddenList.style.display = "none";
//            trendingContainer.classList.remove('addborder');
//        }
//    });

//    document.addEventListener("click", function (event) {
//        if (!hiddenList.contains(event.target) && event.target !== showListBtn) {
//            hiddenList.style.display = "none";
//            trendingContainer.classList.remove('addborder');
//        }
//    });

//    function slideDown(element) {
//        let height = 0;
//        const maxHeight = element.scrollHeight;

//        const slideAnimation = setInterval(function () {
//            height += 5;
//            if (height <= maxHeight) {
//                element.style.height = height + "px";
//            } else {
//                clearInterval(slideAnimation);
//                element.style.overflow = "visible";
//            }
//        }, 10);
//    }
//});





//const divElement = document.getElementById("myDiv");

//divElement.addEventListener("click", () => {
//    divElement.focus();
//});

