document.addEventListener('DOMContentLoaded', function () {

    var lottieContainer = document.getElementById('lottieAnimation');

    bodymovin.loadAnimation({
        container: lottieContainer,
        renderer: 'svg',
        loop: false,
        path: '/lottie/arrow.json',
    });
})