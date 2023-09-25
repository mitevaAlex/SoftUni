function attachEvents() {
    document.getElementById('btnLoadPosts').addEventListener('click', loadPosts);
    document.getElementById('btnViewPost').addEventListener('click', viewPost);
}

async function loadPosts() {
    const postsElement = document.getElementById('posts');
    postsElement.innerHTML = '';
    const responce = await fetch('http://localhost:3030/jsonstore/blog/posts');
    const data = await responce.json();
    Object.values(data).forEach(x => {
        const option = document.createElement('option');
        option.value = x.id;
        option.textContent = x.title.toUpperCase();
        postsElement.appendChild(option);
    });
}

async function viewPost() {
    const postsElement = document.getElementById('posts');
    const commentsList = document.getElementById('post-comments');
    commentsList.innerHTML = '';

    const postResponce = await fetch(`http://localhost:3030/jsonstore/blog/posts/${postsElement.value}`)
    const post = await postResponce.json();
    
    const commentsResponce = await fetch('http://localhost:3030/jsonstore/blog/comments');
    const comments = await commentsResponce.json();
    const commentsElements = document.createDocumentFragment();
    Object.values(comments).filter(x => x.postId === post.id).forEach(x => {
        const commentElement = document.createElement('li');
        commentElement.id = x.id;
        commentElement.textContent = x.text;
        commentsElements.appendChild(commentElement);
    });

    document.getElementById('post-title').textContent = post.title.toUpperCase();
    document.getElementById('post-body').textContent = post.body;
    commentsList.appendChild(commentsElements);
}

attachEvents();