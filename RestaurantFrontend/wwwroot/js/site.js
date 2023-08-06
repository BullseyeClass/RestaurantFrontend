// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const slideUpElements = document.querySelectorAll('.slide-up-text');

setInterval(() => {
    slideUpElements.forEach(element => {
        element.classList.toggle('hidden');
    });
}, 5000); // Toggle every 10 seconds (adjust the time as needed)
