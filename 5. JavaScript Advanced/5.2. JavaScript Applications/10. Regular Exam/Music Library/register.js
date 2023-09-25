import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';

export async function registerView(context) {
    let registerForm = html`
        <!-- Register Page (Only for Guest users) -->
        <section id="register">
            <div class="form">
                <h2>Register</h2>
                <form class="login-form">
                    <input type="text" name="email" id="register-email" placeholder="email" />
                    <input type="password" name="password" id="register-password" placeholder="password" />
                    <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
                    <button type="submit" @click=${onRegister}>register</button>
                    <p class="message">Already registered? <a href="/login">Login</a></p>
                </form>
            </div>
        </section>`;

    render(registerForm, main);
}

async function onRegister(event) {
    event.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    try {
        let body = {
            email: formData.get('email'),
            password: formData.get('password'),
            rePass: formData.get('re-password')
        }
        if (body.rePass !== body.password) {
            throw new Error('Password and repeated password are not equal!');
        }

        delete body.rePass;
        let url = 'http://localhost:3030/users/register';
        let header = getHeader('post', body);

        await fetch(url, header)
            .then(async responce => {
                if (responce.status === 409) {
                    throw new Error('This user already exists!');
                }

                if (responce.status !== 200) {
                    throw new Error('Invalid user data!');
                }

                let data = await responce.json();
                sessionStorage.setItem('accessToken', data.accessToken);
                sessionStorage.setItem('email', data.email);
                sessionStorage.setItem('ownerId', data._id);
                page.redirect('/dashboard');
            });
    } catch (error) {
        console.clear();
        window.alert(error.message);
        form.reset();
    }
}