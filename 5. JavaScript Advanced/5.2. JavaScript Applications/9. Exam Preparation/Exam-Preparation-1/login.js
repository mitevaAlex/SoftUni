import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';

export async function loginView(context) {
    let loginForm = html`
        <!--Login Page-->
        <section id="loginPage">
            <form class="loginForm">
                <img src="./images/logo.png" alt="logo" />
                <h2>Login</h2>

                <div>
                    <label for="email">Email:</label>
                    <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
                </div>

                <div>
                    <label for="password">Password:</label>
                    <input id="password" name="password" type="password" placeholder="********" value="">
                </div>

                <button class="btn" type="submit" @click=${onLogin}>Login</button>

                <p class="field">
                    <span>If you don't have profile click <a href="/register">here</a></span>
                </p>
            </form>
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
                page.redirect('/');
            });
    } catch (error) {
        console.clear();
        window.alert(error.message);
        form.reset();
    }
}