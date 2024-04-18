async function removeOneCourse(event, courseId) {

    bookMarks = document.querySelectorAll('.bookmark')
    bookMarks.forEach(function (link) {
        link.addEventListener('click', async function (event) {
            event.preventDefault();
            event.stopPropagation();

            console.log(courseId)
            var data = { removeId: courseId }
            try {
                var response = await fetch(`/Account/SavedCourses ? removeId = ${ courseId }`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                });

                if (response.ok) {
                    this.closest('.course-card').remove();
                } else {
                    console.log('Hittar inga kurser')
                }
            } catch (error) {
                console.log('Nu blev det fel, ajabaja')
            }
        });
    });
}
