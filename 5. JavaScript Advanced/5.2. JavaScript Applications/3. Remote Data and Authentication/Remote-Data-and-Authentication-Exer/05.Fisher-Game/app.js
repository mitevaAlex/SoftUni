onHomeLoad();
document.getElementById('logout').addEventListener('click', onLogout);
document.querySelector('button.load').addEventListener('click', loadCatches);
document.querySelector('#addForm').addEventListener('submit', addCatch);

function onHomeLoad() {
    let catchesDiv = document.querySelector('#catches');
    catchesDiv.style.display = 'none';
    document.querySelector('#main legend').textContent = 'Click to load catches';
    document.querySelector('#main legend').style.fontWeight = 'normal';
    document.querySelector('fieldset').style.border = 'none';
    if (sessionStorage.getItem('email') && sessionStorage.getItem('authToken')) {
        document.querySelector('#guest').style.display = 'none';
        document.querySelector('#user').style.display = 'inline-block';
        document.querySelector('.email span').textContent = sessionStorage.getItem('email');
        document.querySelector('button.add').disabled = false;
    } else {
        document.querySelector('#guest').style.display = 'inline-block';
        document.querySelector('#user').style.display = 'none';
        document.querySelector('.email span').textContent = 'guest';
        document.querySelector('button.add').disabled = true;
    }
}

async function onLogout() {
    let url = 'http://localhost:3030/users/logout';
    let header = getHeader('get', null);
    let responce = await fetch(url, header);

    if (responce.status === 204) {
        sessionStorage.clear();
        onHomeLoad();
        //loadCatches();
    }
}

async function loadCatches() {
    let catchesDiv = document.querySelector('#catches');
    catchesDiv.style.display = 'block';
    catchesDiv.innerHTML = '';
    document.querySelector('#main legend').textContent = 'Catches';
    document.querySelector('#main legend').style.fontWeight = 'bold';
    document.querySelector('fieldset').style.border = '2px solid black';
    await fetch('http://localhost:3030/data/catches')
        .then(async responce => await responce.json())
        .then(data => {
            for (let currentCatch of data) {
                catchesDiv.innerHTML +=
                    `<div class="catch">
                        <label>Angler</label>
                        <input type="text" class="angler" value="${currentCatch.angler}">
                        <label>Weight</label>
                        <input type="text" class="weight" value="${currentCatch.weight}">
                        <label>Species</label>
                        <input type="text" class="species" value="${currentCatch.species}">
                        <label>Location</label>
                        <input type="text" class="location" value="${currentCatch.location}">
                        <label>Bait</label>
                        <input type="text" class="bait" value="${currentCatch.bait}">
                        <label>Capture Time</label>
                        <input type="number" class="captureTime" value="${currentCatch.captureTime}">
                        <button class="update" data_id="${currentCatch._id}">Update</button>
                        <button class="delete" data_id="${currentCatch._id}">Delete</button>
                    </div>`;
                if (currentCatch._ownerId !== sessionStorage.getItem('ownerId')) {
                    Array.from(catchesDiv.lastChild.getElementsByTagName('input')).forEach(x => x.disabled = true);
                    Array.from(catchesDiv.lastChild.getElementsByTagName('button')).forEach(x => x.disabled = true);
                }
            }

            Array.from(catchesDiv.querySelectorAll('button.update'))
                .filter(x => x.disabled === false)
                .forEach(x => x.addEventListener('click', updateCatch));
            Array.from(catchesDiv.querySelectorAll('button.delete'))
                .filter(x => x.disabled === false)
                .forEach(x => x.addEventListener('click', deleteCatch));
        });
}

async function addCatch(event) {
    event.preventDefault();
    let url = 'http://localhost:3030/data/catches';
    let formData = new FormData(event.target);
    let body = Object.fromEntries(formData);
    console.log(body);
    let header = getHeader('post', body);
    await fetch(url, header);
    event.target.reset();
    loadCatches();
}

async function updateCatch(event) {
    let url = `http://localhost:3030/data/catches/${event.target.attributes.data_id.value}`;
    let body = {
        "angler": null,
        "weight": null,
        "species": null,
        "location": null,
        "bait": null,
        "captureTime": null
    }
    let inputData = Array.from(event.target.parentElement.getElementsByTagName('input'));
    for (let input of inputData) {
        body[input.className] = input.value;
    }

    let header = getHeader('put', body);
    await fetch(url, header);
    loadCatches();
}

async function deleteCatch(event){
    let url = `http://localhost:3030/data/catches/${event.target.attributes.data_id.value}`;
    let header = getHeader('delete', null);
    await fetch(url, header);
    loadCatches();
}

function getHeader(method, body) {
    let authToken = sessionStorage.getItem('authToken');
    let header = {
        method: `${method}`,
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': authToken
        }
    };

    if (body) {
        header.body = JSON.stringify(body);
    }

    return header;
}

