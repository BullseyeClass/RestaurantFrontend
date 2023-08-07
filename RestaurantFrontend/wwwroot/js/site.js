const slideUpElements = document.querySelectorAll('.slide-up-text');

setInterval(() => {
    slideUpElements.forEach(element => {
        element.classList.toggle('hidden');
    });
}, 5000);






document.addEventListener("DOMContentLoaded", function () {
    const showListBtn = document.getElementById("search");
    const hiddenList = document.querySelector(".trending-content");

    showListBtn.addEventListener("click", function () {
        if (hiddenList.style.display === "none") {
            hiddenList.style.display = "block";
            slideDown(hiddenList);
        } else {
            hiddenList.style.display = "none";
        }
    });

    document.addEventListener("click", function (event) {
        if (!hiddenList.contains(event.target) && event.target !== showListBtn) {
            hiddenList.style.display = "none";
        }
    });

    function slideDown(element) {
        let height = 0;
        const maxHeight = element.scrollHeight;

        const slideAnimation = setInterval(function () {
            height += 5;
            if (height <= maxHeight) {
                element.style.height = height + "px";
            } else {
                clearInterval(slideAnimation);
                element.style.overflow = "visible";
            }
        }, 10);
    }
});

