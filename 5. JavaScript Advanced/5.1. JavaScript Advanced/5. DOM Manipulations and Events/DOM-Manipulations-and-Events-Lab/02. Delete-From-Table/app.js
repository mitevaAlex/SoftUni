function deleteByEmail() {
    let emails = document.querySelectorAll("#customers tr td:nth-child(2)");
    let wantedEmail = document.getElementsByName('email')[0].value;
    let result = document.getElementById('result');
    result.textContent = '';
    for (let email of emails) {
        if (email.textContent === wantedEmail) {
            email.parentElement.remove();
            result.textContent = 'Deleted.';
            break;
        }
    }

    if (result.textContent !== 'Deleted.') {
        result.textContent = 'Not found.'
    }
}