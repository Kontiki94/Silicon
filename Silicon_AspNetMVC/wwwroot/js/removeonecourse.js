async function removeOneCourse(event, courseId) {

    event.preventDefault();
    event.stopPropagation();

    event.target.closest('.course-card').remove();

    document.querySelectorAll('.bookmark').forEach(function (link) {
        link.addEventListener('click', async function (event) {
            var courseId = this.dataset.courseId;
            console.log(courseId)
            await removeOneCourse(event, courseId);
        });
    });

    try {
        var response = await fetch(`/Account/SavedCourses?removeId=${courseId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
        });

        if (!response.ok) {
            console.log("Hittar inte kurser")
        }
    } catch (error) {
        console.log('Nu blev det fel, ajabaja')
    }
};





