import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';

export async function registerView(context) {
    let registerForm = html`
        <!--Register Page-->
        <section id="registerPage">
            <form class="registerForm">
                <img src="./images/logo.png" alt="logo" />
                <h2>Register</h2>
                <div class="on-dark">
                    <label for="email">Email:</label>
                    <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
                </div>

                <div class="on-dark">
                    <label for="password">Password:</label>
                    <input id="password" name="password" type="password" placeholder="********" value="">
                </div>

                <div class="on-dark">
                    <label for="repeatPassword">Repeat Password:</label>
                    <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
                </div>

                <button class="btn" type="submit" @click=${onRegister}>Register</button>

                <p class="field">
                    <span>If you have profile click <a href="/login">here</a></span>
                </p>
            </form>
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
            rePass: formData.get('repeatPassword')
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
                page.redirect('/');
            });
    } catch (error) {
        console.clear();
        window.alert(error.message);
        form.reset();
    }
}