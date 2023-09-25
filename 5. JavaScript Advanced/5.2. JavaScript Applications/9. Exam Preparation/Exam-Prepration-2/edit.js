import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';
import { isValid } from './create.js';

export async function editView(context) {
    let album = await fetch(`http://localhost:3030/data/albums/${context.params.id}`)
        .then(async responce => await responce.json());
    let editForm = html`
        <!--Edit Page-->
        <section class="editPage">
            <form>
                <fieldset>
                    <legend>Edit Album</legend>

                    <div class="container">
                        <label for="name" class="vhide">Album name</label>
                        <input id="name" name="name" class="name" type="text" value=${album.name}>

                        <label for="imgUrl" class="vhide">Image Url</label>
                        <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" value=${album.imgUrl}>

                        <label for="price" class="vhide">Price</label>
                        <input id="price" name="price" class="price" type="text" value=${album.price}>

                        <label for="releaseDate" class="vhide">Release date</label>
                        <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" value=${album.releaseDate}>

                        <label for="artist" class="vhide">Artist</label>
                        <input id="artist" name="artist" class="artist" type="text" value=${album.artist}>

                        <label for="genre" class="vhide">Genre</label>
                        <input id="genre" name="genre" class="genre" type="text" value=${album.genre}>

                        <label for="description" class="vhide">Description</label>
                        <textarea name="description" class="description" rows="10" cols="10">${album.description}</textarea>

                        <button id=${context.params.id} class="edit-album" type="submit" @click=${editAlbum}>Edit Album</button>
                    </div>
                </fieldset>
            </form>
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