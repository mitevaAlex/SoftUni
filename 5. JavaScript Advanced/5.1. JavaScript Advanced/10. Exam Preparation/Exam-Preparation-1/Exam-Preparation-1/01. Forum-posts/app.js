window.addEventListener("load", solve);

function solve() {
    let publishBtn = document.getElementById('publish-btn');
    publishBtn.addEventListener('click', publish);

    let title = document.getElementById('post-title');
    let category = document.getElementById('post-category');
    let content = document.getElementById('post-content');
    let reviewList = document.getElementById('review-list');
    let publishedList = document.getElementById('published-list');
    let clearBtn = document.getElementById('clear-btn');
    clearBtn.addEventListener('click', clear);

    function publish(event) {
        //event.preventDefault();

        if (title.value && category.value && content.value) {
            reviewList.innerHTML +=
                `<li class="rpost">
                    <article>
                        <h4>${title.value}</h4>
                        <p>Category: ${category.value}</p>
                        <p>Content: ${content.value}</p>
                    </article>
                    <button class="action-btn edit">Edit</button>
                    <button class="action-btn approve">Approve</button>
                </li>`;
            title.value = '';
            category.value = '';
            content.value = '';

            let editBtn = reviewList.lastChild.getElementsByClassName('action-btn edit')[0];
            editBtn.addEventListener('click', edit);
            let approveBtn = reviewList.lastChild.getElementsByClassName('action-btn approve')[0];
            approveBtn.addEventListener('click', approve);
        }
    }

    function edit(event) {
        let article = event.target.parentElement.getElementsByTagName('article')[0];
        title.value = article.children[0].textContent;
        category.value = article.children[1].textContent.replace('Category: ', '');
        content.value = article.children[2].textContent.replace('Content: ', '');
        reviewList.removeChild(article.parentElement);
    }

    function approve(event){
        let articleListItem = event.target.parentElement;
        let editBtn = articleListItem.getElementsByClassName('action-btn edit')[0];
        let approveBtn = articleListItem.getElementsByClassName('action-btn approve')[0];
        articleListItem.removeChild(editBtn);
        articleListItem.removeChild(approveBtn);
        reviewList.removeChild(articleListItem);
        publishedList.appendChild(articleListItem);
    }

    function clear(event){
        publishedList.innerHTML = '';
    }
}
