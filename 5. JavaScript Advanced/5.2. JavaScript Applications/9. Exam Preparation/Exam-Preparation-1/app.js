import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { homeView } from './home.js';
import { loginView } from './login.js';
import { registerView } from './register.js';
import { dashboardView } from './dashboard.js';
import { createView } from './create.js';
import { detailsView } from './details.js';
import { editView } from './edit.js';

let navigation = document.querySelector('nav');

page('/', menuView, homeView);
page('/login', menuView, loginView);
page('/register', menuView, registerView);
page('/dashboard', menuView, dashboardView);
page('/create', menuView, createView);
page('/details/:id', menuView, detailsView);
page('/edit/:id', menuView, editView);
page.start();


function menuView(context, next) {
    render(createMenu(), navigation);
    next();
}

function createMenu() {
    let menu = html`
        <section class="logo">
                <img src="./images/logo.png" alt="logo">
        </section>
        <ul>
            <!--Users and Guest-->
            <li><a href="/">Home</a></li>
            <li><a href="/dashboard">Dashboard</a></li>
            ${sessionStorage.getItem('accessToken')
            ? html`<!--Only Users-->
            <li><a href="/create">Create Postcard</a></li>
            <li><a href="#" @click=${onLogout}>Logout</a></li>`
            : html`<!--Only Guest-->
            <li><a href="/login">Login</a></li>
            <li><a href="/register">Register</a></li>`}
        </ul>`;

    return menu;
}

export function getHeader(method, body) {
    let accessToken = sessionStorage.getItem('accessToken');
    let header = {
        method: `${method}`,
        headers: {
        }
    };

    if (body) {
        header.headers['Content-Type'] = 'application/json';
        header.body = JSON.stringify(body);
    }

    if(accessToken){
        header.headers['X-Authorization'] = accessToken;
    }

    return header;
}

async function onLogout(){
    let url = 'http://localhost:3030/users/logout';
    let header = getHeader('get', null);
    let responce = await fetch(url, header);

    if (responce.status === 204) {
        sessionStorage.clear();
        page.redirect('/');
    }
}