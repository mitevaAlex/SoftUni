import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { container } from "./catalog.js";
import { getHeader } from "./app.js";

export async function registerView(context) {
    let registerInfo = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Register New User</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>`;
    let registerForm = html`
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
                    <div class="form-group">
                        <label class="form-control-label" for="rePass">Repeat</label>
                        <input class="form-control" id="rePass" type="password" name="rePass">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Register" @click=${onRegister}/>
                </div>
            </div>
        </form>`;
    render([registerInfo, registerForm], container);
}

async function onRegister(event) {
    event.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    try {
        let body = {
            email: formData.get('email'),
            password: formData.get('password'),
            rePass: formData.get('rePass')
        }
        if (body.rePass !== body.password) {
            throw new Error('Password and repeated password are not equal!');
        }

        let url = 'http://localhost:3030/users/register';
        let header = getHeader('post', body);

        await fetch(url, header)
            .then(responce => {
                if (responce.status === 409) {
                    throw new Error('This user already exists!');
                }

                if (responce.status !== 200) {
                    throw new Error('Invalid user data!');
                }

                page.redirect('/');
            });
    } catch (error) {
        console.clear();
        window.alert(error.message);
        form.reset();
    }
}