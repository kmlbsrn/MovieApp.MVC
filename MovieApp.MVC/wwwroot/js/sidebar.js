// Navbar ��elerini se�in
const navbarItems = document.querySelectorAll('.nav-link');

// Her bir navbar ��esi i�in click olay�n� dinleyin
navbarItems.forEach(item => {
    item.addEventListener('click', () => {
        // T�m navbar ��elerinden "active" s�n�f�n� kald�r�n
        navbarItems.forEach(item => {
            item.classList.remove('active');
        });

        // T�klanan navbar ��esine "active" s�n�f�n� ekleyin
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
        modeText.innerText = "G�nd�z";
    } else {
        modeText.innerText = "Gece";
    }
});