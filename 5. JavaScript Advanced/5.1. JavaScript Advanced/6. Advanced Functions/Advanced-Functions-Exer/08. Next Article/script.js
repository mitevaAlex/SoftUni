function getArticleGenerator(articles) {
    let articlesCopy = [...articles];
    return function () {
        if (articlesCopy.length > 0) {
            let content = document.getElementById('content');
            let article = document.createElement('article');
            article.textContent = articlesCopy.shift();
            content.appendChild(article);
        }
    }
}
