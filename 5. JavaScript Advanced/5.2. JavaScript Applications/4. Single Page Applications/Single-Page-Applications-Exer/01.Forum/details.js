let section = document.getElementById('detailsView');
let form = document.querySelector('#detailsView form');
form.addEventListener('submit', onSubmit);
let main = document.querySelector('main');
section.remove();

let topicId;
let topicDiv = section.querySelector('.theme-content');

export async function showDetails(event) {
    topicId = event.target.parentElement.id;
    let topicUrl = `http://localhost:3030/jsonstore/collections/myboard/posts/${topicId}`;
    topicDiv.innerHTML = `
        <div class="theme-title">
            <div class="theme-name-wrapper">
                <div class="theme-name">
                    <h2>${event.target.textContent}</h2>
                </div>
            </div>
        </div>`;
    let post = await fetch(topicUrl)
        .then(async responce => await responce.json());
    topicDiv.innerHTML += `
        <div class="comment">
            <div class="header">
                <img src="./static/profile.png" alt="avatar">
                <p><span>${post.username}</span> posted on <time>${post.date}</time></p>
                <p class="post-content">${post.postText}</p>
            </div>
            <section id="userComments"></section>
        </div>`;
    form.querySelector('button').id = topicId;

    await showComments();

    main.replaceChildren(section);
}

async function showComments() {
    let commentsUrl = 'http://localhost:3030/jsonstore/collections/myboard/comments';
    let comments = await fetch(commentsUrl)
        .then(async responce => Object.values(await responce.json()))
        .then(data => data.filter(x => x.topicId === topicId));
    let commentsSection = topicDiv.querySelector('#userComments');
    commentsSection.innerHTML = '';
    for (let comment of comments) {
        commentsSection.innerHTML += `
        <div class="user-comment">
            <div class="topic-name-wrapper">
                <div class="topic-name">
                    <p><strong>${comment.username}</strong> commented on <time>${comment.date}</time></p>
                    <div class="post-content">
                    <p>${comment.postText}</p>
                    </div>
                </div>
            </div>
        </div>`;
    }
}

async function onSubmit(event) {
    event.preventDefault();
    let url = 'http://localhost:3030/jsonstore/collections/myboard/comments';
    let formData = new FormData(form);
    let { postText, username } = Object.fromEntries(formData);
    if (postText && username) {
        let header = getHeader('post', { postText, username, date: new Date(), topicId: event.submitter.id });
        await fetch(url, header);
        showComments();
    }

    event.target.reset();
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