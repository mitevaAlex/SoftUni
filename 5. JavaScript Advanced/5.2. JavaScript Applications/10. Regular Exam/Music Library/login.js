import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';

export async function loginView(context) {
    let loginForm = html`
        <!-- Login Page (Only for Guest users) -->
        <section id="login">
            <div class="form">
                <h2>Login</h2>
                <form class="login-form">
                    <input type="text" name="email" id="email" placeholder="email" />
                    <input type="password" name="password" id="password" placeholder="password" />
                    <button type="submit" @click=${onLogin}>login</button>
                    <p class="message">
                        Not registered? <a href="/register">Create an account</a>
                    </p>
                </form>
            </div>
        </section>`;

    render(loginForm, main);
}

async function onLogin(event) {
    event.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    try {
        let url = 'http://localhost:3030/users/login';
        let body = {
            email: formData.get('email'),
            password: formData.get('password')
        }
        let header = getHeader('post', body);

        await fetch(url, header)
            .then(async responce => {
                if (responce.status !== 200) {
                    throw new Error('Wrong password or user does not exists!');
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