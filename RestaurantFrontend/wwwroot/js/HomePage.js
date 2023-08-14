function handleDecrementClick(countElement) {
    const currentCount = parseInt(countElement.textContent);
    if (currentCount > 1) {
        countElement.textContent = currentCount - 1;
    }
    if (currentCount === 2) {
        countElement.previousElementSibling.classList.add('faded');
    }
}

function handleIncrementClick(countElement) {
    const currentCount = parseInt(countElement.textContent);
    countElement.textContent = currentCount + 1;
    if (currentCount === 1) {
        countElement.previousElementSibling.classList.remove('faded');
    }
}

const counterContainers = document.querySelectorAll('.counter-container');
counterContainers.forEach(container => {
    const countElement = container.querySelector('.count');
    const decrementBtn = container.querySelector('.decrementBtn');
    const incrementBtn = container.querySelector('.incrementBtn');

    decrementBtn.addEventListener('click', function () {
        handleDecrementClick(countElement);
    });

    incrementBtn.addEventListener('click', function () {
        handleIncrementClick(countElement);
    });
});




//function updateCount(countElement, count) {
//    countElement.textContent = count;
//}

function isElementInViewport(element) {
    var rect = element.getBoundingClientRect();
    return (
        rect.top >= 0 &&
        rect.left >= 0 &&
        rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
        rect.right <= (window.innerWidth || document.documentElement.clientWidth)
    );
}

function animateRollUpElements() {
    var rollUpElements = document.querySelectorAll('.sku-background');
    rollUpElements.forEach(function (element) {
        if (isElementInViewport(element)) {
            element.classList.add('visible');
        }
    });
}

// Call the function when the page is loaded and when it's scrolled
document.addEventListener('DOMContentLoaded', animateRollUpElements);
document.addEventListener('scroll', animateRollUpElements);
