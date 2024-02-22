const toggleMenu = () => {
    console.log("Toggle menu function executed");
    document.getElementById('menu').classList.toggle('hide');
    document.getElementById('account-buttons').classList.toggle('hide');

    const barsIcon = document.getElementById('barsIcon');
    const crossIcon = document.getElementById('crossIcon');
    barsIcon.classList.toggle('hide');
    crossIcon.classList.toggle('hide');

    document.body.classList.toggle('no-scroll');
}

const checkScreenSize = () => {
    if (window.innerWidth >= 1200) {
        document.getElementById('menu').classList.remove('hide');
        document.getElementById('account-buttons').classList.remove('hide');
        menu.classList.add('hide');
        accountButtons.classList.add('hide');
        barsIcon.classList.remove('hide');
        barsIcon.classList.toggle('hide');
        crossIcon.classList.toggle('hide');
    } else {
        if (!document.getElementById('menu').classList.contains('hide')) {
            document.getElementById('menu').classList.add('hide');
            barsIcon.classList.toggle('hide');
            crossIcon.classList.toggle('hide');

        }
        if (!document.getElementById('account-buttons').classList.contains('hide')) {
            document.getElementById('account-buttons').classList.add('hide');
        }
    }
};

window.addEventListener('resize', checkScreenSize);

const menuLinks = document.querySelectorAll('#menu .menu-link');
menuLinks.forEach(link => {
    link.addEventListener('click', () => toggleMenu());
});

checkScreenSize();


