import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { catalogView } from './catalog.js'
import { loginView } from './login.js';
import { registerView } from './register.js';
import { detailsView } from './details.js';
import { createView } from './create.js';
import { myFurnitureView } from './my-furniture.js';
import { editView } from './edit.js';

let navigation = document.querySelector('nav');

page('/', menuView, catalogView);
page('/register', menuView, registerView);
page('/login', menuView, loginView);
page('/details/:id', menuView, detailsView);
page('/create', menuView, createView);
page('/my-furniture', menuView, myFurnitureView);
page('/edit/:id', menuView, editView);
page.start();

function menuView(context, next) {
    render(createMenu(context.path), navigation);
    next();
}

function createMenu(path) {
    let userMenu = html`
        <a id="catalogLink" href="/" class=${path === '/' ? 'active' : ''}>Dashboard</a>
        <div id="user">
            <a id="createLink" href="/create" class=${path === '/create' ? 'active' : ''}>Create Furniture</a>
            <a id="profileLink" href="/my-furniture" class=${path === '/my-furniture' ? 'active' : ''}>My Publications</a>
            <a id="logoutBtn" href="javascript:void(0)" @click=${onLogout}>Logout</a>
        </div>`;

    let guestMenu = html`
        <a id="catalogLink" href="/" class=${path === '/' ? 'active' : ''}>Dashboard</a>
        <div id="guest">
            <a id="loginLink" href="/login" class=${path === '/login' ? 'active' : ''}>Login</a>
            <a id="registerLink" href="/register" class=${path === '/register' ? 'active' : ''}>Register</a>
        </div>`;

    if (sessionStorage.getItem('accessToken')) {
        return userMenu;
    } else {
        return guestMenu;
    }
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