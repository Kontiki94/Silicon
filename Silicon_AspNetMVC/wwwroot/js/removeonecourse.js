bookMarks = document.querySelectorAll('.bookmark')

bookMarks.forEach(function (link) {
    link.addEventListener('click', async function(event) {
        event.preventDefault();

        var courseId = this.getAttribute('data-course-id');
        var data = { removeId: courseId }

        try {
            var response = await fetch(`/Account/SavedCourses`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
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
