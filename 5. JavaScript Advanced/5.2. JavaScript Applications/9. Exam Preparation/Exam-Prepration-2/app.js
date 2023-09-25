import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { homeView } from './home.js';
import { loginView } from './login.js';
import { registerView } from './register.js';
import { catalogView } from './catalog.js';
import { createView } from './create.js';
import { detailsView } from './details.js';
import { editView } from './edit.js';
import { searchView } from './search.js';

let navigation = document.querySelector('nav');

page('/', menuView, homeView);
page('/login', menuView, loginView);
page('/register', menuView, registerView);
page('/catalog', menuView, catalogView);
page('/create', menuView, createView);
page('/details/:id', menuView, detailsView);
page('/edit/:id', menuView, editView);
page('/search', menuView, searchView);
page.start();


function menuView(context, next) {
    render(createMenu(), navigation);
    next();
}

function createMenu() {
    let menu = html`
        <img src="./images/headphones.png">
        <a href="/">Home</a>
        <ul>
            <!--All user-->
            <li><a href="/catalog">Catalog</a></li>
            <li><a href="/search">Search</a></li>
            ${!sessionStorage.getItem('accessToken')
            ? html`<!--Only guest-->
            <li><a href="/login">Login</a></li>
            <li><a href="/register">Register</a></li>`
            : html`<!--Only user-->
            <li><a href="/create">Create Album</a></li>
            <li><a href="javascript:void(0)" @click=${onLogout}>Logout</a></li>`}
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