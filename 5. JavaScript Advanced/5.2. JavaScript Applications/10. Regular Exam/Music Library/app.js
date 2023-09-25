import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { homeView } from './home.js';
import { loginView } from './login.js';
import { registerView } from './register.js';
import { dashboardView } from './dashboard.js';
import { addView } from './add.js';
import { detailsView } from './details.js';
import { editView } from './edit.js';

let header = document.querySelector('header');

page('/', menuView, homeView);
page('/login', menuView, loginView);
page('/register', menuView, registerView);
page('/dashboard', menuView, dashboardView);
page('/add', menuView, addView);
page('/details/:id', menuView, detailsView);
page('/edit/:id', menuView, editView);
page.start();


function menuView(context, next) {
    render(createMenu(), header);
    next();
}

function createMenu() {
    let menu = html`
        <!-- Navigation -->
        <a id="logo" href="/"><img id="logo-img" src="./images/logo.png" alt="" /></a>

        <nav>
            <div>
                <a href="/dashboard">Dashboard</a>
            </div>
            ${sessionStorage.getItem('accessToken')
            ? html`<!-- Logged-in users -->
            <div class="user">
                <a href="/add">Add Album</a>
                <a href="javascript:void(0)" @click=${onLogout}>Logout</a>
            </div>`
            : html`<!-- Guest users -->
            <div class="guest">
                <a href="/login">Login</a>
                <a href="/register">Register</a>
            </div>`}
        </nav>`;

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

    if (accessToken) {
        header.headers['X-Authorization'] = accessToken;
    }

    return header;
}

async function onLogout() {
    let url = 'http://localhost:3030/users/logout';
    let header = getHeader('get', null);
    let responce = await fetch(url, header);

    if (responce.status === 204) {
        sessionStorage.clear();
        page.redirect('/dashboard');
    }
}