document.addEventListener('DOMContentLoaded', function () {

    var lottieContainer = document.getElementById('lottieAnimation');
    console.log("pung")

    bodymovin.loadAnimation({
        container: lottieContainer,
        renderer: 'svg',
        loop: false,
        path: '/lottie/arrow.json',
        animationSpeed: 0.1
    });
})