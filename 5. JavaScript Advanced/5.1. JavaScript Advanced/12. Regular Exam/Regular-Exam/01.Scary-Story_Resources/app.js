window.addEventListener("load", solve);

function solve() {
    let firstName = document.getElementById('first-name');
    let lastName = document.getElementById('last-name');
    let age = document.getElementById('age');
    let genre = document.getElementById('genre');
    let storyTitle = document.getElementById('story-title');
    let storyText = document.getElementById('story');

    let previewList = document.getElementById('preview-list');

    let publishBtn = document.getElementById('form-btn');
    publishBtn.addEventListener('click', publish);

    function publish(event) {
        event.preventDefault();
        if (firstName.value && lastName.value && age.value && storyTitle.value && storyText.value) {
            previewList.innerHTML +=
                `<li class="story-info">
                    <article>
                        <h4>Name: ${firstName.value} ${lastName.value}</h4>
                        <p>Age: ${age.value}</p>
                        <p>Title: ${storyTitle.value}</p>
                        <p>Genre: ${genre.value}</p>
                        <p>${storyText.value}</p>
                    </article>
                    <button class="save-btn">Save Story</button>
                    <button class="edit-btn">Edit Story</button>
                    <button class="delete-btn">Delete Story</button>
                </li>`;
            let saveBtn = previewList.lastChild.querySelector('.save-btn');
            saveBtn.addEventListener('click', save);
            let editBtn = previewList.lastChild.querySelector('.edit-btn');
            editBtn.addEventListener('click', edit);
            let deleteBtn = previewList.lastChild.querySelector('.delete-btn');
            deleteBtn.addEventListener('click', deleteStory);

            firstName.value = '';
            lastName.value = '';
            age.value = '';
            genre.value = 'Disturbing';
            storyTitle.value = '';
            storyText.value = '';
            publishBtn.disabled = true;
        }
    }

    function save(event) {
        let main = document.getElementById('main');
        main.innerHTML = '<h1>Your scary story is saved!</h1>';
    }

    function edit(event) {
        let listItem = event.target.parentElement;
        let listItemArticle = listItem.querySelector('article');
        let names = listItemArticle.querySelector('h4').textContent.replace('Name: ', '').split(' ');
        let paragraphs = listItemArticle.getElementsByTagName('p');
        firstName.value = names[0];
        lastName.value = names[1];
        age.value = paragraphs[0].textContent.replace('Age: ', '');
        storyTitle.value = paragraphs[1].textContent.replace('Title: ', '');
        genre.value = paragraphs[2].textContent.replace('Genre: ', '');
        storyText.value = paragraphs[3].textContent;
        publishBtn.disabled = false;
        previewList.removeChild(listItem);
    }

    function deleteStory(event) {
        let listItem = event.target.parentElement;
        previewList.removeChild(listItem);
        publishBtn.disabled = false;
    }
}
