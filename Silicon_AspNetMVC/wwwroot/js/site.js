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


// Dark mode
document.addEventListener('DOMContentLoaded', function () {
    let sw = document.querySelector('#switch-mode')

    sw.addEventListener('change', function () {
        let theme = this.checked ? "dark" : "light"

        fetch(`/settings/changetheme?theme=${theme}`)
            .then(res => {
                if (res.ok)
                    window.location.reload()
                else
                    console.log("Not working")
            });
        const switchMode = document.getElementById('switch-mode');
        const switchSlider = document.getElementById('slider');

        switchMode.addEventListener('change', function () {


            if (this.checked) {
                console.log("måne")
                switchSlider.classList.remove('round');
                switchSlider.classList.add('halfmoon');
            } else {
                console.log("rund")
                switchSlider.classList.remove('halfmoon');
                switchSlider.classList.add('round');
            }

            console.log(switchSlider.classList);
        });
    });
});


// Upload profileimage
document.addEventListener('DOMContentLoaded', function () {
    handleProfileImageUpload()
})

function handleProfileImageUpload() {
    try {
        let fileUploader = document.querySelector('#fileUploader')

        if (fileUploader != undefined) {
            fileUploader.addEventListener('change', function () {
                if (this.files.length > 0) {
                    this.form.submit()
                }
            })
        }
    }
    catch { }
}

// Half-moon script for switch
//document.addEventListener('DOMContentLoaded', function () {

//    const switchMode = document.getElementById('switch-mode');
//    const switchSlider = document.getElementById('slider');

//    switchMode.addEventListener('change', function () {


//        if (this.checked) {
//            console.log("måne")
//            switchSlider.classList.remove('round');
//            switchSlider.classList.add('halfmoon');
//        } else {
//            console.log("rund")
//            switchSlider.classList.remove('halfmoon');
//            switchSlider.classList.add('round');
//        }

//        console.log(switchSlider.classList);
//    });
//});

