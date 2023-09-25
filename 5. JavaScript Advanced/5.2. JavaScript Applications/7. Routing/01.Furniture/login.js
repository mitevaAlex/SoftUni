import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { container } from "./catalog.js";
import { getHeader } from "./app.js";

export async function loginView(context) {
    let loginInfo = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Login User</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>`;
    let loginForm = html`
        <form>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="email">Email</label>
                        <input class="form-control" id="email" type="text" name="email">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="password">Password</label>
                        <input class="form-control" id="password" type="password" name="password">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Login" @click=${onLogin}/>
                </div>
            </div>
        </form>`;
    render([loginInfo, loginForm], container);
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