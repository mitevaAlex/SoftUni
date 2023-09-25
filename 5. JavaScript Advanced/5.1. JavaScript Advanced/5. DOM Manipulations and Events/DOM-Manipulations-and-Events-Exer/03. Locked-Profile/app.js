function lockedProfile() {
    let buttons = Array.from(document.getElementsByTagName('button'));
    buttons.forEach(x => x.addEventListener('click', showOrHide));

    function showOrHide(event) {
        let profileElement = event.target.parentElement;
        let unlockedRadio = Array.from(profileElement.getElementsByTagName('input'))
            .filter(x => x.type === 'radio')
            .find(x => x.value === 'unlock');
        if (unlockedRadio.checked) {
            if (event.target.textContent == 'Show more') {
                profileElement.getElementsByTagName('div')[0].style.display = 'block';
                event.target.textContent = 'Hide it';
            } else if (event.target.textContent == 'Hide it') {
                profileElement.getElementsByTagName('div')[0].style.display = 'none';
                event.target.textContent = 'Show more';
            }
        }
    }
}