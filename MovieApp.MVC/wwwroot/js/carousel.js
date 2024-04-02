const carousel = document.querySelector('.carousel-inner');
const carouselItems = document.querySelectorAll('.carousel-item');

let currentIndex = 0;
const totalItems = carouselItems.length;
const itemWidth = carouselItems[0].offsetWidth;

function moveCarousel() {
    const newPosition = -currentIndex * itemWidth;
    carousel.style.transform = `translateX(${newPosition}px)`;
}

function nextSlide() {
    currentIndex = (currentIndex + 1) % totalItems;
    moveCarousel();
}

function prevSlide() {
    currentIndex = (currentIndex - 1 + totalItems) % totalItems;
    moveCarousel();
}

// Otomatik kaydýrma için setInterval() kullanabilirsiniz.
// setInterval(nextSlide, 3000); // Her 3 saniyede bir sonraki slayda geçiþ yapar.

// Bu örnekte, klavye ok tuþlarýný kullanarak kaydýrmayý etkinleþtirelim.
document.addEventListener('keydown', function (event) {
    if (event.key === 'ArrowLeft') {
        prevSlide();
    } else if (event.key === 'ArrowRight') {
        nextSlide();
    }
});