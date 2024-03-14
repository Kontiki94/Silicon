function hideuserMessage() {
    var messageSpan = document.getElementById("userMessage");
    if (messageSpan) {
        messageSpan.style.display = "none";
    }
}

function showuserMessage() {
    var messageSpan = document.getElementById("userMessage");
    messageSpan.style.display = "block";

    setTimeout(function () {
        hideuserMessage();
    }, 3000);
}

showuserMessage();
