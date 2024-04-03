// Categories

document.addEventListener('DOMContentLoaded', function () {
    select()
    searchQuery()
})
function select() {
    try {
        let select = document.querySelector('.select')
        let selected = select.querySelector('.selected')
        let selectOptions = select.querySelector('.select-options')

        selected.addEventListener('click', function () {
            selectOptions.style.display = (selectOptions.style.display === 'block') ? 'none' : 'block'
        })

        let options = selectOptions.querySelectorAll('.option')
        options.forEach(function (option) {
            option.addEventListener('click', function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                let category = this.getAttribute('data-value')
                selected.setAttribute('data-value', category)
                updateCoursesByFilter()
            })
        })
    }
    catch { }
}

function searchQuery() {
    try {
        document.querySelector('#searchQuery').addEventListener('keyup', function () {

            updateCoursesByFilter()
        })
    }
    catch { }
}

function updateCoursesByFilter() {
    const category = document.querySelector('.select .selected').getAttribute('data-value') || 'all'
    const query = document.querySelector('#searchQuery').value
    const url = `/courses/index?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(query)}`

    fetch(url)
        .then(res => res.text())
        .then(data => {
            const parser = new DOMParser()
            const dom = parser.parseFromString(data, 'text/html')
            const itemsContainer = document.querySelector('.items')

            if (itemsContainer) {
                itemsContainer.innerHTML = dom.querySelector('.items').innerHTML
            } else {
                console.error('.items element not found')
            }
        })
}
