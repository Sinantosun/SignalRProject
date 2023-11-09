const navLinks = document.querySelectorAll('.nav-item');

navLinks.forEach(navlinkEl => {
    navlinkEl.addEventListener('click', () => {
        document.querySelector('.active')?.classList.remove('active');
        navlinkEl.classList.add('active');
    });
});