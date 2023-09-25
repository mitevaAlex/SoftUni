document.querySelectorAll('a').forEach(x => x.classList.remove('active'));
document.querySelector('#login').classList.add('active');

let loginForm = document.getElementById('login-form');
loginForm.addEventListener('submit', (event) => {
    event.preventDefault();
    let formData = new FormData(event.target);
    onLogin(...formData.values());
});

async function onLogin(email, password) {
    try {
        let url = 'http://localhost:3030/users/login';
        let body = {
            email,
            password
        }
        let header = getHeader('post', body);

        await fetch(url, header)
            .then(async responce => {
                if (responce.status !== 200) {
                    throw new Error('Wrong password or user does not exists!');
                }

                let data = await responce.json();
                sessionStorage.setItem('authToken', data.accessToken);
                sessionStorage.setItem('email', data.email);
                sessionStorage.setItem('ownerId', data._id);
                document.getElementById('home').click();
            });
    } catch (error) {
        loginForm.querySelector('.notification').textContent = error.message;
        loginForm.reset();
    }
}

function getHeader(method, body) {
    return {
        method: `${method}`,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(body)
    }
}