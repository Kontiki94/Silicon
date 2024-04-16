const deleteButton = document.querySelector('.btn-delete');

deleteButton.addEventListener('click', async () => {
    const response = await fetch(`/Account/SavedCourses`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    });

    if (response.ok) {
        const courseCards = document.querySelectorAll('.course-card');
        courseCards.forEach(element => {
            element.remove();
        });
    } else {
        console.log('No courses removed')
    }
});