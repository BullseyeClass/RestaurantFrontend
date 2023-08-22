
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

//$(document).ready(function () {
//    $('.category-details-btn').click(function () {
//        var icon = $(this).find('.icon');
//        $('#collapseWidthCategory').collapse('toggle');
//        icon.text(icon.text() === '-' ? '+' : '-');
//    });
//});

$(document).ready(function () {
    $('.category-details-btn').click(function () {
        var icon = $(this).find('.icon');
        var collapse = $(this).next('.collapse');
        $('.collapse.show').not(collapse).collapse('hide');
        collapse.collapse('toggle');
        $('.category-details-btn .icon').text('+');
        if (collapse.hasClass('show')) {
            icon.text('-');
        }
    });
});





