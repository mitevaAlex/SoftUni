document.querySelectorAll('a').forEach(x => x.classList.remove('active'));
document.querySelector('#register').classList.add('active');

let registerForm = document.getElementById('register-form');
registerForm.addEventListener('submit', (event) => {
    event.preventDefault();
    let formData = new FormData(event.target);
    onRegister(...formData.values());
});

async function onRegister(email, password, repassword) {
    try {
        if (password !== repassword) {
            throw new Error('Password and repeated password are not equal!');
        }

        let url = 'http://localhost:3030/users/register';
        let body = {
            email,
            password
        }
        let header = getHeader('post', body);

        await fetch(url, header)
            .then(responce => {
                if (responce.status === 409) {
                    throw new Error('This user already exists!');
                }

                if (responce.status !== 200) {
                    throw new Error('Invalid user data!');
                }
                
                document.getElementById('home').click();
            });
    } catch (error) {
        registerForm.querySelector('.notification').textContent = error.message;
        registerForm.reset();
    }
}

function getHeader(method, body) {
    return {
        method: `${method}`,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(body)
    }
}