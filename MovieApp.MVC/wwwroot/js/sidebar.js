// Navbar öðelerini seçin
const navbarItems = document.querySelectorAll('.nav-link');

// Her bir navbar öðesi için click olayýný dinleyin
navbarItems.forEach(item => {
    item.addEventListener('click', () => {
        // Tüm navbar öðelerinden "active" sýnýfýný kaldýrýn
        navbarItems.forEach(item => {
            item.classList.remove('active');
        });

        // Týklanan navbar öðesine "active" sýnýfýný ekleyin
        item.classList.add('active');
    });
});


const body = document.querySelector("body"),
    sidebar = body.querySelector("nav"),
    toggle = body.querySelector(".toggle"),
    searchBtn = body.querySelector(".search-box"),
    modeSwitch = body.querySelector(".toggle-switch"),
    modeText = body.querySelector(".mode-text");
toggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
});
searchBtn.addEventListener("click", () => {
    sidebar.classList.remove("close");
});
modeSwitch.addEventListener("click", () => {
    body.classList.toggle("dark");
    if (body.classList.contains("dark")) {
        modeText.innerText = "Gündüz";
    } else {
        modeText.innerText = "Gece";
    }
});