import { showDetails } from './details.js';

let section = document.getElementById('homeView');
let form = document.querySelector('#homeView form');
form.addEventListener('submit', onSubmit);
let main = document.querySelector('main');
section.remove();
let url = 'http://localhost:3030/jsonstore/collections/myboard/posts';

export async function showHome() {
    let posts = await loadPosts();
    let topicsDiv = section.querySelector('.topic-title');
    topicsDiv.innerHTML = '';
    for(let post of posts){
        topicsDiv.innerHTML += `
            <div class="topic-container">
                <div class="topic-name-wrapper">
                    <div class="topic-name">
                        <a id="${post._id}" href="#" class="normal">
                            <h2>${post.topicName}</h2>
                         </a>
                        <div class="columns">
                            <div>
                                <p>Date: <time>${post.date}</time></p>
                                <div class="nick-name">
                                    <p>Username: <span>${post.username}</span></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>`;
    }

    Array.from(topicsDiv.querySelectorAll('a')).forEach(x => x.addEventListener('click', showDetails));
    main.replaceChildren(section);
}

async function onSubmit(event) {
    event.preventDefault();
    let formData = new FormData(form);
    if (event.submitter.className === 'public') {
        let { topicName, username, postText } = Object.fromEntries(formData);
        if(topicName && username && postText){
            let header = getHeader('post', { topicName, username, postText, date: new Date() });
            await fetch(url, header);
            showHome();
        }
    }

    event.target.reset();
}

async function loadPosts() {
    let responce = await fetch(url);
    let data = await responce.json();
    return Object.values(data); 
}

function getHeader(method, body) {
    let header = {
        method: `${method}`,
        headers: {
            'Content-Type': 'application/json',
        }
    };

    if (body) {
        header.body = JSON.stringify(body);
    }

    return header;
}