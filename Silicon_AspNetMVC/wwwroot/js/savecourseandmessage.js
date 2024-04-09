async function saveCourse(event, courseId) {
    event.preventDefault();
    event.stopPropagation();

    console.log("Course Id:", courseId);

    var data = { savedCourseId: courseId };

    try {
        var response = await fetch(`/Courses/Index?savedCourseId=${courseId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (response.ok) {
            var result = await response.json();
            if (result.succeeded) {
                console.log("Course saved successfully");
                showMessage("Course added", "alert-success");
            }
            else if (result.exists) {
                console.log("Course already saved");
                showMessage("You already have this course in your library", "alert-info");
            }
            else {
                console.log("GÅR INTE!!!");
                showMessage("Internal error:: Couldnt add course", "alert-danger");
            }
        }

        setTimeout(function () {
            removeMessage();
        }, 3000);

        var messageContainer = document.getElementById('statusMessage');
        messageContainer.style.position = 'absolute';
        messageContainer.style.top = '60px';
        messageContainer.style.left = '240px';

    } catch (error) {
        console.error("BAJSKORV:", error);
    }
}

function showMessage(message, className) {
    var element = document.getElementById('statusMessage');
    element.innerText = message;
    element.className = "alert " + className;
}

function removeMessage() {
    var element = document.getElementById('statusMessage');
    element.innerText = "";
    element.className = "";
}

var bookmarkLink = document.querySelectorAll('.bookmark');

bookmarkLink.forEach(function (link) {
    link.addEventListener('click', async function (event) {
        var courseId = this.getAttribute('data-course-id');
        saveCourse(event, courseId);
    });
});