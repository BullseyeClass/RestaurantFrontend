
const dropdownItem = document.querySelector('.dropdown');
const dropdownMenu = document.querySelector('.dropdown-menu');

dropdownItem.addEventListener('mouseenter', () => {
    dropdownMenu.style.display = 'block';
});

dropdownItem.addEventListener('mouseleave', () => {
    dropdownMenu.style.display = 'none';
});


