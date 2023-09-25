document.getElementById('loadBooks').addEventListener('click', loadBooks);
document.querySelector('form').addEventListener('submit', createOrUpdateBook);
window.onload = loadBooks();

async function loadBooks() {
    let tableBody = document.getElementsByTagName('tbody')[0];
    tableBody.innerHTML = '';
    await fetch('http://localhost:3030/jsonstore/collections/books')
        .then(async responce => await responce.json())
        .then(data => {
            for (let id in data) {
                let row = document.createElement('tr');
                row.appendChild(createElement('td', data[id].title));
                row.appendChild(createElement('td', data[id].author));
                let buttons = document.createElement('td');
                buttons.id = id;
                buttons.appendChild(createElement('button', 'Edit'));
                buttons.appendChild(createElement('button', 'Delete'));
                row.appendChild(buttons);
                tableBody.appendChild(row);
            }

            Array.from(document.getElementsByTagName('button'))
                .filter(x => x.textContent === 'Edit')
                .forEach(x => x.addEventListener('click', editBook));
            Array.from(document.getElementsByTagName('button'))
                .filter(x => x.textContent === 'Delete')
                .forEach(x => x.addEventListener('click', deleteBook));
        });
}

function createElement(tag, textContent) {
    let element = document.createElement(tag);
    element.textContent = textContent;
    return element;
}

async function createOrUpdateBook(event) {
    event.preventDefault();
    let bookData = new FormData(event.target);
    if(!bookData.get('author') || !bookData.get('title')){
        return;
    }
    
    book = {
        author: bookData.get('author'),
        title: bookData.get('title')
    };
    let button = event.target.querySelector('button');
    if (button.textContent === 'Submit') {
        await fetch('http://localhost:3030/jsonstore/collections/books', {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(book),
        });
    } else if (button.textContent === 'Save') {
        await fetch(`http://localhost:3030/jsonstore/collections/books/${event.target.id}`, {
            method: 'put',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(book),
        });

        event.target.id = null;
        button.textContent = 'Submit';
        event.target.querySelector('h3').textContent = 'FORM';
    }

    event.target.reset();
    loadBooks();
}

function editBook(event) {
    let tableRow = event.target.parentElement.parentElement;
    document.querySelector('form input[name="title"]').value = tableRow.children[0].textContent;
    document.querySelector('form input[name="author"]').value = tableRow.children[1].textContent;
    document.querySelector('form h3').textContent = 'Edit FORM';
    document.querySelector('form button').textContent = 'Save';
    document.querySelector('form').id = event.target.parentElement.id;
}

async function deleteBook(event){
    await fetch(`http://localhost:3030/jsonstore/collections/books/${event.target.parentElement.id}`, {
            method: 'delete'
        });

    loadBooks();
}