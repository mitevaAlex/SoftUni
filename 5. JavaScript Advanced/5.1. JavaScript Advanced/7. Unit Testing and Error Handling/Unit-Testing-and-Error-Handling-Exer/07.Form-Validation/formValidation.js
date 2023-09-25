function validate() {
    let submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', validateForm);

    let companyCheckbox = document.getElementById('company');
    companyCheckbox.addEventListener('change', checkboxChanged);

    function checkboxChanged(event) {
        let companyFieldset = document.getElementById('companyInfo');
        if (event.target.checked) {
            companyFieldset.style.display = 'block';
        } else {
            document.getElementById('companyNumber').value = '';
            companyFieldset.style.display = 'none';
        }
    }

    function validateForm(event) {
        event.preventDefault();
        let validationResults = [];

        let usernameInput = document.getElementById('username');
        let usernameRegex = new RegExp(/^[a-zA-Z0-9]{3,20}$/);
        validationResults.push(isValidWithRegex(usernameInput, usernameRegex));

        let emailInput = document.getElementById('email');
        let emailRegex = new RegExp(/^[^@.]+@[^@]*\.[^@]*$/);
        validationResults.push(isValidWithRegex(emailInput, emailRegex));

        let passwordInput = document.getElementById('password');
        let passwordRegex = new RegExp(/^\w{5,15}$/);
        validationResults.push(isValidWithRegex(passwordInput, passwordRegex));

        let confirmPasswordInput = document.getElementById('confirm-password');
        validationResults.push(isValidWithRegex(confirmPasswordInput, passwordRegex));

        if (passwordInput.value !== confirmPasswordInput.value) {
            passwordInput.style.border = 'solid';
            passwordInput.style.borderColor = 'red';
            confirmPasswordInput.style.border = 'solid';
            confirmPasswordInput.style.borderColor = 'red';
            validationResults.push(false);
        }

        let companyNumberInput = document.getElementById('companyNumber');

        if (companyCheckbox.checked) {
            if (companyNumberInput.value < 1000 || companyNumberInput.value > 9999) {
                companyNumberInput.style.border = 'solid';
                companyNumberInput.style.borderColor = 'red';
                validationResults.push(false);
            } else {
                companyNumberInput.style.border = 'none';
                validationResults.push(true);
            }
        }

        let validDiv = document.getElementById('valid');
        if (validationResults.includes(false)) {
            validDiv.style.display = 'none';
        } else {
            validDiv.style.display = 'block';
        }

        function isValidWithRegex(inputElement, regex) {
            if (inputElement.value.match(regex)) {
                inputElement.style.border = 'none';
                return true;
            } else {
                inputElement.style.border = 'solid';
                inputElement.style.borderColor = 'red';
                return false;
            }
        }
    }
}
