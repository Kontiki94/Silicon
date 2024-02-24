const toggleMenu = () => {
    document.getElementById('menu').classList.toggle('hide');
    document.getElementById('account-buttons').classList.toggle('hide');

    const barsIcon = document.getElementById('barsIcon');
    const crossIcon = document.getElementById('crossIcon');
    barsIcon.classList.toggle('hide');
    crossIcon.classList.toggle('hide');

    document.body.classList.toggle('no-scroll');
}

const checkScreenSize = () => {
    const menu = document.getElementById('menu');
    const accountButtons = document.getElementById('account-buttons');
    const barsIcon = document.getElementById('barsIcon');

    if (window.innerWidth >= 1200) {
        menu.classList.remove('hide');
        accountButtons.classList.remove('hide');

        menu.classList.add('hide');
        accountButtons.classList.add('hide');

        barsIcon.classList.remove('hide');
        
    } else {
        if (!menu.classList.contains('hide')) {
            menu.classList.add('hide');

            barsIcon.classList.toggle('hide');
            crossIcon.classList.toggle('hide');
        }
        if (accountButtons.classList.contains('hide')) {
            document.getElementById('account-buttons').classList.add('hide');
        }
    }
};

window.addEventListener('resize', checkScreenSize);

const menuLinks = document.querySelectorAll('.menu-link');
menuLinks.forEach(link => {
    if (link.classList.contains('asp-fragment')) {
        link.addEventListener('click', () => {
            if (window.innerWidth < 992) {
                toggleMenu();
            }
        });
    }
});

checkScreenSize();


