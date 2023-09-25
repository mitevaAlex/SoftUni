function addItem() {
    let input = document.getElementById('newItemText');
    let newItem = document.createElement('li');
    newItem.textContent = input.value;
    input.value = '';
    let deleteLink = document.createElement('a');
    deleteLink.textContent = '[Delete]';
    deleteLink.href = '#';
    deleteLink.addEventListener('click', function() {
        deleteLink.parentElement.remove();
    });
    newItem.appendChild(deleteLink);
    document.getElementById('items').appendChild(newItem);
}