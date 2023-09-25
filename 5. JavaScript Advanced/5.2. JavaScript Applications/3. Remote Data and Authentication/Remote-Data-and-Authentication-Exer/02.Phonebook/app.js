function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', loadContacts);
    document.getElementById('btnCreate').addEventListener('click', createContact);
}

async function loadContacts() {
    let phonebook = document.getElementById('phonebook');
    phonebook.innerHTML = '';
    await fetch('http://localhost:3030/jsonstore/phonebook')
        .then(async responce => await responce.json())
        .then(data => {
            let contactsFragment = document.createDocumentFragment();
            Object.values(data).forEach(x => {
                let contact = document.createElement('li');
                contact.textContent = `${x.person}: ${x.phone}`;
                let deleteBtn = document.createElement('button');
                deleteBtn.textContent = 'Delete';
                deleteBtn.id = x._id;
                deleteBtn.addEventListener('click', deleteContact);
                contact.appendChild(deleteBtn);
                contactsFragment.appendChild(contact);
            });

            phonebook.appendChild(contactsFragment);
        });
}

async function deleteContact(event) {
    await fetch(`http://localhost:3030/jsonstore/phonebook/${event.target.id}`, {
        method: 'delete'
    });
    loadContacts();
}

async function createContact() {
    let person = document.getElementById('person');
    let phone = document.getElementById('phone');
    let contact = { person: person.value, phone: phone.value };
    await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(contact),
    });
    person.value = '';
    phone.value = '';
    loadContacts();
}

attachEvents();