import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';

export async function addView() {
    let createForm = html`
        <!-- Create Page (Only for logged-in users) -->
        <section id="create">
            <div class="form">
                <h2>Add Album</h2>
                <form class="create-form">
                    <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
                    <input type="text" name="album" id="album-album" placeholder="Album" />
                    <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
                    <input type="text" name="release" id="album-release" placeholder="Release date" />
                    <input type="text" name="label" id="album-label" placeholder="Label" />
                    <input type="text" name="sales" id="album-sales" placeholder="Sales" />
    
                    <button type="submit" @click=${addAlbum}>post</button>
                </form>
            </div>
        </section>`;
    render(createForm, main);
}

async function addAlbum(event) {
    event.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    let url = 'http://localhost:3030/data/albums';
    let body = Object.fromEntries(formData);
    if(isValid(body)){
        let header = getHeader('post', body);
        let responce = await fetch(url, header);
        if (responce.status === 200) {
            page.redirect('/dashboard');
        }
    }
}

export function isValid(body){
    for(let key in body){
        if(!body[key]){
            return false;
        }
    }

    return true;
}