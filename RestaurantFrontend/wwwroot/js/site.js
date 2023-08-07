const slideUpElements = document.querySelectorAll('.slide-up-text');

setInterval(() => {
    slideUpElements.forEach(element => {
        element.classList.toggle('hidden');
    });
}, 5000);
