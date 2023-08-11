
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


function toggleDiv(targetId, iconId) {
    const targetDiv = document.getElementById(targetId);
    const iconDiv = document.getElementById(iconId);

    if (targetDiv.classList.contains('show')) {
        targetDiv.classList.remove('show');
        targetDiv.classList.add('hidden');
        iconDiv.textContent = '+';
    } else {
        targetDiv.classList.remove('hidden');
        targetDiv.classList.add('show');
        iconDiv.textContent = '-';
    }
}



