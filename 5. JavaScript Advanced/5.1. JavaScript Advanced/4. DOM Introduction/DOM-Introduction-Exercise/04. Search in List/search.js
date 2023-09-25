function search() {
    let townElements = document.getElementById('towns').children;
    let searchItem = document.getElementById('searchText').value;
    let matchesMade = 0;
    for(let i = 0; i < townElements.length; i++) {
        if (townElements[i].textContent.includes(searchItem)) {
            townElements[i].style.fontWeight = 'bold';
            townElements[i].style.textDecoration = 'underline';
            matchesMade++;
        } else {
            townElements[i].style.fontWeight = 'none';
            townElements[i].style.textDecoration = 'none';
        }
    }

    document.getElementById('result').textContent = `${matchesMade} matches found`;
}
