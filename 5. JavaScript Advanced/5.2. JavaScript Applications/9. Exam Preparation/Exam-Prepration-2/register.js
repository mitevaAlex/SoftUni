import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';

export async function registerView(context) {
    let registerForm = html`
        <!--Registration-->
        <section id="registerPage">
            <form>
                <fieldset>
                    <legend>Register</legend>

                    <label for="email" class="vhide">Email</label>
                    <input id="email" class="email" name="email" type="text" placeholder="Email">

                    <label for="password" class="vhide">Password</label>
                    <input id="password" class="password" name="password" type="password" placeholder="Password">

                    <label for="conf-pass" class="vhide">Confirm Password:</label>
                    <input id="conf-pass" class="conf-pass" name="conf-pass" type="password" placeholder="Confirm Password">

                    <button type="submit" class="register" @click=${onRegister}>Register</button>

                    <p class="field">
                        <span>If you already have profile click <a href="/login">here</a></span>
                    </p>
                </fieldset>
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
            rePass: formData.get('conf-pass')
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