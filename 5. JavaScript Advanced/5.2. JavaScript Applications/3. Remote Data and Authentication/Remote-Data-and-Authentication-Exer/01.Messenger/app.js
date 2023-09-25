function attachEvents() {
    document.getElementById('submit').addEventListener('click', submit);
    document.getElementById('refresh').addEventListener('click', refresh);
}

async function submit() {
    let author = document.getElementsByName('author')[0].value;
    let content = document.getElementsByName('content')[0].value;
    let message = { author, content };
    await fetch('http://localhost:3030/jsonstore/messenger', {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(message),
    });
}

async function refresh() {
    let messagesArea = document.getElementById('messages');
    await fetch('http://localhost:3030/jsonstore/messenger')
        .then(async responce => await responce.json())
        .then(data => {
            messagesArea.textContent = Object.values(data)
                .map(x => `${x.author}: ${x.content}`)
                .join('\n');
        });
}

attachEvents();