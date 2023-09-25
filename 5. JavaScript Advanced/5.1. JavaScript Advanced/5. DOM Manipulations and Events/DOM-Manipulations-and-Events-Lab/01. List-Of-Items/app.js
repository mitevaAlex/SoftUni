 function addItem() {
    let input = document.getElementById('newItemText');
    let newItem = document.createElement('li');
    newItem.textContent = input.value;
    input.value = '';
    document.getElementById('items').appendChild(newItem);
}