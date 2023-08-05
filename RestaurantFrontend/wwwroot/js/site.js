// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const dropdownItem = document.querySelector('.dropdown');
const dropdownMenu = document.querySelector('.dropdown-menu');

dropdownItem.addEventListener('mouseenter', () => {
    dropdownMenu.style.display = 'block';
});

dropdownItem.addEventListener('mouseleave', () => {
    dropdownMenu.style.display = 'none';
});