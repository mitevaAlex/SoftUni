function focused() {
    let inputElements = document.getElementsByTagName('input');
    for (let inputEl of inputElements) {
        inputEl.addEventListener('focus', focused);
        inputEl.addEventListener('blur', blurred);
    }

    function focused(event) {
        event.target.parentElement.classList.add('focused');
    }

    function blurred(event) {
        event.target.parentElement.classList.remove('focused');
    }
}