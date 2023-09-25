function toggle() {
    let button = document.getElementsByClassName('button')[0];
    if(button.textContent == 'More') {
        document.getElementById('extra').style.display = 'block';
        button.textContent = 'Less';

    } else if (button.textContent == 'Less') {
        document.getElementById('extra').style.display = 'none';
        button.textContent = 'More';
    }
}