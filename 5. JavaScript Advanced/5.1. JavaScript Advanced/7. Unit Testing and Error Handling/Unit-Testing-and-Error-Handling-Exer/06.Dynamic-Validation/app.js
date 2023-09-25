function validate() {
    let emailInput = document.getElementById('email');
    emailInput.addEventListener('change', validateEmail);

    function validateEmail(event) {
        let emailRegex = /^[a-z]+@[a-z]+\.[a-z]+$/;
        let emailValue = event.target.value;
        if (emailValue.match(emailRegex)) {
            event.target.classList.remove('error');
        } else {
            event.target.classList.add('error');
        }
    }
}