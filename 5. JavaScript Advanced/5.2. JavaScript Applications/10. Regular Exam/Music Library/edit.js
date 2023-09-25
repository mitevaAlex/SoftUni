import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';
import { isValid } from './add.js';

export async function editView(context) {
    let album = await fetch(`http://localhost:3030/data/albums/${context.params.id}`)
        .then(async responce => await responce.json());
    let editForm = html`
        <!-- Edit Page (Only for logged-in users) -->
        <section id="edit">
            <div class="form">
                <h2>Edit Album</h2>
                <form class="edit-form">
                    <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" value=${album.singer} />
                    <input type="text" name="album" id="album-album" placeholder="Album" value=${album.album} />
                    <input type="text" name="imageUrl" id="album-img" placeholder="Image url" value=${album.imageUrl} />
                    <input type="text" name="release" id="album-release" placeholder="Release date" value=${album.release} />
                    <input type="text" name="label" id="album-label" placeholder="Label" value=${album.label} />
                    <input type="text" name="sales" id="album-sales" placeholder="Sales" value=${album.sales} />

                    <button id=${context.params.id} type="submit" @click=${editAlbum}>post</button>
                </form>
            </div>
        </section>`;

    render(editForm, main);
}

async function editAlbum(event) {
    event.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    let albumId = event.currentTarget.id;
    let url = `http://localhost:3030/data/albums/${albumId}`;
    let body = Object.fromEntries(formData);
    if (isValid(body)) {
        let header = getHeader('put', body);
        let responce = await fetch(url, header);
        if (responce.status === 200) {
            page.redirect(`/details/${albumId}`);
        }
    }
}