solution();

async function solution() {
    function eFactory(tag, className = '', content = '') {
        const e = document.createElement(tag);
        e.className = className;
        e.textContent = content;

        return e;
    }

    async function template({ _id, title }) {
        const wrapper = eFactory('div', 'accordion');
        const headDiv = eFactory('div', 'head');
        const titleSpan = eFactory('span', '', title);
        const btn = eFactory('button', 'button', 'More');
        const extraDiv = eFactory('div', 'extra');
        extraDiv.style.display = 'none';
        let content = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${_id}`)
            .then(async responce => await responce.json())
            .then(data => data.content);
        const contentParagraph = eFactory('p', '', content);
        btn.id = _id;
        btn.addEventListener('click', btnClicked);

        headDiv.append(titleSpan, btn);
        extraDiv.appendChild(contentParagraph);
        wrapper.append(headDiv, extraDiv);

        return wrapper;
    }

    let main = document.getElementById('main');
    await fetch('http://localhost:3030/jsonstore/advanced/articles/list')
        .then(async responce => await responce.json())
        .then(data => {
            data.forEach(async x => {
                let article = await template(x);
                main.appendChild(article);
            });
        });

    async function btnClicked(event) {
        let button = event.target;
        let articleElement = event.target.parentElement.parentElement;
        if (button.textContent === 'More') {
            button.textContent = 'Less';
            articleElement.querySelector('.extra').style.display = 'inline-block';
        } else if (button.textContent === 'Less') {
            button.textContent = 'More';
            articleElement.querySelector('.extra').style.display = 'none';
        }
    }
}