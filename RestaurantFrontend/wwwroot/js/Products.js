
function toggleDropdown(buttonId, menuId, iconId) {
    const button = document.getElementById(buttonId);
    const menu = document.getElementById(menuId);
    const icon = document.getElementById(iconId);

    button.addEventListener('click', () => {
        if (menu.style.display === 'none') {
            menu.style.display = 'block';
            icon.textContent = '-';
        } else {
            menu.style.display = 'none';
            icon.textContent = '+';
        }
    });
}

toggleDropdown('dropdownButton1', 'dropdownMenu1', 'dropdownIcon1');
toggleDropdown('dropdownButton2', 'dropdownMenu2', 'dropdownIcon2');


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

function toggleDiv() {
    const targetDiv = document.getElementById("targetDiv");
    const signDiv = document.getElementById("signDiv");
    product = "rice";

    if (targetDiv.classList.contains("hidden")) {
        targetDiv.classList.remove("hidden");
        signDiv.innerHTML = "+";
    } else {
        targetDiv.classList.add("hidden");
        signDiv.innerHTML = "-";
    }
}
const toggleButton = document.getElementById("toggleButton");
toggleButton.addEventListener("click", toggleDiv);




//function updateCount(countElement, count) {
//    countElement.textContent = count;
//}

//function handleDecrementClick(countElement) {
//    const currentCount = parseInt(countElement.textContent);
//    if (currentCount > 1) {
//        countElement.textContent = currentCount - 1;
//    }
//}

//function handleIncrementClick(countElement) {
//    const currentCount = parseInt(countElement.textContent);
//    countElement.textContent = currentCount + 1;
//}

//const counterContainers = document.querySelectorAll('.counter-container');
//counterContainers.forEach(container => {
//    const countElement = container.querySelector('.count');
//    const decrementBtn = container.querySelector('.decrementBtn');
//    const incrementBtn = container.querySelector('.incrementBtn');

//    decrementBtn.addEventListener('click', function () {
//        handleDecrementClick(countElement);
//    });

//    incrementBtn.addEventListener('click', function () {
//        handleIncrementClick(countElement);
//    });
//});



