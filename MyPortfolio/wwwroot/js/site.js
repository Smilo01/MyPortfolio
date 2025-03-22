// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//document.addEventListener('mousemove', (e) => {
//    const scene = document.querySelector('.scene3d');
//    const xAxis = (window.innerWidth / 2 - e.pageX) / 50;
//    const yAxis = (window.innerHeight / 2 - e.pageY) / 50;

//    scene.style.transform = `rotateX(${yAxis}deg) rotateY(${xAxis}deg)`;
//});
// Create mouse light element
const mouseLight = document.createElement('div');
mouseLight.className = 'mouse-light';
document.body.appendChild(mouseLight);

// Track mouse movement
document.addEventListener('mousemove', (e) => {
    // Update light position
    mouseLight.style.left = e.clientX + 'px';
    mouseLight.style.top = e.clientY + 'px';

    // Check proximity to desk items
    const deskItems = document.querySelectorAll('.desk-item');
    deskItems.forEach(item => {
        const rect = item.getBoundingClientRect();
        const centerX = rect.left + rect.width / 2;
        const centerY = rect.top + rect.height / 2;

        // Calculate distance from mouse to item center
        const distance = Math.hypot(e.clientX - centerX, e.clientY - centerY);

        // Light up items within proximity
        if (distance < 200) {
            item.dataset.lit = 'true';
            // Calculate intensity based on distance
            const intensity = 1 - (distance / 200);
            item.style.filter = `brightness(${0.3 + (intensity * 0.7)})`;
        } else {
            item.dataset.lit = 'false';
            item.style.filter = 'brightness(0.3)';
        }
    });
});

// Add smooth transition when mouse leaves the window
document.addEventListener('mouseleave', () => {
    const deskItems = document.querySelectorAll('.desk-item');
    deskItems.forEach(item => {
        item.dataset.lit = 'false';
        item.style.filter = 'brightness(0.3)';
    });
});