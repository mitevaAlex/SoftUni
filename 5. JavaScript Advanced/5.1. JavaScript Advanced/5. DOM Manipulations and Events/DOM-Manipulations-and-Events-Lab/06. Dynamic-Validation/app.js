function validate() {
    let inputElement = document.getElementById('email');
    inputElement.addEventListener('change', validateEmail);

    function validateEmail(event) {
        let regex = /^[a-z]+@[a-z]+\.[a-z]+$/;
        let inputEmail = event.target.value;
        if(!inputEmail.match(regex)) {
            event.target.classList.add('error');
        } else {
            event.target.classList.remove('error');
        }
    }
}